using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Produtos.Data;
using Produtos.Models;

namespace Produtos.Controllers
{
    public class ProdutosController : Controller
    {
        private readonly ProdutosContext _context;

        public ProdutosController(ProdutosContext context)
        {
            _context = context;
        }

        // GET: Produtos
        public async Task<IActionResult> Index()
        {
              return _context.ProdutosModel != null ? 
                          View(await _context.ProdutosModel.OrderBy(a => a.Descricao).ToListAsync()) :
                          Problem("Entity set 'ProdutosContext.ProdutosModel'  is null.");
        }

        // GET: Produtos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ProdutosModel == null)
            {
                return NotFound();
            }
            ProdutosModel? produtosModel = await GetItem(id);
            if (produtosModel == null)
            {
                return NotFound();
            }

            return View(produtosModel);
        }

        private async Task<ProdutosModel?> GetItem(int? id)
        {
            return await _context.ProdutosModel.FindAsync(id);
        }

        // GET: Produtos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Produtos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Codigo,Descricao,Unidade,Custo,Preco,Imagem,Estoque")] ProdutosModel produtosModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(produtosModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(produtosModel);
        }

        // GET: Produtos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ProdutosModel == null)
            {
                return NotFound();
            }

            var produtosModel = await GetItem(id);
            if (produtosModel == null)
            {
                return NotFound();
            }
            return View(produtosModel);
        }

        // POST: Produtos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Codigo,Descricao,Unidade,Custo,Preco,Imagem,Estoque")] ProdutosModel produtosModel)
        {
            if (id != produtosModel.Codigo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(produtosModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProdutosModelExists(produtosModel.Codigo))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(produtosModel);
        }

        // GET: Produtos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ProdutosModel == null)
            {
                return NotFound();
            }

            var produtosModel = await GetItem(id);
            if (produtosModel == null)
            {
                return NotFound();
            }

            return View(produtosModel);
        }

        // POST: Produtos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ProdutosModel == null)
            {
                return Problem("Entity set 'ProdutosContext.ProdutosModel'  is null.");
            }
            var produtosModel = await GetItem(id);
            if (produtosModel != null)
            {
                _context.ProdutosModel.Remove(produtosModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProdutosModelExists(int id)
        {
          return (_context.ProdutosModel?.Any(e => e.Codigo == id)).GetValueOrDefault();
        }
    }
}
