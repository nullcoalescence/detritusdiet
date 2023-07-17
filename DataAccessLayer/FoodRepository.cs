using detritusdiet.Db;
using detritusdiet.Models;

using Microsoft.EntityFrameworkCore;

namespace detritusdiet.DataAccessLayer
{
    public class FoodRepository : IFoodRepository, IDisposable
    {
        private DietContext context;

        private bool disposed = false;

        public FoodRepository(DietContext context)
        {
            this.context = context;
        }

        public IEnumerable<Food> GetAllFoods()
        {
            return this.context.Foods.ToList();
        }

        public Food GetFoodById(int foodId)
        {
            return this.context.Foods.Find(foodId);
        }

        public void InsertFood(Food food)
        {
            this.context.Foods.Add(food);
        }

        public void DeleteFood(int foodId)
        {
            Food food = this.context.Foods.Find(foodId);
            this.context.Foods.Remove(food);
        }

        public void UpdateFood(Food food)
        {
            this.context.Entry(food).State = EntityState.Modified;
        }

        public void Save()
        {
            this.context.SaveChanges();
        }

        // GC
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    this.context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
