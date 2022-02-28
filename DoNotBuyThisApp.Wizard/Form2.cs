using DoNotBuyThisApp.Data;
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
        private ReportViewer reportViewer;

        public Form2()
        {
            InitializeComponent();

            Load += Form2_Load;

            reportViewer = new ReportViewer();
            reportViewer.Dock = DockStyle.Fill;
            reportViewer.Location = new Point(0, 0);
            Controls.Add(reportViewer);
        }

        private void Form2_Load(object? sender, EventArgs e)
        {
            var stream = new MemoryStream(Resources.Untitled);
            stream.Position = 0;

            reportViewer.LocalReport.LoadReportDefinition(stream);
            reportViewer.LocalReport.DataSources
                .Add(new ReportDataSource("DataSet1", new ProjectContext().Employees));
            reportViewer.RefreshReport();
        }
    }
}
