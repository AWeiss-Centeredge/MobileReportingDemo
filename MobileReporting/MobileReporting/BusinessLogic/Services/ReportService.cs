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
                    Name = "Sales",
                    EmbedUrl = "http://www.google.com/",
                    ReportId = new Guid("71fe3aea-7881-4911-a7a4-9d94b48acfef"),
                    EmbedHtml = @"<iframe width=""100%"" height=""100%"" src =""https://app.powerbi.com/view?r=eyJrIjoiNzIzYzM4ZTAtYzcxMy00ZmE1LTkxYzgtMTEzMDcwOTMyMmIxIiwidCI6IjAwYTNhYzRkLTY5MzUtNDVjYi04Mjk5LWI5ZmU0NGYwMzNmOCIsImMiOjJ9&isMobile=true"" frameborder=""0"" allowFullScreen=""true""></iframe>"
                },
                new ReportMetaData()
                {
                    Name = "Labor",
                    EmbedUrl = "http://www.google.com/",
                    ReportId = Guid.NewGuid(),
                    EmbedHtml = @"<iframe width=""100%"" height=""100%"" src =""https://app.powerbi.com/view?r=eyJrIjoiZjhmMGRlZjUtYjhlYi00NDhmLWE4NzgtZGE4M2MzYjM4MTZkIiwidCI6IjAwYTNhYzRkLTY5MzUtNDVjYi04Mjk5LWI5ZmU0NGYwMzNmOCIsImMiOjJ9&pageName=ReportSection"" frameborder=""0"" allowFullScreen=""true""></iframe>"
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
