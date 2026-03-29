using System;
using UnityEngine;

public class NotificationService
{
    private static NotificationService _instance;
    public static NotificationService Instance => _instance ??= new NotificationService();

    public void SchedulePaymentReminder(string rentalId, DateTime dueDate)
    {
        DateTime triggerDate = dueDate.AddDays(-3);
        ScheduleNotification(
            "PaymentReminder_" + rentalId,
            "Upcoming Payment",
            "Your rent or utility payment is due soon.",
            triggerDate,
            "RentalDetail"
        );
    }

    public void ScheduleOverdueAlert(string rentalId, DateTime dueDate)
    {
        ScheduleNotification(
            "Overdue_" + rentalId,
            "Payment Overdue",
            "You have an overdue rent or utility payment.",
            dueDate,
            "RentalDetail"
        );
    }

    public void ScheduleMonthlySummary()
    {
        DateTime now = DateTime.Now;
        DateTime firstOfNext = new DateTime(now.Year, now.Month, 1).AddMonths(1);
        ScheduleNotification(
            "MonthlySummary",
            "Monthly Expense Summary",
            "Your rental and utility expenses for this month are ready.",
            firstOfNext,
            "Analytics"
        );
    }

    private void ScheduleNotification(string id, string title, string body, DateTime triggerDate, string deepLink)
    {
        Debug.Log($"[NotificationService] Scheduling '{title}' at {triggerDate}");
    }

    public void CancelAllNotifications()
    {
        Debug.Log("[NotificationService] All notifications cancelled.");
    }
}