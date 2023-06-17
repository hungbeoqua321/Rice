using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Rice
{
    public partial class Login : Form
    {
        public Login(Home h)
        {
            InitializeComponent();
            home = h;
        }

        private Home home;

        private MongoDBConnector connector = new MongoDBConnector();

        private void Login_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
            home.Show();
        }

        private void Submit_Login_Click(object sender, EventArgs e)
        {
            //
            // Kiểm tra xem 2 trường nhập vào có để trống không
            //
            if (string.IsNullOrEmpty(TenDangNhap.Text))
                Not_Blank_TenDangNhap.Visible = true;
            else
                Not_Blank_TenDangNhap.Visible = false;

            if (string.IsNullOrEmpty(MatKhau.Text))
                Not_Blank_MatKhau.Visible = true;
            else
                Not_Blank_MatKhau.Visible = false;

            //
            // Đăng nhập
            //

            if (!string.IsNullOrEmpty(TenDangNhap.Text) && !string.IsNullOrEmpty(MatKhau.Text))
            {
                IMongoCollection<BsonDocument> collection = connector.GetCollection<BsonDocument>("NguoiDung");

                string tk = TenDangNhap.Text.Replace(" ", "");
                string mk = MatKhau.Text.Replace(" ", "");

                var filter = Builders<BsonDocument>.Filter.Eq("tk", tk);
                var check = collection.Find(filter).FirstOrDefault();

                string taikhoan = null;
                string matkhau = null;
                if (check != null)
                {
                    taikhoan = check.GetValue("tk").AsString;
                    matkhau = check.GetValue("mk").AsString;
                }
                bool test = string.Equals(tk, taikhoan) && string.Equals(mk, matkhau);
                if (!test)
                {
                    Check_Text.Visible = true;
                    MatKhau.Focus();
                }
                else
                {
                    MessageBox.Show("Đăng nhập thành công", "Báo Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    string id = check.GetValue("id").AsString;
                    string vaitro = check.GetValue("VaiTro").AsString;
                    //
                    // 3 trường hợp đăng nhập
                    //
                    if (id.StartsWith("K"))
                    {
                        this.Hide();
                        Order order1 = new Order(id);
                        order1.ShowDialog();
                    }
                    else if (id.StartsWith("N"))
                    {
                        if (vaitro == "Nhân viên nhận đơn")
                        {
                            this.Hide();
                            Staff_Order staff_Order = new Staff_Order(id);
                            staff_Order.ShowDialog();
                        }
                        else
                        {
                            this.Hide();
                            Staff_Delivery delivery = new Staff_Delivery(id);
                            delivery.ShowDialog();
                        }    
                    }
                    else if (id.StartsWith("Q"))
                    {
                        this.Hide();
                        TrangchuQL trangchuQL = new TrangchuQL();
                        trangchuQL.ShowDialog();
                    }
                }
            }
        }
    }
}