using System;
using App.Models.ThirdPartySerialization;

namespace App.Extensions
{
    public static class EmployeeExtensions
    {
        private const ConsoleColor DefaultColor = ConsoleColor.DarkBlue;

        public static void WriteLine(this Models.BasicSerialization.Employee employee, string description, ConsoleColor color = DefaultColor)
        {
            color.WriteLine($"{description} : {employee}");
        }

        public static void WriteLine(this Models.CustomSerialization.Employee employee, string description, ConsoleColor color = DefaultColor)
        {
            color.WriteLine($"{description} : {employee}");
        }

        public static void WriteLine(this Employee employee, string description, ConsoleColor color = DefaultColor)
        {
            color.WriteLine($"{description} : {employee}");
        }
    }
}