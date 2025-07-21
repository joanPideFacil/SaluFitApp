using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;

namespace Infrastructure.Services.Mocks
{
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
                    PatientId = Guid.NewGuid(),
                    Department = "Fisioterapia",
                    Reason    = "Revisión de espalda",
                    Date      = DateTime.Today.AddHours(10),
                    Confirmed = false
                },
                new Appointment
                {
                    Id = Guid.NewGuid(),
                    PatientId = Guid.NewGuid(),
                    Department = "Rehabilitación",
                    Reason    = "Ejercicios rodilla",
                    Date      = DateTime.Today.AddDays(1).AddHours(14),
                    Confirmed = true
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
            var upcoming = _store.Where(a => a.Date >= now && a.Date <= cutoff);
            return Task.FromResult(upcoming);
        }

        public Task ConfirmAsync(Guid id)
        {
            var appt = _store.FirstOrDefault(a => a.Id == id);
            if (appt is not null) appt.Confirmed = true;
            return Task.CompletedTask;
        }

        public Task CancelAsync(Guid id)
        {
            _store.RemoveAll(a => a.Id == id);
            return Task.CompletedTask;
        }
    }
}

