using GameGrabber.Model;
using GameGrabber.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameGrabber.ViewModel
{
    internal class OverviewVM
    {
        private IGameRepository _gameRepository = null;
        public List<Game> Games { get; private set; }

        public OverviewVM()
        {
            _gameRepository = new GameRepositoryLocal();
            _ = GetGamesAsync();
        }

        public async Task GetGamesAsync()
        {
            Games = await _gameRepository.GetGamesAsync();
        }
    }
}
