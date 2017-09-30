using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace ProxerToMyAnimeList
{
   static class Proxer
    {
        private static string myUserId;
        private static string myUsername;
        private static List<Animes> list_animes=new List<Animes>();
        private static string myProxerAnimeList;
        private static MALAPI.API api;

        public static Boolean getWatchlist(string ProxerAnimeListUrl)
        {
            myProxerAnimeList = ProxerAnimeListUrl;
            WebClient wc = new WebClient();
           string str_html =wc.DownloadString(ProxerAnimeListUrl);
            var html = new HtmlDocument();
            html.LoadHtml(str_html);
            // Fizzler for HtmlAgilityPack is implemented as the 
            // QuerySelectorAll extension method on HtmlNode
            var document = html.DocumentNode;
            var div=document.SelectSingleNode("//div[@id='pageMetaAjax']");
            var inneruser=div.InnerText;
            myUsername=inneruser.Replace("Profil: ","").Replace(" - Proxer.Me","");
            var tableanimes = document.SelectNodes("//table[@id='box-table-a']");
            foreach (var table in tableanimes)
            {
                var anime_status=table.SelectSingleNode(".//th").InnerText;
                var tablecontent=table.SelectNodes(".//tr");
                foreach (var row_anime in tablecontent)
                {
                    var row_td_anime=row_anime.SelectNodes(".//td");
                    if (row_td_anime!=null&&row_td_anime.Count==6)
                    {
                        var anime_name_eng=row_td_anime[1].SelectSingleNode(".//a").InnerText;
                        var anime_id = row_td_anime[1].SelectSingleNode(".//a").Attributes["href"].Value.Replace("/info/", "").Replace("#top","");
                        var anime_episodes = row_td_anime[4].InnerText;
                        list_animes.Add(new Animes(anime_id, anime_name_eng, anime_status, anime_episodes));
                    }

                }
            }
            if(list_animes.Count>0)
            {
                return true;
            }
           


            return false;
            
            //todo parse proxer watchlist maybe i get a api key they  will talk about the api key next week
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
