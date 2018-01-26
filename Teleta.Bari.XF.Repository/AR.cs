using System;
using System.Collections.Generic;
using System.Text;

namespace Teleta.Bari.XF.Repository
{
    public class AR
    {
        public string cdar { get; set; }

        public string ar_descrizione { get; set; }
        public bool matricola_obbligatoria { get; set; }
        public bool lotto_obbligatorio { get; set; }
        public string cdum { get; set; }
        public double peso_lordo { get; set; }
        public double peso_netto { get; set; }
        public double volume { get; set; }
        public bool is_obsoleto { get; set; }
    }
}