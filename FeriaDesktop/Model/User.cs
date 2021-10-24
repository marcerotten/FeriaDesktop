namespace FeriaDesktop.Model
{
    public class User : ViewModelBase
    {
        public int idUsuario { get; set; }
        public string nombre { get; set; }
        public string apPaterno { get; set; }
        public string apMaterno { get; set; }
        public string dni { get; set; }
        public string direccion { get; set; }
        public string codPostal { get; set; }
        public string correo { get; set; }
        public string usuario { get; set; }
        public string contrasena { get; set; }
        public int idPais { get; set; }
        public int idRol { get; set; }
        public int idEstado { get; set; }
        public int terminosCondiciones { get; set; }
    }

    public class User_info : ViewModelBase
    {
        #region Atributes
        private int idUsuario;
        private string nombre;
        private string apPaterno;
        private string apMaterno;
        private string dni;
        private string direccion;
        private string codPostal;
        private string correo;
        private string pais;
        private string rol;
        private string estado;
        private int terminosCondiciones;
        #endregion

        public int IdUsuario
        {
            get
            {
                return idUsuario;
            }
            set
            {
                idUsuario = value;
                OnPropertyChanged("IdUsuario");
                OnPropertyChanged("DisplayName");
            }
        }
        public string Nombre
        {
            get
            {
                return nombre;
            }
            set
            {
                nombre = value;
                OnPropertyChanged("Nombre");
                OnPropertyChanged("DisplayName");
            }
        }
        public string ApPaterno
        {
            get
            {
                return apPaterno;
            }
            set
            {
                apPaterno = value;
                OnPropertyChanged("ApPaterno");
                OnPropertyChanged("DisplayName");
            }
        }
        public string ApMaterno
        {
            get
            {
                return apMaterno;
            }
            set
            {
                apMaterno = value;
                OnPropertyChanged("ApMaterno");
                OnPropertyChanged("DisplayName");
            }
        }
        public string Dni
        {
            get
            {
                return dni;
            }
            set
            {
                dni = value;
                OnPropertyChanged("Dni");
                OnPropertyChanged("DisplayName");
            }
        }
        public string Direccion
        {
            get
            {
                return direccion;
            }
            set
            {
                direccion = value;
                OnPropertyChanged("Direccion");
                OnPropertyChanged("DisplayName");
            }
        }
        public string CodPostal
        {
            get
            {
                return codPostal;
            }
            set
            {
                codPostal = value;
                OnPropertyChanged("CodPostal");
                OnPropertyChanged("DisplayName");
            }
        }
        public string Correo
        {
            get
            {
                return correo;
            }
            set
            {
                correo = value;
                OnPropertyChanged("Correo");
                OnPropertyChanged("DisplayName");
            }
        }
        public string Pais
        {
            get
            {
                return pais;
            }
            set
            {
                pais = value;
                OnPropertyChanged("Pais");
                OnPropertyChanged("DisplayName");
            }
        }
        public string Rol
        {
            get
            {
                return rol;
            }
            set
            {
                rol = value;
                OnPropertyChanged("Rol");
                OnPropertyChanged("DisplayName");
            }
        }
        public string Estado
        {
            get
            {
                return estado;
            }
            set
            {
                estado = value;
                OnPropertyChanged("Estado");
                OnPropertyChanged("DisplayName");
            }
        }
        public int Terms
        {
            get
            {
                return terminosCondiciones;
            }
            set
            {
                terminosCondiciones = value;
                OnPropertyChanged("Terms");
                OnPropertyChanged("DisplayName");
            }
        }
    }
}
