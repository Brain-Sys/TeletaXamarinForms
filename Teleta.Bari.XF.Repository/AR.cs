using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Teleta.Bari.XF.Repository
{
    public class Articolo
    {
        [JsonProperty("cdar")]
        public string CodiceArticolo { get; set; }

        [JsonProperty("ar_descrizione")]
        public string Descrizione { get; set; }
        public bool matricola_obbligatoria { get; set; }

        [JsonProperty("lotto_obbligatorio")]
        public bool LottoObbligatorio { get; set; }
        public string cdum { get; set; }
        public double peso_lordo { get; set; }
        public double peso_netto { get; set; }
        public double volume { get; set; }
        public bool is_obsoleto { get; set; }
    }
}