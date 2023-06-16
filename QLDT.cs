using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Windows.Forms;

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

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void QLDT_Load(object sender, EventArgs e)
        {
            collection = connector.GetCollection<BsonDocument>("DoanhThu");

        }
    }
}