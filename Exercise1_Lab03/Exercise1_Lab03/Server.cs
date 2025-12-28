using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace Exercise1_Lab03
{
    public partial class Server : Form
    {
        public Server()
        {
            InitializeComponent();
            btn_close.Enabled = false;
        }

        IPEndPoint ip_end_point;
        UdpClient server;


        private void btn_send_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra xem đã kết nối chưa
                if (server == null)
                {
                    MessageBox.Show("Vui lòng Listen trước khi gửi!", "Warning",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Kiểm tra tin nhắn không rỗng
                if (string.IsNullOrWhiteSpace(txt_send.Text))
                {
                    MessageBox.Show("Vui lòng nhập tin nhắn!", "Warning",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Kiểm tra xem đã có client nào kết nối chưa (đã nhận gói tin nào chưa)
                if (ip_end_point == null || ip_end_point.Port == 0)
                {
                     MessageBox.Show("Chưa có Client nào kết nối (chưa nhận được dữ liệu)!", "Warning",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Chuyển đổi tin nhắn sang byte array với UTF8
                byte[] data = Encoding.UTF8.GetBytes(txt_send.Text);

                // Gửi dữ liệu trực tiếp đến endpoint
                server.Send(data, data.Length, ip_end_point);

                // Hiển thị tin nhắn đã gửi
                txt_show_mes.AppendText("Server: " + txt_send.Text + Environment.NewLine);

                // Xóa textbox sau khi gửi
                txt_send.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gửi thất bại! Vui lòng thử lại!\n" + ex.Message,
                    "Send Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_connect_Click(object sender, EventArgs e)
        {
            try
            {
                // Tạo UDP server với port cục bộ
                int port = int.Parse(txt_port.Text);
                server = new UdpClient(port);

                // Tạo endpoint để kết nối đến client (Mặc định hoặc chờ nhận)
                // Lưu ý: Ở đây ta chỉ khởi tạo endpoint, chưa biết port client thực sự cho đến khi nhận được gói tin
                // Tuy nhiên code cũ khởi tạo cứng. Ta có thể giữ nguyên hoặc chỉ init IP.
                // Để đơn giản và giữ logic cũ, ta connect đến IP nhập vào và port mặc định nào đó hoặc để port 0
                ip_end_point = new IPEndPoint(IPAddress.Any, 0);

                // Bắt đầu nhận dữ liệu bất đồng bộ
                server.BeginReceive(new AsyncCallback(onReceive), server);

                MessageBox.Show("Server đang lắng nghe tại port " + port, "Server",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Disable nút Listen sau khi bắt đầu lắng nghe
                btn_connect.Enabled = false;
                btn_close.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Server Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
             // Đóng kết nối
             if (server != null)
             {
                 server.Close();
                 server = null;
             }
             
             // Enable lại nút Listen
             btn_connect.Enabled = true;
             btn_close.Enabled = false;

             MessageBox.Show("Đã dừng Server!", "Server", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void onReceive(IAsyncResult AR)
        {
            try
            {
                // Nhận dữ liệu
                byte[] buff = server.EndReceive(AR, ref ip_end_point);

                // Tiếp tục lắng nghe
                server.BeginReceive(new AsyncCallback(onReceive), server);

                // Hiển thị tin nhắn nhận được từ Client
                string message = Encoding.UTF8.GetString(buff);
                ControlInvoke(txt_show_mes, () =>
                    txt_show_mes.AppendText(ip_end_point.Address.ToString() + ": " + message + Environment.NewLine));
            }
            catch (Exception ex)
            {
                // Xử lý lỗi khi nhận dữ liệu
                ControlInvoke(txt_show_mes, () =>
                    txt_show_mes.AppendText("Lỗi nhận dữ liệu: " + ex.Message + Environment.NewLine));
            }
        }

        delegate void UniversalVoidDelegate();

        public static void ControlInvoke(Control control, Action function)
        {
            if (control.IsDisposed || control.Disposing)
                return;

            if (control.InvokeRequired)
            {
                control.Invoke(new UniversalVoidDelegate(() => ControlInvoke(control, function)));
                return;
            }
            function();
        }

        // Xử lý khi đóng form
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            // Đóng kết nối UDP
            if (server != null)
            {
                server.Close();
            }
        }
    }
}