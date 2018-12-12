using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CustomWebApp.Modules
{
    public class ImageModule : IHttpModule
    {
        public void Dispose() { }

        public void Init(HttpApplication appContext)
        {
            appContext.PostResolveRequestCache += (sender, args) =>
            {
                string controllerSegment = appContext.Context.Request.RequestContext.RouteData.Values["controller"].ToString();
                var idSegment = appContext.Context.Request.RequestContext.RouteData.Values["id"];

                if ((string.Equals(controllerSegment, "Image", StringComparison.OrdinalIgnoreCase) && idSegment != null))
                {
                    appContext.Context.RemapHandler(new ImageHandler());
                }
            };
        }
    }
}