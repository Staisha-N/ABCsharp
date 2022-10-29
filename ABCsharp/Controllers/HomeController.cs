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

        public IActionResult SearchConcept(string searchTerm)
        {
            List<ConceptModel> concepts = new List<ConceptModel>();
            

            using (var db = new StartContext())
            { 
                if (searchTerm != null){
                    concepts = db.Concepts.Where(x => x.title.ToLower().Contains(searchTerm.ToLower())).ToList();
                } else{
                    concepts = db.Concepts.ToList();
                }
                
            }

            TempData["concepts"] = concepts;

            return View("ViewConcepts");
        }

        public IActionResult ResetConcepts()
        {
            List<ConceptModel> concepts = new List<ConceptModel>();

            using (var db = new StartContext())
            {
                concepts = db.Concepts.ToList();
            }

            TempData["concepts"] = concepts;

            return View("ViewConcepts");
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
        public IActionResult UpdateConcept(ConceptModel concept)
        {
            using(var db = new StartContext())
            {
                var conceptTemp = db.Concepts.Where(x => x.id == concept.id).FirstOrDefault();
                TempData["conceptTemp"] = conceptTemp;
            }

            return View();
        }
        public IActionResult UpdateConceptStep2(ConceptModel concept)
        {
            using(var db = new StartContext())
            {
                var UpdateConcept = db.Concepts.Where(x => x.id == concept.id).FirstOrDefault();
                UpdateConcept.title = concept.title;
                UpdateConcept.description = concept.description;
                UpdateConcept.details = concept.details;

                db.SaveChanges();
            }
            
            return View("Index");
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

        [HttpPost]
        public IActionResult DeleteConcept(ConceptModel concept)
        {
            var conceptToDelete = new ConceptModel() { id= concept.id };

                using (var db = new StartContext())
                {
                    db.Remove(conceptToDelete);
                    db.SaveChanges();
                }
            
            return View("Index");
        }
    }
}