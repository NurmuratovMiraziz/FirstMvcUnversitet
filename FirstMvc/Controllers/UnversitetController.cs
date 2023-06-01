using FirstMvc.DbContexts;
using FirstMvc.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FirstMvc.Controllers
{
    public class UnversitetController : Controller
    {
        AppDbContexts dbContexts;

        public UnversitetController(AppDbContexts dbContexts)
        {
            this.dbContexts = dbContexts;
        }

        public IActionResult Index()
        {
            return View(dbContexts.Unversitetlar.Include(p => p.Talabas).ToList());
        }

        public IActionResult Create() 
        {
            return View();
        }

        public async Task<IActionResult> AddUnversitet(Unversitet unversitet)
        {
            await dbContexts.Unversitetlar.AddAsync(unversitet);
            await dbContexts.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            return View(dbContexts.Unversitetlar.Include(p => p.Talabas)
                .FirstOrDefault(unversitetId => unversitetId.Id == id));
        }

        public IActionResult Edit(int id)
        {
            var unversitet = dbContexts.Unversitetlar.FirstOrDefault(unversitetId => unversitetId.Id == id);

            return View(unversitet);
        }

        public async Task<IActionResult> UpdateUnversitet(Unversitet unversitet)
        {
            if (ModelState.IsValid)
            {
                dbContexts.Entry(unversitet).State = EntityState.Modified;
                await dbContexts.SaveChangesAsync();

                return RedirectToAction("Index");
            }
            return View(unversitet);
        }


        public IActionResult Delete(int id)
        {
            var unversitet = dbContexts.Unversitetlar .FirstOrDefault(unversitetId => unversitetId.Id == id);

            return View();
        }

        public async Task<IActionResult> DeleteUnvertsitet(Unversitet unversitet)
        {
            dbContexts.Unversitetlar.Remove(unversitet);
            await dbContexts.SaveChangesAsync();

            return RedirectToAction("Index");
        }

    }
}
