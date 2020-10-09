using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MobileReporting.BusinessLogic.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileReporting.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ReportsListPage : ContentPage
    {
        private readonly IEnumerable<ReportMetaData> Reports;
        public ReportsListPage(IEnumerable<ReportMetaData> reports)
        {
            Reports = reports;
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            Reports_lst.ItemsSource = Reports;
        }

        private async void Reports_lst_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var report = e.SelectedItem as ReportMetaData;
            if (report == null)
            {
                return;
            }

            await Navigation.PushAsync(new ReportViewPage(report));
        }
    }
}