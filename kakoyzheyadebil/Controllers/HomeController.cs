using kakoyzheyadebil.Domain;
using Microsoft.AspNetCore.Mvc;

namespace kakoyzheyadebil.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : Controller
    {
        private InspectorTestContext inspectors;

        public HomeController(InspectorTestContext inspectors)
        {
            this.inspectors = inspectors;
        }

        [HttpGet(Name = "Get")]
        public async Task<IActionResult> GetReportsView()
        {
            return View(inspectors.Set<Report>().Where(e => true).ToList());
        }
    }
}
