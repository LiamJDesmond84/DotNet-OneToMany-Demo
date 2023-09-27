using Microsoft.AspNetCore.Mvc;

namespace DotNet_OneToMany_Demo.Controllers
{
    public class DataController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
