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
        public static Uchwyt Uchwyt = null;

        /// <summary>
        /// Serwer bazy danych
        /// </summary>
        private const string SERVER = "";
        /// <summary>
        /// Baza danych podmiotu
        /// </summary>
        private const string DATABASE = "";
        /// <summary>
        /// Scie¿ka gdzie znajduj¹ siê binaria podmiotu
        /// </summary>
        private const string NEXO_PATH = @"";

        protected void Application_Start()
        {
            AppDomain.CurrentDomain.AssemblyResolve += LoadNexoReferences;

            GlobalConfiguration.Configure(WebApiConfig.Register);

            DanePolaczenia danePolaczenia = DanePolaczenia.Jawne(SERVER, DATABASE, true);
            MenedzerPolaczen mp = new MenedzerPolaczen();
            Uchwyt = mp.Polacz(danePolaczenia, ProductId.Subiekt);
            Uchwyt.ZalogujOperatora("Szef", "robocze");
        }

        /// <summary>
        /// Za³aduj dll które s¹ potrzebne do uruchomienia sfery NEXO
        /// </summary>
        private Assembly LoadNexoReferences(object sender, ResolveEventArgs args)
        {
            Assembly assembly = null;
            string name = args.Name.Split(',')[0] + ".dll";

            if (name == "InsERT.Moria.Security.Core.dll")
            {
                assembly = Assembly.LoadFrom(string.Format(@"{0}\x86\{1}", NEXO_PATH, name));
            }
            else if (name.EndsWith("resources.dll") == false)
            {
                assembly = Assembly.LoadFrom(string.Format(@"{0}\{1}", NEXO_PATH, name));
            }

            return assembly;

            throw new NotImplementedException();
        }
    }
}
