using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Builder.Internal;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.Internal;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Steeltoe.Extensions.Configuration.CloudFoundry;

namespace EFMigrate
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Environment.SetEnvironmentVariable("CF_INSTANCE_INDEX","0");
            Environment.SetEnvironmentVariable("PORT","8080");
            Environment.SetEnvironmentVariable("VCAP_APP_HOST","0.0.0.0");
            Environment.SetEnvironmentVariable("MEMORY_LIMIT","1024m");
            Environment.SetEnvironmentVariable("CF_INSTANCE_PORT","12345");
            Environment.SetEnvironmentVariable("CF_INSTANCE_INTERNAL_IP","0.0.0.0");
            Environment.SetEnvironmentVariable("VCAP_APP_PORT","8080");
  
            CreateWebHostBuilder(args).Build().RunWithTasks();    
            
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .AddCloudFoundry()
                .UseStartup<Startup>();
    }
}