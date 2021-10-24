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
        
        private ICommand getUsersCommand { get; set; }
        private ICommand geContractsCommand { get; set; }

        public ICommand GetUsersCommand
        {
            get { return getUsersCommand; }
            set
            {
                getUsersCommand = value;
            }
        }
        public ICommand GetContractsCommand
        {
            get { return geContractsCommand; }
            set
            {
                geContractsCommand = value;
            }
        }

        public MenuViewModel()
        {
            GetUsersCommand = new RelayCommand(param => this.getUsers());
            GetContractsCommand = new RelayCommand(param => this.getContracts());
        }

        private void getUsers()
        {
            Users win_menu = new Users();
            win_menu.Show();
        }
        private void getContracts()
        {
            Contracts win_menu = new Contracts();
            win_menu.Show();
        }
    }

}

