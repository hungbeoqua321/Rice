using System;
using System.Windows.Forms;

namespace Rice
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void Home_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void login_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login n = new Login(this);
            n.ShowDialog();
        }

        private void regis_Click(object sender, EventArgs e)
        {
            this.Hide();
            Regis n = new Regis(this);
            n.ShowDialog();
        }

        private void Home_Load(object sender, EventArgs e)
        {
        }
    }
}