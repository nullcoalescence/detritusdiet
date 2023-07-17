using detritusdiet.Models;

namespace detritusdiet.DataAccessLayer
{
    public interface IMealRepository : IDisposable
    {
        IEnumerable<Meal> GetAllMeals();
        Meal GetMealById(int mealId);
        void InsertMeal(Meal meal);
        void DeleteMeal(int mealId);
        void UpdateMeal(Meal meal);
        void Save();
    }
}
