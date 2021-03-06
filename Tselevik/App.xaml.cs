﻿using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Tselevik.Services;
using Tselevik.Views;

namespace Tselevik
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<FirebaseDataStore>();
            MainPage = new MainPage();
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
