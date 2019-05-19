using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace _5_15_SignalRTasks.data
{
    public class ChoresContextFactory : IDesignTimeDbContextFactory<ChoresContext>
    {
        public ChoresContext CreateDbContext(string[] args)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), $"..{Path.DirectorySeparatorChar}5-15 SignalRTasks.web"))
                .AddJsonFile("appsettings.json")
                .AddJsonFile("appsettings.local.json", optional: true, reloadOnChange: true).Build();

            return new ChoresContext(config.GetConnectionString("ConStr"));
        }
    }
}
