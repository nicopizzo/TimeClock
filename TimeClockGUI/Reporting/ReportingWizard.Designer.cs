namespace TimeClockGUI.Reporting
{
    partial class ReportingWizard
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnNext = new System.Windows.Forms.Button();
            this.Cancel = new System.Windows.Forms.Button();
            this.btnPrevious = new System.Windows.Forms.Button();
            this.btnFinish = new System.Windows.Forms.Button();
            this.wizardPages1 = new TimeClockGUI.Reporting.WizardPages();
            this.tabReportSelection = new System.Windows.Forms.TabPage();
            this.panel3 = new System.Windows.Forms.Panel();
            this.rdoPayReport = new System.Windows.Forms.RadioButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.panel1.SuspendLayout();
            this.wizardPages1.SuspendLayout();
            this.tabReportSelection.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnFinish);
            this.panel1.Controls.Add(this.btnPrevious);
            this.panel1.Controls.Add(this.Cancel);
            this.panel1.Controls.Add(this.btnNext);
            this.panel1.Location = new System.Drawing.Point(0, 454);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(635, 84);
            this.panel1.TabIndex = 1;
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(328, 33);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(75, 23);
            this.btnNext.TabIndex = 0;
            this.btnNext.Text = "Next";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // Cancel
            // 
            this.Cancel.Location = new System.Drawing.Point(83, 33);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(75, 23);
            this.Cancel.TabIndex = 1;
            this.Cancel.Text = "Cancel";
            this.Cancel.UseVisualStyleBackColor = true;
            this.Cancel.Click += new System.EventHandler(this.Cancel_Click);
            // 
            // btnPrevious
            // 
            this.btnPrevious.Location = new System.Drawing.Point(247, 33);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(75, 23);
            this.btnPrevious.TabIndex = 2;
            this.btnPrevious.Text = "Previous";
            this.btnPrevious.UseVisualStyleBackColor = true;
            this.btnPrevious.Click += new System.EventHandler(this.btnPrevious_Click);
            // 
            // btnFinish
            // 
            this.btnFinish.Location = new System.Drawing.Point(483, 33);
            this.btnFinish.Name = "btnFinish";
            this.btnFinish.Size = new System.Drawing.Size(75, 23);
            this.btnFinish.TabIndex = 3;
            this.btnFinish.Text = "Finish";
            this.btnFinish.UseVisualStyleBackColor = true;
            this.btnFinish.Click += new System.EventHandler(this.btnFinish_Click);
            // 
            // wizardPages1
            // 
            this.wizardPages1.Controls.Add(this.tabReportSelection);
            this.wizardPages1.Controls.Add(this.tabPage2);
            this.wizardPages1.Location = new System.Drawing.Point(0, 0);
            this.wizardPages1.Name = "wizardPages1";
            this.wizardPages1.SelectedIndex = 0;
            this.wizardPages1.Size = new System.Drawing.Size(635, 448);
            this.wizardPages1.TabIndex = 0;
            // 
            // tabReportSelection
            // 
            this.tabReportSelection.Controls.Add(this.panel3);
            this.tabReportSelection.Controls.Add(this.panel2);
            this.tabReportSelection.Location = new System.Drawing.Point(4, 22);
            this.tabReportSelection.Name = "tabReportSelection";
            this.tabReportSelection.Padding = new System.Windows.Forms.Padding(3);
            this.tabReportSelection.Size = new System.Drawing.Size(627, 422);
            this.tabReportSelection.TabIndex = 0;
            this.tabReportSelection.Text = "Report Selection";
            this.tabReportSelection.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.rdoPayReport);
            this.panel3.Location = new System.Drawing.Point(8, 92);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(613, 324);
            this.panel3.TabIndex = 1;
            // 
            // rdoPayReport
            // 
            this.rdoPayReport.AutoSize = true;
            this.rdoPayReport.Location = new System.Drawing.Point(71, 42);
            this.rdoPayReport.Name = "rdoPayReport";
            this.rdoPayReport.Size = new System.Drawing.Size(78, 17);
            this.rdoPayReport.TabIndex = 1;
            this.rdoPayReport.TabStop = true;
            this.rdoPayReport.Text = "Pay Report";
            this.rdoPayReport.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.textBox1);
            this.panel2.Location = new System.Drawing.Point(8, 6);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(613, 80);
            this.panel2.TabIndex = 0;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.Control;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Location = new System.Drawing.Point(195, 25);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(139, 20);
            this.textBox1.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(627, 422);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // ReportingWizard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(638, 538);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.wizardPages1);
            this.Name = "ReportingWizard";
            this.Text = "Reporting Wizard";
            this.panel1.ResumeLayout(false);
            this.wizardPages1.ResumeLayout(false);
            this.tabReportSelection.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private WizardPages wizardPages1;
        private System.Windows.Forms.TabPage tabReportSelection;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnFinish;
        private System.Windows.Forms.Button btnPrevious;
        private System.Windows.Forms.Button Cancel;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.RadioButton rdoPayReport;
    }
}