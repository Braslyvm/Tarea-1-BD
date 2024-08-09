using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Tarea.Models;

namespace Tarea.Controllers
{
    public class HomeController : Controller
    {
        private readonly string filePath = "wwwroot/data/datos.json"; 

        [HttpGet]
        public IActionResult Historial() {

            List<Datos> datosList = GetDatosList();

            
            return View(datosList);
                    
        }
        public IActionResult Index()
        {
            return View();
        }
        

        [HttpPost]
        public IActionResult SaveData(Datos datos)
        {
            List<Datos> datosList = GetDatosList();
            datosList.Add(datos);
            SaveDatosList(datosList);

            TempData["Message"] = "Persona agregada con éxito.";
            return RedirectToAction("Index");
        }

        private List<Datos> GetDatosList()
        {
            if (System.IO.File.Exists(filePath))
            {
                string jsonString = System.IO.File.ReadAllText(filePath);
                return JsonConvert.DeserializeObject<List<Datos>>(jsonString) ?? new List<Datos>();
            }
            return new List<Datos>();
        }

        private void SaveDatosList(List<Datos> datosList)
        {
            string jsonString = JsonConvert.SerializeObject(datosList, Formatting.Indented);
            System.IO.File.WriteAllText(filePath, jsonString);
        }
    }
}