using System.Windows;

namespace POE
{
    public partial class StepPopupWindow : Window
    {
        // Property for storing the step description
        public string StepDescription { get; set; }

        public StepPopupWindow()
        {
            InitializeComponent();
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            // Retrieve the step description from the StepDescriptionTextBox
            StepDescription = StepDescriptionTextBox.Text;

            // Set the DialogResult of the window to true, indicating that the step was entered
            DialogResult = true;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            // Set the DialogResult of the window to false, indicating that the operation was canceled
            DialogResult = false;
        }
    }
}