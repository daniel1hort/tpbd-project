using System;
using System.Collections.Generic;

#nullable disable

namespace DoNotBuyThisApp.Data.Models
{
    public partial class EmployeeSalary
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string JobTitle { get; set; }
        public decimal GrossSalary { get; set; }
        public double? PayRise { get; set; }
        public decimal? BonusGrossSalary { get; set; }
        public decimal? Deductions { get; set; }
        public Guid SalaryId { get; set; }
        public DateTime? EmitedAt { get; set; }
        public DateTime ForMonth { get; set; }
        public decimal TotalGrossSalary { get; set; }
        public decimal TotalTaxableSalary { get; set; }
        public decimal Tax { get; set; }
        public decimal Cas { get; set; }
        public decimal Cass { get; set; }
        public decimal NetSalary { get; set; }
    }
}
