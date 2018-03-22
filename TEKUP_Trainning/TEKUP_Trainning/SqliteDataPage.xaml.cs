using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TEKUP_Trainning
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SqliteDataPage : ContentPage
    {
        private ObservableCollection<Contact> _contacts; 
        private SQLiteAsyncConnection _connection;
        public class Contact : INotifyPropertyChanged
        {
            [PrimaryKey,AutoIncrement]
            public int ContactId { get; set; }
            private string _lastName { get; set; }
            public string LastName { get { return _lastName; } set {
                if (_lastName==value)
                    return;
                _lastName = value;
                    OnPropertyChanged();

            } }
            public string Email { get; set; }
            public string Phone { get; set; }
            public string Name
            {get { return _name; }
                set
                {if(_name==value)
                        return;
                    _name = value;
                    OnPropertyChanged();
                }
            }
            private string _name { get; set; }
            public event PropertyChangedEventHandler PropertyChanged;
            protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        public SqliteDataPage()
        {
            InitializeComponent();
            _connection = DependencyService.Get<ISQLiteDb>().GetConnection();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            await _connection.CreateTableAsync<Contact>();
            var result = await _connection.Table<Contact>().ToListAsync();
            _contacts = new ObservableCollection<Contact>(result);
            ContactList.ItemsSource = _contacts;
        }

        private async void AddContact(object sender, EventArgs e)
        {
            //Contact c = new Contact
            //{
            //    Name = "Slim",
            //    LastName = "Hammami",
            //    Phone = "44 922 325",
            //    Email = "h.slim@french-co.fr"
            //};
            //await _connection.InsertAsync(c);
            //_contacts.Add(c);
            await Navigation.PushAsync(new AddContact());

        }

        private async void UpdateContact(object sender, EventArgs e)
        {var m = (MenuItem)sender;
            var contact = m.CommandParameter as Contact;
            if (contact != null)
            {
                contact.LastName += " updated !";
            }
            
            await _connection.UpdateAsync(contact);
            

        }

        private async void DeleteContact(object sender, EventArgs e)
        {

            var m = (MenuItem)sender;
            var contact = m.CommandParameter as Contact;
            if (contact != null)
            {
                bool b =  await  DisplayAlert("Attention", "Confirm deleting " + contact.Name, "Ok", "Cancel");
                if (b)
                {
                    _contacts.Remove(contact);
                    await _connection.QueryAsync<Contact>("delete from contact where contactid=" + contact.ContactId);
                    // await _connection.DeleteAsync(contact);
                }
            }

        }
    }
}