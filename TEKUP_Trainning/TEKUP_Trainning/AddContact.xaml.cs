using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TEKUP_Trainning
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddContact : ContentPage
    {
        private SQLiteAsyncConnection _connection;

        public AddContact()
        {
            InitializeComponent();
            _connection = DependencyService.Get<ISQLiteDb>().GetConnection();


        }



        private async void AddToDataBase(object sender, EventArgs e)
        {
            SqliteDataPage.Contact c = new SqliteDataPage.Contact
            {
                Name =  Name.Text,
                LastName =   LastName.Text,
                Email =  Email.Text,
                Phone = Phone.Text

            };
            await _connection.InsertAsync(c);
            await Navigation.PopAsync();

        }
    }
}