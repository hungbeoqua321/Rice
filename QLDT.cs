    using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using ZstdSharp.Unsafe;

namespace Rice
{
    public partial class QLDT : Form
    {
        public QLDT()
        {
            InitializeComponent();
        }

        private MongoDBConnector connector = new MongoDBConnector();
        private IMongoCollection<BsonDocument> collection;

        private void QLDT_Load(object sender, EventArgs e)
        {
            collection = connector.GetCollection<BsonDocument>("HoaDon");

            //
            // Bảng thoe ngày
            //

            var pipeline = new BsonDocument[]
            {
                new BsonDocument("$group", new BsonDocument
                {
                    { "_id", new BsonDocument("$dayOfMonth", new BsonDocument("$dateFromString", new BsonDocument
                        {
                            { "dateString", "$ngaymua" },
                            { "format", "%d/%m/%Y" }
                        }))
                    },
                    { "tongTien", new BsonDocument("$sum", "$tongtien") }
                })
            };

            var aggregationOptions = new AggregateOptions { AllowDiskUse = true };

            var results = collection.Aggregate<BsonDocument>(pipeline, aggregationOptions).ToList();

            DataTable dt = new DataTable();

            dt.Columns.Add("Ngày");
            dt.Columns.Add("Tổng tiền");

            foreach (var result in results)
            {
                var row = dt.NewRow();
                row[0] = result["_id"];
                row[1] = result["tongTien"];
                dt.Rows.Add(row);
            }

            dataGridView1.DataSource = dt;

            //
            // Bảng theo Tháng
            //
            pipeline = new BsonDocument[]
            {
                new BsonDocument("$group", new BsonDocument
                {
                    { "_id", new BsonDocument("$month", new BsonDocument("$dateFromString", new BsonDocument
                        {
                            { "dateString", "$ngaymua" },
                            { "format", "%d/%m/%Y" }
                        }))
                    },
                    { "tongTien", new BsonDocument("$sum", "$tongtien") }
                })
            };

            aggregationOptions = new AggregateOptions { AllowDiskUse = true };

            results = collection.Aggregate<BsonDocument>(pipeline, aggregationOptions).ToList();

            dt = new DataTable();

            dt.Columns.Add("Tháng");
            dt.Columns.Add("Tổng tiền");

            foreach (var result in results)
            {
                var row = dt.NewRow();
                row[0] = result["_id"];
                row[1] = result["tongTien"];
                dt.Rows.Add(row);
            }

            dataGridView2.DataSource = dt;

            //
            // Theo năm bảng 3
            //

            pipeline = new BsonDocument[]
            {
                new BsonDocument("$group", new BsonDocument
                {
                    { "_id", new BsonDocument("$year", new BsonDocument("$dateFromString", new BsonDocument
                        {
                            { "dateString", "$ngaymua" },
                            { "format", "%d/%m/%Y" }
                        }))
                    },
                    { "tongTien", new BsonDocument("$sum", "$tongtien") }
                })
            };

            aggregationOptions = new AggregateOptions { AllowDiskUse = true };

            results = collection.Aggregate<BsonDocument>(pipeline, aggregationOptions).ToList();

            dt = new DataTable();

            dt.Columns.Add("Năm");
            dt.Columns.Add("Tổng tiền");

            foreach (var result in results)
            {
                var row = dt.NewRow();
                row[0] = result["_id"];
                row[1] = result["tongTien"];
                dt.Rows.Add(row);
            }

            dataGridView3.DataSource = dt;
        }

        private void update_Click(object sender, EventArgs e)
        {
            this.QLDT_Load(sender, e);
        }

        private void QLDT_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}