using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

namespace CustomWebApp.Modules
{
    public class ImageHandler : IHttpHandler
    {
        public bool IsReusable => false;


        public void ProcessRequest(HttpContext context)
        {
            var imageName = context.Request.RequestContext.RouteData.Values["id"];
            string appPath = HttpRuntime.AppDomainAppPath;
            string path = $@"{appPath}\Images\{imageName}.jpg";

            if (!File.Exists(path))
            {
                context.Response.Write("Image does not exist");
            }
            else
            {
                context.Response.ContentType = "image/jpg";
                byte[] image = File.ReadAllBytes(path);
                context.Response.BinaryWrite(image);
            }
        }
    }
}