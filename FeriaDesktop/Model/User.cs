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
        private string usuario;
        private string paisName;
        private Country pais;
        private string rolName;
        private Role rol;
        private string estadoName;
        private Status estado;
        private string terms;
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
            }
        }
        public string Usuario
        {
            get
            {
                return usuario;
            }
            set
            {
                usuario = value;
                OnPropertyChanged("Usuario");
            }
        }
        public string PaisName
        {
            get
            {
                return paisName;
            }
            set
            {
                paisName = value;
                OnPropertyChanged("PaisName");
            }
        }
        public Country Pais
        {
            get
            {
                return pais;
            }
            set
            {
                pais = value;
                OnPropertyChanged("Pais");
            }
        }
        public string RolName
        {
            get
            {
                return rolName;
            }
            set
            {
                rolName = value;
                OnPropertyChanged("RolName");
            }
        }

        public Role Rol
        {
            get
            {
                return rol;
            }
            set
            {
                rol = value;
                OnPropertyChanged("Rol");
            }
        }
        public string EstadoName
        {
            get
            {
                return estadoName;
            }
            set
            {
                estadoName = value;
                OnPropertyChanged("EstadoName");
            }
        }
        public Status Estado
        {
            get
            {
                return estado;
            }
            set
            {
                estado = value;
                OnPropertyChanged("Estado");
            }
        }
        public string Terms
        {
            get
            {
                return terms;
            }
            set
            {
                terms = value;
                OnPropertyChanged("Terms");
            }
        }
    }


}
