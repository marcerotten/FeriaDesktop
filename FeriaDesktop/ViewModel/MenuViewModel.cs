﻿using FeriaDesktop.View;
using System.Windows.Input;

namespace FeriaDesktop.ViewModel
{
    public class MenuViewModel : ViewModelBase
    {
        
        private ICommand getUsersCommand { get; set; }
        private ICommand getContractsCommand { get; set; }
        private ICommand getRequestsCommand { get; set; }

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
            get { return getContractsCommand; }
            set
            {
                getContractsCommand = value;
            }
        }
        public ICommand GetRequestsCommand
        {
            get { return getRequestsCommand; }
            set
            {
                getRequestsCommand = value;
            }
        }

        public MenuViewModel()
        {
            GetUsersCommand = new RelayCommand(param => this.getUsers());
            GetContractsCommand = new RelayCommand(param => this.getContracts());
            GetRequestsCommand = new RelayCommand(param => this.getRequests());
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
        private void getRequests()
        {
            Requests win_menu = new Requests();
            win_menu.Show();
        }
    }

}

