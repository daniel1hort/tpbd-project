using DoNotBuyThisApp.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoNotBuyThisApp.Wizard
{
    public partial class Form3 : Form
    {
        public double NewTax { get; set; }
        public string Error { get; set; }
        public bool Success { get; set; }

        public Form3()
        {
            InitializeComponent();

            var context = new ProjectContext();
            var tax = context.Constants.FirstOrDefault(a => a.Name == "Tax")?.NumericValue;
            int tax100 = (int)(tax * 100.0f);

            numOldTax.Value = tax100;
            btnSave.Click += BtnSave_Click;
        }

        private void BtnSave_Click(object? sender, EventArgs e)
        {
            var newTax = numNewTax.Value;
            var inputPass = txtPass.Text;

            var context = new ProjectContext();
            var pass = context.Constants.FirstOrDefault(a => a.Name == "Password")?.LiteralValue;

            if(pass != inputPass)
            {
                Error = "Parola introdusa este gresita";
                Success = false;
                return;
            }

            var tax = context.Constants.FirstOrDefault(a => a.Name == "Tax");
            tax.NumericValue = (double)newTax / 100.0;
            context.Constants.Update(tax);
            context.SaveChanges();
            Success = true;
        }
    }
}
