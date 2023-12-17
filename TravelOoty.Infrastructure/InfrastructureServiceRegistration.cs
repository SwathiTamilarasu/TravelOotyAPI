using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelOoty.Application.Contracts.Infrastructure;
using TravelOoty.Application.Models.Mail;
using TravelOoty.Application.Models.Blob;
using TravelOoty.Infrastructure.FileExport;
using TravelOoty.Infrastructure.Mail;
using Azure.Storage.Blobs;

namespace TravelOoty.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services,IConfiguration configuration)
        {
            services.Configure<EmailSettings>(configuration.GetSection("EmailSettings"));
            services.AddTransient<ICsvExporter, CsvExporter>();
            services.AddTransient<IEmailService, EmailService>();
            services.AddTransient<IBlobService, BlobService>();
            //services.Configure<BlobSetting>(configuration.GetSection("BlobSettings"));
            services.AddTransient<BlobSetting>();
            services.AddScoped(x => new BlobServiceClient(configuration.GetValue<string>("BlobSettings:BlobConnectionString")));
            return services;
        }

    }
}
