using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ERS.Data;
using ERS.Models;
using ERS.ViewModels;

namespace ERS.Controllers
{
    public class ProductTemplatesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductTemplatesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ProductTemplates
        public IActionResult Index()
        {
            return Json(_context.ProductTemplates.Select(x=>x.TemplateName).Distinct().ToList());
        }

        // GET: ProductTemplates/Details/5
        public IActionResult Details(string templateName)
        {
            if (string.IsNullOrEmpty(templateName))
            {
                return NotFound();
            }

            var productTemplate = _context.ProductTemplates.Where(x => x.TemplateName == templateName).Include(x=>x.Product);

            if (productTemplate == null)
            {
                return NotFound();
            }

            return Json(productTemplate);
        }

        // GET: ProductTemplates/Create
        public IActionResult Create()
        {
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Id");
            return View();
        }

        [HttpPost]
        public IActionResult Create(ProductTemplateViewModel model)
        {
            if (model != null)
            {
                foreach (var item in model.Products)
                {
                    ProductTemplate template = new ProductTemplate
                    {
                        TemplateName = model.TemplateName,
                        ProductId = item.Id,
                        Quantity = item.Quantity,
                        Price = item.Price
                    };
                    _context.ProductTemplates.Add(template);
                    _context.SaveChanges();
                }
            }
            return Json(_context.ProductTemplates.Select(x => x.TemplateName).Distinct().ToList());
        }

        // GET: ProductTemplates/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productTemplate = await _context.ProductTemplates.SingleOrDefaultAsync(m => m.Id == id);
            if (productTemplate == null)
            {
                return NotFound();
            }
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Id", productTemplate.ProductId);
            return View(productTemplate);
        }

        // POST: ProductTemplates/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TemplateName,Quantity,Price,ProductId")] ProductTemplate productTemplate)
        {
            if (id != productTemplate.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(productTemplate);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductTemplateExists(productTemplate.Id))
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
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Id", productTemplate.ProductId);
            return View(productTemplate);
        }

        // GET: ProductTemplates/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productTemplate = await _context.ProductTemplates
                .Include(p => p.Product)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (productTemplate == null)
            {
                return NotFound();
            }

            return View(productTemplate);
        }

        // POST: ProductTemplates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var productTemplate = await _context.ProductTemplates.SingleOrDefaultAsync(m => m.Id == id);
            _context.ProductTemplates.Remove(productTemplate);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductTemplateExists(int id)
        {
            return _context.ProductTemplates.Any(e => e.Id == id);
        }
    }
}
