using System;
using System.Windows.Forms;

namespace Exercise3_Lab03
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private void btn_open_server_Click(object sender, EventArgs e)
        {
            TCPServerForm serverForm = new TCPServerForm();
            serverForm.Show();
        }

        private void btn_open_client_Click(object sender, EventArgs e)
        {
            TCPClientForm clientForm = new TCPClientForm();
            clientForm.Show();
        }
    }
}
