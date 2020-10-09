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
    public partial class ReportViewPage : ContentPage
    {
        private readonly ReportMetaData _reportMetaData;

        public ReportViewPage(ReportMetaData reportMetaData)
        {
            _reportMetaData = reportMetaData;
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            this.Title = _reportMetaData.Name;
            this.EmbeddedReport_web.Source = new UrlWebViewSource()
            {
                Url = _reportMetaData.EmbedUrl
            };
        }
    }
}