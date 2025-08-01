using System.Reflection.Metadata;
using SaluFitApp.Web.Models;

namespace SaluFitApp.Web.Models
{
    public class NotaModel
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Contenido { get; set; }
        public DateTime Fecha { get; set; }
        public int FKPaciente { get; set; }
    }
}
