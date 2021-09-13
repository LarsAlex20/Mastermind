using Mastermind.Models;
using System;
using System.Windows.Input;

namespace Mastermind.Commands
{
    public class ExecuteCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        private Action _execute;
        private InputModel Model;
        public ExecuteCommand(Action execute, InputModel model)
        {
            _execute = execute;
            Model = model;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            Model.CommandParameter = Convert.ToInt32(parameter.ToString());
            _execute.Invoke();
        }
    }
}
