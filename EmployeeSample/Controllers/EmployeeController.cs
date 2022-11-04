using Microsoft.AspNetCore.Mvc;
using EmployeeSample.Services;
using EmployeeSample.Models;

namespace EmployeeSample.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        public IActionResult Index()
        {
            return View( _employeeService.GetAllEmployees());
        }

        public IActionResult Details(int id)
        {
            return View(_employeeService.GetEmployeeById(id));
        }

        //Getting the id
        public IActionResult Edit(int id)
        {
            return View(_employeeService.GetEmployeeById(id));
        }


        //Saving
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Employee employee)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _employeeService.CreateEmployeeAsync(employee);
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Unable to save changes.");
            }
            return View(employee);
        }


        //Update
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Employee employee)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var dbProduct = await _employeeService.GetEmployeeById(id);
                    if (await TryUpdateModelAsync(dbProduct))
                    {
                        await _employeeService.UpdateEmployeeAsync(dbProduct);
                        return RedirectToAction(nameof(Index));
                    }
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Unable to save changes.");
            }
            return View(employee);
        }
    }
    
}
