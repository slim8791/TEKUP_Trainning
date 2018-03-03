using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TEKUP_Trainning
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OnPlatforms : ContentPage
    {
        public OnPlatforms()
        {
            InitializeComponent();
        }

        //private void Switch_OnToggled(object sender, ToggledEventArgs e)
        //{

        //    SwitchLabel.Text = e.Value.ToString();
        //}
        //private void Entry_OnCompleted(object sender, EventArgs e)
        //{

        //    DisplayAlert("Title", "the text of MyEntry : " + MyEntry.Text, "Ok");
        //}

        //private void MyEntry_OnTextChanged(object sender, TextChangedEventArgs e)
        //{
        //    //MySecond.Text = e.NewTextValue;
        //    MySecond.Text = e.OldTextValue;
        //}
        //private void Picker_OnSelectedIndexChanged(object sender, EventArgs e)
        //{

        // /*   DisplayAlert("Item from picker", MyPicker.SelectedItem.ToString(), "Ok");*/ DisplayAlert("Item from picker", MyPicker.SelectedIndex.ToString(), "Ok");
        //}
        private void DatePicker_OnDateSelected(object sender, DateChangedEventArgs e)
        {
            int a = 0;
            string b = a+"";
            DisplayAlert("Selected Date", e.NewDate.Day+"-"+e.NewDate.Month+"-"+e.NewDate.Year, "Ok");
            //DisplayAlert("Selected Date", e.NewDate.ToString(), "Ok");
        }
    }
}