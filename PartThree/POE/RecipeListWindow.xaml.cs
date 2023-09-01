using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace POE
{
    public partial class RecipeListWindow : Window
    {
        // Property for storing the selected recipe
        public Recipe SelectedRecipe { get; private set; }

        public RecipeListWindow(ArrayList recipes)
        {
            InitializeComponent();

            // Sort the recipes alphabetically by name
            List<Recipe> sortedRecipes = recipes.Cast<Recipe>().OrderBy(recipe => recipe.Name).ToList();

            // Set the sorted recipes as the ItemsSource for the RecipesListBox
            RecipesListBox.ItemsSource = sortedRecipes;
        }

        private void SelectRecipeButton_Click(object sender, RoutedEventArgs e)
        {
            if (RecipesListBox.SelectedItem != null)
            {
                // Retrieve the selected recipe from the RecipesListBox
                SelectedRecipe = (Recipe)RecipesListBox.SelectedItem;

                // Invoke the SelectRecipe event and pass the selected recipe
                SelectRecipe?.Invoke(this, SelectedRecipe);

                // Set the DialogResult of the window to true, indicating that the recipe was selected
                DialogResult = true;
            }
            else
            {
                MessageBox.Show("Please select a recipe.");
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            // Set the DialogResult of the window to false, indicating that the operation was canceled
            DialogResult = false;
        }

        // Event declaration for selecting a recipe
        public event EventHandler<Recipe> SelectRecipe;
    }
}