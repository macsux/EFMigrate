using System;
using System.Linq;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EFMigrate
{
    public static class CFTasksExtensions
    {
        public static void RunWithTasks(this IWebHost webHost)
        {
            var config = webHost.Services.GetRequiredService<IConfiguration>();
            var taskName = config.GetValue<string>("cftask");
            if (taskName != null)
            {
                
                var scope = webHost.Services.CreateScope().ServiceProvider;
                var task = scope.GetServices<IApplicationTask>().FirstOrDefault(x => x.Name.ToLower() == taskName.ToLower());
                if (task != null)
                {
                    task.Run();    
                }
                else
                {
                    Console.Error.WriteLine($"No task with name {taskName} is found");
                    
                }
            }
            else
            {
                webHost.Run();
            }

        }
    }

    public interface IApplicationTask
    {
        string Name { get; }
        void Run();
    }

    public class MigrateTask<T> : IApplicationTask where T : DbContext
    {
        private readonly T _db;

        public MigrateTask(T db)
        {
            _db = db;
        }

        public string Name => "migrate";
        public void Run()
        {
            var migrations = _db.Database.GetPendingMigrations().ToList();
            Console.WriteLine("Starting database migration...");
            _db.Database.Migrate();
            if (migrations.Any())
            {
                Console.WriteLine("The following migrations have been successfully applied:");
                foreach (var migration in migrations)
                {
                    Console.WriteLine(migration);
                }
            }
            else
            {
                Console.WriteLine("Database is already up to date");
            }

        }
    }
    
}