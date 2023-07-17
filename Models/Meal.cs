namespace detritusdiet.Models
{
    public class Meal
    {
        public int MealId { get; set; }
        public DateTime DateAdded { get; set; }
        public List<Food> Foods { get; } = new();
    }
}
