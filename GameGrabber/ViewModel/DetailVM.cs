using CommunityToolkit.Mvvm.Input;
using System;

namespace GameGrabber.ViewModel
{
    internal class DetailVM
    {
        public RelayCommand BackCommand { get; private set; }

        public static event EventHandler Back;

        public DetailVM()
        {
            BackCommand = new RelayCommand(() => Back?.Invoke(null, EventArgs.Empty));
        }
    }
}
