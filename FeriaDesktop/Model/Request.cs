using System;
using System.Collections.Generic;
using System.Text;

namespace FeriaDesktop.Model
{

    
    public class Request : ViewModelBase
    {
        
        #region Atributes
      
        private int idSolicitudProductos;
        private string nombre;
        private string apPaterno;
        private string dni;
        private RequestType solicitud;
        private int solTypeId;
        private string solName;
        private string estado;
        private string fecha;
        private int cantidad;
        private int idUsuario;
        #endregion

        #region Properties
        public int IdSolicitudProductos
        {
            get
            {
                return idSolicitudProductos;
            }
            set
            {
                idSolicitudProductos = value;
                OnPropertyChanged("IdSolicitudProductos");
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
        public RequestType Solicitud
        {
            get
            {
                return solicitud;
            }
            set
            {
                solicitud = value;
                OnPropertyChanged("Solicitud");
            }
        }
        public int SolTypeId
        {
            get
            {
                return solTypeId;
            }
            set
            {
                solTypeId = value;
                OnPropertyChanged("SolTypeId");
            }
        }public string SolName
        {
            get
            {
                return solName;
            }
            set
            {
                solName = value;
                OnPropertyChanged("SolName");
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
            }
        }
        
        public int Cantidad
        {
            get
            {
                return cantidad;
            }
            set
            {
                cantidad = value;
                OnPropertyChanged("Cantidad");
            }
        }
       
        public string Fecha
        {
            get
            {
                return fecha;
            }
            set
            {
                fecha = value;
                OnPropertyChanged("Fecha");
            }
        }

        public int IdUsuario
        {
            get
            {
                return idUsuario;
            }
            set
            {
                idUsuario = value;
                OnPropertyChanged("idUsuario");
            }
        }

        #endregion
    }
}