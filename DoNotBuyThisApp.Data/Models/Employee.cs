using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

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
        [DisplayName("Nume"), Display(Order = 0), Description("Numele de familie")]
        public string LastName { get; set; }

        [StringLength(50)]
        [Category("Informatii personale")]
        [DisplayName("Prenume"), Display(Order = 1), Description("Numele primit la nastere")]
        public string FirstName { get; set; }

        [StringLength(50)]
        [Category("Informatii personale")]
        [DisplayName("Functie"), Display(Order = 2), Description("Denumirea pozitiei pe care o ocupa persoana in companie")]
        public string JobTitle { get; set; }

        [Category("Informatii salariale")]
        [DisplayName("Salar brut"), Display(Order = 3), Description("Suma platita de firma catre angajat, inainte sa se aplice taxele")]
        public decimal GrossSalary { get; set; }

        [Category("Informatii salariale")]
        [DisplayName("Premii brute"), Display(Order = 4), Description("Sume aditionale care se adauga la urmatorul salariu")]
        public decimal? BonusGrossSalary { get; set; }

        [Category("Informatii salariale")]
        [DisplayName("Retineri"), Display(Order = 5), Description("Sume care sunt reduse din salarul brut")]
        public decimal? Deductions { get; set; }

        [Browsable(false)]
        public double? PayRise { get; set; }

        [Browsable(false)]
        public byte[]? Picture { get; set; }

        [Browsable(false)]
        public virtual ICollection<Salary> Salaries { get; set; }



        [NotMapped]
        [Category("Informatii salariale")]
        [DisplayName("Spor"), Display(Order = 6), Description("Marire de salar")]
        public int PayRiseDisplay { get => (int)Math.Ceiling(((decimal)PayRise - 1.0M) * 100.0M); set => PayRise = value / 100.0 + 1.0; }

        [NotMapped]
        [ReadOnly(true)]
        [Category("Informatii salariale")]
        [DisplayName("Total salar brut"), Display(Order = 7), Description("Salar brut dupa aplicarea maririi de salar, adaugarea premiilor si scaderea retinerilor")]
        public decimal? TotalGrossSalary { get => GrossSalary * (decimal)PayRise + BonusGrossSalary - Deductions; }

        [NotMapped]
        [Category("Informatii personale")]
        [DisplayName("Imagine de profil"), Display(Order = 8), Description("O poza care care sa fie afisata la profilul angajatului")]
        public Image PictureDisplay
        {
            get
            {
                if (Picture is null) return null;
                var stream = new MemoryStream(Picture);
                stream.Position = 0;
                return Image.FromStream(stream);
            }
            set
            {
                if (value is null) Picture = null;
                var stream = new MemoryStream();
                value.Save(stream, ImageFormat.Png);
                stream.Position = 0;
                Picture = stream.ToArray();
            }
        }
    }
}
