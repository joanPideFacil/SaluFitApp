using Microsoft.AspNetCore.Mvc;
using SaluFitApp.Web.Models;
using SaluFitApp.Web.Services.Interfaces;

namespace SaluFitApp.Web.Controllers;

public class HomeController : Controller
{
    private readonly IAppointmentService _apptSvc;
    private readonly IPatientService _patientSvc;

    public HomeController(IAppointmentService apptSvc,
                          IPatientService patientSvc)
    {
        _apptSvc = apptSvc;
        _patientSvc = patientSvc;
    }

    public async Task<IActionResult> Index()
    {
        var vm = new DashboardViewModel();
        vm.ActivePatients = 1;
        vm.InactivePatients = 1;
        vm.TodayAppointments = 3;
        return View(vm);
    }
}
