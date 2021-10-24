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

        public ICommand GetUsersCommand
        {
            get { return getUsersCommand; }
            set
            {
                getUsersCommand = value;
            }
        }

        public MenuViewModel()
        {
            GetUsersCommand = new RelayCommand(param => this.getUsers());
        }

        private void getUsers()
        {
            Users win_menu = new Users();
            win_menu.Show();
        }
    }

}

