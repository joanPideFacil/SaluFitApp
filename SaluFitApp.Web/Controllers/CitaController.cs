using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SaluFitApp.Web.Models;

namespace SaluFitApp.Web.Controllers
{
    public class CitaController : Controller
    {
        private readonly FakePacienteService _pacienteService;

        public CitaController(FakePacienteService patientService)
            => _pacienteService = patientService;

        // GET: /Patients
        public async Task<IActionResult> Index(string? search)
        {
            var pacientes = await _pacienteService.SearchAsync(search);
            return View(pacientes);
        }

        // GET: /Patients/Create
        public IActionResult Create()
        {
            return View(new PacienteModel());
        }

        // POST: /Patients/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PacienteModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            await _pacienteService.CreateAsync(model);
            return RedirectToAction(nameof(Index));
        }

        // GET: /Patients/Edit/{id}
        public async Task<IActionResult> Edit(Guid id)
        {
            var paciente = await _pacienteService.GetByIdAsync(id);
            if (paciente == null)
                return NotFound();

            return View(paciente);
        }

        // POST: /Patients/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(PacienteModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            await _pacienteService.UpdateAsync(model);
            return RedirectToAction(nameof(Index));
        }

        // GET: /Patients/Delete/{id}
        public async Task<IActionResult> Delete(Guid id)
        {
            await _pacienteService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
