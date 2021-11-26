using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace FeriaDesktop
{
    public abstract class ViewModelBase : INotifyPropertyChanging, INotifyPropertyChanged
    {
        public event PropertyChangingEventHandler PropertyChanging;
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanging([CallerMemberName] string propertyName = "")
        {
            PropertyChanging(this, new PropertyChangingEventArgs(propertyName));
        }

        protected void OnPropertyChanged(string propertyName)
        {
           if(PropertyChanged != null)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }



}
