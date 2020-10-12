using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MobileReporting.BusinessLogic.Models;
using MobileReporting.BusinessLogic.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileReporting.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ReportViewPage : ContentPage
    {
        private readonly ReportMetaData _reportMetaData;

        private readonly IReportService _reportService;

        public ReportViewPage(ReportMetaData reportMetaData)
        {
            _reportService = new ReportService();

            _reportMetaData = reportMetaData;
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            this.Title = _reportMetaData.Name;
            //var report = await _reportService.GetBiReportAysnc(new Guid("55745a14-cb7a-41e0-9c94-9e3d6328e580"));
            //try
            //{
            //    this.EmbeddedReport_web.Source = new UrlWebViewSource()
            //    {
            //        Url = report.EmbedUrl
            //    };
            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine(e);
            //    throw;
            //}
            var htmlSource = new HtmlWebViewSource();
            htmlSource.Html = _reportMetaData.EmbedHtml;
            EmbeddedReport_web.Source = htmlSource;
        }
    }
}