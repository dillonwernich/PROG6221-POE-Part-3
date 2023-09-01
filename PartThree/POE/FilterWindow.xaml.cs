using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace POE
{
    /// <summary>
    /// Interaction logic for FilterWindow.xaml
    /// </summary>
    public partial class FilterWindow : Window
    {
        public event EventHandler<FilterEventArgs> FilterRecipes;

        public FilterWindow()
        {
            InitializeComponent();
        }

        private void FilterButton_Click(object sender, RoutedEventArgs e)
        {
            // Get the values entered in the text boxes
            string ingredientName = IngredientNameTextBox.Text;
            string foodGroup = FoodGroupTextBox.Text;
            int maximumCalories = 0;

            // Parse the maximum calories value if it is not empty
            if (!string.IsNullOrEmpty(MaximumCaloriesTextBox.Text))
            {
                int.TryParse(MaximumCaloriesTextBox.Text, out maximumCalories);
            }

            // Create a new instance of FilterEventArgs with the entered values
            FilterEventArgs filterEventArgs = new FilterEventArgs(ingredientName, foodGroup, maximumCalories);

            // Invoke the FilterRecipes event and pass the FilterEventArgs object
            FilterRecipes?.Invoke(this, filterEventArgs);

            // Close the filter window
            Close();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            // Close the filter window
            Close();
        }
    }
}