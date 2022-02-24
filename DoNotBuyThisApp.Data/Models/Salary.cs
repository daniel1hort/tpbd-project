using System;
using System.Collections.Generic;

namespace DoNotBuyThisApp.Data.Models
{
    public partial class Salary
    {
        public Guid? Id { get; set; }
        public int EmployeeId { get; set; }
        public DateTime? EmitedAt { get; set; }
        public DateTime ForMonth { get; set; }
        public decimal TotalGrossSalary { get; set; }
        public decimal TotalTaxableSalary { get; set; }
        public decimal Tax { get; set; }
        public decimal Cas { get; set; }
        public decimal Cass { get; set; }
        public decimal NetSalary { get; set; }

        public virtual Employee Employee { get; set; }
    }
}
