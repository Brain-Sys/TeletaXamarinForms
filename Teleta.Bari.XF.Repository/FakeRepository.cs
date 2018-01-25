using System;
using System.Collections.Generic;

namespace Teleta.Bari.XF.Repository
{
    public class FakeRepository
    {
        public List<Article> Read()
        {
            Random rnd = new Random((int)DateTime.Now.Ticks);
            List<Article> result = new List<Article>();

            int count = rnd.Next(100, 500);
            for (int i = 0; i < count; i++)
            {
                Article a = new Article();
                a.ID = rnd.Next(1, 1000);
                a.Quantity = rnd.Next(87, 191);
                a.Name = string.Concat("Nome Art. ", a.ID);

                result.Add(a);
            }

            return result;
        }

        public bool Save(List<Article> articles)
        {
            //IPath path = DependencyService.Get<IPath>();
            //var conn = new SQLite.SQLiteConnection(path.GetLocalPath());
            //conn.CreateTable<Article>();

            //foreach (var item in articles)
            //{
            //    conn.Insert(item);
            //}

            //conn.Close();
            //conn.Dispose();
            //conn = null;

            return true;
        }
    }
}