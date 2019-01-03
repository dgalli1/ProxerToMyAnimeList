using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace ProxerToMyAnimeList
{
   static class AnimeHandler
    {
        private static string myUserId;
        private static string myUsername;
        public static List<Animes> list_animes=new List<Animes>();
        private static string myProxerAnimeList;
        public static MALAPI.API myAnimeListApi;
        public static string today = "09302017";
        public static List<Animes> not_found = new List<Animes>();
        public static MALAPI.Dto.UserList myuserlist;
        public static Boolean overwritte=false;

        public static Boolean getWatchlist(string ProxerAnimeListUrl)
        { 

            //fetch without api key from proxer 
            myProxerAnimeList = ProxerAnimeListUrl;
            WebClient wc = new WebClient();
           string str_html =wc.DownloadString(ProxerAnimeListUrl);
            var html = new HtmlDocument();
            html.LoadHtml(str_html);
            var document = html.DocumentNode;
            var div=document.SelectSingleNode("//div[@id='pageMetaAjax']");
            if(div==null)
            {
                return false;
            }
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
        }

        public static void exportXML()
        {
            
            

        }
        public static bool authenticate(string username, string password)
        {
            try
            {
                myAnimeListApi = new MALAPI.API(username, password); //now throws exception
                return true;
            }
            catch
            {
                return false;
            }
            return false;
        }
        public static async void Add()
        {
            myuserlist = await myAnimeListApi.GetUserListAsync();

            foreach (Animes item in list_animes)
            {
                item.AddtoMyAnimeList();
            }
        }
        public static async void RemoveAll()
        {
            foreach (MALAPI.Dto.UserAnime item in myuserlist.Animes)
            {

                var wtf = await myAnimeListApi.DeleteAnime(item.SeriesId);
            }

        }

    }
}
