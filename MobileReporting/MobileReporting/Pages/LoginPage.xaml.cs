using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MobileReporting.BusinessLogic.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileReporting.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public readonly IReportService ReportService;

        public LoginPage()
        {
            ReportService = new ReportService();
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            Username_txt.Text = string.Empty;
            Password_txt.Text = string.Empty;
        }

        private async void Button_OnClicked(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Username_txt.Text) || string.IsNullOrWhiteSpace(Password_txt.Text))
            {
                Error_lbl.Text = "Please enter a username and password.";
                return;
            }

            var reports = await ReportService.GetReportsAsync();
            await Navigation.PushAsync(new ReportsListPage(reports));
        }
    }
}