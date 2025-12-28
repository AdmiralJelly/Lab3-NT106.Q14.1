using System;
using System.Windows.Forms;

namespace Exercise1_Lab03
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private void btn_udp_server_Click(object sender, EventArgs e)
        {
            // Mở form UDP Server
            Server serverForm = new Server();
            serverForm.Show();
        }

        private void btn_udp_client_Click(object sender, EventArgs e)
        {
            // Mở form UDP Client
            Client clientForm = new Client();
            clientForm.Show();
        }
    }
}