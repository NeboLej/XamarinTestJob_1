using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace xamarineApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegistrationPage : ContentPage
    {

        private static readonly HttpClient _client = new HttpClient();
        private readonly string _url;
        private UserModel _user = new UserModel();


        public RegistrationPage()
        {
            InitializeComponent();
            _url = "https://reqres.in/api/register";


        }

        private void ButtonAutorisation_click(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AutorisationPage());
        }

        private void ButtonRegistration_click(object sender, EventArgs e)
        {
            if (Validation())
            {
                Registration();
            }
        }

        private bool Validation()
        {
            bool validation = true;
            if(EntryName.Text == null)
            {
                validation = false;
                DecorateTheField(EntryName);


            }
            else if (EntryPassword.Text == null)
            {
                validation = false;
                DecorateTheField(EntryPassword);
            }
            return validation;
        }

        private void DecorateTheField(Entry entry)
        {
            entry.BackgroundColor = Color.Pink;
        }

        private async void Registration()
        {
            Dictionary<string, string> dict = new Dictionary<string, string>() { { "email", EntryName.Text }, { "password", EntryPassword.Text } };
            FormUrlEncodedContent form = new FormUrlEncodedContent(dict);
            HttpResponseMessage responseMessage = await _client.PostAsync(_url, form);
            string answer = await responseMessage.Content.ReadAsStringAsync();
            RegistrationCheck(answer);

        }

        private async void RegistrationCheck(string answer)
        {
            if (answer != "400")
            {
                await DisplayAlert("Результат", "Успешно зарегистрирован", "OK");
                Navigation.PushAsync(new AutorisationPage());

            }
            else
            {
                await DisplayAlert("Результат", "ошибка регистрации", "OK");
            }
        }
    }
}