using FeriaDesktop.ViewModel;
using System;
using System.Windows.Input;

namespace FeriaDesktop.Commands
{
    public class ShowClientsCommand : ICommand
    {
        private MenuViewModel viewModel;

        public ShowClientsCommand(MenuViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            Console.WriteLine("dasdasdas");
            if(parameter.ToString() == "Clients")
            {
                viewModel.SelectedViewModel = new ClientsViewModel();
            }
        }
    }
}
