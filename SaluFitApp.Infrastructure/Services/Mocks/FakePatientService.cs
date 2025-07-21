using Core.Entities;
using Core.Interfaces;
namespace Infrastructure.Services.Mocks;

public class FakePatientService : IPatientService
{
    private readonly List<Patient> _store;

    public FakePatientService()
    {
        _store = new List<Patient>
        {
            new Patient {
                Id = Guid.NewGuid(),
                FullName = "José Rodríguez",
                DateOfBirth = new DateTime(1980, 5, 10),
                Phone = "666666661",
                Email = "jose.rodriguez@example.com",
                Address = "Calle Falsa 123"
            },
            new Patient {
                Id = Guid.NewGuid(),
                FullName = "Alberto García",
                DateOfBirth = new DateTime(1985, 7, 12),
                Phone = "666666662",
                Email = "alberto.García@example.com",
                Address = "Calle Falsa2 22"
            },
            new Patient {
                Id = Guid.NewGuid(),
                FullName = "Raúl Martínez",
                DateOfBirth = new DateTime(1990, 9, 1),
                Phone = "666666663",
                Email = "raul.martinez@example.com",
                Address = "Calle Fals3 52"
            }
        };
    }

    public Task<Patient> CreateAsync(Patient dto)
    {
        dto.Id = Guid.NewGuid();
        _store.Add(dto);
        return Task.FromResult(dto);
    }

    public Task DeleteAsync(Guid id)
    {
        _store.RemoveAll(x => x.Id == id);
        return Task.CompletedTask;
    }

    public Task<Patient?> GetByIdAsync(Guid id)
        => Task.FromResult(_store.FirstOrDefault(x => x.Id == id));

    public Task<IEnumerable<Patient>> SearchAsync(string? term, PatientStatus? status = null)
    {
        var q = _store.AsEnumerable();
        if (!string.IsNullOrWhiteSpace(term))
            q = q.Where(p => p.FullName.Contains(term, StringComparison.OrdinalIgnoreCase));
        return Task.FromResult(q);
    }

    public Task UpdateAsync(Patient dto)
    {
        var idx = _store.FindIndex(x => x.Id == dto.Id);
        if (idx >= 0) _store[idx] = dto;
        return Task.CompletedTask;
    }
}
