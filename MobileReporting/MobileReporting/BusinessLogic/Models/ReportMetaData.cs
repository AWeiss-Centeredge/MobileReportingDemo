using System;
using System.Collections.Generic;
using System.Text;

namespace MobileReporting.BusinessLogic.Models
{
    public class ReportMetaData
    {
        public string Name { get; set; }
        public Guid ReportId { get; set; }
        public string EmbedUrl { get; set; }
        public string EmbedHtml { get; set; }
    }
}
