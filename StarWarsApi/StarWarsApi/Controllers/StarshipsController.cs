using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StarWarsApi.Models;

namespace StarWarsApi.Controllers
{
    public class StarshipsController : Controller
    {
        private StarShipContext context { get; set; }

        public StarshipsController(StarShipContext ctx ) => context = ctx;


        [HttpGet]

        // GET: Starships
        public async Task<IActionResult> Index()
        {
            return View(await context.Starships.ToListAsync());
        }


        // GET: Starships/Create
        public IActionResult Create()
        {
            ViewBag.Action = "Create";
            //ViewBag.Genres = context.Genres.OrderBy(g => g.Name).ToList();
            return View("Create", new Starship());        
        }

        //POST: Starships/Create
        //To protect from overposting attacks, enable the specific properties you want to bind to.


       [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,name,model,manufacturer,cost_in_credits,length,max_atmosphering_speed,crew,passengers,cargo_capacity,consumables,hyperdrive_rating,MGLT,starship_class,pilots,films,created,edited,url")] Starship starship)
        {
            if (ModelState.IsValid)
            {
                context.Add(starship);
                await context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(starship);
        }





        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Action = "Edit";
            //ViewBag.Genres = context.Genres.OrderBy(g => g.Name).ToList();
            var starship = context.Starships.Find(id);
            return View(starship);
        }

        [HttpPost]
        public IActionResult Edit(Starship starship)
        {
            if (ModelState.IsValid)
            {
                if (starship.Id == 0)
                    context.Starships.Add(starship);
                else
                    context.Starships.Update(starship);
                context.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Action = (starship.Id == 0) ? "Create" : "Edit";
                //ViewBag.Genres = context.Genres.OrderBy(g => g.Name).ToList();
                return View(starship);
            }
        }



        //// GET: Starships/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var starship = await _context.Starships
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (starship == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(starship);
        //}


        //// GET: Starships/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var starship = await context.Starships.FindAsync(id);
        //    if (starship == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(starship);
        //}

        //// POST: Starships/Edit/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("Id,name,model,manufacturer,cost_in_credits,length,max_atmosphering_speed,crew,passengers,cargo_capacity,consumables,hyperdrive_rating,MGLT,starship_class,pilots,films,created,edited,url")] Starship starship)
        //{
        //    if (id != starship.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(starship);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!StarshipExists(starship.Id))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(starship);
        //}

        // GET: Starships/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var starship = await context.Starships
                .FirstOrDefaultAsync(m => m.Id == id);
            if (starship == null)
            {
                return NotFound();
            }

            return View(starship);
        }

        // POST: Starships/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var starship = await context.Starships.FindAsync(id);
            if (starship != null)
            {
                context.Starships.Remove(starship);
            }

            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StarshipExists(int id)
        {
            return context.Starships.Any(e => e.Id == id);
        }
    }
}
