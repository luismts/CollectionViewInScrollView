using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace CollectionViewInScrollView
{
    public class CustomScrollView : ScrollView
    {
        private CollectionView _collectionView;

        [TypeConverter(typeof(ReferenceTypeConverter))]
        public CollectionView CollectionView
        {
            set => _collectionView = value;
        }

        protected override void LayoutChildren(double x, double y, double width, double height)
        {
            if (_collectionView != null)
                _collectionView.HeightRequest = height;

            base.LayoutChildren(x, y, width, height);
        }

    }
}
