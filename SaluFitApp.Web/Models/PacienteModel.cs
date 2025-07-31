using System.Reflection.Metadata;
using SaluFitApp.Web.Models;

namespace SaluFitApp.Web.Models
{
    public class PacienteModel
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; } = null!;
        public DateTime FechaNacimiento { get; set; }
        public string Genero { get; set; }
        public int Telefono { get; set; }
        public string Email { get; set; } = null!;
        public string Direccion { get; set; } = null!;
        public List<Nota> Notas { get; set; } = new();
        public List<CitaModel> Citas { get; set; } = new();
        public List<EjercicioModel> Ejercicios { get; set; } = new();
        public List<DocumentoModel> Documentos { get; set; } = new();

    }
    public class Nota
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Contenido { get; set; }
        public DateTime Fecha { get; set; }
    }
}
