using Microsoft.Extensions.Configuration;

namespace AppWithConfiguration
{
    internal static class AppSettingsExtensions
    {
        public static int GetWindowHeight(this IConfiguration self)
        {
            string path = "Height";
            var p = self[path];
            if (Int32.TryParse(p, out int v))
            {
                return v;
            }
            else
            {
                throw new Exception($"Not found value for Height");
            }
        }
    }
}
