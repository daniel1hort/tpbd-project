using DoNotBuyThisApp.Data;
using DoNotBuyThisApp.Data.Models;
using Microsoft.Reporting.WinForms;
using System;
using System.Linq;
using System.Windows.Forms;

namespace DoNotBuyThisApp.Wizard
{

    public partial class Form1 : Form
    {
        private Employee LastSelectedEmployee { get; set; }
        private Employee SelectedEmployee { get; set; }

        //private ReportViewer reportViewer;

        public Form1()
        {
            InitializeComponent();
            Load += Form_Load;

            listEmployees.SelectedIndexChanged += ListEmployees_SelectedIndexChanged;
            btnSave.Click += BtnSave_Click;
            btnAdd.Click += BtnAdd_Click;
            btnDelete.Click += BtnDelete_Click;

            //reportViewer = new ReportViewer();
            //reportViewer.Height = 100;
            //reportViewer.Dock = DockStyle.Bottom;
            //Controls.Add(reportViewer);
        }

        private void BtnDelete_Click(object? sender, EventArgs e)
        {
            if (SelectedEmployee.Id is null)
                return;

            var context = new ProjectContext();
            context.Remove(SelectedEmployee);
            context.SaveChanges();
            listEmployees.DataSource = context.Employees.ToList();
        }

        private void BtnAdd_Click(object? sender, EventArgs e)
        {
            var employee = new Employee();
            SelectedEmployee = employee;
            propertyGrid1.SelectedObject = SelectedEmployee;
            listEmployees.ClearSelected();
        }

        private void BtnSave_Click(object? sender, EventArgs e)
        {
            using var context = new ProjectContext();
            context.Employees.Update(SelectedEmployee);
            context.SaveChanges();

            LastSelectedEmployee = SelectedEmployee;
            listEmployees.DataSource = context.Employees.ToList();
            SelectedEmployee = LastSelectedEmployee;
            listEmployees.SelectedItem = SelectedEmployee;
        }

        private void ListEmployees_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (listEmployees.SelectedItem is null)
                return;

            SelectedEmployee = (Employee)listEmployees.SelectedItem;
            RefreshView();
        }

        private void Form_Load(object? sender, EventArgs e)
        {
            using var context = new ProjectContext();
            var employees = context.Employees.ToList();
            //SelectedEmployee = employees.FirstOrDefault();

            listEmployees.DataSource = employees;
        }

        private void RefreshView()
        {
            pictureBox1.Image = SelectedEmployee.PictureDisplay ?? Resources.avatar;
            propertyGrid1.SelectedObject = SelectedEmployee;
        }
    }
}
