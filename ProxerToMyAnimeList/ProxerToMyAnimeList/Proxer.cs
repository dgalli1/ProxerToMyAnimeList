using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ProxerToMyAnimeList
{
   static class Proxer
    {
        private static string myUserId;
        private static List<Animes> animes;
        private static string myProxerAnimeList;
        
        public static Boolean getWatchlist(string ProxerAnimeListUrl)
        {
            myProxerAnimeList = ProxerAnimeListUrl;
            WebClient wc = new WebClient();

            


            return false;
            
            //todo parse proxer watchlist maybe i get a api key
            //todo performe a query for every single anime to get the japanese original title (i guess it will result in less errors)
        }

        public static void export(Boolean xmlexport)
        {
            MALAPI.API AmimeListApi;
            if (xmlexport)
            {
                AmimeListApi = new MALAPI.API();
            }

            //todo add to anime list

            //new Animes(389925,)
        }

    }
}
