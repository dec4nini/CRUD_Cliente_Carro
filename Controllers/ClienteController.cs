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
    public class ClienteController : Controller
    {
        private readonly IESContext _context;

        public ClienteController(IESContext context)
        {
            _context = context;
        }

        #region Index
        public async Task<IActionResult> Index()
        {
            return View(await _context.Clientes.OrderBy(c => c.Nome).ToListAsync()); ;
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
        public async Task<IActionResult> Create([Bind("Nome, Idade, Sexo, Email, Telefone")] Cliente cliente)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(cliente);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (DbUpdateException ex)
            {
                ModelState.AddModelError(ex.Message, "Falha ao inserir");
            }
            return View(cliente);
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
            var cliente = await _context.Clientes.SingleOrDefaultAsync(c => c.ClienteId == id);
            if (cliente == null)
            {
                return NotFound();
            }
            return View(cliente);
        }
        #endregion

        #region Edit - POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long? id, [Bind("ClienteId, Nome,  Idade, Sexo, Email, Telefone")]
        Cliente cliente)
        {
            if (id != cliente.ClienteId)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cliente);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateException ex)
                {
                    ModelState.AddModelError(ex.Message, "Falha ao atualizar");
                }
            }
            return View(cliente);
        }
        #endregion

        #region Details - GET
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var cliente = await _context.Clientes.SingleOrDefaultAsync(c => c.ClienteId == id);
            if (cliente == null)
            {
                return NotFound();
            }
            return View(cliente);
        }
        #endregion

        #region Delete - GET
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var cliente = await _context.Clientes.SingleOrDefaultAsync(c => c.ClienteId == id);
            if (cliente == null)
            {
                return NotFound();
            }
            return View(cliente);
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
            var cliente = await _context.Clientes.SingleOrDefaultAsync(c => c.ClienteId == id);
            if (cliente == null)
            {
                return NotFound();
            }
            

            _context.Clientes.Remove(cliente);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        #endregion
    }
}
