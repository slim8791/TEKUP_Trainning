using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace TEKUP_Trainning
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {

            InitializeComponent();


        }

        private void Button_OnClicked(object sender, EventArgs e)
        {
            DisplayAlert("Alert ! ", "Hello from TEK-UP", "Cancel");

        }

        //private void Slider_OnValueChanged(object sender, ValueChangedEventArgs e)
        //{
        // //   MyLabel.Text = String.Format("Value is {0}",e.NewValue);
        //}
        private void Button_OnClicked1(object sender, EventArgs e)
        {

            Navigation.PopAsync();
        }
    }
}
