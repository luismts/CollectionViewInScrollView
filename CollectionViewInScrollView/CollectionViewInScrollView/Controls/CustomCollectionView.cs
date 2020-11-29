
using System;
using System.Linq;
using Xamarin.Forms;

namespace CollectionViewInScrollView.Controls
{
    public class CustomCollectionView : CollectionView
    {
        private ScrollView _scrollView;
        private Layout<View> _templateReference;
        private int _rowHeigt, _columns = 1;
        private double previousScrollViewPosition = 0;

        public CustomCollectionView()
        {
            //this.SizeChanged += CustomCollectionView_SizeChanged;
        }

        [TypeConverter(typeof(ReferenceTypeConverter))]
        public ScrollView ScrollView
        {
            set
            {
                _scrollView = value;
                _scrollView.Scrolled += _scrollView_Scrolled;
            }
        }

        //[TypeConverter(typeof(ReferenceTypeConverter))]
        //public Layout<View> TemplateContainer
        //{
        //    set => _templateReference = value;
        //}

        private int RowCount => Convert.ToInt32(ItemsSource.Cast<object>().ToList().Count);

        public int RowHeigt 
        {
            set => _rowHeigt = Convert.ToInt32(value);
        }

        public int Columns
        {
            set => _columns = Convert.ToInt32(value);
        }

        private void UpdateHeight()
        {
            int rowCount = RowCount;

            if (_rowHeigt > 0)
            {
                HeightRequest = (_rowHeigt * rowCount) / _columns;                
            }
            else
            {
                if (_templateReference is null)
                    return;
                
                double rowHeight = _templateReference switch
                {
                    Grid        => (_templateReference as Grid).Height,
                    StackLayout => (_templateReference as StackLayout).Height,
                    _           => 0
                };

                if (rowHeight <= 0)
                {
                    rowHeight = _templateReference switch
                    {
                        Grid        => (_templateReference as Grid).HeightRequest,
                        StackLayout => (_templateReference as StackLayout).HeightRequest,
                        _           => 0
                    };
                }

                if (rowHeight > 0)
                {
                    double spacing = _templateReference switch
                    {
                        Grid => (_templateReference as Grid).RowSpacing,
                        StackLayout => (_templateReference as StackLayout).Spacing,
                        _ => 0
                    };

                    //Thickness padding = _templateReference switch
                    //{
                    //    Grid => (_templateReference as Layout).Padding,
                    //    StackLayout => (_templateReference as Layout).Padding,
                    //    _ => 0
                    //};

                    //double verticalPadding = padding.Bottom + padding.Top;

                    Thickness margin = _templateReference switch
                    {
                        Grid => (_templateReference as Layout).Margin,
                        StackLayout => (_templateReference as Layout).Margin,
                        _ => 0
                    };

                    double verticalMargin = margin.Bottom + margin.Top;

                    HeightRequest = (rowHeight * rowCount) + (spacing * rowCount) + /*(verticalPadding * rowCount) +*/ (verticalMargin * rowCount);
                }
            }
            
            
        }

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();
            UpdateHeight();
        }

        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);
            UpdateHeight();
        }

        private void _scrollView_Scrolled(object sender, ScrolledEventArgs e)
        {
            if (previousScrollViewPosition < e.ScrollY)
            {
                //scrolled down

            }
            else
            {
                //scrolled up

            }

            double scrollingSpace = _scrollView.ContentSize.Height - _scrollView.Height;
            if (scrollingSpace <= e.ScrollY)
            {
                // Touched bottom view
                RemainingItemsThresholdReachedCommand?.Execute(RemainingItemsThresholdReachedCommandParameter);
            }

            previousScrollViewPosition = e.ScrollY;
        }

        protected override void OnChildAdded(Element child)
        {
            base.OnChildAdded(child);
            UpdateHeight();
        }
        
        protected override void OnChildRemoved(Element child, int oldLogicalIndex)
        {
            base.OnChildRemoved(child, oldLogicalIndex);
            UpdateHeight();
        }


    }
}
