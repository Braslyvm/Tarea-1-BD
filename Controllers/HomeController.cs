using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Tarea.Models;

namespace Tarea.Controllers
{
    public class HomeController : Controller
    {
        private readonly string filePath = "wwwroot/data/datos.json"; 


        /// <summary>
        /// Es el metodo que se encarga en mostrar la interfaz del historial.
        /// </summary>

        [HttpGet]
        public IActionResult Historial() {

            List<Datos> datosList = GetDatosList();

            
            return View(datosList);
                    
        }
        /// <summary>
        /// Es el metodo que se encarga en mostrar la interfaz del historial.
        /// </summary>
  
        public IActionResult Index()
        {
            return View();
        }
        
        /// <summary>
        /// SaveData es el metodo que recibi los inputs de la interfaz de registro y los agrega al json.
        /// </summary>
        /// <param name="datos">recibe un objeto donde se guarda los datos del usuario.</param>
        [HttpPost]
        public IActionResult SaveData(Datos datos)
        {
            List<Datos> datosList = GetDatosList();
            datosList.Add(datos);
            SaveDatosList(datosList);

            TempData["Message"] = "Persona agregada con éxito.";
            return RedirectToAction("Index");
        }
        /// <summary>
        /// GetDatosList es el metodo que se encarga de estraer todo lo que se encuntra en el json.
        /// </summary>
        /// <returns>la lista de objetos datos.</returns>
        private List<Datos> GetDatosList()
        {
            if (System.IO.File.Exists(filePath))
            {
                string DatosString = System.IO.File.ReadAllText(filePath);
                return JsonConvert.DeserializeObject<List<Datos>>(DatosString) ?? new List<Datos>();
            }
            return new List<Datos>();
        }


        /// <summary>
        /// SaveDatosList guarda la lista de datos en el json.
        /// </summary>
        /// <param name="datosList">es la lista de objetos.</param>

        private void SaveDatosList(List<Datos> datosList)
        {
            string DatosString = JsonConvert.SerializeObject(datosList, Formatting.Indented);
            System.IO.File.WriteAllText(filePath, DatosString);
        }
    }
}