using BlaisePascal.ExArray_Benedettini_Sofia.Domain;
using System;

namespace BlaisePascal.ExArray_Benedettini_Sofia.ConsoleApp
{
    internal class Program
    {
        static void Main()
        {
            try
            {
                WeeklySchedule employee1 = new WeeklySchedule("Mara Bianchi");

                employee1.SetHoursForDay("Lunedì", 8.0);
                employee1.SetHoursForDay("Martedì", 9.0);
                employee1.SetHoursForDay("Mercoledì", 8.5);
                employee1.SetHoursForDay("Giovedì", 9.0);
                employee1.SetHoursForDay("Venerdì", 8.0);
                employee1.SetHoursForDay("Sabato", 14.0);

                Console.WriteLine($"{employee1.EmployeeName} report:");
                Console.WriteLine($"Total hours worked during the week: {employee1.TotalHoursWorked()}");
                Console.WriteLine($"Has the employee overtime: {employee1.HasOvertime()}");
                Console.WriteLine($"Day with most hours: {employee1.DayWithMostHours()}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Errore: {ex.Message}");
            }
        }
    }
}
