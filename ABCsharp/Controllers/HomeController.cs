using ABCsharp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ABCsharp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddConcept()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult ViewConcepts()
        {
            List<ConceptModel> concepts = new List<ConceptModel>();

            using (var db = new StartContext())
            {
                concepts = db.Concepts.ToList();
            }

            TempData["concepts"] = concepts;

            return View();
            
        }

        

        [HttpPost]
        public IActionResult AddConcept(ConceptModel concept)
        {

            if (ModelState.IsValid)
            {
                using (var db = new StartContext())
                {
                    db.Add(concept);
                    db.SaveChanges();
                }
            }
            return View();
        }
    }
}