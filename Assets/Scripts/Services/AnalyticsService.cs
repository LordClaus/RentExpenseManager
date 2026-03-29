using System;
using System.Collections.Generic;
using System.Linq;

public class AnalyticsService
{
    private static AnalyticsService _instance;
    public static AnalyticsService Instance => _instance ??= new AnalyticsService();

    public Dictionary<string, float> GetExpensesByCategory(string rentalId)
    {
        return LocalStorageService.Instance.LoadUtilities()
            .Where(u => u.RentalId == rentalId)
            .GroupBy(u => u.CategoryName)
            .ToDictionary(g => g.Key, g => g.Sum(u => u.Amount));
    }

    public float GetTotalExpensesForMonth(int year, int month)
    {
        float total = 0f;
        foreach (var u in LocalStorageService.Instance.LoadUtilities())
            if (DateTime.TryParse(u.DueDate, out DateTime date))
                if (date.Year == year && date.Month == month)
                    total += u.Amount;
        return total;
    }

    public List<(string Label, float Amount)> GetMonthlyTrend(int monthsCount)
    {
        var result = new List<(string, float)>();
        DateTime now = DateTime.Now;
        for (int i = monthsCount - 1; i >= 0; i--)
        {
            DateTime d = now.AddMonths(-i);
            result.Add((d.ToString("MMM yyyy"), GetTotalExpensesForMonth(d.Year, d.Month)));
        }
        return result;
    }
}