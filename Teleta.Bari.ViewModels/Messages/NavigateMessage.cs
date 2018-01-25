using System;
using System.Collections.Generic;
using System.Text;
using Teleta.Bari.XF.Repository;

namespace Teleta.Bari.ViewModels.Messages
{
    public class NavigateMessage
    {
        public string DestinationPage { get; set; }
        public object Parameter { get; set; }

        public NavigateMessage(string page)
        {
            DestinationPage = page;
        }
    }
}