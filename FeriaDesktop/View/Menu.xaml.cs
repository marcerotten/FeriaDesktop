using FeriaDesktop.ViewModel;
using System.Windows;

namespace FeriaDesktop.View
{
    /// <summary>
    /// Lógica de interacción para Menu.xaml
    /// </summary>
    public partial class Menu : Window
    {
        public Menu()
        {
            InitializeComponent();
            DataContext = new MenuViewModel();
          
        }
    }
}
