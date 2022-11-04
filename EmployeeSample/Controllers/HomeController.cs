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
            return View(await _employeeRepository.GetProductById(id));
        }








        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}