namespace FeriaDesktop.Model
{
    public class User
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

    public class User_info
    {
        public string nombre { get; set; }
        public string apPaterno { get; set; }
        public string apMaterno { get; set; }
        public string dni { get; set; }
        public string direccion { get; set; }
        public string codPostal { get; set; }
        public string correo { get; set; }
        public int idPais { get; set; }
        public int idRol { get; set; }
        public int idEstado { get; set; }
        public int terminosCondiciones { get; set; }
    }
}
