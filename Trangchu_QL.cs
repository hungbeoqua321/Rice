using System;
using System.Windows.Forms;

namespace Rice
{
    public partial class TrangchuQL : Form
    {
        public TrangchuQL()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thoát không  ", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                Application.Exit();
        }

        private void buttonQLNV_Click(object sender, EventArgs e)
        {
            this.Hide();
            Danhsach_NV danhsach_NV = new Danhsach_NV(this);
            danhsach_NV.ShowDialog();
        }

        private void TrangchuQL_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void buttonQLDT_Click(object sender, EventArgs e)
        {
            this.Hide();
            QLDT qLDT = new QLDT();
            qLDT.ShowDialog();
        }

        private void buttonQLNl_Click(object sender, EventArgs e)
        {
            this.Hide();
            QLNL qLNL = new QLNL(this);
            qLNL.ShowDialog();
        }
    }
}