using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class DaoController : Controller
    {
        private readonly ApplicationDbContext _db;

        public  DaoController(ApplicationDbContext db)
        {
            _db = db;
        }


        public async Task<IActionResult> Index()
        {
            return View( await _db.DAO.ToListAsync());
        }

        //
        public ActionResult Create()
        {
            return View();
        }

        // Metodo POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DAO dao)
        {
            if (ModelState.IsValid)
            {
                //Si los campos son validos
                _db.DAO.Add(dao);
                await _db.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            return View(dao);
        }

        //GET  EDITAR

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var dao = await _db.DAO.FindAsync(id);
            if (dao == null)
            {
                return NotFound();

            }
            return View(dao);
        }

        //POST  EDITAR
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Edit(DAO dao)
        {
            if (ModelState.IsValid)
            {
                _db.Update(dao);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dao);
        }


        //GET - Borrar

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var dao = await _db.DAO.FindAsync(id);
            if (dao == null)
            {
                return NotFound();
            }

            return View(dao);
        }

        //POST - Borar
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dao = await _db.DAO.FindAsync(id);

            if (dao == null)
            {
                return View();
            }
            _db.DAO.Remove(dao);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
