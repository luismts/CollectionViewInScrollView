
using System;
using System.Linq;
using Xamarin.Forms;

namespace CollectionViewInScrollView.Controls
{
    public class GoodCollectionView : CollectionView
    {
        private View _customHeader, _secondContent;

        public GoodCollectionView()
        {
            Scrolled += GoodCollectionView_Scrolled;
        }

        [TypeConverter(typeof(ReferenceTypeConverter))]
        public View CustomHeader
        {
            set
            {
                _customHeader = value;
                _customHeader.SizeChanged += (o, e) => this.Header = new BoxView() { HeightRequest = _customHeader.Height };                
            }
        }

        [TypeConverter(typeof(ReferenceTypeConverter))]
        public View SecondContent
        {
            set => _secondContent = value;
        }

        private async void GoodCollectionView_Scrolled(object sender, ItemsViewScrolledEventArgs e)
        {
            double scrollY = e.VerticalOffset < 0 ? 0 : e.VerticalOffset;
            scrollY = scrollY > _customHeader.Height ? _customHeader.Height : scrollY;
            
            //Show or hide the header
            await _customHeader?.TranslateTo(0, -scrollY, 50);

            var viewMarging = _secondContent.Margin;
            _secondContent.Margin = new Thickness(viewMarging.Left, -scrollY + _customHeader.Height, viewMarging.Right, viewMarging.Bottom);
        }
    }
}
