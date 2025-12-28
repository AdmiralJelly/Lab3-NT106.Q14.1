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

namespace Exercise1_Lab03
{
    public partial class Client : Form
    {
        public Client()
        {
            InitializeComponent();
        }

        UdpClient client;
        IPEndPoint ip_end_point;


        private void btn_connect_Click(object sender, EventArgs e)
        {
            try
            {
                // Tạo UDP client (random port explicit)
                client = new UdpClient(0);

                // Lấy port từ UI
                int remote_port = int.Parse(txt_port.Text);

                // Tạo endpoint để kết nối đến server
                ip_end_point = new IPEndPoint(IPAddress.Parse(txt_ip_add.Text), remote_port);

                // Bắt đầu nhận dữ liệu bất đồng bộ
                client.BeginReceive(new AsyncCallback(onReceive), client);

                MessageBox.Show("Đã kết nối thành công!", "Client", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Disable nút Connect sau khi kết nối
                btn_connect.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Client Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void onReceive(IAsyncResult AR)
        {
            try
            {
                // Nhận dữ liệu
                byte[] buff = client.EndReceive(AR, ref ip_end_point);

                // Tiếp tục lắng nghe
                client.BeginReceive(new AsyncCallback(onReceive), client);

                // Hiển thị tin nhắn nhận được từ Server
                string message = Encoding.UTF8.GetString(buff);
                ControlInvoke(txt_show_mes, () =>
                    txt_show_mes.AppendText("Server: " + message + Environment.NewLine));
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

        private void btn_send_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra xem đã kết nối chưa
                if (client == null)
                {
                    MessageBox.Show("Vui lòng kết nối trước khi gửi!", "Warning",
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

                // Chuyển đổi tin nhắn sang byte array với UTF8
                byte[] data = Encoding.UTF8.GetBytes(txt_send.Text);

                // Gửi dữ liệu
                client.Send(data, data.Length, ip_end_point);

                // Hiển thị tin nhắn đã gửi
                txt_show_mes.AppendText("Client: " + txt_send.Text + Environment.NewLine);

                // Xóa textbox sau khi gửi
                txt_send.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gửi thất bại! Vui lòng thử lại!\n" + ex.Message,
                    "Send Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Xử lý khi đóng form
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            // Đóng kết nối UDP
            if (client != null)
            {
                client.Close();
            }
        }
    }
}