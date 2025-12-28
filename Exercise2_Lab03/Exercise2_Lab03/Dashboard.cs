using System;
using System.Net.Sockets;
using System.Windows.Forms;

namespace Exercise2_Lab03
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private void btn_tcp_listener_Click(object sender, EventArgs e)
        {
            // Mở TCP Listener form
            TCPListener listenerForm = new TCPListener();
            listenerForm.Show();
        }
    }
}
