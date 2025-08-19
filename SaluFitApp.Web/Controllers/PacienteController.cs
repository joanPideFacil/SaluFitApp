using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SaluFitApp.Web.Models;

namespace SaluFitApp.Web.Controllers
{
    public class PacienteController : Controller
    {

        private readonly FakePacienteService _pacienteService;
        private readonly FakeNotaService _notaService;

        public PacienteController(FakePacienteService pacienteService, FakeNotaService notaService)
        {
            _pacienteService = pacienteService;
            _notaService = notaService;
        }

        // GET: /Pacientes
        public async Task<IActionResult> Index(string? search)
        {
            var pacientes = await _pacienteService.SearchAsync(search);
            return View(pacientes);
        }

        // GET: /Pacientes/Create
        public IActionResult Create()
        {
            return View(new PacienteModel());
        }

        // POST: /Pacientes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PacienteModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            await _pacienteService.CreateAsync(model);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddNote(int pacienteId, string contenido)
        {
            if (string.IsNullOrWhiteSpace(contenido))
            {
                // puedes manejar el error o devolverlo con ModelState
                return RedirectToAction("Details", new { id = pacienteId });
            }

            var nuevaNota = new NotaModel
            {
                Titulo = "Nota manual", // si decides no incluir campo de título
                Contenido = contenido,
                Fecha = DateTime.Now,
                FKPaciente = 0 // aquí tu lógica de FK (si lo manejas desde Guid, adaptarlo)
            };

            _notaService.CreateAsync(nuevaNota); // o como lo manejes

            return RedirectToAction("Edit", new { id = pacienteId });
        }


        // GET: /Pacientes/Edit/{id}
        public async Task<IActionResult> Edit(int id)
        {
            var paciente = await _pacienteService.GetByIdAsync(id);
            if (paciente == null)
                return NotFound();

            var notas = await _notaService.GetByPacienteAsync(id);
            ViewBag.Notas = notas;

            return View(paciente);
        }

        // POST: /Pacientes/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(PacienteModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            await _pacienteService.UpdateAsync(model);
            return RedirectToAction(nameof(Index));
        }

        // GET: /Pacientes/Delete/{id}
        public async Task<IActionResult> Delete(int id)
        {
            await _pacienteService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
