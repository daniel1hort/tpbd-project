using DoNotBuyThisApp.Data;
using DoNotBuyThisApp.Data.Models;
using Microsoft.Reporting.WinForms;
using System;
using System.Linq;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using System.Drawing;

namespace DoNotBuyThisApp.Wizard
{

    public partial class Form1 : Form
    {
        private Employee LastSelectedEmployee { get; set; }
        private Employee SelectedEmployee { get; set; }
        private Func<Employee, bool> Filter { get; set; }
        private Func<EmployeeSalary, bool> ReportFilter { get; set; }

        public Form1()
        {
            InitializeComponent();
            Load += Form_Load;

            listEmployees.SelectedIndexChanged += ListEmployees_SelectedIndexChanged;
            btnSave.Click += BtnSave_Click;
            btnAdd.Click += BtnAdd_Click;
            btnDelete.Click += BtnDelete_Click;
            btnReports.Click += BtnReport1_Click;
            btnGen.Click += BtnGen_Click;
            btnChangeTax.Click += BtnChangeTax_Click;
            btnChangePass.Click += BtnChangePass_Click;
            txtFilter.TextChanged += TxtFilter_TextChanged;

            Filter = a => true;
            ReportFilter = a => true;
        }

        private void BtnChangePass_Click(object? sender, EventArgs e)
        {
            var form = new Form4();
            var result = form.ShowDialog();

            if (result == DialogResult.Cancel)
                return;

            if (!form.Success)
            {
                DisplayMessage(form.Error, Color.DarkRed);
                return;
            }

            DisplayMessage("Parola modificata cu succes", Color.DarkGreen);
        }

        private void BtnChangeTax_Click(object? sender, EventArgs e)
        {
            var form = new Form3();
            var result = form.ShowDialog();

            if (result == DialogResult.Cancel)
                return;

            if (!form.Success)
            {
                DisplayMessage(form.Error, Color.DarkRed);
                return;
            }

            DisplayMessage("Impozit modificat cu succes", Color.DarkGreen);
        }

        private void TxtFilter_TextChanged(object? sender, EventArgs e)
        {
            var context = new ProjectContext();
            if (string.IsNullOrWhiteSpace(txtFilter.Text))
            {
                Filter = a => true;
                ReportFilter = a => true;
            } else
            {
                Filter = a => $"{a.FirstName} {a.LastName}".ToLower().Contains(txtFilter.Text.ToLower());
                ReportFilter = a => $"{a.FirstName} {a.LastName}".ToLower().Contains(txtFilter.Text.ToLower());
            }
            listEmployees.DataSource = context.Employees.Where(Filter).ToList();
        }

        private void BtnGen_Click(object? sender, EventArgs e)
        {
            var context = new ProjectContext();
            var rows = context.Database.ExecuteSqlRaw("exec CreateSalaries");
            DisplayMessage($"{rows} salarii generate pentru luna trecuta", Color.DarkGreen);
        }

        private void BtnReport1_Click(object? sender, EventArgs e)
        {
            var reportForm = new Form2(ReportFilter);
            reportForm.Show();
        }

        private void BtnDelete_Click(object? sender, EventArgs e)
        {
            if (SelectedEmployee.Id is null)
            {
                DisplayMessage("Te rog selecteaza un angajat inainte", Color.DarkRed);
                return;
            }

            var response = MessageBox.Show($"Esti sugur ca vrei sa stergi {SelectedEmployee}?", "Atentie!", MessageBoxButtons.YesNo);
            if (response == DialogResult.No)
                return;

            var context = new ProjectContext();
            context.Remove(SelectedEmployee);
            context.SaveChanges();
            DisplayMessage($"{SelectedEmployee} a fost sters cu succes", Color.DarkGreen);
            listEmployees.DataSource = context.Employees.ToList();
        }

        private void BtnAdd_Click(object? sender, EventArgs e)
        {
            var employee = new Employee();
            SelectedEmployee = employee;
            propertyGrid1.SelectedObject = SelectedEmployee;
            listEmployees.ClearSelected();
            pictureBox1.Image = Resources.avatar;
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
            DisplayMessage($"Informatiile lui {SelectedEmployee} au fost salvate cu succes", Color.DarkGreen);
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

        private void DisplayMessage(string message, Color color)
        {
            textInfo.BackColor = textInfo.BackColor;
            textInfo.ForeColor = color;
            textInfo.Text = message;
        }

        private bool CheckPassword(ProjectContext context, string password)
            => context.Constants.Any(a => a.Name == "Password" && a.LiteralValue == password);
        private bool AnyPassword(ProjectContext context)
            => context.Constants.Any(a => a.Name == "Password");
    }
}
