namespace TimeClock
{
    partial class GUI
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.signInToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.adminToolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addEmployeeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modifyEmployeeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeEmployeeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timeClock = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dateClock = new System.Windows.Forms.Label();
            this.btnClockIn = new System.Windows.Forms.Button();
            this.btnClockOut = new System.Windows.Forms.Button();
            this.gridEmployees = new System.Windows.Forms.DataGridView();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridEmployees)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.reportingToolStripMenuItem,
            this.adminToolsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(843, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.signInToolStripMenuItem,
            this.closeToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // signInToolStripMenuItem
            // 
            this.signInToolStripMenuItem.Name = "signInToolStripMenuItem";
            this.signInToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.signInToolStripMenuItem.Text = "Sign In";
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.closeToolStripMenuItem.Text = "Close";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // reportingToolStripMenuItem
            // 
            this.reportingToolStripMenuItem.Name = "reportingToolStripMenuItem";
            this.reportingToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
            this.reportingToolStripMenuItem.Text = "Reporting";
            this.reportingToolStripMenuItem.Click += new System.EventHandler(this.reportingToolStripMenuItem_Click);
            // 
            // adminToolsToolStripMenuItem
            // 
            this.adminToolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addEmployeeToolStripMenuItem,
            this.modifyEmployeeToolStripMenuItem,
            this.removeEmployeeToolStripMenuItem,
            this.settingsToolStripMenuItem});
            this.adminToolsToolStripMenuItem.Name = "adminToolsToolStripMenuItem";
            this.adminToolsToolStripMenuItem.Size = new System.Drawing.Size(86, 20);
            this.adminToolsToolStripMenuItem.Text = "Admin Tools";
            // 
            // addEmployeeToolStripMenuItem
            // 
            this.addEmployeeToolStripMenuItem.Name = "addEmployeeToolStripMenuItem";
            this.addEmployeeToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.addEmployeeToolStripMenuItem.Text = "Add Employee";
            this.addEmployeeToolStripMenuItem.Click += new System.EventHandler(this.addEmployeeToolStripMenuItem_Click);
            // 
            // modifyEmployeeToolStripMenuItem
            // 
            this.modifyEmployeeToolStripMenuItem.Name = "modifyEmployeeToolStripMenuItem";
            this.modifyEmployeeToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.modifyEmployeeToolStripMenuItem.Text = "Modify Employee";
            this.modifyEmployeeToolStripMenuItem.Click += new System.EventHandler(this.modifyEmployeeToolStripMenuItem_Click);
            // 
            // removeEmployeeToolStripMenuItem
            // 
            this.removeEmployeeToolStripMenuItem.Name = "removeEmployeeToolStripMenuItem";
            this.removeEmployeeToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.removeEmployeeToolStripMenuItem.Text = "Remove Employee";
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.settingsToolStripMenuItem.Text = "Settings";
            // 
            // timeClock
            // 
            this.timeClock.AutoSize = true;
            this.timeClock.Dock = System.Windows.Forms.DockStyle.Top;
            this.timeClock.Font = new System.Drawing.Font("Arial Rounded MT Bold", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timeClock.Location = new System.Drawing.Point(0, 0);
            this.timeClock.Name = "timeClock";
            this.timeClock.Size = new System.Drawing.Size(175, 43);
            this.timeClock.TabIndex = 1;
            this.timeClock.Text = "00:00:00";
            this.timeClock.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // panel1
            // 
            this.panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel1.Controls.Add(this.splitContainer1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(843, 644);
            this.panel1.TabIndex = 2;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.panel3);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.gridEmployees);
            this.splitContainer1.Size = new System.Drawing.Size(843, 644);
            this.splitContainer1.SplitterDistance = 322;
            this.splitContainer1.TabIndex = 6;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.panel2);
            this.panel3.Controls.Add(this.btnClockIn);
            this.panel3.Controls.Add(this.btnClockOut);
            this.panel3.Location = new System.Drawing.Point(233, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(339, 181);
            this.panel3.TabIndex = 6;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.timeClock);
            this.panel2.Controls.Add(this.dateClock);
            this.panel2.Location = new System.Drawing.Point(54, 30);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(234, 90);
            this.panel2.TabIndex = 3;
            // 
            // dateClock
            // 
            this.dateClock.AutoSize = true;
            this.dateClock.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dateClock.Font = new System.Drawing.Font("Arial Rounded MT Bold", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateClock.Location = new System.Drawing.Point(0, 66);
            this.dateClock.Name = "dateClock";
            this.dateClock.Size = new System.Drawing.Size(187, 24);
            this.dateClock.TabIndex = 2;
            this.dateClock.Text = "January 1st, 2016";
            this.dateClock.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnClockIn
            // 
            this.btnClockIn.Location = new System.Drawing.Point(3, 155);
            this.btnClockIn.Name = "btnClockIn";
            this.btnClockIn.Size = new System.Drawing.Size(75, 23);
            this.btnClockIn.TabIndex = 4;
            this.btnClockIn.Text = "Clock In";
            this.btnClockIn.UseVisualStyleBackColor = true;
            this.btnClockIn.Click += new System.EventHandler(this.btnClockIn_Click);
            // 
            // btnClockOut
            // 
            this.btnClockOut.Location = new System.Drawing.Point(261, 155);
            this.btnClockOut.Name = "btnClockOut";
            this.btnClockOut.Size = new System.Drawing.Size(75, 23);
            this.btnClockOut.TabIndex = 5;
            this.btnClockOut.Text = "Clock Out";
            this.btnClockOut.UseVisualStyleBackColor = true;
            this.btnClockOut.Click += new System.EventHandler(this.btnClockOut_Click);
            // 
            // gridEmployees
            // 
            this.gridEmployees.AllowUserToAddRows = false;
            this.gridEmployees.AllowUserToDeleteRows = false;
            this.gridEmployees.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridEmployees.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridEmployees.Location = new System.Drawing.Point(0, 0);
            this.gridEmployees.MultiSelect = false;
            this.gridEmployees.Name = "gridEmployees";
            this.gridEmployees.ReadOnly = true;
            this.gridEmployees.RowHeadersVisible = false;
            this.gridEmployees.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridEmployees.Size = new System.Drawing.Size(843, 318);
            this.gridEmployees.TabIndex = 0;
            // 
            // GUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(843, 668);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "GUI";
            this.Text = "TimeClock";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridEmployees)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem signInToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reportingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem adminToolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addEmployeeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modifyEmployeeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeEmployeeToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label timeClock;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label dateClock;
        private System.Windows.Forms.Button btnClockOut;
        private System.Windows.Forms.Button btnClockIn;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView gridEmployees;
        private System.Windows.Forms.Panel panel3;
    }
}

