using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TEKUP_Trainning
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListPage : ContentPage
    {
        ObservableCollection<Person> persons = new ObservableCollection<Person>();
        public ListPage()
        {
            InitializeComponent();
            

            persons.Add(new Person { Name = "Slim", LastName = "Hammami" });
            persons.Add(new Person { Name = "Ali", LastName = "Hammami" });
            persons.Add(new Person { Name = "Mohamed", LastName = "Hammami" }); persons.Add(new Person { Name = "Salah", LastName = "Ben Ali" }); persons.Add(new Person { Name = "Ahmed", LastName = "Ben mohamed" });
            persons.Add(new Person { Name = "Youssef", LastName = "Ben Ali" });
            persons.Add(new Person { Name = "Sami", LastName = "Hammami" });

            Persons.ItemsSource = persons;

        }

        private void MenuItem_OnClicked(object sender, EventArgs e)
        {
            var m =(MenuItem) sender;
            var person = m.CommandParameter as Person;
            if (person != null)
            {
                DisplayAlert("Hello", person.Name + " " + person.LastName, "Ok");
            }
        }

        private void MenuItemDelete_OnClicked(object sender, EventArgs e)
        {
            var m = (MenuItem)sender;
            var person = m.CommandParameter as Person;
            if (person != null)
            {
                persons.Remove(person);
            }

        }

        private void MySearchBar_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            string keyworrd = MySearchBar.Text;
            List<Person> perss = new List<Person>();
          
            perss = persons.Where(p => p.Name.ToUpper().Contains(keyworrd.ToUpper())).ToList();


            ObservableCollection<Person> pers = new ObservableCollection<Person>(perss);

            Persons.ItemsSource = pers;

        }
    }
}