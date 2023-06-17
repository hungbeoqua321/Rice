using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Rice
{
    public partial class Payment : Form
    {
        public Payment(Order o, string ID)
        {
            InitializeComponent();
            order = o;
            id = ID;
        }

        private Order order;
        private string id;

        private MongoDBConnector connector = new MongoDBConnector();
        private IMongoCollection<BsonDocument> collection;

        private void Payment_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
            order.Show();
        }

        private void ATM_Click(object sender, System.EventArgs e)
        {
            collection = connector.GetCollection<BsonDocument>("HoaDon");
            var filter = Builders<BsonDocument>.Filter.And(
                Builders<BsonDocument>.Filter.Eq("idKH", id),
                Builders<BsonDocument>.Filter.Eq("trangthai","Pending"));
            var condition = Builders<BsonDocument>.Update.Set("hinhthucthanhtoan", "Banking");
            collection.UpdateOne(filter, condition);
            tabControl1.SelectedTab = tabControl1.TabPages[1];
            Deal();
        }

        private void tienmat_Click(object sender, System.EventArgs e)
        {
            collection = connector.GetCollection<BsonDocument>("HoaDon");
            var filter = Builders<BsonDocument>.Filter.And(
                Builders<BsonDocument>.Filter.Eq("idKH", id),
                Builders<BsonDocument>.Filter.Eq("trangthai", "Pending"));
            var condition = Builders<BsonDocument>.Update.Set("hinhthucthanhtoan", "Cash");
            collection.UpdateOne(filter, condition);
            tabControl1.SelectedTab = tabControl1.TabPages[1];
            Deal();
        }

        private void Cancel_Click(object sender, System.EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("Bạn có chắc chắn muốn hủy đơn", "Quán cơm Shinco", MessageBoxButtons.YesNo))
            {
                collection = connector.GetCollection<BsonDocument>("HoaDon");
                var filter = Builders<BsonDocument>.Filter.And(
                    Builders<BsonDocument>.Filter.Eq("idKH", id),
                    Builders<BsonDocument>.Filter.Eq("trangthai", "Pending"));
                var hd = collection.Find(filter).FirstOrDefault();
                var idHD = hd["_id"].AsBsonValue;
                collection.DeleteOne(filter);
                collection = null;
                collection = connector.GetCollection<BsonDocument>("ChiTietHD");
                filter = Builders<BsonDocument>.Filter.Eq("idHD",idHD.AsInt64);
                collection.DeleteMany(filter);
                this.Close();
                order.Order_Load(sender, e);
                order.Show();
            }
        }

        private void Deal()
        {
            collection = connector.GetCollection<BsonDocument>("HoaDon");
            var HD = collection.Find(Builders<BsonDocument>.Filter.And(
                                    Builders<BsonDocument>.Filter.Eq("idKH", id),
                                    Builders<BsonDocument>.Filter.Eq("trangthai", "Pending"))).FirstOrDefault();
            var idHD = HD["_id"].AsInt64;
            listView1.Items.Clear();

            if (HD != null)
            {
                collection = null;
                collection = connector.GetCollection<BsonDocument>("ChiTietHD");
                var ChiTietHD = collection.Find(Builders<BsonDocument>.Filter.Eq("idHD", idHD)).ToList();
                foreach (var item in ChiTietHD)
                {
                    var tenMon = item.GetValue("id");
                    var soLuong = item.GetValue("soluong");

                    ListViewItem listItem = new ListViewItem(tenMon.ToString());
                    listItem.SubItems.Add(soLuong.ToString());
                    listItem.ToolTipText = soLuong.ToString();

                    listView1.Items.Add(listItem);
                }
            }
            listView1.ShowItemToolTips = true;
            label2.Text = "Tổng tiền: " + HD["tongtien"].ToString();
            label2.Location = new Point((this.Width - label1.Width) / 2, (this.Height - label1.Height) / 2); // Vị trí label

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("Bạn có chắc chắn muốn hủy đơn", "Quán cơm Shinco", MessageBoxButtons.YesNo))
            {
                collection = connector.GetCollection<BsonDocument>("HoaDon");
                var filter = Builders<BsonDocument>.Filter.And(
                                    Builders<BsonDocument>.Filter.Eq("idKH", id),
                                    Builders<BsonDocument>.Filter.Eq("trangthai", "Pending"));
                var hd = collection.Find(filter).FirstOrDefault();
                var idHD = hd["_id"].AsBsonValue;
                collection.DeleteOne(filter);
                collection = null;
                collection = connector.GetCollection<BsonDocument>("ChiTietHD");
                filter = Builders<BsonDocument>.Filter.Eq("idHD", idHD.AsInt64);
                collection.DeleteMany(filter);
                this.Close();
                order.Order_Load(sender, e);
                order.Show();
            }
        }

        private void CF_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabControl1.TabPages[2];
            collection = connector.GetCollection<BsonDocument>("HoaDon");
            var filter = Builders<BsonDocument>.Filter.And(
                Builders<BsonDocument>.Filter.Eq("idKH",id),
                Builders<BsonDocument>.Filter.Eq("trangthai","Pending"));
            var condition = Builders<BsonDocument>.Update.Set("trangthai","Complete - Paied");
            collection.UpdateOne(filter, condition);
            collection = connector.GetCollection<BsonDocument>("ChiTietHD");
            filter = Builders<BsonDocument>.Filter.Eq("soluong",0);
            collection.DeleteMany(filter);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            order.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            order.Order_Load(sender, e);
            order.Show();
        }
    }
}