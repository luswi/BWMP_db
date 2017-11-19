namespace BWMP_db.modules
{
    partial class NewProjectForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewProjectForm));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.comboboxNOrder = new System.Windows.Forms.ComboBox();
            this.comboboxSfaRec = new System.Windows.Forms.ComboBox();
            this.comboboxSfaSent = new System.Windows.Forms.ComboBox();
            this.comboboxSfaCreated = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.comboboxVesselMethodDil = new System.Windows.Forms.ComboBox();
            this.comboboxVesselMethodFt = new System.Windows.Forms.ComboBox();
            this.comboboxVesselMethodSeq = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.comboboxVesselLcs = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textboxVesselName = new System.Windows.Forms.TextBox();
            this.textboxVesselId = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.comboboxStatus = new System.Windows.Forms.ComboBox();
            this.newProject = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tabPage4.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.AccessibleName = "";
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(876, 599);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.Tag = "";
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox3);
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.pictureBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(868, 566);
            this.tabPage1.TabIndex = 4;
            this.tabPage1.Text = "Main Informations ->";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.comboboxNOrder);
            this.groupBox3.Controls.Add(this.comboboxSfaRec);
            this.groupBox3.Controls.Add(this.comboboxSfaSent);
            this.groupBox3.Controls.Add(this.comboboxSfaCreated);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Location = new System.Drawing.Point(3, 312);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(615, 251);
            this.groupBox3.TabIndex = 9;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "SFA / NOrder";
            // 
            // comboboxNOrder
            // 
            this.comboboxNOrder.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboboxNOrder.FormattingEnabled = true;
            this.comboboxNOrder.Items.AddRange(new object[] {
            "Yes",
            "No"});
            this.comboboxNOrder.Location = new System.Drawing.Point(136, 93);
            this.comboboxNOrder.Name = "comboboxNOrder";
            this.comboboxNOrder.Size = new System.Drawing.Size(223, 28);
            this.comboboxNOrder.TabIndex = 16;
            // 
            // comboboxSfaRec
            // 
            this.comboboxSfaRec.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboboxSfaRec.FormattingEnabled = true;
            this.comboboxSfaRec.Items.AddRange(new object[] {
            "Yes",
            "No",
            "Special Case"});
            this.comboboxSfaRec.Location = new System.Drawing.Point(136, 127);
            this.comboboxSfaRec.Name = "comboboxSfaRec";
            this.comboboxSfaRec.Size = new System.Drawing.Size(223, 28);
            this.comboboxSfaRec.TabIndex = 15;
            // 
            // comboboxSfaSent
            // 
            this.comboboxSfaSent.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboboxSfaSent.FormattingEnabled = true;
            this.comboboxSfaSent.Items.AddRange(new object[] {
            "Yes",
            "No",
            "Special Case"});
            this.comboboxSfaSent.Location = new System.Drawing.Point(136, 59);
            this.comboboxSfaSent.Name = "comboboxSfaSent";
            this.comboboxSfaSent.Size = new System.Drawing.Size(223, 28);
            this.comboboxSfaSent.TabIndex = 14;
            // 
            // comboboxSfaCreated
            // 
            this.comboboxSfaCreated.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboboxSfaCreated.FormattingEnabled = true;
            this.comboboxSfaCreated.Items.AddRange(new object[] {
            "Yes",
            "No",
            "Special Case"});
            this.comboboxSfaCreated.Location = new System.Drawing.Point(136, 25);
            this.comboboxSfaCreated.Name = "comboboxSfaCreated";
            this.comboboxSfaCreated.Size = new System.Drawing.Size(223, 28);
            this.comboboxSfaCreated.TabIndex = 13;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(11, 62);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(76, 20);
            this.label10.TabIndex = 11;
            this.label10.Text = "SFA sent";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(11, 130);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(104, 20);
            this.label9.TabIndex = 10;
            this.label9.Text = "SFA received";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(11, 96);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(60, 20);
            this.label8.TabIndex = 9;
            this.label8.Text = "NOrder";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(11, 28);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(99, 20);
            this.label7.TabIndex = 8;
            this.label7.Text = "SFA created";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.comboboxVesselMethodDil);
            this.groupBox2.Controls.Add(this.comboboxVesselMethodFt);
            this.groupBox2.Controls.Add(this.comboboxVesselMethodSeq);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.comboboxVesselLcs);
            this.groupBox2.Location = new System.Drawing.Point(3, 108);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(615, 198);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "LCS / Methods";
            // 
            // comboboxVesselMethodDil
            // 
            this.comboboxVesselMethodDil.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboboxVesselMethodDil.FormattingEnabled = true;
            this.comboboxVesselMethodDil.Items.AddRange(new object[] {
            "Yes",
            "No"});
            this.comboboxVesselMethodDil.Location = new System.Drawing.Point(136, 127);
            this.comboboxVesselMethodDil.Name = "comboboxVesselMethodDil";
            this.comboboxVesselMethodDil.Size = new System.Drawing.Size(223, 28);
            this.comboboxVesselMethodDil.TabIndex = 12;
            // 
            // comboboxVesselMethodFt
            // 
            this.comboboxVesselMethodFt.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboboxVesselMethodFt.FormattingEnabled = true;
            this.comboboxVesselMethodFt.Items.AddRange(new object[] {
            "Yes",
            "No"});
            this.comboboxVesselMethodFt.Location = new System.Drawing.Point(136, 93);
            this.comboboxVesselMethodFt.Name = "comboboxVesselMethodFt";
            this.comboboxVesselMethodFt.Size = new System.Drawing.Size(223, 28);
            this.comboboxVesselMethodFt.TabIndex = 11;
            // 
            // comboboxVesselMethodSeq
            // 
            this.comboboxVesselMethodSeq.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboboxVesselMethodSeq.FormattingEnabled = true;
            this.comboboxVesselMethodSeq.Items.AddRange(new object[] {
            "Yes",
            "No"});
            this.comboboxVesselMethodSeq.Location = new System.Drawing.Point(136, 59);
            this.comboboxVesselMethodSeq.Name = "comboboxVesselMethodSeq";
            this.comboboxVesselMethodSeq.Size = new System.Drawing.Size(223, 28);
            this.comboboxVesselMethodSeq.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(11, 130);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 20);
            this.label6.TabIndex = 9;
            this.label6.Text = "Dilution";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 96);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(97, 20);
            this.label5.TabIndex = 8;
            this.label5.Text = "Flow-Trough";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 62);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 20);
            this.label4.TabIndex = 7;
            this.label4.Text = "Sequential";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(116, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "Loading Comp.";
            // 
            // comboboxVesselLcs
            // 
            this.comboboxVesselLcs.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboboxVesselLcs.FormattingEnabled = true;
            this.comboboxVesselLcs.Items.AddRange(new object[] {
            "Yes",
            "No"});
            this.comboboxVesselLcs.Location = new System.Drawing.Point(136, 25);
            this.comboboxVesselLcs.Name = "comboboxVesselLcs";
            this.comboboxVesselLcs.Size = new System.Drawing.Size(223, 28);
            this.comboboxVesselLcs.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.textboxVesselName);
            this.groupBox1.Controls.Add(this.textboxVesselId);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(615, 99);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Core informations";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Vessel ID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "Vessel Name";
            // 
            // textboxVesselName
            // 
            this.textboxVesselName.Location = new System.Drawing.Point(136, 54);
            this.textboxVesselName.Name = "textboxVesselName";
            this.textboxVesselName.Size = new System.Drawing.Size(223, 26);
            this.textboxVesselName.TabIndex = 4;
            // 
            // textboxVesselId
            // 
            this.textboxVesselId.Location = new System.Drawing.Point(136, 22);
            this.textboxVesselId.Name = "textboxVesselId";
            this.textboxVesselId.Size = new System.Drawing.Size(223, 26);
            this.textboxVesselId.TabIndex = 1;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(653, 13);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(200, 200);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 29);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(868, 566);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Approval Process ->";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Location = new System.Drawing.Point(4, 29);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(868, 566);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Invoicing ->";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.comboboxStatus);
            this.tabPage4.Location = new System.Drawing.Point(4, 29);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(868, 566);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Status";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // comboboxStatus
            // 
            this.comboboxStatus.FormattingEnabled = true;
            this.comboboxStatus.Items.AddRange(new object[] {
            "Open",
            "Close"});
            this.comboboxStatus.Location = new System.Drawing.Point(197, 96);
            this.comboboxStatus.Name = "comboboxStatus";
            this.comboboxStatus.Size = new System.Drawing.Size(304, 28);
            this.comboboxStatus.TabIndex = 0;
            // 
            // newProject
            // 
            this.newProject.Location = new System.Drawing.Point(728, 628);
            this.newProject.Name = "newProject";
            this.newProject.Size = new System.Drawing.Size(75, 23);
            this.newProject.TabIndex = 1;
            this.newProject.Text = "OK";
            this.newProject.UseVisualStyleBackColor = true;
            this.newProject.Click += new System.EventHandler(this.newProject_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(809, 628);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "Clear";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // NewProjectForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(898, 663);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.newProject);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "NewProjectForm";
            this.Text = "New BWMP";
            this.Load += new System.EventHandler(this.NewProjectForm_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tabPage4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TextBox textboxVesselId;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboboxVesselLcs;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textboxVesselName;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox comboboxNOrder;
        private System.Windows.Forms.ComboBox comboboxSfaRec;
        private System.Windows.Forms.ComboBox comboboxSfaSent;
        private System.Windows.Forms.ComboBox comboboxSfaCreated;
        private System.Windows.Forms.ComboBox comboboxVesselMethodDil;
        private System.Windows.Forms.ComboBox comboboxVesselMethodFt;
        private System.Windows.Forms.ComboBox comboboxVesselMethodSeq;
        private System.Windows.Forms.Button newProject;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ComboBox comboboxStatus;
    }
}