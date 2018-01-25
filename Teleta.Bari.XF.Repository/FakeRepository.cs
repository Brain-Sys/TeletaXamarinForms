using System;
using System.Linq;
using System.Collections.Generic;

namespace Teleta.Bari.XF.Repository
{
    public static class FakeRepository
    {
        private static SQLite.SQLiteConnection conn;
        public static string ConnectionString { get; set; }

        static FakeRepository() { }

        public static void StartDb()
        {
            string filename = string.Concat(ConnectionString, "Teleta.db");
            conn = new SQLite.SQLiteConnection(filename);
            conn.Tracer = controlloSql;
            conn.Trace = true;
            conn.CreateTable<Article>();
        }

        public static List<Article> Read()
        {
            var result = conn.Table<Article>().ToList();

            var proiezioneArticoli = conn.Table<Article>().Select(a => new SmallArticle
            {
                id = a.ID,
                quantita_a_magazzino = a.Quantity
            });

            //var result = new List<Article>();

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
            try
            {
                foreach (var item in articles)
                {
                    if (item.ID == 0)
                    {
                        conn.Insert(item);
                    }
                    else
                    {
                        conn.Update(item);
                    }
                }
            }
            catch (Exception ex)
            {

            }

            conn.Close();
            conn.Dispose();
            conn = null;

            return true;
        }

        private static void controlloSql(string sql)
        {
            System.Diagnostics.Debug.WriteLine(sql);
        }
    }
}