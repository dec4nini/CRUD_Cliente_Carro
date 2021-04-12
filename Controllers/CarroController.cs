using ClienteProduto.Data;
using ClienteProduto.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClienteProduto.Controllers
{
    public class CarroController : Controller
    {
        private readonly IESContext _context;

        public CarroController(IESContext context)
        {
            _context = context;
        }

        #region Index
        public async Task<IActionResult> Index()
        {
            return View(await _context.Carros.OrderBy(c => c.Marca).ToListAsync()); ;
        }
        #endregion

        #region Create - GET
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        #endregion

        #region Create - POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Marca, Modelo, Cor, NumRodas, NumChassi")] Carro carro)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(carro);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (DbUpdateException ex)
            {
                ModelState.AddModelError(ex.Message, "Falha ao inserir");
            }
            return View(carro);
        }
        #endregion

        #region Edit - GET
        [HttpGet]
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var carro = await _context.Carros.SingleOrDefaultAsync(c => c.CarroId == id);
            if (carro == null)
            {
                return NotFound();
            }
            return View(carro);
        }
        #endregion

        #region Edit - POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long? id, [Bind("CarroId, Marca, Modelo, Cor, NumRodas, NumChassi")]
        Carro carro)
        {
            if (id != carro.CarroId)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(carro);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateException ex)
                {
                    ModelState.AddModelError(ex.Message, "Falha ao atualizar");
                }
            }
            return View(carro);
        }
        #endregion

        #region Details - GET
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var carro = await _context.Carros.SingleOrDefaultAsync(c => c.CarroId == id);
            if (carro == null)
            {
                return NotFound();
            }
            return View(carro);
        }
        #endregion

        #region Delete - GET
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var carro = await _context.Carros.SingleOrDefaultAsync(c => c.CarroId == id);
            if (carro == null)
            {
                return NotFound();
            }
            return View(carro);
        }
        #endregion

        #region Delete - POST
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var carro = await _context.Carros.SingleOrDefaultAsync(c => c.CarroId == id);
            if (carro == null)
            {
                return NotFound();
            }
            

            _context.Carros.Remove(carro);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        #endregion
    }
}
