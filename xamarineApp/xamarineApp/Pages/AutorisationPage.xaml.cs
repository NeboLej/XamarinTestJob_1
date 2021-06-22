using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Newtonsoft;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http;

namespace xamarineApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AutorisationPage : ContentPage
    {
        private static readonly HttpClient _client = new HttpClient();
        private readonly string _url;
        private UserModel _user = new UserModel();


        public AutorisationPage()
        {
            InitializeComponent();
            _url = "https://reqres.in/api/login";
        }

        private void ButtonRegistration_Click(object sender, EventArgs e)
        {
            Navigation.PushAsync(new RegistrationPage());
        }

        private void ButtonAutorisation_Click(object sender, EventArgs e)
        {
            if (Validation())
            {
                Authorization();
            }
        }

        private bool Validation()
        {
            bool validation = true;
            if (EntryName.Text == null)
            {
                DecorateTheField(EntryName);
                validation = false;
            }
            else if (EntryPassword.Text == null)
            {
                DecorateTheField(EntryPassword);
                validation = false;
            }

            return validation;
        }

        private void DecorateTheField(Entry entry)
        {
            entry.BackgroundColor = Color.Pink;
        }

        private async void Authorization()
        {
            Dictionary<string, string> dict = new Dictionary<string, string>() { { "email", EntryName.Text}, { "password", EntryPassword.Text} };
            FormUrlEncodedContent form = new FormUrlEncodedContent(dict);
            HttpResponseMessage responseMessage = await _client.PostAsync(_url, form);
            string result = await responseMessage.Content.ReadAsStringAsync();
            AuthorizationCheck(result);
        }

        private async void AuthorizationCheck(string serverResponse)
        {
            if (serverResponse != "{\"error\":\"user not found\"}")
            {
                Navigation.PushAsync(new ClientPage(EntryName.Text));
                //await DisplayAlert("Результат", serverResponse, "OK");
            }
            else
            {
                await DisplayAlert("Ошибка", "Пользователь не существует", "OK");
            }
        }
    }
}