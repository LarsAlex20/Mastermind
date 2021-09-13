using Mastermind.Commands;

namespace Mastermind.ViewModels
{
    public class MainViewModel : AViewModel
    {
        private AViewModel _selectedViewModel;

        public AViewModel SelectedViewModel
        {
            get { return _selectedViewModel; }
            set
            {
                _selectedViewModel = value;
                OnPropertyChanged(nameof(SelectedViewModel));
            }
        }
        public UpdateViewCommand UpdateViewCommand { get; set; }

        public MainViewModel()
        {
            UpdateViewCommand = new UpdateViewCommand(this, Data);

        }
    }
}
