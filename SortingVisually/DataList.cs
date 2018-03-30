using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Media;
using System.ComponentModel;

namespace SortingVisually
{


    class DataList : INotifyPropertyChanged
    {
        private int number;
        public int Number
        {
            get {return number; }
            set
            {
                if (value == number) return;
                number = value;
                OnPropertyChanged(nameof(Number));
            }
        }

        private Brush myColor;
        public Brush MyColor
        {
            get { return myColor; }
            set
            {
                if (value == myColor) return;
                myColor = value;
                OnPropertyChanged(nameof(MyColor));
            }
        }

        public DataList(int number, Brush myColor)
        {
            Number = number;
            MyColor = myColor;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        internal void OnPropertyChanged(string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
