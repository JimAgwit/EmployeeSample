using EmployeeSample.Models;
using EmployeeSample.Repositories;
using EmployeeSample.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace EmployeeSample.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IEmployeeRepository _employeeRepository;

        public HomeController(ILogger<HomeController> logger, IEmployeeRepository employeeRepository)
        {
            _logger = logger;
            _employeeRepository = employeeRepository;
        }

        public async Task<IActionResult> IndexAsync()
        {
            return View(await _employeeRepository.GetAllAsync());
        }

        public async Task<IActionResult> Details(int id)
        {
            return View(await _employeeRepository.GetByIdAsync(id));
        }



        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        //Get 
        public async Task<IActionResult> Edit(int id)
        {
            return View(await _employeeRepository.GetByIdAsync(id));
        }

        //Save
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Employee employee)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _employeeRepository.CreateAsync(employee);
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Unable to save changes.");
            }
            return View(employee);
        }
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Employee employee)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var dbProduct = await _employeeRepository.GetByIdAsync(id);
                    if (await TryUpdateModelAsync<Employee>(dbProduct))
                    {
                        await _employeeRepository.UpdateAsync(dbProduct);
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