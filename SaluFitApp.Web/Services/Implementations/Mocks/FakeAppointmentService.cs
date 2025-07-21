using SaluFitApp.Web.Domain.Entities;
using SaluFitApp.Web.Services.Interfaces;

namespace SaluFitApp.Web.Services.Implementations.Mocks;
public class FakeAppointmentService : IAppointmentService
{
    private readonly List<Appointment> _store;

    public FakeAppointmentService()
    {
        _store = new List<Appointment>
        {
            new Appointment
            {
                Id = Guid.NewGuid(),
                FKCliente = 2,
                FKProfesional = 2,
                Departamento = "Fisioterapia",
                Descripcion    = "Revisión de espalda",
                FechaCita      = DateTime.Today.AddHours(10),
                Estado = "Activa"
            },
            new Appointment
            {
                Id = Guid.NewGuid(),
                FKCliente = 1,
                FKProfesional = 1,
                Departamento = "Rehabilitación",
                Descripcion    = "Ejercicios rodilla",
                FechaCita      = DateTime.Today.AddDays(1).AddHours(14),
                Estado = "Inactiva"
            }
        };
    }

    public Task<Appointment> CreateAsync(Appointment dto)
    {
        dto.Id = Guid.NewGuid();
        _store.Add(dto);
        return Task.FromResult(dto);
    }

    public Task<IEnumerable<Appointment>> GetUpcomingAsync(int daysAhead)
    {
        var now = DateTime.Now;
        var cutoff = now.AddDays(daysAhead);
        var upcoming = _store.Where(a => a.FechaCita >= now && a.FechaCita <= cutoff);
        return Task.FromResult(upcoming);
    }

    public Task ConfirmAsync(Guid id)
    {
        var appt = _store.FirstOrDefault(a => a.Id == id);
        if (appt is not null) appt.Estado = "Activada";
        return Task.CompletedTask;
    }

    public Task CancelAsync(Guid id)
    {
        _store.RemoveAll(a => a.Id == id);
        return Task.CompletedTask;
    }
    
}

