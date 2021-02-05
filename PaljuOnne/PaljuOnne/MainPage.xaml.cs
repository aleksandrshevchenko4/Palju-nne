using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Essentials;


namespace PaljuOnne
{
    public partial class MainPage : ContentPage
    {
        List<string> contacts, mail, number, congratulations;

        private void leftRight_Toggled(object sender, ToggledEventArgs e)
        {
            if (leftRight.IsToggled == true)
            {
                congrat.Text = "Поздравить по SMS";
            }
            else
            {
                congrat.Text = "Поздравить по E-mail";
            }
        }

        public MainPage()
        {
            contacts = new List<string>() { "Dima", "Yarik", "", "Sasha" };
            number = new List<string>() { "7968434", "6875123", "5675318"};
            mail = new List<string> { "dima.dovzenok2003@gmail.com", "akkaunkclasha@gmail.com", "sanjkashevcenko@gmail.com" };
            congratulations = new List<string> { "С Новым годос!", "С прошедним Новым годом!", "С днём святого Валентина!", "С днём Святого Патрика!" };
            InitializeComponent();
            contactPicker.ItemsSource = contacts;
            contactPicker.SelectedIndexChanged += ContactPicker_SelectedIndexChanged;
            congratulate.Clicked += Congratulate_Clicked;
        }

        private void ContactPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            maill.Text = mail[contactPicker.SelectedIndex];
            num.Text = number[contactPicker.SelectedIndex];
        }

        private async void Congratulate_Clicked(object sender, EventArgs e)
        {
            Random ranGreet = new Random();
            int rand = ranGreet.Next(5);
            if (leftRight.IsToggled == true)
            {
                congrat.Text = "Поздравить по SMS";
                await Sms.ComposeAsync(new SmsMessage { Body = congratulations[rand], Recipients = new List<string> { number[contactPicker.SelectedIndex] } });
            }
            else
            {
                congrat.Text = "Поздравить по E-mail";
                await Email.ComposeAsync("Поздравление", congratulations[rand], mail[contactPicker.SelectedIndex]);
            }
        }
    }
}
