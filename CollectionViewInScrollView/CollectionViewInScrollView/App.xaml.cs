﻿using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CollectionViewInScrollView
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new BestPracticePage();  // Good way
            //MainPage = new MainPage();        // Bad way
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
