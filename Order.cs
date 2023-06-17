using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Rice
{
    public partial class Order : Form
    {
        public Order(string ID)
        {
            InitializeComponent();
            id = ID;
        }

        private string id;

        private int SUM()
        {
            return 40000 * (Convert.ToInt32(SL_cgcst.Text) + Convert.ToInt32(SL_ccr.Text) + Convert.ToInt32(SL_ctt.Text) + Convert.ToInt32(SL_cdgc.Text) + Convert.ToInt32(SL_crt.Text)) +
                                        30000 * (Convert.ToInt32(SL_cdstx.Text) + Convert.ToInt32(SL_cc.Text) + Convert.ToInt32(SL_mc.Text) + Convert.ToInt32(SL_sc.Text)) +
                                        50000 * Convert.ToInt32(SL_cst.Text);
        }

        private int s = 0;
        private MongoDBConnector connector = new MongoDBConnector();
        private IMongoCollection<BsonDocument> collection;

        private void reCalSum()
        {
            s = SUM(); sum.Text = s.ToString("N0");
        }

        private void ChiTietHD_Update_UP(string food, int count)
        {
            collection = connector.GetCollection<BsonDocument>("ChiTietHD");
            var filter = Builders<BsonDocument>.Filter.And(
                Builders<BsonDocument>.Filter.Eq("id", food),
                Builders<BsonDocument>.Filter.Eq("idHD",countDocument + 1));
            var check = collection.Find(filter).FirstOrDefault();
            if (check != null)
            {
                var condition = Builders<BsonDocument>.Update.Set("soluong", count);
                collection.UpdateOne(filter, condition);
            }
            else
            {
                BsonDocument bsons = new BsonDocument
                {
                    {"id",food },
                    {"idHD",countDocument + 1},
                    {"soluong",count}
                };
                collection.InsertOne(bsons);
            }
        }

        private void ChiTietHD_Update_DOWN(string food, int count)
        {
            collection = connector.GetCollection<BsonDocument>("ChiTietHD");
            var filter = Builders<BsonDocument>.Filter.And(
                Builders<BsonDocument>.Filter.Eq("id", food),
                Builders<BsonDocument>.Filter.Eq("idHD", countDocument + 1));
            if (count != 0)
            {
                var condition = Builders<BsonDocument>.Update.Set("soluong", count);
                collection.UpdateOne(filter, condition);
            }
            else
            {
                collection.DeleteOne(filter);
            }
        }

        private void UP_cgcst_Click(object sender, EventArgs e)
        {
            SL_cgcst.Text = Convert.ToString(Convert.ToInt32(SL_cgcst.Text) + 1);
            reCalSum();
            ChiTietHD_Update_UP("Cơm gà chiên sốt Teriyaki", Convert.ToInt32(SL_cgcst.Text));
        }

        private void DOWN_cgcst_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(SL_cgcst.Text) > 0)
                SL_cgcst.Text = Convert.ToString(Convert.ToInt32(SL_cgcst.Text) - 1);
            reCalSum();
            ChiTietHD_Update_DOWN("Cơm gà chiên sốt Teriyaki", Convert.ToInt32(SL_cgcst.Text));
        }

        private void UP_cdstx_Click(object sender, EventArgs e)
        {
            SL_cdstx.Text = Convert.ToString(Convert.ToInt32(SL_cdstx.Text) + 1);
            reCalSum();
            ChiTietHD_Update_UP("Cơm đậu sốt Tứ Xuyên", Convert.ToInt32(SL_cgcst.Text));
        }

        private void DOWN_cdstx_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(SL_cdstx.Text) > 0)
                SL_cdstx.Text = Convert.ToString(Convert.ToInt32(SL_cdstx.Text) - 1);
            reCalSum();
            ChiTietHD_Update_DOWN("Cơm đậu sốt Tứ Xuyên", Convert.ToInt32(SL_cdstx.Text));
        }

        private void UP_ccr_Click(object sender, EventArgs e)
        {
            SL_ccr.Text = Convert.ToString(Convert.ToInt32(SL_ccr.Text) + 1);
            reCalSum();
            ChiTietHD_Update_UP("Cơm cà ri", Convert.ToInt32(SL_ccr.Text));
        }

        private void DOWN_ccr_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(SL_ccr.Text) > 0)
                SL_ccr.Text = Convert.ToString(Convert.ToInt32(SL_ccr.Text) - 1);
            reCalSum();
            ChiTietHD_Update_DOWN("Cơm cà ri", Convert.ToInt32(SL_ccr.Text));
        }

        private void UP_cst_Click(object sender, EventArgs e)
        {
            SL_cst.Text = Convert.ToString(Convert.ToInt32(SL_cst.Text) + 1);
            reCalSum();
            ChiTietHD_Update_UP("Cơm heo sốt Teriyaki", Convert.ToInt32(SL_cst.Text));
        }

        private void DOWN_cst_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(SL_cst.Text) > 0)
                SL_cst.Text = Convert.ToString(Convert.ToInt32(SL_cst.Text) - 1);
            reCalSum();
            ChiTietHD_Update_DOWN("Cơm heo sốt Teriyaki", Convert.ToInt32(SL_cst.Text));
        }

        private void UP_ctt_Click(object sender, EventArgs e)
        {
            SL_ctt.Text = Convert.ToString(Convert.ToInt32(SL_ctt.Text) + 1);
            reCalSum();
            ChiTietHD_Update_UP("Cơm tôm trứng", Convert.ToInt32(SL_ctt.Text));
        }

        private void DOWN_ctt_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(SL_ctt.Text) > 0)
                SL_ctt.Text = Convert.ToString(Convert.ToInt32(SL_ctt.Text) - 1);
            reCalSum();
            ChiTietHD_Update_DOWN("Cơm tôm trứng", Convert.ToInt32(SL_ctt.Text));
        }

        private void UP_cdgc_Click(object sender, EventArgs e)
        {
            SL_cdgc.Text = Convert.ToString(Convert.ToInt32(SL_cdgc.Text) + 1);
            reCalSum();
            ChiTietHD_Update_UP("Cơm đùi gà chiên", Convert.ToInt32(SL_cdgc.Text));
        }

        private void DOWN_cdgc_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(SL_cdgc.Text) > 0)
                SL_cdgc.Text = Convert.ToString(Convert.ToInt32(SL_cdgc.Text) - 1);
            reCalSum();
            ChiTietHD_Update_DOWN("Cơm đùi gà chiên", Convert.ToInt32(SL_cdgc.Text));
        }

        private void UP_crt_Click(object sender, EventArgs e)
        {
            SL_crt.Text = Convert.ToString(Convert.ToInt32(SL_crt.Text) + 1);
            reCalSum();
            ChiTietHD_Update_UP("Cơm rang trứng", Convert.ToInt32(SL_crt.Text));
        }

        private void DOWN_crt_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(SL_crt.Text) > 0)
                SL_crt.Text = Convert.ToString(Convert.ToInt32(SL_crt.Text) - 1);
            reCalSum();
            ChiTietHD_Update_DOWN("Cơm rang trứng", Convert.ToInt32(SL_crt.Text));
        }

        private void UP_cc_Click(object sender, EventArgs e)
        {
            SL_cc.Text = Convert.ToString(Convert.ToInt32(SL_cc.Text) + 1);
            reCalSum();
            ChiTietHD_Update_UP("Chocolate Cake", Convert.ToInt32(SL_cc.Text));
        }

        private void DOWN_cc_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(SL_cc.Text) > 0)
                SL_cc.Text = Convert.ToString(Convert.ToInt32(SL_cc.Text) - 1);
            reCalSum();
            ChiTietHD_Update_DOWN("Chocolate Cake", Convert.ToInt32(SL_cc.Text));
        }

        private void UP_mc_Click(object sender, EventArgs e)
        {
            SL_mc.Text = Convert.ToString(Convert.ToInt32(SL_mc.Text) + 1);
            reCalSum();
            ChiTietHD_Update_UP("Matcha Cake", Convert.ToInt32(SL_mc.Text));
        }

        private void DOWN_mc_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(SL_mc.Text) > 0)
                SL_mc.Text = Convert.ToString(Convert.ToInt32(SL_mc.Text) - 1);
            reCalSum();
            ChiTietHD_Update_DOWN("Matcha Cake", Convert.ToInt32(SL_mc.Text));
        }

        private void UP_sc_Click(object sender, EventArgs e)
        {
            SL_sc.Text = Convert.ToString(Convert.ToInt32(SL_sc.Text) + 1);
            reCalSum();
            ChiTietHD_Update_UP("Strawberry Cake", Convert.ToInt32(SL_sc.Text));
        }

        private void DOWN_sc_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(SL_sc.Text) > 0)
                SL_sc.Text = Convert.ToString(Convert.ToInt32(SL_sc.Text) - 1);
            reCalSum();
            ChiTietHD_Update_DOWN("Strawberry Cake", Convert.ToInt32(SL_sc.Text));
        }

        private void Pay_Click(object sender, EventArgs e)
        {
            collection = connector.GetCollection<BsonDocument>("HoaDon");
            var filter = Builders<BsonDocument>.Filter.And(
                Builders<BsonDocument>.Filter.Eq("idKH", id),
                Builders<BsonDocument>.Filter.Eq("_id",countDocument + 1),
                Builders<BsonDocument>.Filter.Eq("trangthai","Pending"));
            var condition = Builders<BsonDocument>.Update.Set("tongtien", SUM());
            collection.UpdateOne(filter, condition);
            this.Hide();
            Payment payment = new Payment(this, id);
            payment.ShowDialog();
        }

        private void label24_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            CL_Information cl = new CL_Information(this, id);
            cl.ShowDialog();
        }

        private void Order_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void Rate_Click(object sender, EventArgs e)
        {
            this.Hide();
            Rating rating = new Rating(this, id);
            rating.ShowDialog();
        }

        private long countDocument;

        public void Order_Load(object sender, EventArgs e)
        {
            collection = connector.GetCollection<BsonDocument>("HoaDon");
            countDocument = collection.CountDocuments(Builders<BsonDocument>.Filter.Empty);
            DateTime currentUtcDate = DateTime.UtcNow;

            BsonDocument bsons = new BsonDocument
            {
                {"_id", countDocument + 1},
                {"idKH" , id },
                {"tongtien" , SUM() },
                {"ngaymua" , currentUtcDate.ToString("dd/MM/yyyy") },
                {"hinhthucthanhtoan" , "none" },
                {"trangthai" , "Pending" }
            };
            collection.InsertOne(bsons);
            SL_cc.Text = "0";
            SL_ccr.Text = "0";
            SL_cdgc.Text = "0";
            SL_cdstx.Text = "0";
            SL_cgcst.Text = "0";
            SL_crt.Text = "0";
            SL_cst.Text = "0";
            SL_ctt.Text = "0";
            SL_mc.Text = "0";
            SL_sc.Text = "0";
            sum.Text = "0";
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("Bạn có chắc chắn muốn hủy đơn", "Quán cơm Shinco", MessageBoxButtons.YesNo))
            {
                collection = connector.GetCollection<BsonDocument>("HoaDon");
                countDocument = collection.CountDocuments(Builders<BsonDocument>.Filter.Empty);

                var filter = Builders<BsonDocument>.Filter.And(
                            Builders<BsonDocument>.Filter.Eq("idKH", id),
                            Builders<BsonDocument>.Filter.Eq("_id", countDocument),
                            Builders<BsonDocument>.Filter.Eq("trangthai","Pending"));

                var hd = collection.Find(filter).FirstOrDefault();
                var idHD = hd["_id"].AsBsonValue;
                collection.DeleteOne(filter);
                collection = null;
                collection = connector.GetCollection<BsonDocument>("ChiTietHD");
                filter = Builders<BsonDocument>.Filter.Eq("idHD", idHD.AsInt64);
                collection.DeleteMany(filter);
                this.Close();
            }
        }
    }
}