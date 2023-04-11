using GameGrabber.Model;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace GameGrabber.Repository
{
    internal class GameRepositoryOnline : IGameRepository
    {
        private const string RequestUri = "https://www.gamerpower.com/api/giveaways?sort-by=value";
        private List<Game> _games = null;

        private async Task LoadGames()
        {
            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync(RequestUri);
                var content = await response.Content.ReadAsStringAsync();
                _games = JsonConvert.DeserializeObject<List<Game>>(content);
            }
        }

        public async Task<List<Game>> GetGamesAsync()
        {
            if (_games == null)
            {
                await LoadGames();
            }

            return _games;
        }
    }
}
