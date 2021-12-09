using System;
using System.Collections.Generic;
using System.Text;

namespace FeriaDesktop.Model
{

    
    public class Request : ViewModelBase
    {
        
        #region Atributes
      
        private int idSolicitudProductos;
        private int idUsuario;
        private int idTipoSolicitud;
        private int idEstadoSolicitud;
        private string fecha;
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
        public int IdTipoSolicitud
        {
            get
            {
                return idTipoSolicitud;
            }
            set
            {
                idTipoSolicitud = value;
                OnPropertyChanged("IdTipoSolicitud");
            }
        }
        public int IdEstadoSolicitud
        {
            get
            {
                return idEstadoSolicitud;
            }
            set
            {
                idEstadoSolicitud = value;
                OnPropertyChanged("IdEstadoSolicitud");
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


        #endregion
    }
}