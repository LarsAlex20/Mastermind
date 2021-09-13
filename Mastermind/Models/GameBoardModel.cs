using System.ComponentModel;

namespace Mastermind.Models
{
    public class GameBoardModel : INotifyPropertyChanged
    {
        //Variable für die Farben der Pins auf dem Spielbrett.
        private BindableTwoDArray<string> _PinColors;
        public BindableTwoDArray<string> PinColors
        {
            get { return _PinColors; }
            set
            {
                _PinColors = value;
                OnPropertyChanged("PinColors");
            }
        }

        //Variable für die Farben der Kontrollpins auf dem Spielbrett.
        private BindableTwoDArray<string> _CheckPinColors;
        public BindableTwoDArray<string> CheckPinColors
        {
            get { return _CheckPinColors; }
            set
            {
                _CheckPinColors = value;
                OnPropertyChanged("CheckPinColors");
            }
        }

        //Variable um die Sichtbarkeit der Farbpins zu steuern.
        private BindableTwoDArray<string> _ColorPinVisibility;
        public BindableTwoDArray<string> ColorPinVisibility
        {
            get { return _ColorPinVisibility; }
            set
            {
                _ColorPinVisibility = value;
                OnPropertyChanged("ColorPinVisibility");
            }
        }

        //Variable um die Sichtbarkeit des GameOver-Screens zu steuern.
        private string _gameOverVisibility;
        public string GameOverVisibility
        {
            get { return _gameOverVisibility; }
            set
            {
                _gameOverVisibility = value;
                OnPropertyChanged("GameOverVisibility");
            }
        }

        //Variable um die Sichtbarkeit des Victory-Screens zu steuern.
        private string _victoryVisibility;
        public string VictoryVisibility
        {
            get { return _victoryVisibility; }
            set
            {
                _victoryVisibility = value;
                OnPropertyChanged("VictoryVisibility");
            }
        }

        //Variable um die Sichtbarkeit des Screens für einen Code aus 4 Pins zu steuern.
        private string _code4Visibility;
        public string Code4Visibility
        {
            get { return _code4Visibility; }
            set
            {
                _code4Visibility = value;
                OnPropertyChanged("Code4Visibility");
            }
        }

        //Variable um die Sichtbarkeit des Screens für einen Code aus 5 Pins zu steuern.
        private string _code5Visibility;
        public string Code5Visibility
        {
            get { return _code5Visibility; }
            set
            {
                _code5Visibility = value;
                OnPropertyChanged("Code5Visibility");
            }
        }

        private string _try;
        public string Try
        {
            get { return _try; }
            set
            {
                _try = value;
                OnPropertyChanged("Try");
            }
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
