using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SaluFitApp.Web.Domain;
using SaluFitApp.Web.Domain.Entities;
using SaluFitApp.Web.Services.Interfaces;

namespace SaluFitApp.Web.Controllers
{
    public class PatientsController : Controller
    {
        private readonly IPatientService _patientService;

        public PatientsController(IPatientService patientService)
            => _patientService = patientService;

        // GET: /Patients
        public async Task<IActionResult> Index(string? search)
        {
            var patients = await _patientService.SearchAsync(search);
            return View(patients);
        }

        // GET: /Patients/Create
        public IActionResult Create()
        {
            return View(new Patient());
        }

        // POST: /Patients/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Patient model)
        {
            if (!ModelState.IsValid)
                return View(model);

            await _patientService.CreateAsync(model);
            return RedirectToAction(nameof(Index));
        }

        // GET: /Patients/Edit/{id}
        public async Task<IActionResult> Edit(Guid id)
        {
            var patient = await _patientService.GetByIdAsync(id);
            if (patient == null)
                return NotFound();

            return View(patient);
        }

        // POST: /Patients/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Patient model)
        {
            if (!ModelState.IsValid)
                return View(model);

            await _patientService.UpdateAsync(model);
            return RedirectToAction(nameof(Index));
        }

        // GET: /Patients/Delete/{id}
        public async Task<IActionResult> Delete(Guid id)
        {
            await _patientService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
