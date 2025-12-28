using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

namespace Exercise3_Lab03
{
    public partial class TCPClientForm : Form
    {
        private TcpClient? tcpClient;
        private NetworkStream? stream;
        private bool isConnected = false;

        public TCPClientForm()
        {
            InitializeComponent();
            InitializeUI();
        }

        private void InitializeUI()
        {
            // Set default values
            txt_server_ip.Text = "127.0.0.1";
            txt_server_port.Text = "8888";

            // Initial button states
            btn_connect.Enabled = true;
            btn_send.Enabled = false;
            btn_disconnect.Enabled = false;
            txt_message.Enabled = false;
        }

        private void btn_connect_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_server_ip.Text))
            {
                MessageBox.Show("Vui lòng nhập địa chỉ IP của Server!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!int.TryParse(txt_server_port.Text, out int port) || port < 1 || port > 65535)
            {
                MessageBox.Show("Port không hợp lệ! Vui lòng nhập số từ 1-65535.", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                // Create TCP client
                tcpClient = new TcpClient();

                // Parse IP address
                IPAddress serverAddr;
                if (!IPAddress.TryParse(txt_server_ip.Text, out serverAddr))
                {
                    MessageBox.Show("Địa chỉ IP không hợp lệ!", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Connect to server
                tcpClient.Connect(serverAddr, port);
                stream = tcpClient.GetStream();
                isConnected = true;

                // Update UI
                UpdateConnectionStatus(true);
                AppendLog($"Đã kết nối đến Server {txt_server_ip.Text}:{port}");

                MessageBox.Show("Kết nối thành công!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (SocketException ex)
            {
                MessageBox.Show($"Không thể kết nối đến Server!\nLỗi: {ex.Message}",
                    "Lỗi kết nối", MessageBoxButtons.OK, MessageBoxIcon.Error);
                CleanupConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                CleanupConnection();
            }
        }

        private void btn_send_Click(object sender, EventArgs e)
        {
            SendMessage();
        }

        private void SendMessage()
        {
            if (!isConnected || stream == null)
            {
                MessageBox.Show("Chưa kết nối đến Server!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string message = txt_message.Text.Trim();
            if (string.IsNullOrWhiteSpace(message))
            {
                MessageBox.Show("Vui lòng nhập tin nhắn!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Convert message to bytes (UTF-8)
                byte[] data = Encoding.UTF8.GetBytes(message);

                // Send to server
                stream.Write(data, 0, data.Length);

                // Log sent message
                AppendLog($"Đã gửi: {message}");

                // Clear input
                txt_message.Clear();
                txt_message.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi gửi tin nhắn: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                // Connection might be lost
                DisconnectFromServer();
            }
        }

        private void btn_disconnect_Click(object sender, EventArgs e)
        {
            DisconnectFromServer();
        }

        private void DisconnectFromServer()
        {
            try
            {
                CleanupConnection();
                UpdateConnectionStatus(false);
                AppendLog("Đã ngắt kết nối khỏi Server");

                MessageBox.Show("Đã ngắt kết nối!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi ngắt kết nối: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CleanupConnection()
        {
            isConnected = false;

            if (stream != null)
            {
                stream.Close();
                stream.Dispose();
                stream = null;
            }

            if (tcpClient != null)
            {
                tcpClient.Close();
                tcpClient.Dispose();
                tcpClient = null;
            }
        }

        private void UpdateConnectionStatus(bool connected)
        {
            if (connected)
            {
                btn_connect.Enabled = false;
                btn_send.Enabled = true;
                btn_disconnect.Enabled = true;
                txt_message.Enabled = true;
                txt_server_ip.Enabled = false;
                txt_server_port.Enabled = false;

                lbl_status.Text = "Trạng thái: Đã kết nối";
                lbl_status.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                btn_connect.Enabled = true;
                btn_send.Enabled = false;
                btn_disconnect.Enabled = false;
                txt_message.Enabled = false;
                txt_server_ip.Enabled = true;
                txt_server_port.Enabled = true;

                lbl_status.Text = "Trạng thái: Chưa kết nối";
                lbl_status.ForeColor = System.Drawing.Color.Red;
            }
        }

        private void AppendLog(string message)
        {
            if (txt_log.InvokeRequired)
            {
                txt_log.Invoke(new Action(() => AppendLog(message)));
                return;
            }

            string timestamp = DateTime.Now.ToString("HH:mm:ss");
            txt_log.AppendText($"[{timestamp}] {message}\r\n");

            // Auto scroll to bottom
            txt_log.SelectionStart = txt_log.Text.Length;
            txt_log.ScrollToCaret();
        }

        private void txt_message_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; // Prevent beep sound
                SendMessage();
            }
        }

        private void btn_clear_log_Click(object sender, EventArgs e)
        {
            txt_log.Clear();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            if (isConnected)
            {
                var result = MessageBox.Show(
                    "Bạn đang kết nối đến Server. Bạn có chắc muốn đóng ứng dụng?",
                    "Xác nhận",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.No)
                {
                    e.Cancel = true;
                    return;
                }
            }

            CleanupConnection();
        }
    }
}
