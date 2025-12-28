using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Exercise3_Lab03
{
    public partial class TCPServerForm : Form
    {
        private TcpListener? server;
        private TcpClient? client;
        private NetworkStream? stream;
        private Thread? listenThread;
        private Thread? receiveThread;
        private bool isListening = false;
        private bool isClientConnected = false;

        public TCPServerForm()
        {
            InitializeComponent();
            InitializeUI();
        }

        private void InitializeUI()
        {
            txt_port.Text = "8888";
            btn_listen.Enabled = true;
            btn_stop.Enabled = false;
            lbl_status.Text = "Trạng thái: Chưa lắng nghe";
            lbl_status.ForeColor = System.Drawing.Color.Red;
        }

        private void btn_listen_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txt_port.Text, out int port) || port < 1 || port > 65535)
            {
                MessageBox.Show("Port không hợp lệ! Vui lòng nhập số từ 1-65535.", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                // Create TCP listener
                IPEndPoint ep = new IPEndPoint(IPAddress.Any, port);
                server = new TcpListener(ep);

                // Start listening thread
                listenThread = new Thread(ListenForClients)
                {
                    IsBackground = true
                };
                listenThread.Start();

                // Update UI
                isListening = true;
                UpdateListeningStatus(true);
                AppendLog($"Server đã bắt đầu lắng nghe trên port {port}");
                AppendLog("Đang chờ Client kết nối...");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi khởi động Server: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ListenForClients()
        {
            try
            {
                server?.Start();

                while (isListening)
                {
                    if (server?.Pending() == true)
                    {
                        // Accept client connection
                        client = server.AcceptTcpClient();
                        isClientConnected = true;

                        // Get client info
                        IPEndPoint? clientEndPoint = client.Client.RemoteEndPoint as IPEndPoint;
                        string clientInfo = clientEndPoint != null
                            ? $"{clientEndPoint.Address}:{clientEndPoint.Port}"
                            : "Unknown";

                        AppendLog($"Client đã kết nối từ {clientInfo}");
                        UpdateClientStatus(true, clientInfo);

                        // Start receiving thread
                        stream = client.GetStream();
                        receiveThread = new Thread(ReceiveMessages)
                        {
                            IsBackground = true
                        };
                        receiveThread.Start();

                        // Wait for this client to disconnect before accepting new connections
                        while (isClientConnected && isListening)
                        {
                            Thread.Sleep(100);
                        }
                    }
                    else
                    {
                        Thread.Sleep(100);
                    }
                }
            }
            catch (SocketException ex)
            {
                if (isListening)
                {
                    AppendLog($"Lỗi Socket: {ex.Message}");
                }
            }
            catch (Exception ex)
            {
                if (isListening)
                {
                    AppendLog($"Lỗi: {ex.Message}");
                }
            }
        }

        private void ReceiveMessages()
        {
            byte[] buffer = new byte[1024];
            int bytesRead;

            try
            {
                while (isClientConnected && stream != null)
                {
                    bytesRead = stream.Read(buffer, 0, buffer.Length);

                    if (bytesRead == 0)
                    {
                        // Client has disconnected
                        break;
                    }

                    string message = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                    AppendLog($"Client: {message}");
                }
            }
            catch (Exception ex)
            {
                if (isClientConnected)
                {
                    AppendLog($"Lỗi khi nhận dữ liệu: {ex.Message}");
                }
            }
            finally
            {
                DisconnectClient();
            }
        }

        private void DisconnectClient()
        {
            if (!isClientConnected)
                return;

            try
            {
                isClientConnected = false;

                if (stream != null)
                {
                    stream.Close();
                    stream.Dispose();
                    stream = null;
                }

                if (client != null)
                {
                    IPEndPoint? clientEndPoint = client.Client.RemoteEndPoint as IPEndPoint;
                    string clientInfo = clientEndPoint != null
                        ? $"{clientEndPoint.Address}:{clientEndPoint.Port}"
                        : "Unknown";

                    client.Close();
                    client.Dispose();
                    client = null;

                    AppendLog($"Client đã ngắt kết nối từ {clientInfo}");
                    UpdateClientStatus(false, "");
                }
            }
            catch (Exception ex)
            {
                AppendLog($"Lỗi khi ngắt kết nối Client: {ex.Message}");
            }
        }

        private void btn_stop_Click(object sender, EventArgs e)
        {
            StopServer();
        }

        private void StopServer()
        {
            try
            {
                isListening = false;

                // Disconnect client first
                if (isClientConnected)
                {
                    DisconnectClient();
                }

                // Stop server
                if (server != null)
                {
                    server.Stop();
                    server = null;
                }

                // Wait for threads to finish
                if (listenThread != null && listenThread.IsAlive)
                {
                    listenThread.Join(1000);
                }

                if (receiveThread != null && receiveThread.IsAlive)
                {
                    receiveThread.Join(1000);
                }

                UpdateListeningStatus(false);
                AppendLog("Server đã dừng");

                MessageBox.Show("Server đã dừng!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi dừng Server: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateListeningStatus(bool listening)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => UpdateListeningStatus(listening)));
                return;
            }

            if (listening)
            {
                btn_listen.Enabled = false;
                btn_stop.Enabled = true;
                txt_port.Enabled = false;
                lbl_status.Text = "Trạng thái: Đang lắng nghe";
                lbl_status.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                btn_listen.Enabled = true;
                btn_stop.Enabled = false;
                txt_port.Enabled = true;
                lbl_status.Text = "Trạng thái: Chưa lắng nghe";
                lbl_status.ForeColor = System.Drawing.Color.Red;
                lbl_client_info.Text = "Client: Không có";
            }
        }

        private void UpdateClientStatus(bool connected, string clientInfo)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => UpdateClientStatus(connected, clientInfo)));
                return;
            }

            if (connected)
            {
                lbl_client_info.Text = $"Client: {clientInfo}";
                lbl_client_info.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                lbl_client_info.Text = "Client: Không có";
                lbl_client_info.ForeColor = System.Drawing.Color.Gray;
            }
        }

        private void AppendLog(string message)
        {
            if (txt_chat.InvokeRequired)
            {
                txt_chat.Invoke(new Action(() => AppendLog(message)));
                return;
            }

            string timestamp = DateTime.Now.ToString("HH:mm:ss");
            txt_chat.AppendText($"[{timestamp}] {message}\r\n");

            // Auto scroll to bottom
            txt_chat.SelectionStart = txt_chat.Text.Length;
            txt_chat.ScrollToCaret();
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            txt_chat.Clear();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            if (isListening)
            {
                var result = MessageBox.Show(
                    "Server đang chạy. Bạn có chắc muốn đóng ứng dụng?",
                    "Xác nhận",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.No)
                {
                    e.Cancel = true;
                    return;
                }

                StopServer();
            }
        }
    }
}
