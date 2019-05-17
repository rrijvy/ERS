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
using System.Collections.Generic;

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
                ProductTemplates = _context.ProductTemplates.Select(x => x.TemplateName).Distinct().ToList()
            };

            return View(eSSEntry);
        }

        [HttpPost]
        public IActionResult Create(ESSEntryModel model)
        {
            if (model.ESSCode == null && model.EmployeeId == 0)
            {
                Employee employee = new Employee
                {
                    Name = model.EmployeeName,
                    Designation = model.Designation,
                    Phone = model.EmployeePhone
                };
                _context.Employees.Add(employee);

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

                return Json(new { essCode, employeeId = employee.Id });
            }
            else
            {
                Employee employee = new Employee
                {
                    Id = model.EmployeeId,
                    Name = model.EmployeeName,
                    Designation = model.Designation,
                    Phone = model.EmployeePhone
                };
                _context.Employees.Update(employee);

                ESSInfo info = _context.ESSInfos.Where(x => x.ESSCode == model.ESSCode).FirstOrDefault();

                info.WorkingArea = model.WorkingArea;

                _context.ESSInfos.Update(info);

                if (model.Divisions.Count() > 0)
                {
                    List<EmpDivisionMap> empDivisionMap = _context.EmpDivisionMaps.Where(x => x.ESSInfoId == info.Id).ToList();
                    _context.EmpDivisionMaps.RemoveRange(empDivisionMap);

                    foreach (var item in model.Divisions)
                    {
                        Division division = _context.Divisions.Where(x => x.Name == item).FirstOrDefault();
                        EmpDivisionMap empDivision = new EmpDivisionMap
                        {
                            EmployeeId = model.EmployeeId,
                            DivisionId = division.Id,
                            ESSInfoId = info.Id
                        };
                        _context.EmpDivisionMaps.Add(empDivision);
                    }
                }
                else
                {
                    List<EmpDivisionMap> empDivisionMap = _context.EmpDivisionMaps.Where(x => x.ESSInfoId == info.Id).ToList();
                    _context.EmpDivisionMaps.RemoveRange(empDivisionMap);
                }

                if (model.Districts.Count() > 0)
                {
                    List<EmpDistrictMap> empDistrictMaps = _context.EmpDistrictMaps.Where(x => x.ESSInfoId == info.Id).ToList();
                    _context.EmpDistrictMaps.RemoveRange(empDistrictMaps);

                    foreach (var item in model.Districts)
                    {
                        District district = _context.Districts.Where(x => x.Name == item).FirstOrDefault();
                        EmpDistrictMap empDistrict = new EmpDistrictMap
                        {
                            EmployeeId = model.EmployeeId,
                            DistrictId = district.Id,
                            ESSInfoId = info.Id
                        };
                        _context.EmpDistrictMaps.Add(empDistrict);
                    }
                }
                else
                {
                    List<EmpDistrictMap> empDistrictMaps = _context.EmpDistrictMaps.Where(x => x.ESSInfoId == info.Id).ToList();
                    _context.EmpDistrictMaps.RemoveRange(empDistrictMaps);
                }

                if (model.Upazilas.Count() > 0)
                {
                    List<EmpUpazilaMap> empUpazilaMaps = _context.EmpUpazilaMaps.Where(x => x.ESSInfoId == info.Id).ToList();
                    _context.EmpUpazilaMaps.RemoveRange(empUpazilaMaps);

                    foreach (var item in model.Upazilas)
                    {
                        Upazila upazila = _context.Upazilas.Where(x => x.Name == item).FirstOrDefault();
                        EmpUpazilaMap empUpazila = new EmpUpazilaMap
                        {
                            EmployeeId = model.EmployeeId,
                            UpazilaId = upazila.Id,
                            ESSInfoId = info.Id
                        };
                        _context.EmpUpazilaMaps.Add(empUpazila);
                    }
                }
                else
                {
                    List<EmpDistrictMap> empDistrictMaps = _context.EmpDistrictMaps.Where(x => x.ESSInfoId == info.Id).ToList();
                    _context.EmpDistrictMaps.RemoveRange(empDistrictMaps);
                }

                if (model.Products.Count() > 0)
                {
                    List<EmpProductMap> empProductMaps = _context.EmpProductMaps.Where(x => x.ESSInfoId == info.Id).ToList();
                    _context.EmpProductMaps.RemoveRange(empProductMaps);

                    foreach (var item in model.Products)
                    {
                        EmpProductMap empProduct = new EmpProductMap
                        {
                            EmployeeId = model.EmployeeId,
                            ESSInfoId = info.Id,
                            Price = item.Price,
                            Quantity = item.Quantity,
                            ProductId = item.Id
                        };
                        _context.EmpProductMaps.Add(empProduct);
                    }
                }
                else
                {
                    List<EmpProductMap> empProductMaps = _context.EmpProductMaps.Where(x => x.ESSInfoId == info.Id).ToList();
                    _context.EmpProductMaps.RemoveRange(empProductMaps);
                }

                _context.SaveChanges();
            }

            return View();
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eSSInfo = await _context.ESSInfos.Include(x => x.Employee).SingleOrDefaultAsync(m => m.Id == id);

            ESSEditModel model = new ESSEditModel
            {
                ESSCode = eSSInfo.ESSCode,
                Name = eSSInfo.Employee.Name,
                Designation = eSSInfo.Employee.Designation,
                WorkingArea = eSSInfo.WorkingArea,
                Phone = eSSInfo.Employee.Phone,
                EmpDistricts = _context.EmpDistrictMaps.Where(x => x.ESSInfoId == eSSInfo.Id).Include(x=>x.District).ToList(),
                EmpDivisions = _context.EmpDivisionMaps.Where(x => x.ESSInfoId == eSSInfo.Id).Include(x => x.Division).ToList(),
                EmpUpazilas = _context.EmpUpazilaMaps.Where(x => x.ESSInfoId == eSSInfo.Id).Include(x => x.Upazila).ToList(),
                EmpProducts = _context.EmpProductMaps.Where(x=>x.ESSInfoId==eSSInfo.Id).Include(x=>x.Product).ToList(),
                Products = _context.Products.ToList(),
                Divisions = _context.Divisions.ToList(),
                Districts = _context.Districts.ToList(),
                Upazilas = _context.Upazilas.ToList(),
                ProductTemplates = _context.ProductTemplates.Select(x => x.TemplateName).Distinct().ToList()
            };

            ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "Id", eSSInfo.EmployeeId);
            return View(model);
        }

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

        [HttpGet]
        public IActionResult Report()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ReportView(string essCode)
        {
            ESSInfo info = _context.ESSInfos.FirstOrDefault(x => x.ESSCode == essCode);
            ReportViewModel report = new ReportViewModel
            {
                ESSInfo = info,
                Employee = _context.Employees.FirstOrDefault(x => x.Id == info.EmployeeId),
                EmpProductMap = _context.EmpProductMaps.Where(x => x.ESSInfoId == info.Id).Include(x => x.Product).ToList(),
                EmpDivisionMap = _context.EmpDivisionMaps.Where(x => x.ESSInfoId == info.Id).Include(x => x.Division).ToList(),
                EmpDistrictMap = _context.EmpDistrictMaps.Where(x => x.ESSInfoId == info.Id).Include(x => x.District).ToList(),
                EmpUpazilaMap = _context.EmpUpazilaMaps.Where(x => x.ESSInfoId == info.Id).Include(x => x.Upazila).ToList()
            };
            return View(report);
        }
    }
}
