namespace POE
{
    public class Ingredient
    {
        // Properties of an ingredient
        public string Name { get; set; }
        public double Quantity { get; set; }
        public string UnitOfMeasurement { get; set; }
        public int Calories { get; set; }
        public string FoodGroup { get; set; }
        public double OriginalQuantity { get; set; }

        // Default constructor
        public Ingredient() { }

        // Constructor with parameters to initialize the ingredient properties
        public Ingredient(string name, double quantity, string unitOfMeasurement, int calories, string foodGroup, double originalQuantity)
        {
            Name = name;
            Quantity = quantity;
            UnitOfMeasurement = unitOfMeasurement;
            Calories = calories;
            FoodGroup = foodGroup;
            OriginalQuantity = originalQuantity;
        }
    }
}