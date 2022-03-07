using DoNotBuyThisApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoNotBuyThisApp.Wizard
{
    public partial class Form2 : Form
    {
        private IEnumerable<string> ReportTypes => new string[] { "Stat de plata", "Fluturasi" };
        private ReportViewer reportViewer;
        private DateTime month;

        public Form2()
        {
            InitializeComponent();

            reportViewer = new ReportViewer();
            reportViewer.Dock = DockStyle.Fill;
            reportViewer.Location = new Point(0, 0);
            Controls.Add(reportViewer);

            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "MMM yyyy";
            comboBox1.DataSource = ReportTypes;

            btnEnter.Select();
            btnEnter.Click += BtnEnter_Click;
        }

        private void BtnEnter_Click(object? sender, EventArgs e)
        {
            month = dateTimePicker1.Value;
            panel1.Hide();

            var template = comboBox1.SelectedIndex switch
            {
                0 => Resources.statdeplata,
                1 => Resources.fluturasi,
                _ => Resources.statdeplata
            };

            var stream = new MemoryStream(template);
            stream.Position = 0;

            var context = new ProjectContext();
            var data = context.EmployeeSalaries
                .Where(a => a.ForMonth.Year == month.Year && a.ForMonth.Month == month.Month);

            reportViewer.LocalReport.LoadReportDefinition(stream);
            reportViewer.LocalReport.DataSources
                .Add(new ReportDataSource("DataSet1", data));
            reportViewer.RefreshReport();
        }
    }
}
