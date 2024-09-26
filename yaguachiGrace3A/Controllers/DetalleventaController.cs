using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using yaguachiGrace3A.Models;

namespace yaguachiGrace3A.Controllers
{
    public class DetalleventaController : Controller
    {
        private readonly examengraceContext _context;

        public DetalleventaController(examengraceContext context)
        {
            _context = context;
        }

        // GET: Detalleventa
        public async Task<IActionResult> Index()
        {
            var examengraceContext = _context.Detalleventa.Include(d => d.CodigoProductoNavigation).Include(d => d.CodigoVentaNavigation);
            return View(await examengraceContext.ToListAsync());
        }

        // GET: Detalleventa/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Detalleventa == null)
            {
                return NotFound();
            }

            var detalleventum = await _context.Detalleventa
                .Include(d => d.CodigoProductoNavigation)
                .Include(d => d.CodigoVentaNavigation)
                .FirstOrDefaultAsync(m => m.CodigoDetalle == id);
            if (detalleventum == null)
            {
                return NotFound();
            }

            return View(detalleventum);
        }

        // GET: Detalleventa/Create
        public IActionResult Create()
        {
            ViewData["CodigoProducto"] = new SelectList(_context.Productos, "CodigoProducto", "NombreProducto");
            ViewData["CodigoVenta"] = new SelectList(_context.Venta, "CodigoVenta", "codigoVenta");
            return View();
        }

        // POST: Detalleventa/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CodigoDetalle,CodigoVenta,CodigoProducto,Cantidad,Descuento")] Detalleventum detalleventum)
        {
            if (ModelState.IsValid)
            {
                _context.Add(detalleventum);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CodigoProducto"] = new SelectList(_context.Productos, "CodigoProducto", "CodigoProducto", detalleventum.CodigoProducto);
            ViewData["CodigoVenta"] = new SelectList(_context.Venta, "CodigoVenta", "CodigoVenta", detalleventum.CodigoVenta);
            return View(detalleventum);
        }

        // GET: Detalleventa/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Detalleventa == null)
            {
                return NotFound();
            }

            var detalleventum = await _context.Detalleventa.FindAsync(id);
            if (detalleventum == null)
            {
                return NotFound();
            }
            ViewData["CodigoProducto"] = new SelectList(_context.Productos, "CodigoProducto", "NombreProducto", detalleventum.CodigoProducto);
            ViewData["CodigoVenta"] = new SelectList(_context.Venta, "CodigoVenta", "codigoVenta", detalleventum.CodigoVenta);
            return View(detalleventum);
        }

        // POST: Detalleventa/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CodigoDetalle,CodigoVenta,CodigoProducto,Cantidad,Descuento")] Detalleventum detalleventum)
        {
            if (id != detalleventum.CodigoDetalle)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(detalleventum);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DetalleventumExists(detalleventum.CodigoDetalle))
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
            ViewData["CodigoProducto"] = new SelectList(_context.Productos, "CodigoProducto", "CodigoProducto", detalleventum.CodigoProducto);
            ViewData["CodigoVenta"] = new SelectList(_context.Venta, "CodigoVenta", "CodigoVenta", detalleventum.CodigoVenta);
            return View(detalleventum);
        }

        // GET: Detalleventa/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Detalleventa == null)
            {
                return NotFound();
            }

            var detalleventum = await _context.Detalleventa
                .Include(d => d.CodigoProductoNavigation)
                .Include(d => d.CodigoVentaNavigation)
                .FirstOrDefaultAsync(m => m.CodigoDetalle == id);
            if (detalleventum == null)
            {
                return NotFound();
            }

            return View(detalleventum);
        }

        // POST: Detalleventa/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Detalleventa == null)
            {
                return Problem("Entity set 'examengraceContext.Detalleventa'  is null.");
            }
            var detalleventum = await _context.Detalleventa.FindAsync(id);
            if (detalleventum != null)
            {
                _context.Detalleventa.Remove(detalleventum);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DetalleventumExists(int id)
        {
          return (_context.Detalleventa?.Any(e => e.CodigoDetalle == id)).GetValueOrDefault();
        }
    }
}
