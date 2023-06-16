using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Windows.Forms;

namespace Rice
{
    public partial class Ed_NhanVien : Form
    {
        public Ed_NhanVien(Danhsach_NV ds, string ID)
        {
            InitializeComponent();
            DanhsachNV = ds;
            id = ID;
        }

        private Danhsach_NV DanhsachNV;
        private string id;

        public MongoDBConnector connector = new MongoDBConnector();
        public IMongoCollection<BsonDocument> collection;

        private void Ed_NhanVien_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
            DanhsachNV.Show();
        }

        private void reload(object sender, EventArgs e)
        {
            collection = connector.GetCollection<BsonDocument>("NguoiDung");
            var r = collection.Find(Builders<BsonDocument>.Filter.Eq("id", id)).FirstOrDefault();
            if (r != null)
            {
                txthoten.Text = r.GetValue("ten").AsString;
                txttaikhoan.Text = r.GetValue("tk").AsString;
                txtmatkhau.Text = r.GetValue("mk").AsString;
                txtsdt.Text = r.GetValue("sdt").AsString;
                txtdiachi.Text = r.GetValue("addr").AsString;
            }
            txthoten.ReadOnly = true;
            txttaikhoan.ReadOnly = true;
            txtmatkhau.ReadOnly = true;
            txtsdt.ReadOnly = true;
            txtdiachi.ReadOnly = true;
        }

        private void btnchinhsua_Click(object sender, EventArgs e)
        {
            txthoten.ReadOnly = false;
            txttaikhoan.ReadOnly = false;
            txtmatkhau.ReadOnly = false;
            txtsdt.ReadOnly = false;
            txtdiachi.ReadOnly = false;
            btnchinhsua.Visible = false;
            CF.Visible = true;
        }

        private void txtsdt_TextChanged(object sender, EventArgs e)
        {
            if ((!int.TryParse(txtsdt.Text, out int value) || txtsdt.TextLength > 10) && txtsdt.TextLength > 0)
            {
                txtsdt.Text = txtsdt.Text.Remove(txtsdt.TextLength - 1);
                txtsdt.SelectionStart = txtsdt.TextLength;
            }
        }

        private void CF_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txttaikhoan.Text) && !string.IsNullOrEmpty(txtmatkhau.Text))
            {
                string tk = txttaikhoan.Text.Replace(" ", "");
                string mk = txtmatkhau.Text.Replace(" ", "");

                collection = connector.GetCollection<BsonDocument>("NguoiDung");
                var filter = Builders<BsonDocument>.Filter.Eq("id", id);
                var condition = Builders<BsonDocument>.Update.Set("ten", txthoten.Text)
                                                             .Set("tk", tk)
                                                             .Set("mk", mk)
                                                             .Set("sdt", txtsdt.Text)
                                                             .Set("addr", txtdiachi.Text);
                collection.UpdateOne(filter, condition);

                this.reload(sender, e);
                MessageBox.Show("Thay đổi thành công!");
                btnchinhsua.Visible = true;
                CF.Visible = false;
            }
            else
            {
                MessageBox.Show("Không được để trống tài khoản và mật khẩu", "Lỗi");
            }
        }
    }
}