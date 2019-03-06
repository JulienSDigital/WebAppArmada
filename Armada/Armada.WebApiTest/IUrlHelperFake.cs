using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using System;
using System.Collections.Generic;
using System.Text;

namespace Armada.WebApiTest
{
    class IUrlHelperFake : IUrlHelper
    {
        public ActionContext ActionContext => throw new NotImplementedException();

        public string Action(UrlActionContext actionContext)
        {
            return "";
        }

        public string Content(string contentPath)
        {
            return "";
        }

        public bool IsLocalUrl(string url)
        {
            return false;
        }

        public string Link(string routeName, object values)
        {
            return "";
        }

        public string RouteUrl(UrlRouteContext routeContext)
        {
            return "";
        }
    }
}
