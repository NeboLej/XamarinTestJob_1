using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace xamarineApp.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ChangeUserPage : ContentPage
    {
        private Datum _user;
        public ChangeUserPage(Datum user)
        {
            InitializeComponent();
            _user = user;
            EntryEmail.Text = _user.Email;
            EntryFirstName.Text = _user.First_Name;
            EntryLastName.Text = _user.Last_Name;
            _user.Avatar = user.Avatar;
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            if (Validation())
            {
                _user.Email = EntryEmail.Text;
                _user.First_Name = EntryFirstName.Text;
                _user.Last_Name = EntryLastName.Text;
                Navigation.PushAsync(new ClientPage(_user));
            }

        }

        private bool Validation()
        {
            bool validation = true;
            if(EntryEmail.Text == null)
            {
                validation = false;
                DecorateTheField(EntryEmail);
            }
            else if (EntryFirstName==null)
            {
                validation = false;
                DecorateTheField(EntryFirstName);
            }
            else if (EntryLastName==null)
            {
                validation = false;
                DecorateTheField(EntryFirstName);
            }
            return validation;
        }

        private void DecorateTheField(Entry entry)
        {
            entry.BackgroundColor = Color.Pink;
        }
    }
}