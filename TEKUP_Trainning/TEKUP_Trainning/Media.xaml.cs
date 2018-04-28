using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 using Plugin.Media;
 using Plugin.Media.Abstractions;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TEKUP_Trainning
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Media : ContentPage
    {
        private MediaFile _mediaFile;
        public Media()
        {
            InitializeComponent();
        }

        private async void TakePhotoClick(object sender, EventArgs e)
        {
            CrossMedia.Current.Initialize();
            _mediaFile = await CrossMedia.Current.TakePhotoAsync(new StoreCameraMediaOptions
            {
                Directory = "Photos",
                Name = "image.jpg"
            });
            if (_mediaFile ==null)            
                return;
            await DisplayAlert("File location", _mediaFile.Path, "Ok");
            image.Source = ImageSource.FromStream(() => { return _mediaFile.GetStream(); });
        }
    }
}