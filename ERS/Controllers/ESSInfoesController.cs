using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ERS.Data;
using ERS.Models;
using System;

namespace ERS.Controllers
{
    public class ESSInfoesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ESSInfoesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ESSInfoes
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.ESSInfos.Include(e => e.Employee);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: ESSInfoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eSSInfo = await _context.ESSInfos
                .Include(e => e.Employee)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (eSSInfo == null)
            {
                return NotFound();
            }

            return View(eSSInfo);
        }

        // GET: ESSInfoes/Create
        public IActionResult Create()
        {
            string month = DateTime.UtcNow.ToString("MM");
            string year = DateTime.UtcNow.Year.ToString();
            ESSInfo lastEssInfo = _context.ESSInfos.LastOrDefault();
            int essNumber = 1;
            if (lastEssInfo != null)
            {
                essNumber = int.Parse(lastEssInfo.ESSCode.Substring(6));
            }            
            string essCode = month + year + essNumber++;
            ViewData["ESSCode"] = essCode;
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "Id");
            return View();
        }

        // POST: ESSInfoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ESSCode,WorkingArea,EntryTime,EmployeeId")] ESSInfo eSSInfo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(eSSInfo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "Id", eSSInfo.EmployeeId);
            return View(eSSInfo);
        }

        // GET: ESSInfoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eSSInfo = await _context.ESSInfos.SingleOrDefaultAsync(m => m.Id == id);
            if (eSSInfo == null)
            {
                return NotFound();
            }
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "Id", eSSInfo.EmployeeId);
            return View(eSSInfo);
        }

        // POST: ESSInfoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ESSCode,WorkingArea,EntryTime,EmployeeId")] ESSInfo eSSInfo)
        {
            if (id != eSSInfo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(eSSInfo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ESSInfoExists(eSSInfo.Id))
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
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "Id", eSSInfo.EmployeeId);
            return View(eSSInfo);
        }

        // GET: ESSInfoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eSSInfo = await _context.ESSInfos
                .Include(e => e.Employee)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (eSSInfo == null)
            {
                return NotFound();
            }

            return View(eSSInfo);
        }

        // POST: ESSInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var eSSInfo = await _context.ESSInfos.SingleOrDefaultAsync(m => m.Id == id);
            _context.ESSInfos.Remove(eSSInfo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ESSInfoExists(int id)
        {
            return _context.ESSInfos.Any(e => e.Id == id);
        }
    }
}
