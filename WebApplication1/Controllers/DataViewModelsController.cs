using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Context;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class DataViewModelsController : Controller
    {
        private readonly AppDBContext _context;

        public DataViewModelsController(AppDBContext context)
        {
            _context = context;
        }

        // GET: DataViewModels
        public async Task<IActionResult> Index()
        {
            return View(await _context.Books.ToListAsync());
        }

        // GET: DataViewModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dataViewModel = await _context.Books
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dataViewModel == null)
            {
                return NotFound();
            }

            return View(dataViewModel);
        }

        // GET: DataViewModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DataViewModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,BookName,Price")] DataViewModel dataViewModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dataViewModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dataViewModel);
        }

        // GET: DataViewModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dataViewModel = await _context.Books.FindAsync(id);
            if (dataViewModel == null)
            {
                return NotFound();
            }
            return View(dataViewModel);
        }

        // POST: DataViewModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, [Bind("Id,BookName,Price")] DataViewModel dataViewModel)
        {
            if (id != dataViewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dataViewModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DataViewModelExists(dataViewModel.Id))
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
            return View(dataViewModel);
        }

        // GET: DataViewModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dataViewModel = await _context.Books
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dataViewModel == null)
            {
                return NotFound();
            }

            return View(dataViewModel);
        }

        // POST: DataViewModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            var dataViewModel = await _context.Books.FindAsync(id);
            if (dataViewModel != null)
            {
                _context.Books.Remove(dataViewModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DataViewModelExists(int? id)
        {
            return _context.Books.Any(e => e.Id == id);
        }
    }
}
