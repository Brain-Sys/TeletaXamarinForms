using System;
using System.Collections.Generic;
using System.Text;

namespace Teleta.Bari.ViewModels.Messages
{
    public class ShowMessage
    {
        public string Title { get; set; }
        public string Text { get; set; }
        public string Ok { get; set; } = "OK";
    }
}