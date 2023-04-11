using CommunityToolkit.Mvvm.Input;
using GameGrabber.View;
using System;
using System.Windows.Controls;

namespace GameGrabber.ViewModel
{
    internal class MainVM
    {
        public MainVM()
        {
            CurrentPage = OverviewPage;
            SwitchPageCommand = new RelayCommand(SwitchPage);
        }

        public Page CurrentPage { get; private set; }
        public RelayCommand SwitchPageCommand { get; private set; }

        public OverviewPage OverviewPage { get; } = new OverviewPage();

        private void SwitchPage()
        {
            throw new NotImplementedException();
        }
    }
}
