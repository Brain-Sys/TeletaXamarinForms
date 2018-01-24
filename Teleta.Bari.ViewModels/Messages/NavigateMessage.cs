using System;
using System.Collections.Generic;
using System.Text;

namespace Teleta.Bari.ViewModels.Messages
{
    public class NavigateMessage
    {
        public string DestinationPage { get; set; }

        public NavigateMessage(string page)
        {
            DestinationPage = page;
        }
    }
}