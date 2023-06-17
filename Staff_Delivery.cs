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
        private void Capnhat_Click(object sender, EventArgs e)
        {
            Staff_Delivery_Load(sender, e);
        }

        private void Staff_Delivery_Load(object sender, EventArgs e)
        {

        }
    }
}
