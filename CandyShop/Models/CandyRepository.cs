using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CandyShop.Models
{
    public class CandyRepository : ICandyRepository
    {
        private readonly AppDbContext dbContext;

        public CandyRepository(AppDbContext appDbContext)
        {
            dbContext = appDbContext;
        }
        public IEnumerable<Candy> GetAllCandy
        {
            get
            {
                return dbContext.Candies.Include(c=>c.Category);
            }
        }

        public IEnumerable<Candy> GetCandyOnSale
        {
            get
            {
                return dbContext.Candies.Include(c => c.Category).Where(p=>p.IsOnSale);
            }
            
        }

        public Candy GetCandyById(int candyId)
        {
            return dbContext.Candies.FirstOrDefault(c => c.CandyId == candyId);
        }
    }
}
