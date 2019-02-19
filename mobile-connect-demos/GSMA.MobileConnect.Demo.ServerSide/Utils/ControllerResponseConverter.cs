using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using RazorEngine;

namespace GSMA.MobileConnect.ServerSide.Web.Utils
{
    public class ControllerResponseConverter
    {

        public static HttpResponseMessage GetResponseMessage(dynamic model,  string viewPath, HttpStatusCode httpStatus = HttpStatusCode.OK)
        {
            var response = new HttpResponseMessage(httpStatus);
            var template = viewPath != null ? File.ReadAllText(Path.Combine(HttpRuntime.AppDomainAppPath, viewPath)) : null;
            string parseView = Razor.Parse(template, model);
            response.Content = new StringContent(parseView);
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("text/html");
            return response;
        }
    }
}