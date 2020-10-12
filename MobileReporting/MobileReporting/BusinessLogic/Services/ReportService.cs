using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.PowerBI.Api;
using Microsoft.Rest;
using MobileReporting.BusinessLogic.Models;

namespace MobileReporting.BusinessLogic.Services
{
    public interface IReportService
    {
        Task<IEnumerable<ReportMetaData>> GetReportsAsync();

        Task<Microsoft.PowerBI.Api.Models.Report> GetBiReportAysnc(Guid reportId);
    }
    public class ReportService: IReportService
    {
        private PowerBIClient _powerBiClient
        {
            get
            {
                var credentials = new TokenCredentials("", "AppKey");
                return new PowerBIClient(credentials);
            }
        }

        public ReportService()
        {
        }


        public async Task<IEnumerable<ReportMetaData>> GetReportsAsync()
        {
            var IDs = new List<Guid>()
            {
                new Guid("71fe3aea-7881-4911-a7a4-9d94b48acfef")
            };
            //try
            //{
            //    using (var client = _powerBiClient)
            //    {
            //        var reports = await client.Reports.GetReportsWithHttpMessagesAsync();
            //        //reports = await client.Reports.get
            //        return reports.Body.Value
            //            .Where(report => IDs.Contains(report.Id))
            //            .Select(report => new ReportMetaData()
            //            {
            //                Name = report.Name,
            //                EmbedUrl = report.EmbedUrl,
            //                ReportId = report.Id
            //            });
            //    }
            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine(e);
            //    throw;
            //}

            return new System.Collections.Generic.List<ReportMetaData>()
            {
                new ReportMetaData()
                {
                    Name = "Report 1",
                    EmbedUrl = "http://www.google.com/",
                    ReportId = new Guid("71fe3aea-7881-4911-a7a4-9d94b48acfef")
                },
                new ReportMetaData()
                {
                    Name = "Report 2",
                    EmbedUrl = "http://www.google.com/",
                    ReportId = Guid.NewGuid()
                },
                new ReportMetaData()
                {
                    Name = "Report 3",
                    EmbedUrl = "http://www.google.com/",
                    ReportId = Guid.NewGuid()
                }
            };
        }

        public async Task<Microsoft.PowerBI.Api.Models.Report> GetBiReportAysnc(Guid reportId)
        {
            using (var client = _powerBiClient)
            {
                var report = await client.Reports.GetReportWithHttpMessagesAsync(reportId);
                return report.Body;
            }
        }
    }
}
