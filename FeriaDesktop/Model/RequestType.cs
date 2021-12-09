using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Xml.Serialization;

namespace FeriaDesktop.Model
{
    public class RequestType : INotifyPropertyChanged
    {
        private int idTipoSol;
        private string descripcion;
        public int IdTipoSol
        {
            get
            {
                return idTipoSol;
            }
            set
            {
                idTipoSol = value;
                OnPropertyChanged("IdTipoSol");
            }
        }
        [XmlAttribute("Descripcion")]
        public string Descripcion
        {
            get
            {
                return descripcion;
            }
            set
            {
                descripcion = value;
                OnPropertyChanged("Descripcion");
            }
        }

        public void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        [field: NonSerialized]
        public event PropertyChangedEventHandler PropertyChanged;
    }
}

