using HtmlAgilityPack;
using MALAPI;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace ProxerToMyAnimeList
{
    public class Animes
    {
        private string myProxID;
        private string myAnimeListID;
        private string myNameDeu;
        private string myEpisodeWatchedTill;
        private string myEpisodeTotal;
        private Boolean myfound;
        private List<MALAPI.Dto.SearchResult> mySearchResults = new List<MALAPI.Dto.SearchResult>();

        private enum EnumMyStatus
        {
             watching, completed,onhold,dropped, plantowatch
        }
        private EnumMyStatus myStatus;



        public Animes(string anime_id, string anime_name_eng, string anime_status, string anime_episodes)
        {
            this.myProxID = anime_id;
            this.myNameDeu = anime_name_eng; //not sure what lang this name is i guess if german exits german otherwhise eng
            setStatus(anime_status);
            myEpisodeWatchedTill = anime_episodes.Substring(0,anime_episodes.IndexOf("/")-1).Replace(" ","");
            myEpisodeTotal = anime_episodes.Substring(anime_episodes.IndexOf("/")+1).Replace(" ", "");
        }

        private void setStatus(string status)
        {
            switch(status)
            {
                case "Geschaut":
                    myStatus = EnumMyStatus.completed;
                    break;
                case "Am Schauen":
                    myStatus = EnumMyStatus.watching;
                    break;
                case "Wird noch geschaut":
                    myStatus = EnumMyStatus.plantowatch;
                    break;
                case "Abgebrochen":
                    myStatus = EnumMyStatus.dropped;
                    break;
                default:
                    throw (new Exception("Unbekannter Anime Status"));
                    break;
            }
        }
        public void getMyAnimeListID()
        {
            //todo perform search on my anime list with name, save id in class 
        }
        public async void AddtoMyAnimeList()
        {
            MALAPI.Dto.SearchResult results=  await AnimeHandler.myAnimeListApi.SearchForAsync(myNameDeu);
            var entries=results.Entries;
            Boolean found = false;
            foreach (var item in entries)
            {
                if(item.EnglishTitle.ToLower()==myNameDeu.ToLower()||item.Title.ToLower()==myNameDeu.ToLower()||item.Synonyms.ToLower()==myNameDeu.ToLower()) //this is why we need the japanese Title
                {
                    var Anime = new MALAPI.Dto.Anime();
                    Anime.Status = myStatus.ToString();
                    Anime.Episode = Int32.Parse(myEpisodeWatchedTill);
                    Anime.DateStart = DateTime.Today;
                    Anime.DateEnd = DateTime.Today;
                    Anime.Priority = 0;
                    Anime.EnableDiscussion = 0;
                    Anime.EnableRewatching = 0;
                    Anime.RewatchValue = 0;
                    var add_result = await AnimeHandler.myAnimeListApi.AddAnime(Anime, item.Id);
                    found = true;
                }
            }

            
        }
        private async void SearchOnMyAnimeListAsync(string search)
        {
            MALAPI.Dto.SearchResult results = await AnimeHandler.myAnimeListApi.SearchForAsync(search);
            var entries = results.Entries;
            foreach (var item in entries)
            {
                if (item.EnglishTitle.ToLower() == search.ToLower() || item.Title.ToLower() == search.ToLower() || item.Synonyms.ToLower() == search.ToLower()) //this is why we need the japanese Title
                {
                    var Anime = new MALAPI.Dto.Anime();
                    myAnimeListID = item.Id+"";
                    Anime.Status = myStatus.ToString();
                    Anime.Episode = Int32.Parse(myEpisodeWatchedTill);
                    Anime.DateStart = DateTime.Today;
                    Anime.DateEnd = DateTime.Today;
                    Anime.Priority = 0;
                    Anime.EnableDiscussion = 0;
                    Anime.EnableRewatching = 0;
                    Anime.RewatchValue = 0;
                    var add_result = await AnimeHandler.myAnimeListApi.AddAnime(Anime, item.Id);
                    myfound = true;
                }
            }
            if(!myfound)
            {
                //todo get japanese Title from Proxer
                myfound = true;
                WebClient wc = new WebClient();
                string str_html = wc.DownloadString(getlink());
                var html = new HtmlDocument();
                html.LoadHtml(str_html);
                var document = html.DocumentNode;
                var tablecontents = document.SelectNodes("//table[@class='details'].//tbody.//tr.//td");
                if (tablecontents == null)
                {
                    AnimeHandler.not_found.Add(this);
                    return;
                }
                Console.WriteLine(tablecontents.Count);
                SearchOnMyAnimeListAsync("");
            }
            if(myAnimeListID=="")
            {
                AnimeHandler.not_found.Add(this);
            }

        }
        private string getlink()
        {
            return @"https://proxer.me/info/" + "myProxID";
        }
        public void generateMyAnimeListXML()
        {
            //maybe easier then implementing with the add function (and we wouldnt ddos their server so hard)
        }
    }
}