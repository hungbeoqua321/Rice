using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Data;
using System.Windows.Forms;

namespace Rice
{
    public partial class Danhsach_NV : Form
    {
        public Danhsach_NV(TrangchuQL qL)
        {
            InitializeComponent();
            QL = qL;
        }

        private TrangchuQL QL;
        private MongoDBConnector connector = new MongoDBConnector();
        private IMongoCollection<BsonDocument> collection;

        private void Danhsach_NV_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
            QL.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                // Lấy dữ liệu từ dòng được chọn
                DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];
                string MaNV = selectedRow.Cells["ID"].Value.ToString();
                Ed_NhanVien ed_NhanVien = new Ed_NhanVien(this, MaNV);
                this.Hide();
                ed_NhanVien.ShowDialog();
            }
        }

        private void Danhsach_NV_Load(object sender, EventArgs e)
        {
            collection = connector.GetCollection<BsonDocument>("NguoiDung");
            var users = collection.Find(Builders<BsonDocument>.Filter.Eq("VaiTro", "Nhân viên")).ToList();
            DataTable tb = new DataTable();

            // collumns
            tb.Columns.Add("ID");
            tb.Columns.Add("Tên");
            tb.Columns.Add("Số Điện Thoại");
            tb.Columns.Add("Địa Chỉ");
            // fill
            foreach (var user in users)
            {
                var row = tb.NewRow();
                row["ID"] = user["id"];
                row["tên"] = user["ten"];
                row["Số Điện Thoại"] = user["sdt"];
                row["Địa Chỉ"] = user["addr"];
                tb.Rows.Add(row);
            }

            dataGridView1.Columns["edit"].DisplayIndex = dataGridView1.ColumnCount - 1;
            dataGridView1.DataSource = tb;

            dataGridView1.Columns["ID"].FillWeight = 30;
        }
    }
}