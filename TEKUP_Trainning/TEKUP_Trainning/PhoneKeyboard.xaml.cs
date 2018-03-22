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
    public partial class PhoneKeyboard : ContentPage
    {
        public PhoneKeyboard()
        {
            InitializeComponent();
        }

        private void Button_OnClicked(object sender, EventArgs e)
        {
            var btn = (Button) sender;
            Number.Text = Number.Text + btn.Text;
        }

        private void Button_OnClicked1(object sender, EventArgs e)
        {
            Navigation.PushAsync(new StackLayoutPage(),false);
            //  Navigation.PopModalAsync();
            //Navigation.PopAsync();
            //   Navigation.PushAsync(new MainPage());
        }
    }
}