namespace Tarea.Models
{
    
    public class ErrorViewModel
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }

    public class Datos
    {
        public string Cedula { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public int Edad { get; set; }
        public string Direccion { get; set; }
    }
}