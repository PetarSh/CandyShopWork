using CandyShop.Models;
using CandyShop.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CandyShop.Controllers
{
    public class CandyController : Controller
    {
        private readonly ICandyRepository candyR;
        private readonly ICategoryRepository categoryR;

        public CandyController(ICandyRepository candyRepository, ICategoryRepository categoryRepository)
        {
            candyR = candyRepository;
            categoryR = categoryRepository;
        }

        public IActionResult List(string category)
        {
            IEnumerable<Candy> candies;
            string currentCategory;

            if (string.IsNullOrEmpty(category))
            {
                candies = candyR.GetAllCandy.OrderBy(c => c.CandyId);
                currentCategory = "All Candy";
            }
            else
            {
                candies = candyR.GetAllCandy.Where(c => c.Category.CategoryName == category);

                currentCategory = categoryR.GetAllCategories.FirstOrDefault(c => c.CategoryName == category)?.CategoryName;
            }

            return View(new CandyListVM
            {
                Candies = candies,
                currentCategory = currentCategory
            });
        }

        public IActionResult Details(int id)
        {
            var candy = candyR.GetCandyById(id);
            if (candy == null)
                return NotFound();

            return View(candy);
        }
    }
}
