namespace SaluFitApp.Web.Models
{
    public class DocumentoModel

    {
        public Guid Id { get; set; }
        public string Nombre { get; set; }
        public string DescripcionCorta { get; set; }
        public DateTime FechaSubida { get; set; }
        public DateTime FechaFin { get; set; }
        public int FKCliente { get; set; }

    }
}
