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
using xamarineApp.Pages;

namespace xamarineApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ClientPage : ContentPage
    {
        private static readonly HttpClient _client = new HttpClient();
        private readonly string _url;
        List<Datum> _userList;
        Datum User { get; set; }
        string _email;


        public ClientPage(string email)
        {
            InitializeComponent();
            _userList = new List<Datum>();
            _url = "https://reqres.in/api/users?page=2";
            _email = email;
            GetUser();
        }
        public ClientPage(Datum user)
        {
            InitializeComponent();
            User = user;
            LoadPage();
        }

        private async void GetUser()
        {
            Dictionary<string, string> dict = new Dictionary<string, string>() {};
            FormUrlEncodedContent form = new FormUrlEncodedContent(dict);
            HttpResponseMessage responseMessage = await _client.GetAsync(_url);
            string answer = await responseMessage.Content.ReadAsStringAsync();
            ListUsers list = JsonConvert.DeserializeObject<ListUsers>(answer);
            _userList = list.Data;
            User = GetClientByEmail();

            LoadPage();

        }

        public void LoadPage()
        {
            UserAvatar.Source = User.Avatar;
            UserFirstName.Text = User.First_Name;
            UserLastName.Text = User.Last_Name;
            UserEmail.Text = User.Email;
        }

        private Datum GetClientByEmail()
        {
            foreach (Datum a in _userList)
            {
                if (a.Email == _email)
                {
                    return a;
                }
            }
            return null;
        }

        private void ButtonChangeUser_Click(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ChangeUserPage(User));
        }



    }

}