using System;
using System.IO;
using System.Linq;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using System.Diagnostics;

namespace WebHostServiceDemo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var pathToExe = Process.GetCurrentProcess().MainModule.FileName;
            var pathToContentRoot = Path.GetDirectoryName(pathToExe);

            IWebHost host;

            if (Debugger.IsAttached || args.Contains("console"))
            {
                host = WebHost.CreateDefaultBuilder()
                        .UseContentRoot(Directory.GetCurrentDirectory())
                        .UseStartup<Startup>()
                        .Build();
                host.Run();
            }
            else
            {
                host = WebHost.CreateDefaultBuilder(args)
                        .UseContentRoot(pathToContentRoot)
                        .UseStartup<Startup>()
                        .Build();
                host.RunAsCustomService();
            }
        }
    }
}
