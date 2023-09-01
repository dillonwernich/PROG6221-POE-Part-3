using System.Collections.Generic;

namespace POE
{
    public class Recipe
    {
        // Properties of a recipe
        public string Name { get; set; }
        public int IngredientCount { get; set; }
        public int StepCount { get; set; }
        public List<Ingredient> Ingredients { get; set; } = new List<Ingredient>();
        public List<Step> Steps { get; set; } = new List<Step>();
    }
}