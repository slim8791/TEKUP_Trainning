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
    public partial class AppPropreties : ContentPage
    {
        public AppPropreties()
        {
            InitializeComponent();
            if (Application.Current.Properties.ContainsKey("ToDo"))
            {
                MyEntry.Text = Application.Current.Properties["ToDo"].ToString();

            }
            if (Application.Current.Properties.ContainsKey("IsTrue"))
            {
                MySwitch.On = (bool) Application.Current.Properties["IsTrue"];
            }
        }

        protected override async void OnDisappearing()
        {
            base.OnDisappearing();
            Application.Current.Properties["ToDo"] = MyEntry.Text;

            await Application.Current.SavePropertiesAsync();
        }

        private async void MyEntry_OnCompleted(object sender, EventArgs e)
        {
            Application.Current.Properties["IsTrue"] = MySwitch.On;

            Application.Current.Properties["ToDo"] = MyEntry.Text;
            await Application.Current.SavePropertiesAsync();
        }

     
    }
}