using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FinalExam.DAL.Context;
using FinalExam.Core.Entities;
using FinalExam.BL.ViewModels.Department;

namespace FinalExam.Areas.Admin.Controllers;

[Area("Admin")]
[Authorize(Roles = nameof(Google.Apis.Admin.Directory.directory_v1.Data.Roles.Admin))]
public class DepartmentController(AppDbContext _context, IWebHostEnvironment _env) : Controller
{
    public async Task<IActionResult> Index()
    { 
        return View(await _context.Departments.Where(department => department.IsDeleted == false).ToListAsync());
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(DepartmentCreateVM vm)
    {
        if (vm.ImageUrl != null)
        { 
            if (!vm.ImageUrl.IsValidType("image"))
                ModelState.AddModelError("Logo", "File must be image type");

            else if (!vm.ImageUrl.IsValidSize(2 * 1024))
                ModelState.AddModelError("Logo", "File must be less than 2mb");
        }

        if (!ModelState.IsValid)
        {
            return View(vm);
        }

        Departments department = new Departments;
        {
            Name = department.Name,
            CreatedTime = DateTime.Now,
            IsDeleted = false,
        };

        if (department.ImageUrl != null)
        { 
            string filePath = Path.Combine(_env.WebRootPath, "imgs", "brands");
            string newFileName = await department.ImageUrl!.Upload(filePath);
            department.ImageUrl = newFileName;
        }

        await _context.Departments.AddAsync(department);
        await _context.SaveChangesAsync();

        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public async Task<IActionResult> Delete(int? id)
    {
        if (!id.HasValue) return BadRequest();

        Departments? departments = await _context.Departments.Where(departments => departments.IsDeleted == false).FirstOrDefaultAsync(departments => departments.Id == id);
        if (departments == null) return NotFound();

        
        departments.IsDeleted = true;
        await _context.SaveChangesAsync();

        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Update(int? id)
    {
        Departments? departments = await _context.Departments.Where(departments => departments.IsDeleted == false).FirstOrDefaultAsync(departments => departments.Id == id);
        if (departments == null) return NotFound();

        ViewBag.departments = departments;
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Update(int? id, DepartmentUpdateVM vm)
    {
        if (vm.Image != null)
        {
            if (!vm.Image.IsValidType("image"))
                ModelState.AddModelError("Logo", "Logo must be image type");

            else if (!vm.Image.IsValidSize(2 * 1024))
                ModelState.AddModelError("Logo", "Logo must be less than 2mb");
        }

        if (!ModelState.IsValid)
        { 
            ViewBag.department = await _context.Departments.Where(Departments => Departments.IsDeleted == false).FirstOrDefaultAsync(Departments => Departments.Id == id);
            return View(vm);
        }

        Departments? departments = await _context.Departments.Where(departments => departments.IsDeleted == false).FirstOrDefaultAsync(departments => departments.Id == id);
        if (departments == null) return NotFound();

        ViewBag.departments = departments;

        if (vm.Image != null)
        { 
            string filePath = Path.Combine(_env.WebRootPath, "imgs", "brands");
            string newFileName = await vm.Image.Upload(filePath, departments.LogoUrl);
            departments.LogoUrl = newFileName;
        }

        departments.Name = vm.Name;

        await _context.SaveChangesAsync();

        return RedirectToAction(nameof(Index));
    }
}
