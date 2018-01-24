using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Teleta.Bari.XF.Repository
{
    public class Article : INotifyPropertyChanged
    {
        public int ID { get; set; }

        private double quantity;
        public double Quantity
        {
            get { return quantity; }
            set { quantity = value;
                if (this.PropertyChanged != null)
                {
                    this.PropertyChanged(this, new PropertyChangedEventArgs(nameof(Quantity)));
                }
            }
        }

        private string name;
        public string Name
        {
            get { return name; }
            set { name = value;

                if (this.PropertyChanged != null)
                {
                    this.PropertyChanged(this, new PropertyChangedEventArgs(nameof(Name)));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public override string ToString()
        {
            return Name;
        }
    }
}