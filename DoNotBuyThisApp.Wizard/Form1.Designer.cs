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
            this.textError = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // listEmployees
            // 
            this.listEmployees.FormattingEnabled = true;
            this.listEmployees.ItemHeight = 20;
            this.listEmployees.Location = new System.Drawing.Point(12, 12);
            this.listEmployees.Name = "listEmployees";
            this.listEmployees.Size = new System.Drawing.Size(405, 684);
            this.listEmployees.TabIndex = 0;
            // 
            // propertyGrid1
            // 
            this.propertyGrid1.Location = new System.Drawing.Point(423, 12);
            this.propertyGrid1.Name = "propertyGrid1";
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
            // textError
            // 
            this.textError.Enabled = false;
            this.textError.Location = new System.Drawing.Point(423, 465);
            this.textError.Multiline = true;
            this.textError.Name = "textError";
            this.textError.ReadOnly = true;
            this.textError.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textError.Size = new System.Drawing.Size(474, 231);
            this.textError.TabIndex = 3;
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1242, 709);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.textError);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.propertyGrid1);
            this.Controls.Add(this.listEmployees);
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
        private TextBox textError;
        private PictureBox pictureBox1;
        private Button btnAdd;
        private Button btnDelete;
    }
}