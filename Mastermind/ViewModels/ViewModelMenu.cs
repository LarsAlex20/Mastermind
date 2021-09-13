using Mastermind.Commands;
using Mastermind.Models;
using System.Collections.ObjectModel;

namespace Mastermind.ViewModels
{
    public class ViewModelMenu : AViewModel
    {
        public ObservableCollection<int> List_Versuche { get; }
        public ObservableCollection<int> List_Farben { get; }
        public ObservableCollection<string> List_Ratender { get; }
        public ObservableCollection<int> List_CodeLaenge { get; }
        public InputModel model { get; set; }


        public ViewModelMenu(InputModel Model)
        {
            List_Versuche = new ObservableCollection<int>() { 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };
            List_Farben = new ObservableCollection<int>() { 6, 7, 8 };
            List_Ratender = new ObservableCollection<string>() { "Sie", "Computer" };
            List_CodeLaenge = new ObservableCollection<int>() { 4, 5 };
            model = Model;
        }
        public ViewModelMenu()
        {
            List_Versuche = new ObservableCollection<int>() { 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };
            List_Farben = new ObservableCollection<int>() { 6, 7, 8 };
            List_Ratender = new ObservableCollection<string>() { "Sie", "Computer" };
            List_CodeLaenge = new ObservableCollection<int>() { 4, 5 };
            model = new InputModel();
        }
    }
}
