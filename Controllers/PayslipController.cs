using Microsoft.AspNetCore.Mvc;
using PayslipApp.Models;

namespace PayslipApp.Controllers
{
    public class PayslipController : Controller
    {
        public IActionResult Index()
        {
            var emp = new Employee
            {
                Id = 101,
                Name = "Rohith",
                BasicSalary = 30000,
                HRA = 8000,
                DA = 5000
            };

            emp.CalculateNetSalary();
            return View(emp);
        }
    }
}
