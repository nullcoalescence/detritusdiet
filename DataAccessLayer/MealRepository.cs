using detritusdiet.Db;
using detritusdiet.Models;

using Microsoft.EntityFrameworkCore;

namespace detritusdiet.DataAccessLayer
{
    public class MealRepository : IMealRepository, IDisposable
    {
        private DietContext context;

        private bool disposed = false;

        public MealRepository(DietContext context)
        {
            this.context = context;
        }

        public IEnumerable<Meal> GetAllMeals()
        {
            return this.context.Meals.ToList();
        }

        public Meal GetMealById(int mealId)
        {
            return this.context.Meals.Find(mealId);
        }

        public void InsertMeal(Meal meal)
        {
            this.context.Meals.Add(meal);
        }

        public void DeleteMeal(int mealId)
        {
            Meal meal = this.context.Meals.Find(mealId);
            this.context.Meals.Remove(meal);
        }

        public void UpdateMeal(Meal meal)
        {
            this.context.Entry(meal).State = EntityState.Modified;
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
