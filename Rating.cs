using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Rice
{
    public partial class Rating : Form
    {
        public Rating(Order o, string ID)
        {
            InitializeComponent();
            order = o;
            id_nd = ID;
        }

        private Order order;
        private string id_nd;

        public MongoDBConnector connector = new MongoDBConnector();
        private int id_ma;

        private void rateBtn_Click(object sender, EventArgs e)
        {
            input.ReadOnly = true;
            rateBtn.Visible = false;
            string r = input.Text;
            string test = Fr(id_nd, id_ma, connector);

            IMongoCollection<BsonDocument> collection = connector.GetCollection<BsonDocument>("DanhGia");
            var filter = Builders<BsonDocument>.Filter.And(Builders<BsonDocument>.Filter.Eq("id_nd", id_nd),
                                                           Builders<BsonDocument>.Filter.Eq("id_ma", id_ma));
            if (string.IsNullOrEmpty(test))
            {
                // insert
                BsonDocument rate = new BsonDocument {
                    {"id_nd",id_nd },
                    {"id_ma",id_ma },
                    {"danhgia",r }
                    };
                collection.InsertOne(rate);
            }
            else
            {
                //update
                var update_condition = Builders<BsonDocument>.Update.Set("danhgia", r);
                collection.UpdateOne(filter, update_condition);
            }
        }

        public static string Fr(string nd, int ma, MongoDBConnector connector)
        {
            IMongoCollection<BsonDocument> collection = connector.GetCollection<BsonDocument>("DanhGia");
            var filter = Builders<BsonDocument>.Filter.And(Builders<BsonDocument>.Filter.Eq("id_nd", nd),
                                                           Builders<BsonDocument>.Filter.Eq("id_ma", ma));
            var result = collection.Find(filter).FirstOrDefault();

            return result != null ? result.GetValue("danhgia").AsString : null;
        }

        private void DanhGia(int i)
        {
            input.Clear();
            Name_dish.Visible = true;
            input.Text = Fr(id_nd, i, connector);
            id_ma = i;
        }

        private void mon1_CheckedChanged(object sender, EventArgs e)
        {
            Name_dish.Text = dish1.Text;
            DanhGia(1);
        }

        private void mon2_CheckedChanged(object sender, EventArgs e)
        {
            Name_dish.Text = dish2.Text;

            DanhGia(2);
        }

        private void mon3_CheckedChanged(object sender, EventArgs e)
        {
            Name_dish.Text = dish3.Text;

            DanhGia(3);
        }

        private void mon4_CheckedChanged(object sender, EventArgs e)
        {
            Name_dish.Text = dish4.Text;

            DanhGia(4);
        }

        private void mon5_CheckedChanged(object sender, EventArgs e)
        {
            Name_dish.Text = dish5.Text;

            DanhGia(5);
        }

        private void mon6_CheckedChanged(object sender, EventArgs e)
        {
            Name_dish.Text = dish6.Text;

            DanhGia(6);
        }

        private void mon7_CheckedChanged(object sender, EventArgs e)
        {
            Name_dish.Text = dish7.Text;

            DanhGia(7);
        }

        private void mon8_CheckedChanged(object sender, EventArgs e)
        {
            Name_dish.Text = dish8.Text;

            DanhGia(8);
        }

        private void mon9_CheckedChanged(object sender, EventArgs e)
        {
            Name_dish.Text = dish9.Text;

            DanhGia(9);
        }

        private void mon10_CheckedChanged(object sender, EventArgs e)
        {
            Name_dish.Text = dish10.Text;

            DanhGia(10);
        }

        private void Rating_FormClosed(object sender, FormClosedEventArgs e)
        {
            order.Show();
            this.Close();
        }

        private void editBtn_Click(object sender, EventArgs e)
        {
            rateBtn.Visible = true;
            input.ReadOnly = false;
        }
    }
}