using Mastermind.Models;
using System.ComponentModel;

namespace Mastermind.ViewModels
{
    public class AViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public static InputModel Data = new InputModel();



    }
}
