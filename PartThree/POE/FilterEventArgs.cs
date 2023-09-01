using System;
using System.Collections.Generic;

namespace POE
{
    public class FilterEventArgs : EventArgs
    {
        // Properties for the filter criteria
        public string IngredientName { get; }
        public string FoodGroup { get; }
        public int MaximumCalories { get; }

        // Property for storing the filtered recipes
        public List<Recipe> FilteredRecipes { get; set; }

        // Constructor to initialize the filter criteria
        public FilterEventArgs(string ingredientName, string foodGroup, int maximumCalories)
        {
            IngredientName = ingredientName;
            FoodGroup = foodGroup;
            MaximumCalories = maximumCalories;
        }
    }
}