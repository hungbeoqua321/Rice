using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Rice
{
    public partial class QLNL : Form
    {
        public QLNL(TrangchuQL q)
        {
            InitializeComponent();
            ql = q;
        }

        private TrangchuQL ql;
        private MongoDBConnector connector = new MongoDBConnector();
        private IMongoCollection<BsonDocument> collection;

        private void QLNL_Load(object sender, EventArgs e)
        {
            collection = connector.GetCollection<BsonDocument>("NguyenLieu");
            var nls = collection.Find(Builders<BsonDocument>.Filter.Empty).ToList();
            DataTable dt = new DataTable();

            dt.Columns.Add("Tên nguyên liệu");
            dt.Columns.Add("Đơn vị");
            dt.Columns.Add("Đơn giá");

            foreach (var nl in nls)
            {
                var Row = dt.NewRow();
                Row["Tên nguyên liệu"] = nl["ten"];
                Row["Đơn vị"] = nl["donvi"];
                Row["Đơn giá"] = nl["dongia"];
                dt.Rows.Add(Row);
            }

            dataGridView1.DataSource = dt;
            dataGridView1.Columns["edit"].DisplayIndex = 4;
            dataGridView1.Columns["del"].DisplayIndex = dataGridView1.ColumnCount - 1;
            dataGridView1.Columns["Tên nguyên liệu"].FillWeight = 150;
        }

        private void QLNL_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
            ql.Show();
        }

        private void reset()
        {
            TenNguyenLieu.Text = string.Empty;
            DonGia.Text = string.Empty;
            SoLuong.Text = string.Empty;
            TenNguyenLieu.Visible = true; label2.Visible = true;
            SoLuong.Visible = true; label3.Visible = true;
            DonGia.Visible = true; label4.Visible = true;
        }

        private string name;

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            collection = connector.GetCollection<BsonDocument>("NguyenLieu");
            if (dataGridView1.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                DataGridViewRow dataGridViewRow = dataGridView1.Rows[e.RowIndex];
                name = dataGridViewRow.Cells["Tên nguyên liệu"].Value.ToString();

                if (e.ColumnIndex == dataGridView1.Columns["edit"].Index)// chỉnh sửa
                {
                    reset();
                    btnthem.Visible = false;
                    btncf.Visible = true;
                    TenNguyenLieu.Text = dataGridViewRow.Cells["Tên nguyên liệu"].Value.ToString();
                    DonGia.Text = dataGridViewRow.Cells["Đơn giá"].Value.ToString();
                    SoLuong.Text = dataGridViewRow.Cells["Đơn vị"].Value.ToString();
                    MessageBox.Show("Cập nhật thành công");
                }
                if (e.ColumnIndex == dataGridView1.Columns["del"].Index) // xóa
                {
                    if (DialogResult.OK == MessageBox.Show("Bạn có chắc chắn muốn xóa?", "Cảnh báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question))
                    {
                        collection.DeleteOne(Builders<BsonDocument>.Filter.Eq("ten", name));
                        MessageBox.Show("Đã xóa thành công!");
                        this.QLNL_Load(sender, e);
                    }
                }
            }
        }

        private int i = 0;

        private void btncf_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(TenNguyenLieu.Text) &&
                !string.IsNullOrEmpty(DonGia.Text) &&
                !string.IsNullOrEmpty(SoLuong.Text))
            {
                collection = connector.GetCollection<BsonDocument>("NguyenLieu");
                if (i == 1)// thêm
                {
                    var id = collection.Find(Builders<BsonDocument>.Filter.Empty).CountDocuments() + 1;
                    BsonDocument nl = new BsonDocument
                    {
                        {"ten",TenNguyenLieu.Text },
                        {"donvi",SoLuong.Text },
                        {"dongia",DonGia.Text }
                    };
                    collection.InsertOne(nl);
                }
                else// chỉnh sửa
                {
                    var filter = Builders<BsonDocument>.Filter.Eq("ten", name);
                    var condition = Builders<BsonDocument>.Update.Set("ten", TenNguyenLieu.Text)
                                                                 .Set("dongia", DonGia.Text)
                                                                 .Set("donvi", SoLuong.Text);
                    collection.UpdateOne(filter, condition);
                }
            }
            reset();
            btnthem.Visible = true;
            btncf.Visible = false;
            i = 0;
            this.QLNL_Load(sender, e);
            TenNguyenLieu.Visible = false; label2.Visible = false;
            SoLuong.Visible = false; label3.Visible = false;
            DonGia.Visible = false; label4.Visible = false;
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            i = 1;
            reset();
            btnthem.Visible = false;
            btncf.Visible = true;
        }

        private void TextChanged1(object sender, EventArgs e)
        {
            if (!int.TryParse(DonGia.Text, out var value) && DonGia.TextLength > 0)
            {
                DonGia.Text = DonGia.Text.Substring(0, DonGia.TextLength - 1);
                DonGia.SelectionStart = DonGia.TextLength;
            }
            if (!int.TryParse(SoLuong.Text, out var valu) && SoLuong.TextLength > 0)
            {
                SoLuong.Text = SoLuong.Text.Substring(0, SoLuong.TextLength - 1);
                SoLuong.SelectionStart = SoLuong.TextLength;
            }
        }
    }
}