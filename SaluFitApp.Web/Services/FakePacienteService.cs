using SaluFitApp.Web.Models;

public class FakePacienteService 
{
    private readonly List<PacienteModel> _store;

    public FakePacienteService()
    {
        _store = new List<PacienteModel>
        {
            new PacienteModel {
                Id = 1,
                Nombre = "José Rodríguez",
                FechaNacimiento = new DateTime(1980, 12, 10),
                Genero = "Hombre",
                Telefono = 666666661,
                Email = "jose.rodriguez@example.com",
                Direccion = "Calle Falsa 123",
                Notas = new List<NotaModel>{
                    new NotaModel
                    {
                        Id = 1,
                        Titulo = "Desgarro abismal",
                        Contenido = "Descomuanalmente destrozado",
                        Fecha = new DateTime(2025, 07, 01)
                    }
                },
                Citas = new List<CitaModel>{
                    new CitaModel
                    {
                        Nombre = "Dolor perianal",
                        Departamento = "Desgarro abismal",
                        Descripcion = "Descomuanalmente destrozado",
                        FechaCita = new DateTime(2025, 07, 01)
                    }
                },
                Ejercicios = new List<EjercicioModel>{
                    new EjercicioModel
                    {
                        Id = 1,
                        Nombre = "Masaje perianal",
                        Descripcion = "Perforación profunda",
                        Repeticiones = "3 repeticiones profundas al fallo"
                    }
                },
                Documentos = new List<DocumentoModel>{
                    new DocumentoModel
                    {
                        Nombre = "Fotos rotura",
                        DescripcionCorta = "Descomuanalmente destrozado",
                        FechaSubida = new DateTime(2025, 07, 01)
                    }
                }
            },
            new PacienteModel {
                Id = 2,
                Nombre = "Alberto García",
                FechaNacimiento = new DateTime(1985, 7, 12),
                Genero = "Hombre",
                Telefono = 666666662,
                Email = "alberto.García@example.com",
                Direccion = "Calle Falsa2 22"
            },
            new PacienteModel {
                Id = 3,
                Nombre = "Raúl Martínez",
                FechaNacimiento = new DateTime(1990, 9, 1),
                Genero = "Hombre",
                Telefono = 666666663,
                Email = "raul.martinez@example.com",
                Direccion = "Calle Fals3 52"
            }
        };
    }

    public Task<PacienteModel> CreateAsync(PacienteModel dto)
    {
        dto.Id = 4;
        _store.Add(dto);
        return Task.FromResult(dto);
    }

    public Task DeleteAsync(int id)
    {
        _store.RemoveAll(x => x.Id == id);
        return Task.CompletedTask;
    }

    public Task<PacienteModel?> GetByIdAsync(int id)
        => Task.FromResult(_store.FirstOrDefault(x => x.Id == id));

    public Task<IEnumerable<PacienteModel>> SearchAsync(string? term)
    {
        var q = _store.AsEnumerable();
        if (!string.IsNullOrWhiteSpace(term))
            q = q.Where(p => p.Nombre.Contains(term, StringComparison.OrdinalIgnoreCase));
        return Task.FromResult(q);
    }

    public Task UpdateAsync(PacienteModel dto)
    {
        var idx = _store.FindIndex(x => x.Id == dto.Id);
        if (idx >= 0) _store[idx] = dto;
        return Task.CompletedTask;
    }
}
