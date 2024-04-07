using Newtonsoft.Json;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Client
{
    public partial class Main : Form
    {
        #region Variables
        public IniFile settingsfile = new IniFile("settings.ini");
        private static string ip = "127.0.0.1";
        private static int port = 5000;
        private static Socket clientSocket;
        private string avatar;
        private string username = "Sneaky";
        #endregion

        #region Constructor
        public Main()
        {
            InitializeComponent();
            if (!System.IO.File.Exists("settings.ini"))
            {
                settingsfile.Write("username", username);
                settingsfile.Write("ip", ip);
                settingsfile.Write("port", port.ToString());
            }
            else
            {
                avatar = Base64Image(@"C:\Users\alleh\Docs\!C#_Projects\Chat\profile.png");
                username = settingsfile.Read("username");
                ip = settingsfile.Read("ip");
                int.TryParse(settingsfile.Read("port"), out port);
            }
        }
        #endregion

        #region Control Events
        private void Main_Load(object sender, EventArgs e)
        {
            Connect();
            Thread backgroundThread = new Thread(new ThreadStart(RequestLoop));
            backgroundThread.Start();
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            Message message = new Message();
            message.type = "disconnect";
            message.username = username;
            clientSocket.Shutdown(SocketShutdown.Both);
            clientSocket.Close();
        }

        private void sendButton_Click(object sender, EventArgs e)
        {
            if (messageText.Text.Length > 0)
            {
                Message message = new Message();
                message.type = "message";
                message.avatar = avatar;
                message.username = username;
                message.message = messageText.Text;
                messageText.Text = "";
                SendMessage(message);
            }
        }

        private void messageText_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && !e.Shift)
            {
                if (messageText.Text.Length > 0)
                {
                    Message message = new Message();
                    message.type = "message";
                    message.avatar = avatar;
                    message.username = username;
                    message.message = messageText.Text;
                    messageText.Text = "";
                    SendMessage(message);
                }
            }
        }
        #endregion

        #region Methods
        private void Connect()
        {
            IPAddress ipAddress = IPAddress.Parse(ip);

            clientSocket = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

            int i = 0;
            while (!clientSocket.Connected)
            {
                try
                {
                    i++;
                    clientSocket.Connect(ip, port);
                }
                catch (SocketException)
                {
                    Console.WriteLine("Attempts: {0}", i);
                }
            }

            Console.WriteLine("Connected to: {0} ", clientSocket.RemoteEndPoint.ToString());

            connectionLabel.Text = "Connected";
            usernameLabel.Text = "as " + username;
            connectionLabel.ForeColor = Color.Green;

            Message message = new Message();
            message.type = "login";
            message.username = username;

            SendMessage(message);
        }

        private void RequestLoop()
        {
            while (true)
            {
                byte[] messageRecvBuffer = new byte[32768];

                int byteRecv = clientSocket.Receive(messageRecvBuffer);
                string messageRecv = Encoding.ASCII.GetString(messageRecvBuffer, 0, byteRecv);
                var received = JsonConvert.DeserializeObject<Message>(messageRecv);

                Console.WriteLine("Received: {0}", messageRecv);

                if (received.type == "message")
                {
                    CreateBubble(received);
                }
            }
        }

        private void CreateBubble(Message received)
        {
            if(messagesLayout.InvokeRequired)
            {
                Action callback = delegate { CreateBubble(received); };
                this.Invoke(callback);
            }
            else
            {
                Bubble bubble = new Bubble();
                bubble.avatarPictureBox.Image = Image.FromStream(new MemoryStream(Convert.FromBase64String(received.avatar)));
                bubble.usernameLabel.Text = received.username;
                bubble.messageText.Text = received.message;
                bubble.timeDateLabel.Text = received.dateTime;
                bubble.Parent = messagesLayout;
                bubble.Dock = DockStyle.Top;
            }
        }

        private void SendMessage(Message message)
        {
            byte[] messageSent = Encoding.ASCII.GetBytes(JsonConvert.SerializeObject(message));
            Console.WriteLine("Sent: {0}", JsonConvert.SerializeObject(message));
            clientSocket.Send(messageSent);
        }
        private string Base64Image(string path)
        {
            using (Image image = Image.FromFile(path))
            {
                Image newimage = ResizeImage(image, 50, 50);
                using (MemoryStream m = new MemoryStream())
                {
                    newimage.Save(m, image.RawFormat);
                    byte[] imageBytes = m.ToArray();

                    string base64String = Convert.ToBase64String(imageBytes);
                    return base64String;
                }
            }
        }
        public static Bitmap ResizeImage(Image image, int width, int height)
        {
            var destRect = new Rectangle(0, 0, width, height);
            var destImage = new Bitmap(width, height);

            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (var graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            return destImage;
        }
        #endregion
    }
}

#region Classes/Enums
public class Message
{
    public string type { get; set; }
    public string avatar { get; set; }
    public string username { get; set; }
    public string message { get; set; }
    public string dateTime { get; set; }
}
#endregion