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
    public partial class Menu : MasterDetailPage
    {
        public Menu()
        {
            InitializeComponent();
            IsPresented = true;
            Detail = new NavigationPage((Page)Activator.CreateInstance(typeof(OnPlatforms)));
            var masterDetailItems = new List<MasterDetailItem>();

            masterDetailItems.Add(new MasterDetailItem {Title = "Stack Layout Page",TargetType = typeof(StackLayoutPage), IconSource = "icon.png"});

            masterDetailItems.Add(new MasterDetailItem { Title = "Relative Layout Page", TargetType = typeof(RelativeLayout), IconSource = "icon.png" });

            masterDetailItems.Add(new MasterDetailItem { Title = "Absolute Layout Page", TargetType = typeof(AbsolutePage), IconSource = "icon.png" });

            masterDetailItems.Add(new MasterDetailItem { Title = "Grid Page", TargetType = typeof(GridPage), IconSource = "icon.png" });

            masterDetailItems.Add(new MasterDetailItem { Title = "Tabbed PAge Page", TargetType = typeof(TabbedPage), IconSource = "icon.png" });

            MenuList.ItemsSource = masterDetailItems;
        }

        private void MenuList_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

            var item = e.SelectedItem as MasterDetailItem;
            if (item != null)
            {
                Detail = new NavigationPage((Page)Activator.CreateInstance(item.TargetType));
                MenuList.SelectedItem = null;
                IsPresented = false;
            }
        }
    }
}