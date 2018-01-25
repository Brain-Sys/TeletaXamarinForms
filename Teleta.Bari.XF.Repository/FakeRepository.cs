using System;
using System.Linq;
using System.Collections.Generic;

namespace Teleta.Bari.XF.Repository
{
    public static class FakeRepository
    {
        public static string ConnectionString { get; set; }

        static FakeRepository()
        {

        }

        public static List<Article> Read()
        {
            string filename = string.Concat(ConnectionString, "Teleta.db");
            var conn = new SQLite.SQLiteConnection(filename);

            var result = conn.Table<Article>().ToList();

            //Random rnd = new Random((int)DateTime.Now.Ticks);
            //List<Article> result = new List<Article>();

            //int count = rnd.Next(100, 500);
            //for (int i = 0; i < count; i++)
            //{
            //    Article a = new Article();
            //    a.ID = rnd.Next(1, 1000);
            //    a.Quantity = rnd.Next(87, 191);
            //    a.Name = string.Concat("Nome Art. ", a.ID);

            //    result.Add(a);
            //}

            return result;
        }

        public static bool Save(List<Article> articles)
        {
            string filename = string.Concat(ConnectionString, "Teleta.db");
            var conn = new SQLite.SQLiteConnection(filename);

            try
            {
                conn.CreateTable<Article>();
                conn.InsertAll(articles);
                //foreach (var item in articles)
                //{
                //    conn.Insert(item);
                //}
            }
            catch (Exception ex)
            {

            }

            conn.Close();
            conn.Dispose();
            conn = null;

            return true;
        }
    }
}