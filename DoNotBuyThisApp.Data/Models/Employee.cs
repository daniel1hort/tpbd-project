using System;
using System.Collections.Generic;

namespace DoNotBuyThisApp.Data.Models
{
    public partial class Employee
    {
        public Employee()
        {
            Salaries = new HashSet<Salary>();
        }

        public int? Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string JobTitle { get; set; }
        public decimal GrossSalary { get; set; }
        public double? PayRise { get; set; }
        public decimal? BonusGrossSalary { get; set; }
        public decimal? Deductions { get; set; }
        public byte[] Picture { get; set; }

        public virtual ICollection<Salary> Salaries { get; set; }
    }
}
