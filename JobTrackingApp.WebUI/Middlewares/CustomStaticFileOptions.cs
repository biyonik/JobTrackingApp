using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.FileProviders;

namespace JobTrackingApp.WebUI.Middlewares
{
    public static class CustomStaticFileOptions
    {
        public static StaticFileOptions GetFileOptions(IApplicationBuilder app, IWebHostEnvironment env, string path)
        {
            string root = Path.Combine(env.ContentRootPath,  path);
            return new StaticFileOptions()
            {
                FileProvider = new PhysicalFileProvider(root),
                RequestPath = "/"+path
            };
        }
    }
}