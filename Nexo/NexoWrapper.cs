using InsERT.Moria.Sfera;
using InsERT.Mox.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace Nexo
{
    public class NexoWrapper
    {
        /// <summary>
        /// Serwer bazy danych
        /// </summary>
        private const string SERVER = "";
        /// <summary>
        /// Baza danych podmiotu
        /// </summary>
        private const string DATABASE = "";
        /// <summary>
        /// Scieżka gdzie znajdują się binaria podmiotu
        /// </summary>
        private const string NEXO_PATH = @"";

        public static Uchwyt Uchwyt = null;

        public static void Init()
        {

            DanePolaczenia danePolaczenia = DanePolaczenia.Jawne(SERVER, DATABASE, true);
            MenedzerPolaczen mp = new MenedzerPolaczen();
            Uchwyt = mp.Polacz(danePolaczenia, ProductId.Subiekt);
            Uchwyt.ZalogujOperatora("Szef", "robocze");
        }

        /// <summary>
        /// Załaduj dll które są potrzebne do uruchomienia sfery NEXO
        /// </summary>
        public static Assembly LoadNexoReferences(object sender, ResolveEventArgs args)
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