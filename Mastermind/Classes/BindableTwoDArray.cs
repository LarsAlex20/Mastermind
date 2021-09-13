using System;
using System.ComponentModel;
using System.Windows.Data;

namespace Mastermind.Models
{
    public class BindableTwoDArray<T> : INotifyPropertyChanged
    {
        // Mit dieser Klasse wird das Binding mit einem zweidimensionalen Array ermöglicht, da man das Zeichen im Binding (beispielsweise "Array[1-1]") zu einem normalen Array machen kann.
        public event PropertyChangedEventHandler PropertyChanged;
        private void Notify(string property)
        {
            var pc = PropertyChanged;
            if (pc != null)
                pc(this, new PropertyChangedEventArgs(property));
        }

        T[,] data;

        public T this[int c1, int c2]
        {
            get { return data[c1, c2]; }
            set
            {
                data[c1, c2] = value;
                Notify(Binding.IndexerName);
            }
        }

        public string GetStringIndex(int c1, int c2)
        {
            return c1.ToString() + "-" + c2.ToString();
        }

        private void SplitIndex(string index, out int c1, out int c2)
        {
            var parts = index.Split('-');
            if (parts.Length != 2)
                throw new ArgumentException("The provided index is not valid");

            c1 = int.Parse(parts[0]);
            c2 = int.Parse(parts[1]);
        }

        public T this[string index]
        {
            get
            {
                int c1, c2;
                SplitIndex(index, out c1, out c2);
                return data[c1, c2];
            }
            set
            {
                int c1, c2;
                SplitIndex(index, out c1, out c2);
                data[c1, c2] = value;
                Notify(Binding.IndexerName);
            }
        }

        public BindableTwoDArray(int size1, int size2)
        {
            data = new T[size1, size2];
        }

        public static implicit operator T[,](BindableTwoDArray<T> a)
        {
            return a.data;
        }
    }
}
