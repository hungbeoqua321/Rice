using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rice
{
    public partial class Staff_Order : Form
    {
        public Staff_Order(string ID)
        {
            InitializeComponent();
            id = ID;
        }
        string id;

        MongoDBConnector connector = new MongoDBConnector();
        IMongoCollection<BsonDocument> collection;

        

        private void reload(object sender, EventArgs e)
        {
            collection = connector.GetCollection<BsonDocument>("HoaDon");
            var HDs = collection.Find(Builders<BsonDocument>.Filter.Eq("trangthai", "Complete")).ToList();

            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("id");
            dataTable.Columns.Add("Tên khách hàng");
            dataTable.Columns.Add("Địa chỉ");
            dataTable.Columns.Add("Tổng tiền");
            dataTable.Columns.Add("Thu tiền");

            foreach (var hd in HDs)
            {
                var row = dataTable.NewRow();
                var idkh = hd["idKH"];
                collection = connector.GetCollection<BsonDocument>("NguoiDung");
                var ttkh = collection.Find(Builders<BsonDocument>.Filter.Eq("id", idkh)).FirstOrDefault();
                row["id"] = hd["_id"];
                row[1] = ttkh.GetValue("ten").AsString;
                row[2] = ttkh.GetValue("addr").AsString;
                row[3] = hd["tongtien"].AsInt32;
                if (hd["hinhthucthanhtoan"].AsString == "Cash")
                    row[4] = "Có";
                else
                    row[4] = "Không";
                dataTable.Rows.Add(row);
            }

            dataGridView1.DataSource = dataTable;
            dataGridView1.Columns["check"].DisplayIndex = dataGridView1.ColumnCount - 1;
            dataGridView1.Columns["id"].Visible = false;
        }

        private void Staff_Order_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                collection = connector.GetCollection<BsonDocument>("HoaDon");
                var filter = Builders<BsonDocument>.Filter.And(
                             Builders<BsonDocument>.Filter.Eq("_id", dataGridView1.Rows[e.RowIndex].Cells["id"].Value.ToString()),
                             Builders<BsonDocument>.Filter.Eq("trangthai","Complete"));
                var condition = Builders<BsonDocument>.Update.Set("idNV", id);
                DataGridViewButtonCell buttonCell = dataGridView1.Rows[e.RowIndex].Cells["check"] as DataGridViewButtonCell;
                if (buttonCell.ToString() != "Hủy")// Nhận đơn
                {
                    buttonCell.Value = "Hủy";
                    collection.UpdateOne(filter, condition);
                }
                    
                else // Không nhận đơn
                {
                    buttonCell.Value = "Nhận";
                    condition = Builders<BsonDocument>.Update.Set("idNV","None");
                    collection.UpdateOne(filter, condition);

                }
            }
        }
    }
}
