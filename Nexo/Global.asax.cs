using InsERT.Moria.Sfera;
using InsERT.Mox.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Routing;

namespace Nexo
{
    public class WebApiApplication : System.Web.HttpApplication
    {

        protected void Application_Start()
        {
            AppDomain.CurrentDomain.AssemblyResolve += NexoWrapper.LoadNexoReferences;

            GlobalConfiguration.Configure(WebApiConfig.Register);

            NexoWrapper.Init();
        }

    }
}
