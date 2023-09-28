using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Newtonsoft.Json;
using System.Net.Http;
using Xamarin.Forms.Xaml;

namespace AutoDrive
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void BtnLogin_Clicked(object sender, EventArgs e)
        {
            string error = "";
            if (string.IsNullOrWhiteSpace(LoginEntr.Text))
                error += "Вы не ввели Логин\n";
            if (string.IsNullOrWhiteSpace(PasswordEntr.Text))
                error += "Вы не ввели Пароль\n";
            if (error != "")
            {
                await DisplayAlert("Ошибка!", $"Не ввели все данные:\n{error}", "ОК");
                return;
            }
            var user = new User()
            {
                phoneNumber = LoginEntr.Text,
                password = PasswordEntr.Text
            };
            if(await ApiAll.GetAuth(user) is Client client)
            {
                App.CurrentClient = client;
                await Navigation.PushAsync(new Pages.CarsPage());
            }
            else
                await DisplayAlert("Ошибка!!!", "Вы ввели неправильные данные/Отсуствует подключение к интернету", "ОК");
        }

        private void ContentPage_Appearing(object sender, EventArgs e)
        {
            App.CurrentClient = null;
        }


        private async void BtnReg_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Pages.RegPage());
        }
    }
}
