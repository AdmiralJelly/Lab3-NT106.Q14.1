using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Exercise2_Lab03
{
    public partial class TCPListener : Form
    {
        public TCPListener()
        {
            InitializeComponent();
        }

        private Socket listenerSocket;
        private Socket clientSocket;
        private Thread serverThread;
        private bool isListening = false;

        private void btn_listen_Click(object sender, EventArgs e)
        {
            if (!isListening)
            {
                // Xử lý lỗi InvalidOperationException
                CheckForIllegalCrossThreadCalls = false;

                // Tạo và chạy server thread
                serverThread = new Thread(new ThreadStart(StartListening));
                serverThread.IsBackground = true; // Set as background thread
                serverThread.Start();

                isListening = true;
                btn_listen.Enabled = false;
                btn_listen.Text = "Listening...";
            }
        }

        private void StartListening()
        {
            try
            {
                int bytesReceived = 0;
                byte[] recv = new byte[1024]; // Tăng buffer size lên 1024 bytes

                // Tạo socket listener - TCP/IP socket
                // AddressFamily.InterNetwork: IPv4
                // SocketType.Stream: Stream-based socket (TCP)
                // ProtocolType.Tcp: TCP protocol
                listenerSocket = new Socket(
                    AddressFamily.InterNetwork,
                    SocketType.Stream,
                    ProtocolType.Tcp
                );

                // Lấy địa chỉ IP local của máy
                string localIP = GetLocalIPAddress();
                IPEndPoint ipepServer = new IPEndPoint(IPAddress.Parse(localIP), 8080);

                // Bind socket đến địa chỉ IP và port
                listenerSocket.Bind(ipepServer);

                // Bắt đầu lắng nghe với queue length = 10
                listenerSocket.Listen(10);

                // Hiển thị thông báo
                string message = $"TCP Listener started on {localIP}:8080";
                AddToListView(message);
                AddToListView("Waiting for telnet connection...");
                AddToListView($"Use command: telnet {localIP} 8080");

                // Chấp nhận kết nối từ client (blocking call)
                clientSocket = listenerSocket.Accept();

                // Lấy thông tin client
                IPEndPoint clientEndPoint = (IPEndPoint)clientSocket.RemoteEndPoint;
                AddToListView($"New client connected from {clientEndPoint.Address}:{clientEndPoint.Port}");

                // Nhận dữ liệu từ client
                while (clientSocket.Connected)
                {
                    string text = "";

                    try
                    {
                        do
                        {
                            bytesReceived = clientSocket.Receive(recv);

                            if (bytesReceived == 0)
                            {
                                // Client đã ngắt kết nối
                                break;
                            }

                            // Convert bytes thành string (chỉ lấy số bytes đã nhận)
                            text += Encoding.UTF8.GetString(recv, 0, bytesReceived);

                        } while (text.Length > 0 && text[text.Length - 1] != '\n');

                        // Hiển thị tin nhắn nếu có
                        if (!string.IsNullOrWhiteSpace(text))
                        {
                            // Loại bỏ ký tự xuống dòng và khoảng trắng thừa
                            text = text.Trim();
                            if (!string.IsNullOrEmpty(text))
                            {
                                AddToListView($"Received: {text}");
                            }
                        }
                    }
                    catch (SocketException)
                    {
                        // Client ngắt kết nối đột ngột
                        break;
                    }
                }

                // Client đã ngắt kết nối
                AddToListView("Client disconnected");
            }
            catch (Exception ex)
            {
                AddToListView($"Error: {ex.Message}");
            }
            finally
            {
                // Cleanup
                CleanupSockets();
            }
        }

        private void AddToListView(string message)
        {
            if (listView_messages.InvokeRequired)
            {
                listView_messages.Invoke(new Action(() => AddToListView(message)));
                return;
            }

            // Thêm timestamp
            string timestampedMessage = $"[{DateTime.Now:HH:mm:ss}] {message}";
            listView_messages.Items.Add(new ListViewItem(timestampedMessage));

            // Auto scroll to bottom
            if (listView_messages.Items.Count > 0)
            {
                listView_messages.Items[listView_messages.Items.Count - 1].EnsureVisible();
            }
        }

        private string GetLocalIPAddress()
        {
            try
            {
                // Lấy hostname của máy
                string hostName = Dns.GetHostName();

                // Lấy tất cả địa chỉ IP của máy
                IPAddress[] addresses = Dns.GetHostAddresses(hostName);

                // Tìm địa chỉ IPv4 đầu tiên (không phải loopback)
                foreach (IPAddress address in addresses)
                {
                    if (address.AddressFamily == AddressFamily.InterNetwork &&
                        !IPAddress.IsLoopback(address))
                    {
                        return address.ToString();
                    }
                }

                // Nếu không tìm thấy, trả về loopback
                return "127.0.0.1";
            }
            catch
            {
                return "127.0.0.1";
            }
        }

        private void CleanupSockets()
        {
            try
            {
                // Đóng client socket
                if (clientSocket != null)
                {
                    if (clientSocket.Connected)
                    {
                        clientSocket.Shutdown(SocketShutdown.Both);
                    }
                    clientSocket.Close();
                    clientSocket = null;
                }

                // Đóng listener socket
                if (listenerSocket != null)
                {
                    listenerSocket.Close();
                    listenerSocket = null;
                }
            }
            catch (Exception ex)
            {
                AddToListView($"Cleanup error: {ex.Message}");
            }
            finally
            {
                // Enable lại button
                if (btn_listen.InvokeRequired)
                {
                    btn_listen.Invoke(new Action(() =>
                    {
                        btn_listen.Enabled = true;
                        btn_listen.Text = "Listen";
                        isListening = false;
                    }));
                }
                else
                {
                    btn_listen.Enabled = true;
                    btn_listen.Text = "Listen";
                    isListening = false;
                }
            }
        }

        // Xử lý khi đóng form
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            // Dọn dẹp resources
            CleanupSockets();

            // Dừng server thread
            if (serverThread != null && serverThread.IsAlive)
            {
                serverThread.Abort();
            }
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            listView_messages.Items.Clear();
        }
    }
}
