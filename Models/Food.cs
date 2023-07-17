namespace detritusdiet.Models
{
    public class Food
    {
        public int FoodId { get; set; }
        public string Name { get; set; }

        public int MealId { get; set; }
        public Meal Meal { get; set; }
    }
}
