using CommunityToolkit.Mvvm.ComponentModel;
using GameGrabber.Model;
using GameGrabber.Repository;
using GameGrabber.View.UserControls;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameGrabber.ViewModel
{
    internal class OverviewVM : ObservableObject
    {
        private IGameRepository _gameRepository = null;

        private List<Game> _games;
        private List<Game> _allGames;

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

            // Subscribe to the Search event of the SearchBox UserControl
            SearchBox.Search += SearchBox_Search;
        }

        public async Task GetGamesAsync()
        {
            _allGames = await _gameRepository.GetGamesAsync();
            Games = _allGames;
        }

        private void SearchBox_Search(object sender, string searchQuery)
        {
            if (string.IsNullOrEmpty(searchQuery))
            {
                ShowAllGames();
                return;
            }

            _ = SearchGames(searchQuery);
        }

        private async Task SearchGames(string searchQuery)
        {
            // Convert the search query to lowercase for case-insensitive comparison
            string query = searchQuery.ToLowerInvariant();

            // Perform the search asynchronously on a separate thread
            List<Game> filteredGames = await Task.Run(() =>
            {
                return _allGames.Where(game => game.Title.ToLowerInvariant().Contains(query)).ToList();
            }).ConfigureAwait(true);

            // Update the Games property with the filtered games on the UI thread
            Games = filteredGames;
        }

        public void ShowAllGames()
        {
            Games = _allGames;
        }
    }
}
