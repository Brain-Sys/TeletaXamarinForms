using System;
using System.Collections.Generic;
using System.Text;

namespace Teleta.Bari.ViewModels.Messages
{
    public class QuestionMessage : ShowMessage
    {
        public string Cancel { get; set; }

        public Action Yes { get; set; }
        public Action No { get; set; }
    }
}