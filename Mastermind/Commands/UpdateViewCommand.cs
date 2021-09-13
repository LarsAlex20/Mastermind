using Mastermind.Models;
using Mastermind.ViewModels;
using System;
using System.Windows.Input;

namespace Mastermind.Commands
{
    public class UpdateViewCommand : ICommand
    {
        // Dieser Command ist dafür da, die Views und die entsprechenden ViewModels zu wecheseln. Genaueres in der Datei "App.xaml".
        private MainViewModel viewModel;
        private InputModel Model;

        public UpdateViewCommand(MainViewModel viewModel, InputModel model)
        {
            this.viewModel = viewModel;
            Model = model;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (parameter.ToString() == "Spielbrett")
            {
                if (Model.InputFarben != 0)
                {
                    viewModel.SelectedViewModel = new ViewModelGameBoard();
                }
                else
                {
                    Model.Error = "Bitte geben Sie die fehlenden Daten ein";
                    viewModel.SelectedViewModel = new ViewModelMenu(Model);

                }

            }
            else if (parameter.ToString() == "Menue")
            {
                viewModel.SelectedViewModel = new ViewModelMenu(Model);
            }
        }
    }
}
