using MALAPI;
using System;
using System.Threading.Tasks;

namespace ProxerToMyAnimeList
{
    public class Animes
    {
        private string myProxID;
        private string myAnimeListID;
        private string myNameDeu;
        private string myEpisodeStart;
        private string myEpisodeEnd; 

        private enum EnumMyStatus
        {
            watched, watching, willbewatched, aborted
        }
        private EnumMyStatus myStatus;



        public Animes(string anime_id, string anime_name_eng, string anime_status, string anime_episodes)
        {
            this.myProxID = anime_id;
            this.myNameDeu = anime_name_eng; //not sure what lang this name is i guess if german exits german otherwhise eng
            setStatus(anime_status);
            myEpisodeStart = anime_episodes.Substring(0,anime_episodes.IndexOf("/")-1).Replace(" ","");
            myEpisodeEnd = anime_episodes.Substring(anime_episodes.IndexOf("/")+1).Replace(" ", "");
        }

        private void setStatus(string status)
        {
            switch(status)
            {
                case "Geschaut":
                    myStatus = EnumMyStatus.watched;
                    break;
                case "Am Schauen":
                    myStatus = EnumMyStatus.watching;
                    break;
                case "Wird noch geschaut":
                    myStatus = EnumMyStatus.willbewatched;
                    break;
                case "Abgebrochen":
                    myStatus = EnumMyStatus.aborted;
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
        public void AddtoMyAnimeList()
        {
            Task<MALAPI.Dto.SearchResult> results=Proxer.myAnimeListApi.SearchForAsync(myNameDeu);
            results.RunSynchronously();
            foreach (var item in results.Result.Entries)
            {

            }
            Console.WriteLine("lol");
            
        }
        public void generateMyAnimeListXML()
        {
            //maybe easier then implementing with the add function (and we wouldnt ddos their server so hard)
        }
    }
}