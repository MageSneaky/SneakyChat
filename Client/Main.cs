using Newtonsoft.Json;
using SneakyChat.Client.Properties;
using System;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Runtime;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace SneakyChat.Client
{
    public partial class Main : Form
    {
        #region Variables
        public IniFile settingsfile = new IniFile("settings.ini");
        private static string ip = "127.0.0.1";
        private static int port = 5000;
        private static Socket clientSocket;
        private static Thread RequestLoopThread;
        public string avatar;
        public string username;
        public Settings settings;
        public About about;
        #endregion

        #region Constructor
        public Main()
        {
            InitializeComponent();
            if (!settingsfile.KeyExists("ip") || !settingsfile.KeyExists("port"))
            {
                settingsfile.Write("ip", ip);
                settingsfile.Write("port", port.ToString());
            }
            else
            {
                ip = settingsfile.Read("ip");
                int.TryParse(settingsfile.Read("port"), out port);
            }
            messagesLayout.Padding = new Padding(0, 0, SystemInformation.VerticalScrollBarWidth, 0);
        }
        #endregion

        #region Control Events
        private void Main_Load(object sender, EventArgs e)
        {
            Connect();
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(clientSocket.Connected)
            {
                Message message = new Message();
                message.type = "disconnect";
                message.username = username;
                SendMessage(message);
            }
        }

        private void Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
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

        private void aboutButton_Click(object sender, EventArgs e)
        {
            if (about == null)
            {
                about = new About();
                about.main = this;
            }
            about.Show();
            about.Focus();
        }

        private void settingsButton_Click(object sender, EventArgs e)
        {
            Settings settings = new Settings();
            settings.main = this;
            settings.Show();
            settings.Focus();
            this.Enabled = false;
        }
        #endregion

        #region Methods
        private void Connect()
        {
            IPAddress ipAddress = IPAddress.Parse(ip);

            clientSocket = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

            try
            {
                clientSocket.Connect(ip, port);
            }
            catch (Exception)
            {
                connectionLabel.Text = "Disconnected";
                connectionLabel.ForeColor = Color.Red;
                sendButton.Enabled = false;
            }

            if (clientSocket.Connected && !(clientSocket.Poll(0, SelectMode.SelectRead) && clientSocket.Available == 0))
            {
                Console.WriteLine("Connected to: {0} ", clientSocket.RemoteEndPoint.ToString());
                RequestLoopThread = new Thread(new ThreadStart(RequestLoop));
                RequestLoopThread.Start();

                connectionLabel.Text = "Connected";
                usernameLabel.Text = "as " + username;
                connectionLabel.ForeColor = Color.Green;

                Message message = new Message();
                message.type = "login";
                message.username = username;

                SendMessage(message);
            }
        }

        private void RequestLoop()
        {
            while (true)
            {
                try
                {
                    byte[] messageRecvBuffer = new byte[65536];

                    int byteRecv = clientSocket.Receive(messageRecvBuffer);
                    string messageRecv = Encoding.ASCII.GetString(messageRecvBuffer, 0, byteRecv);
                    var received = JsonConvert.DeserializeObject<Message>(messageRecv);

                    Console.WriteLine("Received: {0}", messageRecv);

                    if (received.type == "login" || received.type == "disconnect")
                    {
                        CreateStatus(received);
                    }
                    else if (received.type != "unknown")
                    {
                        CreateBubble(received);
                    }
                }
                catch (Exception)
                {
                    Disconnect();
                }
            }
        }

        private void CreateBubble(Message received)
        {
            if (messagesLayout.InvokeRequired)
            {
                Action callback = delegate { CreateBubble(received); };
                this.Invoke(callback);
            }
            else
            {
                Bubble bubble = new Bubble();
                int i = ((messagesLayout.VerticalScroll.Maximum - messagesLayout.VerticalScroll.LargeChange) + 1);
                bubble.avatarPictureBox.Image = Image.FromStream(new MemoryStream(Convert.FromBase64String(received.avatar)));
                bubble.usernameLabel.Text = received.username;
                bubble.messageText.Text = received.message;
                bubble.timeDateLabel.Text = received.dateTime;
                bubble.ClientSize = new Size(this.ClientSize.Width, (bubble.ClientSize.Height - bubble.messageText.Height) + (15 * (bubble.messageText.Lines.Length + 2)));
                messagesLayout.RowCount = messagesLayout.RowCount + 1;
                messagesLayout.RowStyles[messagesLayout.RowStyles.Count - 1].SizeType = SizeType.AutoSize;
                bubble.Parent = messagesLayout;
                bubble.Dock = DockStyle.Top;
                GoToBottom(i);
            }
        }

        private void CreateStatus(Message received)
        {
            if (messagesLayout.InvokeRequired)
            {
                Action callback = delegate { CreateStatus(received); };
                this.Invoke(callback);
            }
            else
            {
                Status status = new Status();
                int i = ((messagesLayout.VerticalScroll.Maximum - messagesLayout.VerticalScroll.LargeChange) + 1);
                string type;
                switch (received.type)
                {
                    case ("login"):
                        type = "Connected";
                        break;
                    case ("disconnect"):
                        type = "Disconnected";
                        break;
                    default:
                        type = "Connected";
                        break;
                }
                status.statusLabel.Text = string.Format("{0} {1}", received.username, type) ;
                status.Parent = messagesLayout;
                status.Dock = DockStyle.Top;
                GoToBottom(i);
            }
        }

        private void Disconnect()
        {
            if (InvokeRequired)
            {
                Action callback = delegate { Disconnect(); };
                this.Invoke(callback);
            }
            else
            {
                connectionLabel.Text = "Disconnected";
                connectionLabel.ForeColor = Color.Red;
                usernameLabel.Text = "";
                sendButton.Enabled = false;
                RequestLoopThread.Abort();
            }
        }

        private void SendMessage(Message message)
        {
            try
            {
                byte[] messageSent = Encoding.ASCII.GetBytes(JsonConvert.SerializeObject(message));
                clientSocket.BeginSend(messageSent, 0, messageSent.Length, SocketFlags.None, SendCallback, null);
                Console.WriteLine("Sent: {0}", JsonConvert.SerializeObject(message));
            }
            catch (SocketException)
            {
                Disconnect();
            }
            catch (ObjectDisposedException)
            {
                Disconnect();
            }
        }

        private void SendCallback(IAsyncResult AR)
        {
            try
            {
                clientSocket.EndSend(AR);
            }
            catch (SocketException)
            {
                Disconnect();
            }
            catch (ObjectDisposedException)
            {
                Disconnect();
            }
        }

        private void GoToBottom(int i)
        {
            if (messagesLayout.VerticalScroll.Value >= i)
            {
                messagesLayout.VerticalScroll.Value = ((messagesLayout.VerticalScroll.Maximum - messagesLayout.VerticalScroll.LargeChange) + 1);
                messagesLayout.PerformLayout();
            }
        }
        #endregion

        #region Title Bar Color
        [DllImport("DwmApi")]
        private static extern int DwmSetWindowAttribute(IntPtr hwnd, int attr, int[] attrValue, int attrSize);

        protected override void OnHandleCreated(EventArgs e)
        {
            if (DwmSetWindowAttribute(Handle, 19, new[] { 1 }, 4) != 0)
                DwmSetWindowAttribute(Handle, 20, new[] { 1 }, 4);
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