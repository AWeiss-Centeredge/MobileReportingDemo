using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using MobileReporting.BusinessLogic.Services;
using MobileReporting.Pages;

namespace MobileReporting.BusinessLogic
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddPages(this IServiceCollection services)
        {
            services.TryAddScoped<LoginPage>();
            services.TryAddScoped<ReportsListPage>();
            services.TryAddScoped<ReportViewPage>();

            return services;
        }

        public static IServiceCollection AddBusinessLogic(this IServiceCollection services)
        {
            services.TryAddTransient<IReportService,ReportService>();

            return services;
        }
    }
}
