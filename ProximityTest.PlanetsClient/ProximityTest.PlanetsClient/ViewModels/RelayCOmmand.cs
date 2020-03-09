using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace ProximityTest.PlanetsClient.ViewModels
{
    public class RelayCommand : ICommand
    {
        private Action myAction;

        public event EventHandler CanExecuteChanged = (sender, e) => { };

        public RelayCommand(Action action)
        {
            myAction = action;
        }

        public bool CanExecute(object parameter) => true;

        public void Execute(object parameter) => myAction();
    }
}
