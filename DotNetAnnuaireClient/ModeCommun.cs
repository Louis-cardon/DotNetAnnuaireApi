using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using DotNetAnnuaireClient.ViewModel;

namespace DotNetAnnuaireClient
{
    static class ModeCommun
    {
        public static HttpClient client;

        public static Salarie CurrentUser;
    }
}
