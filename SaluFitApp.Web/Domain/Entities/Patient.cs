namespace SaluFitApp.Web.Domain.Entities
{
    public class Patient
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; } = null!;
        public DateTime DateOfBirth { get; set; }
        public int Phone { get; set; }
        public string Email { get; set; } = null!;
        public string Address { get; set; } = null!;

    }
}
