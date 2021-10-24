using System;
using System.ComponentModel;
using System.Xml.Serialization;

namespace FeriaDesktop.Model
{
    public class Status : INotifyPropertyChanged
    {
        private int idEstado;
        private string descripcion;
        public int IdEstado
        {
            get
            {
                return idEstado;
            }
            set
            {
                idEstado = value;
                OnPropertyChanged("IdEstado");
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
