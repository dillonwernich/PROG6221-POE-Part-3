using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace POE
{
    public partial class MainWindow : Window
    {
        private ArrayList recipes = new ArrayList(); // ArrayList to store recipes
        private Recipe selectedRecipe; // Currently selected recipe

        // Declare a delegate type to notify when a recipe exceeds 300 calories
        public delegate void RecipeCaloriesExceededDelegate(Recipe recipe);
        // Declare an event of type RecipeCaloriesExceededDelegate
        public event RecipeCaloriesExceededDelegate RecipeCaloriesExceeded;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void CreateRecipeButton_Click(object sender, RoutedEventArgs e)
        {
            // Check if recipe name is empty or null
            if (string.IsNullOrEmpty(RecipeNameTextBox.Text))
            {
                MessageBox.Show("Please enter the recipe name.");
                return;
            }

            // Check if ingredient count is empty or not a valid number
            if (string.IsNullOrEmpty(IngredientNumberTextBox.Text) || !int.TryParse(IngredientNumberTextBox.Text, out int ingredientCount))
            {
                MessageBox.Show("Please enter a valid number for the ingredient count.");
                return;
            }

            // Check if step count is empty or not a valid number
            if (string.IsNullOrEmpty(StepNumberTextBox.Text) || !int.TryParse(StepNumberTextBox.Text, out int stepCount))
            {
                MessageBox.Show("Please enter a valid number for the step count.");
                return;
            }

            // Create a new Recipe object and set its properties
            Recipe recipe = new Recipe();
            recipe.Name = RecipeNameTextBox.Text;
            recipe.IngredientCount = ingredientCount;
            recipe.StepCount = stepCount;

            // Loop to gather ingredients for the recipe
            for (int i = 0; i < recipe.IngredientCount; i++)
            {
                IngredientPopupWindow ingredientPopup = new IngredientPopupWindow();
                ingredientPopup.Owner = this;
                ingredientPopup.ShowDialog();

                // Check if ingredient popup dialog result is true (OK button clicked)
                if (ingredientPopup.DialogResult.HasValue && ingredientPopup.DialogResult.Value)
                {
                    Ingredient ingredient = new Ingredient();
                    ingredient.Name = ingredientPopup.IngredientName;
                    ingredient.Quantity = ingredientPopup.IngredientQuantity;
                    ingredient.UnitOfMeasurement = ingredientPopup.IngredientUnit;
                    ingredient.Calories = ingredientPopup.IngredientCalories;
                    ingredient.FoodGroup = ingredientPopup.IngredientFoodGroup;

                    ingredient.OriginalQuantity = ingredient.Quantity;

                    recipe.Ingredients.Add(ingredient);
                }
                else
                {
                    break;
                }
            }

            // Loop to gather steps for the recipe
            for (int i = 0; i < recipe.StepCount; i++)
            {
                StepPopupWindow stepPopup = new StepPopupWindow();
                stepPopup.Owner = this;
                stepPopup.ShowDialog();

                // Check if step popup dialog result is true (OK button clicked)
                if (stepPopup.DialogResult.HasValue && stepPopup.DialogResult.Value)
                {
                    Step step = new Step();
                    step.Description = stepPopup.StepDescription;

                    recipe.Steps.Add(step);
                }
                else
                {
                    break;
                }
            }

            // Calculate the total calories of the recipe
            int totalCalories = recipe.Ingredients.Sum(ingredient => ingredient.Calories);
            if (totalCalories > 300)
            {
                MessageBox.Show("Warning: The total calories of the recipe exceed 300.");
                // Trigger the RecipeCaloriesExceeded event
                RecipeCaloriesExceeded?.Invoke(recipe);
            }

            // Add the recipe to the recipes ArrayList
            recipes.Add(recipe);

            // Clear input fields
            RecipeNameTextBox.Text = string.Empty;
            IngredientNumberTextBox.Text = string.Empty;
            StepNumberTextBox.Text = string.Empty;
        }

        private void ListRecipeButton_Click(object sender, RoutedEventArgs e)
        {
            // Create a new instance of RecipeListWindow and pass the recipes ArrayList to it
            RecipeListWindow recipeListWindow = new RecipeListWindow(recipes);

            // Set the owner of the recipeListWindow to be this MainWindow
            recipeListWindow.Owner = this;

            // Subscribe to the SelectRecipe event of recipeListWindow and provide a callback method
            recipeListWindow.SelectRecipe += RecipeListWindow_SelectRecipe;

            // Show the recipeListWindow as a modal dialog and wait for the result
            bool? result = recipeListWindow.ShowDialog();

            // Check if the dialog result is true (OK button clicked)
            if (result.HasValue && result.Value)
            {
                // Retrieve the selected recipe from the recipeListWindow
                selectedRecipe = recipeListWindow.SelectedRecipe;

                // Clear the RecipeRichTextBox and display the selected recipe information
                RecipeRichTextBox.Document.Blocks.Clear();
                RecipeRichTextBox.AppendText($"Selected Recipe: {selectedRecipe.Name}\n\n");

                // Display the ingredients of the selected recipe
                RecipeRichTextBox.AppendText("Ingredients:\n");
                foreach (Ingredient ingredient in selectedRecipe.Ingredients)
                {
                    RecipeRichTextBox.AppendText($"- {ingredient.Name} ({ingredient.Quantity} {ingredient.UnitOfMeasurement})\n");
                }

                // Display the steps of the selected recipe
                RecipeRichTextBox.AppendText("\nSteps:\n");
                int stepNumber = 1;
                foreach (Step step in selectedRecipe.Steps)
                {
                    RecipeRichTextBox.AppendText($"{stepNumber}. {step.Description}\n");
                    stepNumber++;
                }
            }
        }

        private void FilterRecipesButton_Click(object sender, RoutedEventArgs e)
        {
            // Create a new instance of FilterWindow
            FilterWindow filterWindow = new FilterWindow();

            // Subscribe to the FilterRecipes event of filterWindow and provide a callback method
            filterWindow.FilterRecipes += FilterWindow_FilterRecipes;

            // Show the filterWindow as a modal dialog
            filterWindow.ShowDialog();
        }

        private void ScaleRecipeButton_Click(object sender, RoutedEventArgs e)
        {
            // Check if a recipe is selected
            if (selectedRecipe != null)
            {
                // Check if the scaling factor entered is a valid number
                if (double.TryParse(ScalingFactorTextBox.Text, out double scalingFactor))
                {
                    // Call the ScaleRecipe method to scale the selected recipe
                    ScaleRecipe(selectedRecipe, scalingFactor);
                }
                else
                {
                    MessageBox.Show("Invalid scaling factor. Please enter a numeric value.");
                }
            }
            else
            {
                MessageBox.Show("Please select a recipe first.");
            }
        }

        private void ResetQuantitiesButton_Click(object sender, RoutedEventArgs e)
        {
            // Check if a recipe is selected
            if (selectedRecipe != null)
            {
                // Call the ResetQuantities method to reset the quantities of the selected recipe
                ResetQuantities(selectedRecipe);
            }
            else
            {
                MessageBox.Show("Please select a recipe first.");
            }
        }

        private void ClearRecipeButton_Click(object sender, RoutedEventArgs e)
        {
            // Check if a recipe is selected
            if (selectedRecipe != null)
            {
                // Call the ClearRecipe method to clear the selected recipe
                ClearRecipe(selectedRecipe);
            }
            else
            {
                MessageBox.Show("Please select a recipe first.");
            }
        }

        private void RecipeListWindow_SelectRecipe(object sender, Recipe selectedRecipe)
        {
            // Update the selectedRecipe field with the newly selected recipe
            this.selectedRecipe = selectedRecipe;

            // Calculate the total calories of the selected recipe
            int totalCalories = selectedRecipe.Ingredients.Sum(ingredient => ingredient.Calories);
            if (totalCalories > 300)
            {
                MessageBox.Show("Warning: The total calories of the selected recipe exceed 300.");
            }

            // Enable the ScaleRecipeButton, ResetQuantitiesButton, and ClearRecipeButton
            ScaleRecipeButton.IsEnabled = true;
            ResetQuantitiesButton.IsEnabled = true;
            ClearRecipeButton.IsEnabled = true;

            // Display the selected recipe
            DisplayRecipe(selectedRecipe);
        }

        private void ScaleRecipe(Recipe recipe, double scalingFactor)
        {
            // Scale the quantities of ingredients in the recipe by the scaling factor
            foreach (Ingredient ingredient in recipe.Ingredients)
            {
                ingredient.Quantity *= scalingFactor;
            }

            // Display a success message
            MessageBox.Show("Recipe scaled successfully.");

            // Clear the ScalingFactorTextBox
            ScalingFactorTextBox.Text = string.Empty;

            // Display the updated recipe
            DisplayRecipe(recipe);
        }

        private void ResetQuantities(Recipe recipe)
        {
            // Reset the quantities of ingredients in the recipe to their original values
            foreach (Ingredient ingredient in recipe.Ingredients)
            {
                ingredient.Quantity = ingredient.OriginalQuantity;
            }

            // Display a success message
            MessageBox.Show("Quantities reset successfully.");

            // Display the updated recipe
            DisplayRecipe(recipe);
        }

        private void ClearRecipe(Recipe recipe)
        {
            // Remove the recipe from the recipes ArrayList
            recipes.Remove(recipe);

            // Clear the ingredients and steps of the recipe
            recipe.Ingredients.Clear();
            recipe.Steps.Clear();

            // Set the selectedRecipe to null
            selectedRecipe = null;

            // Display a success message
            MessageBox.Show("Recipe cleared and deleted successfully.");

            // Clear the RecipeRichTextBox
            RecipeRichTextBox.Document.Blocks.Clear();
        }

        private void DisplayRecipe(Recipe recipe)
        {
            // Clear the RecipeRichTextBox
            RecipeRichTextBox.Document.Blocks.Clear();

            // Display the name of the selected recipe
            RecipeRichTextBox.AppendText($"Selected Recipe: {recipe.Name}\n\n");

            // Display the ingredients of the recipe
            RecipeRichTextBox.AppendText("Ingredients:\n");
            foreach (Ingredient ingredient in recipe.Ingredients)
            {
                RecipeRichTextBox.AppendText($"- {ingredient.Name} ({ingredient.Quantity} {ingredient.UnitOfMeasurement})\n");
            }

            // Display the steps of the recipe
            RecipeRichTextBox.AppendText("\nSteps:\n");
            int stepNumber = 1;
            foreach (Step step in recipe.Steps)
            {
                RecipeRichTextBox.AppendText($"{stepNumber}. {step.Description}\n");
                stepNumber++;
            }
        }

        private void FilterWindow_FilterRecipes(object sender, FilterEventArgs e)
        {
            // Retrieve the filter criteria from the FilterEventArgs
            string ingredientName = e.IngredientName;
            string foodGroup = e.FoodGroup;
            int maximumCalories = e.MaximumCalories;

            // Convert the recipes ArrayList to a List<Recipe> for filtering
            List<Recipe> filteredRecipes = recipes.Cast<Recipe>().ToList();

            // Apply filters based on the provided criteria
            if (!string.IsNullOrEmpty(ingredientName))
            {
                // Filter recipes that contain the specified ingredient name
                filteredRecipes = filteredRecipes.Where(recipe =>
                    recipe.Ingredients.Any(ingredient => ingredient.Name.Equals(ingredientName))).ToList();
            }

            if (!string.IsNullOrEmpty(foodGroup))
            {
                // Filter recipes that contain ingredients from the specified food group
                filteredRecipes = filteredRecipes.Where(recipe =>
                    recipe.Ingredients.Any(ingredient => ingredient.FoodGroup.Equals(foodGroup))).ToList();
            }

            if (maximumCalories > 0)
            {
                // Filter recipes that have a total calorie count less than or equal to the specified maximum calories
                filteredRecipes = filteredRecipes.Where(recipe =>
                    recipe.Ingredients.Sum(ingredient => ingredient.Calories) <= maximumCalories).ToList();
            }

            // Update the filtered recipes
            UpdateFilteredRecipes(filteredRecipes);

            // Display a success message
            MessageBox.Show("Recipes filtered successfully.");
        }

        private void UpdateFilteredRecipes(List<Recipe> filteredRecipes)
        {
            // Clear the RecipeRichTextBox
            RecipeRichTextBox.Document.Blocks.Clear();

            if (filteredRecipes != null && filteredRecipes.Any())
            {
                // Display the header for filtered recipes
                RecipeRichTextBox.AppendText("Filtered Recipes:\n\n");

                // Display each filtered recipe
                foreach (Recipe recipe in filteredRecipes)
                {
                    // Display the name of the recipe
                    RecipeRichTextBox.AppendText($"Recipe: {recipe.Name}\n");

                    // Display the ingredients of the recipe
                    RecipeRichTextBox.AppendText("Ingredients:\n");
                    foreach (Ingredient ingredient in recipe.Ingredients)
                    {
                        RecipeRichTextBox.AppendText($"- {ingredient.Name} ({ingredient.Quantity} {ingredient.UnitOfMeasurement})\n");
                    }

                    // Display the steps of the recipe
                    RecipeRichTextBox.AppendText("\nSteps:\n");
                    int stepNumber = 1;
                    foreach (Step step in recipe.Steps)
                    {
                        RecipeRichTextBox.AppendText($"{stepNumber}. {step.Description}\n");
                        stepNumber++;
                    }

                    // Add an empty line between recipes
                    RecipeRichTextBox.AppendText("\n");
                }
            }
            else
            {
                // Display a message when no recipes are found
                RecipeRichTextBox.AppendText("No recipes found.");
            }
        }
    }
}
