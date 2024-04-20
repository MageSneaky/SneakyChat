using Newtonsoft.Json;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace SneakyChat.Server
{
    class Program
    {
        #region Variables
        private static IniFile settingsfile = new ("settings.ini");
        private static string ip = "127.0.0.1";
        private static int port = 5000;
        private static List<Socket> clientSockets = [];
        private static Socket serverSocket;

        private static byte[] buffer = new byte[65536];
        #endregion

        #region Constructor
        static void Main()
        {
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
            Console.Title = string.Format("ChatServer running on {0}:{1}", ip, port.ToString());
            ExecuteServer();
            Console.ReadLine();
            CloseAllSockets();
        }
        #endregion

        #region Methods
        private static void ExecuteServer()
        {
            IPAddress ipAddress = IPAddress.Parse(ip);
            IPEndPoint localEndPoint = new(ipAddress, port);

            serverSocket = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

            try
            {
                serverSocket.Bind(localEndPoint);
                serverSocket.Listen(10);
                serverSocket.BeginAccept(new AsyncCallback(AcceptCallback), null);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        private static void AcceptCallback(IAsyncResult asyncResult)
        {
            Socket socket = serverSocket.EndAccept(asyncResult);
            clientSockets.Add(socket);
            Console.WriteLine(socket.RemoteEndPoint + " Connected");
            socket.BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, new AsyncCallback(ReceiveCallback), socket);
            serverSocket.BeginAccept(new AsyncCallback(AcceptCallback), null);
        }

        private static void ReceiveCallback(IAsyncResult asyncResult)
        {
            Socket socket = (Socket)asyncResult.AsyncState;
            int received;

            try
            {
                received = socket.EndReceive(asyncResult);
            }
            catch (SocketException)
            {
                Console.WriteLine("{0} forcefully disconnected", socket.RemoteEndPoint);
                socket.Close();
                clientSockets.Remove(socket);
                return;
            }

            byte[] dataBuffer = new byte[received];
            Array.Copy(buffer, dataBuffer, received);

            string data = Encoding.ASCII.GetString(dataBuffer);

            var recvMessage = JsonConvert.DeserializeObject<Message>(data);
            Message respMessage = new();
            if (recvMessage.type == "login")
            {
                respMessage.type = "login";
                respMessage.username = recvMessage.username;
                respMessage.message = "connected";
            }
            else if (recvMessage.type == "message")
            {
                respMessage.type = "message";
                respMessage.avatar = recvMessage.avatar;
                respMessage.username = recvMessage.username;
                respMessage.message = recvMessage.message;
            }
            else if (recvMessage.type == "disconnect")
            {
                Console.WriteLine("{0} disconnected", socket.RemoteEndPoint);
                respMessage.type = "disconnect";
                respMessage.username = recvMessage.username;
                SendData(socket, new Message() { type = "logout" });
                clientSockets.Remove(socket);
                socket.Shutdown(SocketShutdown.Both);
                socket.Close();
            }
            else
            {
                respMessage.type = "unknown";
                respMessage.username = recvMessage.username;
                respMessage.message = "unknown";
            }

            Console.WriteLine("Received: {0} ", data);

            SendToAll(respMessage);
            if (socket.Connected)
            {
                socket.BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, new AsyncCallback(ReceiveCallback), socket);
            }
        }

        private static void SendCallback(IAsyncResult asyncResult)
        {
            Socket socket = (Socket)asyncResult.AsyncState;
            socket.EndSend(asyncResult);
        }

        private static void CloseAllSockets()
        {
            foreach (Socket socket in clientSockets)
            {
                socket.Shutdown(SocketShutdown.Both);
                socket.Close();
            }

            serverSocket.Close();
        }

        private static void SendData(Socket socket, Message message)
        {
            byte[] response = Encoding.ASCII.GetBytes(JsonConvert.SerializeObject(message));
            socket.BeginSend(response, 0, response.Length, SocketFlags.None, new AsyncCallback(SendCallback), socket);
        }

        private static void SendToAll(Message message)
        {
            foreach (Socket socket in clientSockets)
            {
                SendData(socket, message);
            }
        }
        #endregion
    }
    #region Classes/Enums
    public class Message
    {
        public string type { get; set; }
        public string avatar { get; set; }
        public string username { get; set; }
        public string message { get; set; }
        public string dateTime = DateTime.Now.ToString("yyyy-MM-dd h:mm:ss tt");
    }
    #endregion
}