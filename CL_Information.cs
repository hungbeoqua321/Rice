using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Rice
{
    public partial class CL_Information : Form
    {
        public CL_Information(Order o, string ID)
        {
            InitializeComponent();
            id = ID;
            order = o;
        }

        private string id;
        private Order order;

        private MongoDBConnector connector = new MongoDBConnector();

        private void Edit_button_Click(object sender, EventArgs e)
        {
            HoTen.Visible = true; ht.Visible = false;
            MatKhau.Visible = true; mk.Visible = false;
            SDT.Visible = true; num.Visible = false;
            Addr.Visible = true; dc.Visible = false;
            HoTen.Text = ht.Text;
            MatKhau.Text = mk.Text;
            SDT.Text = num.Text;
            Addr.Text = dc.Text;
            Edit_button.Visible = false;
            CF.Visible = true;
        }

        private void CL_Information_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
            order.Show();
        }

        private void reload(object sender, EventArgs e)
        {
            IMongoCollection<BsonDocument> collection = connector.GetCollection<BsonDocument>("NguoiDung");
            var filter = Builders<BsonDocument>.Filter.Eq("id", id);
            var user = collection.Find(filter).FirstOrDefault();
            ht.Text = user.GetValue("ten").ToString();
            mk.Text = user.GetValue("mk").ToString();
            num.Text = user.GetValue("sdt").ToString();
            dc.Text = user.GetValue("addr").ToString();
            panel1.BackColor = Color.FromArgb(200, 255, 255, 255);
        }

        private void CF_Click(object sender, EventArgs e)
        {
            Edit_button.Visible = true;
            CF.Visible = false;

            IMongoCollection<BsonDocument> collection = connector.GetCollection<BsonDocument>("NguoiDung");
            var filter = Builders<BsonDocument>.Filter.Eq("id", id);
            var update_condition = Builders<BsonDocument>.Update.Set("ten", HoTen.Text)
                                                                .Set("mk", MatKhau.Text)
                                                                .Set("sdt", SDT.Text)
                                                                .Set("addr", Addr.Text);
            collection.UpdateOne(filter, update_condition);

            HoTen.Visible = false; ht.Visible = true;
            MatKhau.Visible = false; mk.Visible = true;
            SDT.Visible = false; num.Visible = true;
            Addr.Visible = false; dc.Visible = true;
            Edit_button.Visible = true;
            this.reload(sender, e);
            MessageBox.Show("Chỉnh sửa thông tin cá nhân thành công");
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

        private void SDT_TextChanged(object sender, EventArgs e)
        {
            if (!int.TryParse(SDT.Text, out int value) || SDT.TextLength > 10)
            {
                SDT.Text = SDT.Text.Remove(SDT.TextLength - 1);
                SDT.SelectionStart = SDT.TextLength;
            }
        }
    }
}