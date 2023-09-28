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
    public partial class RegPage : ContentPage
    {
        public RegPage()
        {
            InitializeComponent();
        }

        private async void BtnReg_Clicked(object sender, EventArgs e)
        {
            string error = "";
            if (string.IsNullOrEmpty(PhoneEntr.Text))
                error += "Вы не ввели номер телефона\n";
            if (string.IsNullOrEmpty(PasswordEntr.Text))
                error += "Вы не ввели пароль\n";
            if (string.IsNullOrEmpty(NameEntr.Text))
                error += "Вы не ввели имя\n";
            if (string.IsNullOrEmpty(LastNEntr.Text))
                error += "Вы не ввели фамилию\n";
            if (string.IsNullOrEmpty(PatrEntr.Text))
                error += "Вы не ввели отчество\n";
            if (string.IsNullOrEmpty(PassportEntr.Text))
                error += "Вы не ввели номер паспорта";
            if (string.IsNullOrEmpty(DriveLicEntr.Text))
                error += "Вы не ввели номер вод. удост";
            if (!string.IsNullOrEmpty(error))
            {
                await DisplayAlert("Ошибка!", "Произошла ошибка!\n\n" + error, "OK");
                return;
            }
            else
            {
                Client client = new Client()
                {
                    phoneNumber = PhoneEntr.Text,
                    password = PasswordEntr.Text,
                    firstName = NameEntr.Text,
                    lastName = LastNEntr.Text,
                    patronymic = PatrEntr.Text,
                    passport = PassportEntr.Text,
                    drivingLicense = DriveLicEntr.Text
                };
                await ApiAll.PostClient(client);
                Navigation.RemovePage(this);
            }
        }
    }
}