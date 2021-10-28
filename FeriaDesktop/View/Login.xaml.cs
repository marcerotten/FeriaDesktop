using FeriaDesktop.ViewModel;
using System.Windows;

namespace FeriaDesktop.View
{
    /// <summary>
    /// Lógica de interacción para Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
            DataContext = new LoginViewModel();
        }
    }
}
