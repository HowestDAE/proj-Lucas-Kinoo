using CommunityToolkit.Mvvm.ComponentModel;
using GameGrabber.Model;
using GameGrabber.Repository;
using GameGrabber.View.UserControls;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameGrabber.ViewModel
{
    internal class OverviewVM : ObservableObject
    {
        private IGameRepository _gameRepository = null;

        private List<Game> _games;
        private List<Game> _allGames;
        private Game _selectedGame;

        public Game SelectedGame
        {
            get { return _selectedGame; }
            set
            {
                _selectedGame = value;
                OnPropertyChanged(nameof(SelectedGame));
            }
        }

        public bool UseLocalRepository
        {
            get { return _gameRepository is GameRepositoryLocal; }
            set
            {
                if (value)
                {
                    _gameRepository = new GameRepositoryLocal();
                }
                else
                {
                    _gameRepository = new GameRepositoryOnline();
                }
                _ = GetGamesAsync();
            }
        }

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
            UseLocalRepository = false;

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
            _ = SearchGames(searchQuery.ToString());
        }

        private async Task SearchGames(string searchQuery)
        {
            // Perform the search asynchronously on a separate thread
            List<Game> filteredGames = await Task.Run(() =>
            {
                // Use List<T> constructor with capacity to optimize memory allocation
                List<Game> results = new List<Game>(_allGames.Count);

                // Use foreach loop for better readability and potential performance improvement
                foreach (Game game in _allGames)
                {
                    // Use string.IndexOf instead of string.Contains for case-insensitive search
                    if (game.Title.IndexOf(searchQuery, StringComparison.OrdinalIgnoreCase) >= 0)
                    {
                        results.Add(game);
                    }
                }

                return results;
            }).ConfigureAwait(false);

            // Update the Games property with the filtered games on the UI thread
            Games = filteredGames;
        }

        public void ShowAllGames()
        {
            Games = _allGames;
        }
    }
}
