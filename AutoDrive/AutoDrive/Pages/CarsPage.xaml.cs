using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Newtonsoft.Json;

namespace AutoDrive.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CarsPage : ContentPage
    {
        private bool _isActive = false;
        private TimeSpan _time = new TimeSpan(0,0,1);
        private TimeSpan _second = new TimeSpan(0, 0, 1);
        private Car _car = null;
        private DateTime _curentDate = DateTime.Now;
        public CarsPage()
        {
            InitializeComponent();
        }

        private async void ContentPage_Appearing(object sender, EventArgs e)
        {
            List<Car> cars = await ApiAll.GetCars();
            ListViewCars.ItemsSource = cars;
            List<Category> categories = await ApiAll.GetCategory();
            categories.Insert(0, new Category
            {
                categoryName = "Категория"
            });
            CatPicker.ItemsSource = categories;
            CatPicker.SelectedIndex = 0;
        }

        private async void BtnProfile_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Pages.ProfilePage());            
        }

        private async void CatPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<Car> cars = await ApiAll.GetCars();
            if (CatPicker.SelectedIndex != 0)
                cars = cars.Where(p => p.Idcategory.categoryName == (CatPicker.SelectedItem as Category).categoryName).ToList();
            ListViewCars.ItemsSource = cars;
        }

        private async void BtnCancle_Clicked(object sender, EventArgs e)
        {
            LbTimes.IsVisible = false;
            BtnCancle.IsVisible = false;
            LbModel.IsVisible = false;
            _time = new TimeSpan(0, 0, 0);
            _isActive = false;
            Order order = new Order
            {
                clientId = App.CurrentClient.clientId,
                carId = _car.carId,
                startTime = _curentDate,
                endTime = DateTime.Now,
                car = _car,
                client = App.CurrentClient
            };
            await ApiAll.PostOrder(order);
        }

        private async void BtnRent_Clicked(object sender, EventArgs e)
        {
            if(_isActive == false)
            {
                _curentDate = DateTime.Now;
                LbModel.Text = ((sender as Button).BindingContext as Car).FullCar.ToString();
                _car = (sender as Button).BindingContext as Car;
                LbModel.IsVisible = true;
                _isActive = true;
                LbTimes.IsVisible = true;
                BtnCancle.IsVisible = true;
                Device.StartTimer(new TimeSpan(0,0,1), () =>
                {
                    _time += _second;
                    Device.BeginInvokeOnMainThread(() =>
                    {
                        LbTimes.Text = _time.ToString();
                    });
                    if (_isActive == true)
                        return true;
                    else
                        return false;
                });
            }
            else
            {
                await DisplayAlert("Ошибка","У вас уже есть активная аренда", "ОК");
            }
        }
    }
}