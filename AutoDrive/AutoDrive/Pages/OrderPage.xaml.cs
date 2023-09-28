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
    public partial class OrderPage : ContentPage
    {
        int idOrder;
        public OrderPage(int id)
        {
            InitializeComponent();
            idOrder = id;

        }

        private async void ContentPage_Appearing(object sender, EventArgs e)
        {
            List<Order> orders = await ApiAll.GetOrder();
            List<Order> order = new List<Order>();
            foreach (var item in orders)
            {
                if(item.clientId == idOrder)
                    order.Add(item);
            }
            ListViewOrder.ItemsSource = order;
        }
    }
}