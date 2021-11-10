using System;
using System.ComponentModel;
using System.Xml.Serialization;

namespace FeriaDesktop.Model
{
    public class Role : INotifyPropertyChanged
    {
        private int idRol;
        private string descripcion;
        public int IdRol
        {
            get
            {
                return idRol;
            }
            set
            {
                idRol = value;
                OnPropertyChanged("IdRol");
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
