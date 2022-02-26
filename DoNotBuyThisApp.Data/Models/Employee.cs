using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DoNotBuyThisApp.Data.Models
{
    public partial class Employee
    {
        public Employee()
        {
            Salaries = new HashSet<Salary>();
            PayRise = 1;
            BonusGrossSalary = 0;
            Deductions = 0;
        }

        [Browsable(false)]
        public int? Id { get; set; }

        [StringLength(50)]
        [Category("Informatii personale")]
        [DisplayName("Prenume"), Description("Numele primit la nastere")]
        public string FirstName { get; set; }

        [StringLength(50)]
        [Category("Informatii personale")]
        [DisplayName("Nume"), Description("Numele de familie")]
        public string LastName { get; set; }

        [StringLength(50)]
        [Category("Informatii personale")]
        [DisplayName("Functie"), Description("Denumirea pozitiei pe care o ocupa persoana in companie")]
        public string JobTitle { get; set; }

        [Category("Informatii salariale")]
        [DisplayName("Salar brut"), Description("Suma platita de firma catre angajat, inainte sa se aplice taxele")]
        public decimal GrossSalary { get; set; }

        [Browsable(false)]
        public double? PayRise { get; set; }

        [Category("Informatii salariale")]
        [DisplayName("Premii brute"), Description("Sume aditionale care se adauga la urmatorul salariu")]
        public decimal? BonusGrossSalary { get; set; }

        [Category("Informatii salariale")]
        [DisplayName("Retineri"), Description("Sume care sunt reduse din salarul brut")]
        public decimal? Deductions { get; set; }

        [Browsable(false)]
        public byte[]? Picture { get; set; }

        [Browsable(false)]
        public virtual ICollection<Salary> Salaries { get; set; }
    }
}
