//using Microsoft.AspNetCore.Mvc;
//using SaluFitApp.Web.Models;

//public class NotaController : Controller
//{
//    private readonly FakeNotaService _notaService;

//    public NotaController(FakeNotaService context)
//    {
//        _notaService = context;
//    }

//    // GET partial para editar (o ver) una nota existente
//    [HttpGet]
//    public async Task<IActionResult> Editar(int id)
//    {
//        var nota = await _context.Nota.FirstOrDefaultAsync(n => n.Id == id);
//        if (nota == null) return NotFound();

//        var vm = new CrearEditarNotaInputModel
//        {
//            Id = nota.Id,
//            PacienteId = nota.PacienteId,
//            Titulo = nota.Titulo,
//            Contenido = nota.Contenido
//        };

//        return PartialView("_EditarNotaForm", vm);
//    }

//    // POST creación o edición (determina por Id)
//    [HttpPost]
//    [ValidateAntiForgeryToken]
//    public async Task<IActionResult> Guardar(CrearEditarNotaInputModel input)
//    {
//        if (!ModelState.IsValid)
//            return BadRequest(ModelState);

//        NotaModel nota;

//        if (input.Id == null)
//        {
//            // crear nueva
//            nota = new NotaModel
//            {
//                Id = 2,
//                FKPaciente = input.PacienteId,
//                Titulo = input.Titulo,
//                Contenido = input.Contenido,
//                Fecha = DateTime.UtcNow
//            };

//            _context.Notas.Add(nota);
//        }
//        else
//        {
//            // editar existente
//            nota = await _context.Notas.FirstOrDefaultAsync(n => n.Id == input.Id);
//            if (nota == null) return NotFound();

//            nota.Titulo = input.Titulo;
//            nota.Contenido = input.Contenido;
//            // opcional: actualizar fecha si lo deseas
//        }

//        await _context.SaveChangesAsync();

//        // devolver la representación de la nota para re-renderizar en la lista
//        return PartialView("_NotaItem", nota);
//    }

//    // POST borrar
//    [HttpPost]
//    [ValidateAntiForgeryToken]
//    public async Task<IActionResult> Borrar(int id)
//    {
//        var nota = await _context.Notas.FirstOrDefaultAsync(n => n.Id == id);
//        if (nota == null) return NotFound();

//        _context.Notas.Remove(nota);
//        await _context.SaveChangesAsync();

//        return Ok(); // cliente puede quitar el item del DOM
//    }
//}
