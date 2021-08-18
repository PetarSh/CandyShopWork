using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CandyShop.Models
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext dbContext;
        public CategoryRepository(AppDbContext appDbContext)
        {
            dbContext = appDbContext;
        }
        public IEnumerable<Category> GetAllCategories => dbContext.Categories;


    }
}
