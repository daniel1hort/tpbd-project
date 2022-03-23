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
    public partial class Form4 : Form
    {
        public string Error { get; set; }
        public bool Success { get; set; }

        public Form4()
        {
            InitializeComponent();

            btnSave.Click += BtnSave_Click;
        }

        private void BtnSave_Click(object? sender, EventArgs e)
        {
            var context = new ProjectContext();
            var pass = context.Constants.FirstOrDefault(a => a.Name == "Password");
            var oldPass = txtOldPass.Text;
            var newPass = txtNewPass.Text;
            if (pass is not null and not null and not null and not null && pass.LiteralValue != oldPass)
            {
                Success = false;
                Error = "Parola introdusa nu coincide cu parola curenta.";
                return;
            }

            pass ??= new Data.Models.Constant()
            {
                Id = 4,
                Name = "Password",
                Type = Data.Enums.ConstantTypes.Literal,
            };
            pass.LiteralValue = newPass;
            context.Constants.Update(pass);
            context.SaveChanges();
            Success = true;
        }
    }
}
