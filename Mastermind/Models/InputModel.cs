using System.Collections.Generic;
using System.ComponentModel;

namespace Mastermind.Models
{
    public class InputModel : INotifyPropertyChanged
    {
        private int _inputVersuche;
        public int InputVersuche
        {
            get { return _inputVersuche; }
            set
            {
                _inputVersuche = value;
                OnPropertyChanged("InputVersuche");
            }
        }

        private int _inputFarben;
        public int InputFarben
        {
            get { return _inputFarben; }
            set
            {
                _inputFarben = value;
                OnPropertyChanged("InputFarben");
            }
        }

        private int _commandParameter;
        public int CommandParameter
        {
            get { return _commandParameter; }
            set
            {
                _commandParameter = value;
                OnPropertyChanged("CommandParameter");
            }
        }

        private string _error;
        public string Error
        {
            get { return _error; }
            set
            {
                _error = value;
                OnPropertyChanged("Error");
            }
        }

        private int _inputCodeLaenge;
        public int InputCodeLaenge
        {
            get { return _inputCodeLaenge; }
            set
            {
                _inputCodeLaenge = value;
                OnPropertyChanged("InputCodeLaenge");
            }
        }
        public List<Farbpin> Code = new List<Farbpin>();
        public InputModel()
        {
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;

            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
