using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ERS.Data;
using ERS.Models;
using System;
using ERS.ViewModels;
using ERS.Services;

namespace ERS.Controllers
{
    public class ESSInfoesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IESSService _ess;

        public ESSInfoesController(ApplicationDbContext context, IESSService ess)
        {
            _context = context;
            _ess = ess;
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
            ESSEntryViewModel eSSEntry = new ESSEntryViewModel
            {
                Divisions = _context.Divisions.ToList(),
                Districts = _context.Districts.ToList(),
                Upazilas = _context.Upazilas.ToList(),
                Products = _context.Products.ToList(),
                ProductTemplates = _context.ProductTemplates.Select(x=>x.TemplateName).Distinct().ToList()
            };

            return View(eSSEntry);
        }

        [HttpPost]
        public IActionResult Create(ESSEntryModel model)
        {
            var emp = _context.Employees.Where(x => x.Name == model.EmployeeName).FirstOrDefault();

            if (emp == null)
            {
                Employee employee = new Employee
                {
                    Name = model.EmployeeName,
                    Designation = model.Designation,
                    Phone = model.EmployeePhone
                };
                _context.Employees.Add(employee);
                _context.SaveChanges();

                string essCode = _ess.GenerateESSCode();

                ESSInfo info = new ESSInfo
                {
                    EmployeeId = employee.Id,
                    EntryTime = DateTime.UtcNow,
                    WorkingArea = model.WorkingArea,
                    ESSCode = essCode
                };
                _context.ESSInfos.Add(info);
                _context.SaveChanges();

                return Json(essCode);
            }

            return View();
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
