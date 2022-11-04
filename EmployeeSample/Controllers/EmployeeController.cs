using Microsoft.AspNetCore.Mvc;
using EmployeeSample.Services;

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
    }
}
