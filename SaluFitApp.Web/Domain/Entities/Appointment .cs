namespace SaluFitApp.Web.Domain.Entities
{
    public class Appointment
    {
        public Guid Id { get; set; }
        public string Descripcion { get; set; }
        public string Departamento { get; set; }
        public DateTime FechaCita { get; set; }
        public string Estado { get; set; }

        public int FKCliente { get; set; }
        public int FKProfesional { get; set; }

    }
}
