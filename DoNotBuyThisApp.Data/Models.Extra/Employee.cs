using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DoNotBuyThisApp.Data.Models
{
    public partial class Employee
    {
        public Employee(string firstName, string lastName, string jobTitle, decimal grossSalary)
            : this()
        {
            FirstName = firstName;
            LastName = lastName;
            JobTitle = jobTitle;
            GrossSalary = grossSalary;
        }

        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }

        public (bool, string?) ValidateProperties()
        {
            var result = string.Empty;
            if (string.IsNullOrWhiteSpace(FirstName))
                result += "Prenumele nu poate fi gol\n";
            if (FirstName?.Length > 50)
                result += "Prenumele poate sa aiba maxim 50 de caractere\n";
            if (string.IsNullOrWhiteSpace(LastName))
                result += "Numele nu poate fi gol\n";
            if (LastName?.Length > 50)
                result += "Numele poate sa aiba maxim 50 de caractere\n";
            if (string.IsNullOrWhiteSpace(JobTitle))
                result += "Functia nu poate fi goala\n";
            if (JobTitle?.Length > 50)
                result += "Functia poate sa aiba maxim 50 de caractere\n";

            return string.IsNullOrWhiteSpace(result) switch
            {
                true => (true, null),
                _ => (false, result)
            };
        }
    }
}
