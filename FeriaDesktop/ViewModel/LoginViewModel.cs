using FeriaDesktop.Services;
using log4net;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Windows.Input;

namespace FeriaDesktop.ViewModel
{
    public class LoginViewModel : ViewModelBase
    {
        #region Atributos
        private string user;
        private string password;
        private ICommand getInCommand;

        #endregion

        #region Propiedades

        [Required(ErrorMessage = "No debe ir vacío")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Ingrese al menos 5 carácteres")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail no valido")]
        public string User
        {
            get
            {
                return user;
            }
            set
            {
                ValidateProperty(value, "User");
                user = value;
                OnPropertyChanged("User");
            }
        }

        [Required(ErrorMessage = "No debe ir vacío")]
        [StringLength(50, MinimumLength = 4, ErrorMessage = "Ingrese al menos 4 carácteres")]
        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                ValidateProperty(value, "Password");
                password = value;
                OnPropertyChanged("Password");
            }
        }

        public ICommand GetInCommand
        {
            get
            {
                if (getInCommand == null)
                {
                    getInCommand = new RelayCommand(param => this.GetInCommandExecute(), null);
                }
                return getInCommand;

            }
            set
            {
                getInCommand = value;
            }
        }

        private void GetInCommandExecute()
        {

            var loginService = new LoginService();
            loginService.GetLogin(user,password);


        }
        #endregion

        #region Constructores
        
       
        public LoginViewModel()
        {
            
        }
         
        #endregion

        #region Interface
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion

        #region Metodos/Funciones

        private void ValidateProperty<T>(T value, string name)
        {
            Validator.ValidateProperty(value, new ValidationContext(this, null, null)
            {
                MemberName = name
            });
        }
        
        #endregion
    }
}
