namespace SaluFitApp.Web.Models
{
    public class EjercicioModel

    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Repeticiones { get; set; }
        public string Etiquetas { get; set; }
        public int FKCliente { get; set; }
    }
}
