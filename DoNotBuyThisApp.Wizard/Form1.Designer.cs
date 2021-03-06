using System.Windows.Forms;

namespace DoNotBuyThisApp.Wizard
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.listEmployees = new System.Windows.Forms.ListBox();
            this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
            this.btnSave = new System.Windows.Forms.Button();
            this.textInfo = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnReports = new System.Windows.Forms.Button();
            this.btnGen = new System.Windows.Forms.Button();
            this.txtFilter = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnChangeTax = new System.Windows.Forms.Button();
            this.btnChangePass = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // listEmployees
            // 
            this.listEmployees.FormattingEnabled = true;
            this.listEmployees.ItemHeight = 20;
            this.listEmployees.Location = new System.Drawing.Point(12, 12);
            this.listEmployees.Name = "listEmployees";
            this.listEmployees.Size = new System.Drawing.Size(405, 624);
            this.listEmployees.TabIndex = 0;
            // 
            // propertyGrid1
            // 
            this.propertyGrid1.Location = new System.Drawing.Point(423, 12);
            this.propertyGrid1.Name = "propertyGrid1";
            this.propertyGrid1.PropertySort = System.Windows.Forms.PropertySort.Categorized;
            this.propertyGrid1.Size = new System.Drawing.Size(474, 447);
            this.propertyGrid1.TabIndex = 1;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(903, 646);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(327, 50);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "Salveaza";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // textInfo
            // 
            this.textInfo.ForeColor = System.Drawing.SystemColors.ControlText;
            this.textInfo.Location = new System.Drawing.Point(423, 465);
            this.textInfo.Multiline = true;
            this.textInfo.Name = "textInfo";
            this.textInfo.ReadOnly = true;
            this.textInfo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textInfo.Size = new System.Drawing.Size(474, 231);
            this.textInfo.TabIndex = 3;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.Desktop;
            this.pictureBox1.Location = new System.Drawing.Point(903, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(327, 235);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(903, 590);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(327, 50);
            this.btnAdd.TabIndex = 5;
            this.btnAdd.Text = "Adauga angajat";
            this.btnAdd.UseVisualStyleBackColor = true;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(903, 534);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(327, 50);
            this.btnDelete.TabIndex = 6;
            this.btnDelete.Text = "Sterge angajat";
            this.btnDelete.UseVisualStyleBackColor = true;
            // 
            // btnReports
            // 
            this.btnReports.Location = new System.Drawing.Point(903, 253);
            this.btnReports.Name = "btnReports";
            this.btnReports.Size = new System.Drawing.Size(327, 50);
            this.btnReports.TabIndex = 7;
            this.btnReports.Text = "Rapoarte";
            this.btnReports.UseVisualStyleBackColor = true;
            // 
            // btnGen
            // 
            this.btnGen.Location = new System.Drawing.Point(903, 309);
            this.btnGen.Name = "btnGen";
            this.btnGen.Size = new System.Drawing.Size(327, 50);
            this.btnGen.TabIndex = 8;
            this.btnGen.Text = "Genereaza salarii";
            this.btnGen.UseVisualStyleBackColor = true;
            // 
            // txtFilter
            // 
            this.txtFilter.Location = new System.Drawing.Point(12, 665);
            this.txtFilter.Name = "txtFilter";
            this.txtFilter.Size = new System.Drawing.Size(405, 27);
            this.txtFilter.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 642);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(233, 20);
            this.label1.TabIndex = 10;
            this.label1.Text = "Filtreaza dupa nume sau prenume";
            // 
            // btnChangeTax
            // 
            this.btnChangeTax.Location = new System.Drawing.Point(903, 365);
            this.btnChangeTax.Name = "btnChangeTax";
            this.btnChangeTax.Size = new System.Drawing.Size(327, 50);
            this.btnChangeTax.TabIndex = 11;
            this.btnChangeTax.Text = "Schimba impozitul";
            this.btnChangeTax.UseVisualStyleBackColor = true;
            // 
            // btnChangePass
            // 
            this.btnChangePass.Location = new System.Drawing.Point(903, 421);
            this.btnChangePass.Name = "btnChangePass";
            this.btnChangePass.Size = new System.Drawing.Size(327, 50);
            this.btnChangePass.TabIndex = 12;
            this.btnChangePass.Text = "Schimba parola";
            this.btnChangePass.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1242, 704);
            this.Controls.Add(this.btnChangePass);
            this.Controls.Add(this.btnChangeTax);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtFilter);
            this.Controls.Add(this.btnGen);
            this.Controls.Add(this.btnReports);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.textInfo);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.propertyGrid1);
            this.Controls.Add(this.listEmployees);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.Text = "Nu cumparati aplicatia asta!";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ListBox listEmployees;
        private PropertyGrid propertyGrid1;
        private Button btnSave;
        private TextBox textInfo;
        private PictureBox pictureBox1;
        private Button btnAdd;
        private Button btnDelete;
        private Button btnReports;
        private Button btnGen;
        private TextBox txtFilter;
        private Label label1;
        private Button btnChangeTax;
        private Button btnChangePass;
    }
}
