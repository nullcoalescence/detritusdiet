using detritusdiet.Models;

namespace detritusdiet.DataAccessLayer
{
    public interface IFoodRepository : IDisposable
    {
        IEnumerable<Food> GetAllFoods();
        Food GetFoodById(int foodId);
        void InsertFood(Food food);
        void DeleteFood(int foodId);
        void UpdateFood(Food food);
        void Save();
    }
}
