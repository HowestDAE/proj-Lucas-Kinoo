using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace GameGrabber.View.UserControls
{
    public partial class SearchBox : UserControl
    {
        // Define the search event
        public static event EventHandler<string> Search;

        public SearchBox()
        {
            InitializeComponent();

            txtInput.KeyUp += TxtInput_KeyUp;
        }

        private void txtInput_IsKeyboardFocusedChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (txtInput.IsKeyboardFocused)
            {
                // Show the clear button
                tbPlaceholder.Visibility = Visibility.Hidden;
            }
            else
            {
                if (!string.IsNullOrEmpty(txtInput.Text)) return;

                // Hide the clear button
                tbPlaceholder.Visibility = Visibility.Visible;
            }
        }

        private void txtInput_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtInput.Text))
            {
                // Show the clear button
                tbPlaceholder.Visibility = Visibility.Visible;
            }
            else
            {
                // Hide the clear button
                tbPlaceholder.Visibility = Visibility.Hidden;
            }
        }

        private void TxtInput_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter && txtInput.IsKeyboardFocused)
            {
                // Raise the search event with the search query as an argument
                OnSearch(txtInput.Text);
            }
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            // Raise the search event with the search query as an argument
            OnSearch(txtInput.Text);
        }

        private void OnSearch(string searchQuery)
        {
            if (string.IsNullOrEmpty(txtInput.Text))
            {
                tbPlaceholder.Visibility = Visibility.Visible;
                return;
            }

            Search?.Invoke(null, searchQuery);
        }
    }
}
