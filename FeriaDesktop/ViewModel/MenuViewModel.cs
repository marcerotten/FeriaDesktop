using FeriaDesktop.Commands;
using FeriaDesktop.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;

namespace FeriaDesktop.ViewModel
{
    public class MenuViewModel : ViewModelBase
    {
        
        private ICommand getClientsCommand { get; set; }

        public ICommand GetClientsCommand
        {
            get { return getClientsCommand; }
            set
            {
                getClientsCommand = value;
            }
        }

        public MenuViewModel()
        {
            GetClientsCommand = new RelayCommand(param => this.getClients());
        }

        private void getClients()
        {
            Clients win_menu = new Clients();
            win_menu.Show();
        }
    }

}

