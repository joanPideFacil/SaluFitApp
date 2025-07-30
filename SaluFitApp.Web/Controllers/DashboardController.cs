using Microsoft.AspNetCore.Mvc;
using SaluFitApp.Web.Models;

namespace SaluFitApp.Web.Controllers;

public class DashboardController : Controller
{

    public async Task<IActionResult> Index()
    {
        var vm = new DashboardViewModel();
        vm.ActivePatients = 1;
        vm.InactivePatients = 1;
        vm.TodayAppointments = 3;
        return View(vm);
    }
}
