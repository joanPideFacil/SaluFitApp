using System;
using System.Collections.Generic;

namespace SaluFitApp.Web.Models
{
    public class NotificationDto
    {
        public string Title { get; set; } = null!;
        public string Message { get; set; } = null!;
        public DateTime Date { get; set; }
    }
    public class DashboardViewModel
    {
        public int TodayAppointments { get; set; }
        public int ActivePatients { get; set; }
        public int InactivePatients { get; set; }
        public int NotificationsCount { get; set; }
        public List<NotificationDto> RecentNotifications { get; set; } = new();
    }
}
