using CommunityToolkit.Mvvm.ComponentModel;
using GameGrabber.Model;
using GameGrabber.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameGrabber.ViewModel
{
    internal class OverviewVM : ObservableObject
    {
        private IGameRepository _gameRepository = null;

        private List<Game> _games;

        public List<Game> Games
        {
            get { return _games; }
            set
            {
                _games = value;
                OnPropertyChanged(nameof(Games));
            }
        }

        public OverviewVM()
        {
            _gameRepository = new GameRepositoryOnline();
            _ = GetGamesAsync();
        }

        public async Task GetGamesAsync()
        {
            Games = await _gameRepository.GetGamesAsync();
        }
    }
}
