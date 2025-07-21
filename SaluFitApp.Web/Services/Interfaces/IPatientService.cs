using SaluFitApp.Web.Domain.Entities;

namespace SaluFitApp.Web.Services.Interfaces
{
    public interface IPatientService
    {
        Task<IEnumerable<Patient>> SearchAsync(string? term);
        Task<Patient?> GetByIdAsync(Guid id);
        Task<Patient> CreateAsync(Patient dto);
        Task UpdateAsync(Patient dto);
        Task DeleteAsync(Guid id);
    }
}
