using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rice
{
    public partial class Staff_Delivery : Form
    {
        public Staff_Delivery(string ID)
        {
            InitializeComponent();
            id = ID;
        }
        string id;

        MongoDBConnector connector = new MongoDBConnector();
        IMongoCollection<BsonDocument> collection;
        
        private void Staff_Delivery_Load(object sender, EventArgs e)
        {
            collection = connector.GetCollection<BsonDocument>("HoaDon");
            var HDs = collection.Find(Builders<BsonDocument>.Filter.Eq("trangthai", "Complete - Pending")).ToList();

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

            table.DataSource = dataTable;
            table.Columns["id"].Visible = false;
            table.Columns["Done"].FillWeight = 40;
            table.Columns["Done"].DisplayIndex = table.ColumnCount - 1;
            table.Columns["Failure"].FillWeight = 40;
            table.Columns["Failure"].DisplayIndex = table.ColumnCount - 1;


        }

        private void Staff_Delivery_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void table_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (table.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                collection = connector.GetCollection<BsonDocument>("HoaDon");
                var filter = Builders<BsonDocument>.Filter.And(
                Builders<BsonDocument>.Filter.Eq("trangthai", "Complete - Paied"),
                Builders<BsonDocument>.Filter.Eq("_id",table.Rows[e.RowIndex].Cells["id"].Value.ToString()));
                if (table.Rows[e.RowIndex].Cells[e.ColumnIndex] == table.Rows[e.RowIndex].Cells["Done"])
                {
                    MessageBox.Show("Giao hàng thành công");
                    var condition = Builders<BsonDocument>.Update.Set("trangthai", "Complete");
                    collection.UpdateOne(filter, condition);
                    this.Staff_Delivery_Load(sender, e);
                }
                if (table.Rows[e.RowIndex].Cells[e.ColumnIndex] == table.Rows[e.RowIndex].Cells["Failure"])
                {
                    MessageBox.Show("Giao hàng thất bại");
                    this.Staff_Delivery_Load(sender, e);
                }
            }
        }
    }
}
