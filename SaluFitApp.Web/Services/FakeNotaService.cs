using SaluFitApp.Web.Models;

public class FakeNotaService
{
    private readonly List<NotaModel> _store;

    public FakeNotaService()
    {
        _store = new List<NotaModel>
        {
            new NotaModel {
                Id = 1,
                Titulo = "Desgarro abismal",
                Contenido = "Descomuanalmente destrozado",
                Fecha = new DateTime(2025, 07, 01),
                FKPaciente = 1
            }
        };
    }

    public Task<IEnumerable<NotaModel>> GetByPacienteAsync(int pacienteId)
    {
        var notas = _store.Where(n => n.FKPaciente == pacienteId);
        return Task.FromResult(notas.AsEnumerable());
    }

    public Task<NotaModel> CreateAsync(NotaModel dto)
    {
        dto.Id = _store.Count + 1;
        _store.Add(dto);
        return Task.FromResult(dto);
    }

    public Task DeleteAsync(int id)
    {
        _store.RemoveAll(x => x.Id == id);
        return Task.CompletedTask;
    }

    public Task<NotaModel?> GetByIdAsync(int id)
        => Task.FromResult(_store.FirstOrDefault(x => x.Id == id));

    public Task<IEnumerable<NotaModel>> SearchAsync(string? term)
    {
        var q = _store.AsEnumerable();
        if (!string.IsNullOrWhiteSpace(term))
            q = q.Where(p => p.Titulo.Contains(term, StringComparison.OrdinalIgnoreCase));
        return Task.FromResult(q);
    }

    public Task UpdateAsync(NotaModel dto)
    {
        var idx = _store.FindIndex(x => x.Id == dto.Id);
        if (idx >= 0) _store[idx] = dto;
        return Task.CompletedTask;
    }
}
