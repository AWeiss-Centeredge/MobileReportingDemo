using System;
using System.Diagnostics;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using MobileReporting.BusinessLogic;
using MobileReporting.Pages;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileReporting
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            
            var loginPage = new LoginPage();
            MainPage = new NavigationPage(loginPage);
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
