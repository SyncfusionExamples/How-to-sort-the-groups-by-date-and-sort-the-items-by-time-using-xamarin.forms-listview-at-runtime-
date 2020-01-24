using Syncfusion.DataSource;
using Syncfusion.DataSource.Extensions;
using Syncfusion.ListView.XForms;
using Syncfusion.ListView.XForms.Control.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ListViewSample
{
   public class Behavior : Behavior<ContentPage>
    {

        #region Fields
        private Syncfusion.ListView.XForms.SfListView ListView;
        private ContactsViewModel viewModel;
        #endregion

        #region Methods
        protected override void OnAttachedTo(ContentPage bindable)
        {
            ListView = bindable.FindByName<Syncfusion.ListView.XForms.SfListView>("listView");
            viewModel = new ContactsViewModel();
            ListView.BindingContext = viewModel;
            ListView.ItemsSource = viewModel.contactsinfo;
            ListView.DataSource.LiveDataUpdateMode = LiveDataUpdateMode.AllowDataShaping;


            ListView.DataSource.GroupDescriptors.Add(new GroupDescriptor()
            {
                PropertyName = "DateTime",

                KeySelector = (object obj1) =>
                {
                    var item = (obj1 as Contacts);
                    var date = string.Format("{0:MM/dd/yyyy}", item.DateTime);
                    return date;
                },
                Comparer = new CustomGroupComparer()
            });

            ListView.DataSource.SortDescriptors.Add(new SortDescriptor()
            {
                PropertyName = "Time",
                Direction = ListSortDirection.Descending
            });

            base.OnAttachedTo(bindable);
        }
        public class CustomGroupComparer : IComparer<GroupResult>, ISortDirection
        {
            public CustomGroupComparer()
            {
                this.SortDirection = ListSortDirection.Descending;
            }

            public ListSortDirection SortDirection
            {
                get;
                set;
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


        private void Button_Clicked(object sender, System.EventArgs e)
        {

        }

        #endregion
    }
}
