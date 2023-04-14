using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GameGrabber.Model;
using System;

namespace GameGrabber.ViewModel
{
    internal class DetailVM : ObservableObject
    {
        public RelayCommand BackCommand { get; private set; }

        public static event EventHandler Back;

        private Game _game;

        public Game Game
        {
            get { return _game; }
            set
            {
                _game = value;
                OnPropertyChanged(nameof(Game));
            }
        }

        public DetailVM()
        {
            BackCommand = new RelayCommand(() => Back?.Invoke(null, EventArgs.Empty));
        }
    }
}
