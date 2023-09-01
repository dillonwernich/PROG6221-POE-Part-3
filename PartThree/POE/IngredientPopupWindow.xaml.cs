using System.Windows;

namespace POE
{
    public partial class IngredientPopupWindow : Window
    {
        // Properties for storing the ingredient information entered in the popup window
        public string IngredientName { get; set; }
        public double IngredientQuantity { get; set; }
        public string IngredientUnit { get; set; }
        public int IngredientCalories { get; set; }
        public string IngredientFoodGroup { get; set; }

        public IngredientPopupWindow()
        {
            InitializeComponent();
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            // Retrieve the values entered in the text boxes and assign them to the corresponding properties
            IngredientName = IngredientNameTextBox.Text;
            IngredientQuantity = double.Parse(IngredientQuantityTextBox.Text);
            IngredientUnit = IngredientUnitTextBox.Text;
            IngredientCalories = int.Parse(IngredientCaloriesTextBox.Text);
            IngredientFoodGroup = IngredientFoodGroupTextBox.Text;

            // Set the DialogResult of the popup window to true
            DialogResult = true;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            // Set the DialogResult of the popup window to false
            DialogResult = false;
        }
    }
}