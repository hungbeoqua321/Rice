using MongoDB.Driver;
using System;
using System.Windows.Forms;

namespace Rice
{
    public class MongoDBConnector
    {
        private IMongoDatabase database;
        private MongoClient client;

        public MongoDBConnector()
        {
            client = new MongoClient("mongodb+srv://comngon:123@rice.nhtnqnj.mongodb.net/");
            database = client.GetDatabase("Rice");
        }

        public IMongoCollection<T> GetCollection<T>(string collectionName)
        {
            return database.GetCollection<T>(collectionName);
        }
    }

    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Home());
        }
    }
}