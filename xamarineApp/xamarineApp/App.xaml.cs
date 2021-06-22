﻿using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace xamarineApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
         
            MainPage = new NavigationPage(new AutorisationPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}