using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CollectionViewInScrollView
{
    public class ListViewAutoFitContentViewModel : INotifyPropertyChanged
    {
        public ListViewAutoFitContentViewModel()
        {
            var images = new List<string>
            {
                "path",
                "thinking",
                "time",
                "thinking",
                "path",
                "time",
                "path",
                "thinking",
                "time",
                "thinking",
                "path",
                "time",
                "path",
                "thinking",
                "time",
                "thinking",
                "path",
                "time",
                "path",
                "thinking",
                "time",
                "thinking",
                "path",
                "time",
                "path",
                "thinking",
                "time",
                "thinking",
                "path",
                "time",
            };
            _images = new ObservableCollection<string>(images);
        }

  

        private ObservableCollection<string> _images;
        public ObservableCollection<string> Images
        {
            get { return _images; }
            set { this._images = value; }
        }

        #region Interface Member

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string name)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(name));
        }

        #endregion
    }
}
