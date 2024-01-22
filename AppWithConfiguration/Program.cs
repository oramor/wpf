using Microsoft.Extensions.Configuration;
using System.IO;

namespace AppWithConfiguration
{
    internal class Program
    {
        [STAThread]
        public static void Main()
        {
            var builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            IConfiguration config = builder.Build();

            new App(config).Run();
        }
    }
}
