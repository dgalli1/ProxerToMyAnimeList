using MALAPI;

namespace ProxerToMyAnimeList
{
    public class Animes
    {
        private string myProxID;
        private string myAnimeListID;
        private string myName;
        private MALAPI.API api;

        private enum myStatus
        {
            watched, watching, willbewatched, aborted
        }
        public Animes(string ProxID, MALAPI.API api)
        {
            this.myProxID = ProxID;
            this.api = api;
        }

        public void getMyAnimeListID()
        {
            //todo perform search on my anime list with name, save id in class 
        }
        public void AddtoMyAnimeList()
        {

        }
        public void generateMyAnimeListXML()
        {
            //maybe easier then implementing with the add function (and we wouldnt brutforce their server so hard)
        }
    }
}