using FirstMvc.DbContexts;
using FirstMvc.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FirstMvc.Controllers
{
    public class TalabaController : Controller
    {
        AppDbContexts dbContext;

        public TalabaController(AppDbContexts dbContext)
        {
            this.dbContext = dbContext;
        }

        public IActionResult Index()
        {
            return View(dbContext.Talabas.ToList());
        }

        public IActionResult Create()
        {
            var unversitet = dbContext.Unversitetlar.Select(unversitet => 
            new { 
                Id = unversitet.Id, 
                Nomi = unversitet.Name 
            }).ToList();

            ViewBag.UnversitetList = unversitet;

            return View();
        }
        public async Task<IActionResult> AddTalaba(TalabaDto talabaDto)
        {
            Talaba talaba = new Talaba();
            talaba.Ismi = talabaDto.Ismi;
            talaba.Yoshi = talabaDto.Yoshi;
            talaba.Manzili = talabaDto.Manzili;
            talaba.Unversitets = await dbContext.Unversitetlar.FirstOrDefaultAsync(talabaId => talabaId.Id == talabaDto.UnversitetId);
            talaba.ImageURL = talabaDto.ImageURl;
            await dbContext.Talabas.AddAsync(talaba);
            await dbContext.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            return View(dbContext.Talabas.FirstOrDefault(talabaId => talabaId.Id == id));
        }

        public IActionResult Edit(int id)
        {
            var talaba = dbContext.Talabas.FirstOrDefault(talabaId => talabaId.Id == id);

            return View(talaba);
        }

        public async Task<IActionResult> UpdateTalaba(Talaba newTalaba)
        {
            if (ModelState.IsValid)
            {
                dbContext.Entry(newTalaba).State = EntityState.Modified;
                await dbContext.SaveChangesAsync();

                return RedirectToAction("Index");
            }
            return View(newTalaba);
        }

        public IActionResult Delete(int id)
        {
            var talaba = dbContext.Talabas.FirstOrDefault(talabaId => talabaId.Id == id);

            return View();
        }

        public async Task<IActionResult> DeleteTalaba(int id)
        {
            var talaba = await dbContext.Talabas.FirstOrDefaultAsync(talabaId => talabaId.Id == id);
            dbContext.Talabas.Remove(talaba);
            await dbContext.SaveChangesAsync();

            return RedirectToAction("Index");
        }


    }
}
