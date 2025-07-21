using SaluFitApp.Web.Domain.Entities;

namespace SaluFitApp.Web.Services.Interfaces
{
    public interface IAppointmentService
    {
        Task<IEnumerable<Appointment>> GetUpcomingAsync(int daysAhead);
        Task<Appointment> CreateAsync(Appointment dto);
        Task ConfirmAsync(Guid id);
        Task CancelAsync(Guid id);
    }
}
