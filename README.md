# Loading Xamarin.Forms CollectionView inside a ScrollView

When the `CollectionView` is loaded inside the `ScrollView` with the height of total items, scrolling will not occur in the CollectionView. The CollectionView does not pass touch to the parent ScrollView.

When the CollectionView is loaded inside the ScrollView the following scenarios, the height of the total items is set to `HeightRequest` of the CollectionView.

```
<ScrollView x:Name="myScrollView">
        <StackLayout>

            <!-- YOURS CONTROLS GOES HERE -->

            <ctrls:CustomCollectionView
                Columns="3"
                ItemSizingStrategy="MeasureFirstItem"
                ItemsLayout="VerticalGrid, 3"
                ItemsSource="{Binding Items}"
                RowHeigt="120"
                ScrollView="myScrollView">

                <CollectionView.ItemTemplate>
                    <DataTemplate>
                        ...
                    </DataTemplate>
                </CollectionView.ItemTemplate>
            </ctrls:CustomCollectionView>

        </StackLayout>
</ScrollView>
```
To know more about this implementation, please refer our documentation [here](https://luismts.com)

#### Acknowledgment

Thanks to syncfusion for [its implementation](https://github.com/SyncfusionExamples/xamarin.forms-listview-inside-scrollview/) and all the collaborations they do.
