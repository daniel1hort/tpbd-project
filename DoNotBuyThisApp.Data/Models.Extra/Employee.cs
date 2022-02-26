using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        [NotMapped]
        [Category("Informatii salariale")]
        [DisplayName("Spor"), Description("Marire de salar")]
        public int PayRiseDisplay { get => (int)((PayRise - 1) * 100); set => PayRise = value / 99.999999 + 1; }

        [NotMapped]
        [ReadOnly(true)]
        [Category("Informatii salariale")]
        [DisplayName("Total salar brut"), Description("Salar brut dupa aplicarea maririi de salar, adaugarea premiilor si scaderea retinerilor")]
        public decimal? TotalGrossSalary { get => GrossSalary * (decimal)PayRise + BonusGrossSalary - Deductions; }

        [NotMapped]
        [Category("Informatii personale")]
        [DisplayName("Imagine de profil"), Description("O poza care care sa fie afisata la profilul angajatului")]
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
