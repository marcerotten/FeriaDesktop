using FeriaDesktop.ViewModel;
using log4net;
using System.Linq;
using System.Reflection;
using System.Windows;

namespace FeriaDesktop.View
{
    /// <summary>
    /// Lógica de interacción para Menu.xaml
    /// </summary>
    public partial class Menu : Window
    {
        public ILog Logger { get; set; }
        public Menu()
        {
            InitializeComponent();
            DataContext = new MenuViewModel();

            InitializeComponent();

            this.Logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
            log4net.Config.XmlConfigurator.Configure();

            this.Logger.Info("Inicio de la app - Menú");
        }
    }
}
