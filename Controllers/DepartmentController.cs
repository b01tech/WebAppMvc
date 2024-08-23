using Microsoft.AspNetCore.Mvc;
using WebAppMvc.Models;

namespace WebAppMvc.Controllers
{
    public class DepartmentController : Controller
    {
        public IActionResult Index()
        {
            var list = new List<Department>();

            list.Add(new Department { DepartmentId = 1, Name = "Eletronics"});
            list.Add(new Department { DepartmentId = 2, Name = "Books"});
            list.Add(new Department { DepartmentId = 2, Name = "Fashion"});
            return View(list);
        }
    }
}
