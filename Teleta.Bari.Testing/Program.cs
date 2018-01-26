using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teleta.Bari.Reporting;
using Teleta.Bari.XF.Repository;

namespace Teleta.Bari.Testing
{
    class Program
    {
        static void Main(string[] args)
        {
            Article a = new Article();
            a.ID = 5654;
            a.Name = "Mouse bluetooth";
            a.Quantity = 981;

            string filename = @"c:\users\igord\desktop\articolo.pdf";
            Report.Print(a, filename);
        }
    }
}
