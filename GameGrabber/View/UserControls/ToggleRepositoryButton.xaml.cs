using GameGrabber.ViewModel;
using System.Windows;
using System.Windows.Controls;

namespace GameGrabber.View.UserControls
{
    public partial class ToggleRepositoryButton : UserControl
    {
        public ToggleRepositoryButton()
        {
            InitializeComponent();
        }

        private void btnToggleRepo_Click(object sender, RoutedEventArgs e)
        {
            // Get the OverviewVM from the DataContext
            OverviewVM overviewVM = (OverviewVM)DataContext;
            // Toggle the UseLocalRepository property
            overviewVM.UseLocalRepository = !overviewVM.UseLocalRepository;
            // Update the button text
            btnToggleRepo.Content = overviewVM.UseLocalRepository ? "📂" : "🌐";
        }
    }
}
