using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ListViewSample 
{
    public class ContactsViewModel : INotifyPropertyChanged
    {
        #region Properties
        public ObservableCollection<Contacts> contactsinfo { get; set; }
        public Command<object> AddCommand { get; set; }

        #endregion

        #region Constructor

        public ContactsViewModel()
        {
            contactsinfo = new ObservableCollection<Contacts>();
            AddCommand = new Command<object>(OnAddCommand);
            Random r = new Random();
            for (int i=0;i<6;i++)
            {
                if (i < 3)
                {
                    var contact = new Contacts();
                    contact.ContactName = CustomerNames[i];
                    var date = DateTimeOffset.Now;
                    contact.DateTime = date.AddDays(-1).AddMonths(-1).AddYears(-1);
                    contact.Time = date.AddHours(-r.Next(1,10));
                    contact.ContactImage = ImageSource.FromResource("ListViewSample.Images.Image" + r.Next(0, 28) + ".png",typeof(MainPage));
                    contactsinfo.Add(contact);
                }
                else
                {
                    var contact = new Contacts();
                    contact.ContactName = CustomerNames[i];
                    var date = DateTimeOffset.Now;
                    contact.DateTime = date.AddDays(-2).AddMonths(-2).AddYears(-2);
                    contact.Time = date.AddHours(-r.Next(1,10));
                    contact.ContactImage = ImageSource.FromResource("ListViewSample.Images.Image" + r.Next(0, 28) + ".png",typeof(MainPage));
                    contactsinfo.Add(contact);
                }
            }
        }

        #endregion

        #region TapMethod
        private void OnAddCommand(object obj)
        {
            Random r = new Random();
            var date = DateTimeOffset.Now;
            var newItem = new Contacts();
            newItem.ContactName = "John";
            newItem.ContactImage = ImageSource.FromResource("ListViewSample.Images.Image" + r.Next(0) + ".png",typeof(MainPage));
            newItem.DateTime = date.AddDays(0).AddMonths(0).AddYears(0);
            newItem.Time = System.DateTime.Now.AddHours(-r.Next(1, 6));
            this.contactsinfo.Add(newItem);
        }

        #endregion

        #region Fields
        string[] CustomerNames = new string[] {
            "Kyle",
            "Gina",
            "Irene",
            "Katie",
            "Michael",
            "Oscar",
            "Ralph",
            "Torrey",
            "William",
            "Bill",
            "Daniel",
            "Frank",
            "Brenda",
            "Danielle",
            "Fiona",
            "Howard",
            "Jack",
            "Larry",
            "Holly",
            "Jennifer",
            "Liz",
            "Pete",
            "Steve",
            "Vince",
            "Zeke",
            "Aiden",
            "Jackson"    ,
            "Mason  "    ,
            "Liam   "    ,
            "Jacob  "    ,
            "Jayden "    ,
            "Ethan  "    ,
            "Noah   "    ,
            "Lucas  "    ,
            "Logan  "    ,
            "Caleb  "    ,
            "Caden  "    ,
            "Jack   "    ,
            "Ryan   "    ,
            "Connor "    ,
            "Michael"    ,
            "Elijah "    ,
            "Brayden"    ,
            "Benjamin"   ,
            "Nicholas"   ,
            "Alexander"  ,
            "William"    ,
            "Matthew"
        };

        #endregion

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
