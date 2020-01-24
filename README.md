# How-to-sort-the-groups-by-date-and-sort-the-items-by-time-using-xamarin.forms-listview

In Xamarin.Forms ListView, group can be sort based on Date property using comparer and items can be sorted separately inside the respected group based on Time property.

```
<ContentPage xmlns:syncfusion="clr-namespace:Syncfusion.ListView.XForms;assembly=Syncfusion.SfListView.XForms" >
     <ContentPage.Resources>
        <local:ThicknessConverter x:Key="converter"/>
    </ContentPage.Resources>
    <ContentPage.Content>
        <StackLayout >
         <Button Text="AddItem" x:Name="AddButton" HeightRequest="50"/>
         <syncfusion:SfListView x:Name="listView" ItemsSource="{Binding contactsinfo}">
                <syncfusion:SfListView.GroupHeaderTemplate>
             <DataTemplate>
                <ViewCell>
                   <Label Text="{Binding Key}" />
                </ViewCell>
              </DataTemplate>
          </listView:SfListView.GroupHeaderTemplate>
                <syncfusion:SfListView.ItemTemplate>
                    <DataTemplate>
                        <ViewCell>
                            <Grid>
                                     <Label Text="{Binding ContactName}"/>
                                     <Label Text="{Binding Time}"/>
                             </Grid>                               
                        </ViewCel>
                    </DataTemplate>
                </syncfusion:SfListView.ItemTemplate>    
            </syncfusion:SfListView>
        </StackLayout>
    </ContentPage.Content>
</ContentPage>

```

```
namespace ListViewSample
{
  public class Behavior : Behavior<ContentPage>
  {
  
   protected override void OnAttachedTo(ContentPage bindable)
   {
     ListView = bindable.FindByName<Syncfusion.ListView.XForms.SfListView>("listView");
    ListView.DataSource.LiveDataUpdateMode = LiveDataUpdateMode.AllowDataShaping;
     ListView.DataSource.GroupDescriptors.Add(new GroupDescriptor()
     {
       PropertyName = "DateTime",

       KeySelector = (object obj1) =>
       {
          var item = (obj1 as Contacts);
          var date = string.Format("{0:dd/MM/yyyy}", item.DateTime);
          return date;
       },
       Comparer = new CustomGroupComparer()
      });

      ListView.DataSource.SortDescriptors.Add(new SortDescriptor()
      {
        PropertyName = "Time",
        Direction = ListSortDirection.Descending
      });
     }
    }
  public class CustomGroupComparer : IComparer<GroupResult>, ISortDirection
  {
      public CustomGroupComparer()
      {
        this.SortDirection = ListSortDirection.Descending;
      }
       public int Compare(GroupResult x, GroupResult y)
       {
         var xdateparse = DateTime.Parse(x.Key.ToString());
         var ydateparse = DateTime.Parse(y.Key.ToString());
         var groupX = xdateparse;
         var groupY = ydateparse;

         if (DateTime.Compare(groupX, groupY) > 0)
            return SortDirection == ListSortDirection.Ascending ? 1 : -1;
         else if (DateTime.Compare(groupX, groupY) == -1)
            return SortDirection == ListSortDirection.Ascending ? -1 : 1;
         else
            return 0;
       }
  }
}
```