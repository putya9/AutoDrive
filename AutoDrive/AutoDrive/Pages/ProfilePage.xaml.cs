using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AutoDrive.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProfilePage : ContentPage
    {

        public ProfilePage()
        {
            InitializeComponent();
        }

        private void ContentPage_Appearing(object sender, EventArgs e)
        {
            List<Client> client = new List<Client>();
            client.Add(App.CurrentClient);
            ClientList.ItemsSource = client;
        }

        private async void BtnOrders_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Pages.OrderPage(App.CurrentClient.clientId));
        }
    }
}