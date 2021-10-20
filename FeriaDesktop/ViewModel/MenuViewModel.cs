using FeriaDesktop.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;

namespace FeriaDesktop.ViewModel
{
    public class MenuViewModel : ViewModelBase
    {
        private ViewModelBase _selectedViewModel;

        public ViewModelBase SelectedViewModel
        {
            get { return _selectedViewModel; }
            set
            {
                _selectedViewModel = value;
                OnPropertyChanged(nameof(SelectedViewModel));
            }
        }

            public ICommand ShowClientsCommand { get; set; }
            
            public MenuViewModel()
        {
            ShowClientsCommand = new ShowClientsCommand(this);
        }
        }

    }

