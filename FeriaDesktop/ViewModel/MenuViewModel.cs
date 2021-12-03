using FeriaDesktop.View;
using System.Windows.Input;

namespace FeriaDesktop.ViewModel
{
    public class MenuViewModel : ViewModelBase
    {
        
        private ICommand getUsersCommand { get; set; }
        private ICommand getContractsCommand { get; set; }
        private ICommand getRequestsCommand { get; set; }
        private ICommand getSalesDataCommand { get; set; }

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

        public ICommand GetSalesDataCommand
        {
            get { return getSalesDataCommand; }
            set
            {
                getSalesDataCommand = value;
            }
        }

        public MenuViewModel()
        {
            GetUsersCommand = new RelayCommand(param => this.getUsers());
            GetContractsCommand = new RelayCommand(param => this.getContracts());
            GetRequestsCommand = new RelayCommand(param => this.getRequests());
            GetSalesDataCommand = new RelayCommand(param => this.getSalesDatas());
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

        private void getSalesDatas()
        {
            SalesData win_menu = new SalesData();
            win_menu.Show();
        }
    }

}

