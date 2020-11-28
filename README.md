# Loading Xamarin.Forms CollectionView inside a ScrollView

When the `CollectionView` is loaded inside the `ScrollView` with the height of total items, scrolling will not occur in the CollectionView only when AllowSwiping is set to `true`. The CollectionView does not pass touch to the parent ScrollView in UWP, because swiping is handled in it.

When the CollectionView is loaded inside the ScrollView the following scenarios, the height of the total items is set to `HeightRequest` of the CollectionView.

If the position of the CollectionView is not in view when loading inside the StackLayout with more than one children, the CollectionView will not be loaded. Because, the StackLayout passes the height for the `CollectionView` as 1.

When loading the CollectionView inside the `Grid` with row definition as `Auto` in UWP, Grid passes the height for the CollectionView to be 1.

```
<ctrls:ExtScrollView x:Name="scrollView" >
   <CollectionView x:Name="collectionView" ItemsSource="{Binding BookInfo}"/>
</ctrls:ExtScrollView>
```
When the CollectionView is loaded inside the ScrollView with sticky header and sticky group header, it changed to scrollable. The empty space remains after the CollectionView items, when the device orientation is changed to horizontal. Because, the total extend is set to the `ScrollView` in horizontal orientation

```
public class ExtScrollView: ScrollView
{    
     protected override void LayoutChildren(double x, double y, double width, double height)
     {
         this.Content.HeightRequest = height;
         base.LayoutChildren(x, y, width, height);
     }
}
```

To know more about MVVM in ListView, please refer our documentation [here](https://luismts.com)

#### Acknowledgment

Thanks to syncfusion for [its implementation](https://github.com/SyncfusionExamples/xamarin.forms-listview-inside-scrollview/) and all the collaborations they do.
