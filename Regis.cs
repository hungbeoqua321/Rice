using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Rice
{
    public partial class Regis : Form
    {
        public Regis(Home h)
        {
            InitializeComponent();
            home = h;
        }

        private Home home;

        private MongoDBConnector connector = new MongoDBConnector();

        private void Regis_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
            home.Show();
        }

        private void Submit_Regis_Click(object sender, EventArgs e)
        {
            //
            // Kiểm tra trống
            //
            if (string.IsNullOrEmpty(HoTen.Text))
                Not_Blank_HoTen.Visible = true;
            else
                Not_Blank_HoTen.Visible = false;

            if (string.IsNullOrEmpty(SĐT.Text))
                Not_Blank_SĐT.Visible = true;
            else
                Not_Blank_SĐT.Visible = false;

            if (Addr.TextLength == 0)
                Not_Blank_Addr.Visible = true;
            else
                Not_Blank_Addr.Visible = false;

            if (TaiKhoan.TextLength == 0)
                Not_Blank_TK.Visible = true;
            else
                Not_Blank_TK.Visible = false;

            if (MatKhau.TextLength == 0)
                Not_Blank_MatKhau.Visible = true;
            else
                Not_Blank_MatKhau.Visible = false;

            bool isNum = int.TryParse(SĐT.Text, out int num);
            //
            // CSDL
            //
            if (!string.IsNullOrEmpty(HoTen.Text) && !string.IsNullOrEmpty(SĐT.Text) && !string.IsNullOrEmpty(Addr.Text) && !string.IsNullOrEmpty(TaiKhoan.Text) && !string.IsNullOrEmpty(MatKhau.Text) && isNum)
            {
                //
                // Thiết lập kết nối
                //
                IMongoCollection<BsonDocument> users = connector.GetCollection<BsonDocument>("NguoiDung");

                //
                // lấy thông tin
                //
                string ht = HoTen.Text;
                string sdt = SĐT.Text.Replace(" ", "");
                string dc = Addr.Text;
                string tk = TaiKhoan.Text.Replace(" ", "");
                string mk = MatKhau.Text.Replace(" ", "");
                //
                // kiểm tra trùng tk
                //
                var filter = Builders<BsonDocument>.Filter.Eq("TK", tk);
                var ck = users.Find(filter).FirstOrDefault();
                if (ck == null)
                {
                    //
                    // lấy số bản ghi để thêm khách mới
                    //
                    var filter_user = Builders<BsonDocument>.Filter.Eq("VaiTro", "Khách Hàng");
                    string id = "K" + users.Find(filter).CountDocuments().ToString();

                    //
                    // Ghi vào bảng người dùng
                    //
                    BsonDocument user = new BsonDocument
                    {
                        {"id",id },
                        {"ten",ht },
                        {"tk",tk },
                        {"mk",mk },
                        {"sdt",sdt },
                        {"addr",dc },
                        {"VaiTro","Khách Hàng" }
                    };
                    users.InsertOne(user);
                    MessageBox.Show("Đăng ký thành công!", "Thông báo", MessageBoxButtons.OK);
                    Order order = new Order(id);
                    this.Hide();
                    order.ShowDialog();
                }
                else
                    MessageBox.Show("Trùng tên tài khoản!", "Đăng ký thất bại", MessageBoxButtons.OK);
            }
        }

        private void SĐT_TextChanged(object sender, EventArgs e)
        {
            if ((!int.TryParse(SĐT.Text, out int value) || SĐT.TextLength > 10) && SĐT.TextLength > 0)
            {
                SĐT.Text = SĐT.Text.Remove(SĐT.TextLength - 1);
                SĐT.SelectionStart = SĐT.TextLength;
            }
        }

        private void Regis_Load(object sender, EventArgs e)
        {
            panel1.BackColor = Color.FromArgb(150, 255, 255, 255);
        }

        private void HoTen_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(HoTen.Text))
            {
                if (int.TryParse(HoTen.Text[HoTen.TextLength - 1].ToString(), out int value))
                {
                    HoTen.Text = HoTen.Text.Remove(HoTen.TextLength - 1);
                    HoTen.SelectionStart = HoTen.TextLength;
                }
            }
        }
    }
}