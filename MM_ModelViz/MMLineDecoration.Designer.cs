namespace MM_ModelViz
{
    partial class MMLineDecoration
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
            this.logAtFilePath = new System.Windows.Forms.CheckBox();
            this.decorationProgressBar = new System.Windows.Forms.ProgressBar();
            this.selectedLogFileName = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.summarizeCheckBox = new System.Windows.Forms.CheckBox();
            this.targetElementColumnName = new System.Windows.Forms.TextBox();
            this.sourceElementColumnName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.connectionExcelFileNameButton = new System.Windows.Forms.Button();
            this.connectionsFileName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.vsdFileNameButton = new System.Windows.Forms.Button();
            this.visioFileName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.decorate = new System.Windows.Forms.Button();
            this.saveConfigButton = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.LoadConfigButton = new System.Windows.Forms.Button();
            this.Version = new System.Windows.Forms.Label();
            this.mapName = new System.Windows.Forms.TextBox();
            this.mapVersion = new System.Windows.Forms.TextBox();
            this.errorListBox = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.shapeName = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.elementTagName = new System.Windows.Forms.TextBox();
            this.connectionsSheetName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.openConfigFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveConfigFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.label7 = new System.Windows.Forms.Label();
            this.connectorStencilName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // logAtFilePath
            // 
            this.logAtFilePath.AutoSize = true;
            this.logAtFilePath.Checked = true;
            this.logAtFilePath.CheckState = System.Windows.Forms.CheckState.Checked;
            this.logAtFilePath.Location = new System.Drawing.Point(838, 591);
            this.logAtFilePath.Name = "logAtFilePath";
            this.logAtFilePath.Size = new System.Drawing.Size(15, 14);
            this.logAtFilePath.TabIndex = 83;
            this.logAtFilePath.UseVisualStyleBackColor = true;
            // 
            // decorationProgressBar
            // 
            this.decorationProgressBar.Location = new System.Drawing.Point(15, 205);
            this.decorationProgressBar.Name = "decorationProgressBar";
            this.decorationProgressBar.Size = new System.Drawing.Size(705, 23);
            this.decorationProgressBar.TabIndex = 82;
            // 
            // selectedLogFileName
            // 
            this.selectedLogFileName.Location = new System.Drawing.Point(126, 585);
            this.selectedLogFileName.Name = "selectedLogFileName";
            this.selectedLogFileName.Size = new System.Drawing.Size(698, 20);
            this.selectedLogFileName.TabIndex = 79;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(15, 591);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(44, 17);
            this.label11.TabIndex = 78;
            this.label11.Text = "Log File";
            this.label11.UseCompatibleTextRendering = true;
            // 
            // summarizeCheckBox
            // 
            this.summarizeCheckBox.AutoSize = true;
            this.summarizeCheckBox.Checked = true;
            this.summarizeCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.summarizeCheckBox.Location = new System.Drawing.Point(743, 181);
            this.summarizeCheckBox.Name = "summarizeCheckBox";
            this.summarizeCheckBox.Size = new System.Drawing.Size(81, 18);
            this.summarizeCheckBox.TabIndex = 77;
            this.summarizeCheckBox.Text = "Summarize";
            this.summarizeCheckBox.UseCompatibleTextRendering = true;
            this.summarizeCheckBox.UseVisualStyleBackColor = true;
            // 
            // targetElementColumnName
            // 
            this.targetElementColumnName.Location = new System.Drawing.Point(522, 110);
            this.targetElementColumnName.Name = "targetElementColumnName";
            this.targetElementColumnName.Size = new System.Drawing.Size(302, 20);
            this.targetElementColumnName.TabIndex = 71;
            // 
            // sourceElementColumnName
            // 
            this.sourceElementColumnName.Location = new System.Drawing.Point(133, 110);
            this.sourceElementColumnName.Name = "sourceElementColumnName";
            this.sourceElementColumnName.Size = new System.Drawing.Size(249, 20);
            this.sourceElementColumnName.TabIndex = 69;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 114);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(115, 17);
            this.label4.TabIndex = 68;
            this.label4.Text = "Source Column Name";
            this.label4.UseCompatibleTextRendering = true;
            // 
            // connectionExcelFileNameButton
            // 
            this.connectionExcelFileNameButton.Location = new System.Drawing.Point(830, 56);
            this.connectionExcelFileNameButton.Name = "connectionExcelFileNameButton";
            this.connectionExcelFileNameButton.Size = new System.Drawing.Size(23, 23);
            this.connectionExcelFileNameButton.TabIndex = 67;
            this.connectionExcelFileNameButton.Text = "+";
            this.connectionExcelFileNameButton.UseCompatibleTextRendering = true;
            this.connectionExcelFileNameButton.UseVisualStyleBackColor = true;
            this.connectionExcelFileNameButton.Click += new System.EventHandler(this.ConnectionExcelFileNameButtonClick);
            // 
            // connectionsFileName
            // 
            this.connectionsFileName.Location = new System.Drawing.Point(133, 58);
            this.connectionsFileName.Name = "connectionsFileName";
            this.connectionsFileName.Size = new System.Drawing.Size(691, 20);
            this.connectionsFileName.TabIndex = 66;
            this.connectionsFileName.TextChanged += new System.EventHandler(this.connectionsFileName_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(26, 17);
            this.label3.TabIndex = 65;
            this.label3.Text = "Map";
            this.label3.UseCompatibleTextRendering = true;
            // 
            // vsdFileNameButton
            // 
            this.vsdFileNameButton.Location = new System.Drawing.Point(830, 30);
            this.vsdFileNameButton.Name = "vsdFileNameButton";
            this.vsdFileNameButton.Size = new System.Drawing.Size(23, 23);
            this.vsdFileNameButton.TabIndex = 63;
            this.vsdFileNameButton.Text = "+";
            this.vsdFileNameButton.UseCompatibleTextRendering = true;
            this.vsdFileNameButton.UseVisualStyleBackColor = true;
            this.vsdFileNameButton.Click += new System.EventHandler(this.VsdFileNameButtonClick);
            // 
            // visioFileName
            // 
            this.visioFileName.Location = new System.Drawing.Point(133, 32);
            this.visioFileName.Name = "visioFileName";
            this.visioFileName.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.visioFileName.Size = new System.Drawing.Size(691, 20);
            this.visioFileName.TabIndex = 60;
            this.visioFileName.TextChanged += new System.EventHandler(this.visioFileName_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 17);
            this.label1.TabIndex = 59;
            this.label1.Text = "Visio";
            this.label1.UseCompatibleTextRendering = true;
            // 
            // decorate
            // 
            this.decorate.Location = new System.Drawing.Point(749, 205);
            this.decorate.Name = "decorate";
            this.decorate.Size = new System.Drawing.Size(75, 23);
            this.decorate.TabIndex = 58;
            this.decorate.Text = "decorate";
            this.decorate.UseCompatibleTextRendering = true;
            this.decorate.UseVisualStyleBackColor = true;
            this.decorate.Click += new System.EventHandler(this.decorate_Click);
            // 
            // saveConfigButton
            // 
            this.saveConfigButton.Location = new System.Drawing.Point(797, 6);
            this.saveConfigButton.Name = "saveConfigButton";
            this.saveConfigButton.Size = new System.Drawing.Size(27, 23);
            this.saveConfigButton.TabIndex = 102;
            this.saveConfigButton.Text = "S";
            this.saveConfigButton.UseVisualStyleBackColor = true;
            this.saveConfigButton.Click += new System.EventHandler(this.saveConfigButton_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(12, 9);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(35, 13);
            this.label10.TabIndex = 97;
            this.label10.Text = "Name";
            // 
            // LoadConfigButton
            // 
            this.LoadConfigButton.Location = new System.Drawing.Point(830, 6);
            this.LoadConfigButton.Name = "LoadConfigButton";
            this.LoadConfigButton.Size = new System.Drawing.Size(23, 23);
            this.LoadConfigButton.TabIndex = 101;
            this.LoadConfigButton.Text = "+";
            this.LoadConfigButton.UseVisualStyleBackColor = true;
            this.LoadConfigButton.Click += new System.EventHandler(this.LoadConfigButton_Click);
            // 
            // Version
            // 
            this.Version.AutoSize = true;
            this.Version.Location = new System.Drawing.Point(636, 11);
            this.Version.Name = "Version";
            this.Version.Size = new System.Drawing.Size(42, 13);
            this.Version.TabIndex = 98;
            this.Version.Text = "Version";
            // 
            // mapName
            // 
            this.mapName.Location = new System.Drawing.Point(133, 6);
            this.mapName.Name = "mapName";
            this.mapName.Size = new System.Drawing.Size(485, 20);
            this.mapName.TabIndex = 99;
            // 
            // mapVersion
            // 
            this.mapVersion.Location = new System.Drawing.Point(691, 6);
            this.mapVersion.Name = "mapVersion";
            this.mapVersion.Size = new System.Drawing.Size(100, 20);
            this.mapVersion.TabIndex = 100;
            // 
            // errorListBox
            // 
            this.errorListBox.FormattingEnabled = true;
            this.errorListBox.Location = new System.Drawing.Point(12, 250);
            this.errorListBox.Name = "errorListBox";
            this.errorListBox.Size = new System.Drawing.Size(841, 329);
            this.errorListBox.TabIndex = 103;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 139);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 13);
            this.label2.TabIndex = 104;
            this.label2.Text = "Element Shape Name";
            // 
            // shapeName
            // 
            this.shapeName.Location = new System.Drawing.Point(133, 136);
            this.shapeName.Name = "shapeName";
            this.shapeName.Size = new System.Drawing.Size(249, 20);
            this.shapeName.TabIndex = 105;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(394, 136);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(76, 13);
            this.label8.TabIndex = 106;
            this.label8.Text = "Element Name";
            // 
            // elementTagName
            // 
            this.elementTagName.Location = new System.Drawing.Point(522, 136);
            this.elementTagName.Name = "elementTagName";
            this.elementTagName.Size = new System.Drawing.Size(302, 20);
            this.elementTagName.TabIndex = 107;
            // 
            // connectionsSheetName
            // 
            this.connectionsSheetName.Location = new System.Drawing.Point(133, 84);
            this.connectionsSheetName.Name = "connectionsSheetName";
            this.connectionsSheetName.Size = new System.Drawing.Size(249, 20);
            this.connectionsSheetName.TabIndex = 108;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 87);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(66, 13);
            this.label6.TabIndex = 109;
            this.label6.Text = "Sheet Name";
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog";
            // 
            // openConfigFileDialog
            // 
            this.openConfigFileDialog.FileName = "openConfigFileDialog";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(394, 87);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(91, 13);
            this.label7.TabIndex = 110;
            this.label7.Text = "Connector Stencil";
            // 
            // connectorStencilName
            // 
            this.connectorStencilName.Location = new System.Drawing.Point(522, 84);
            this.connectorStencilName.Name = "connectorStencilName";
            this.connectorStencilName.Size = new System.Drawing.Size(302, 20);
            this.connectorStencilName.TabIndex = 111;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(394, 113);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(107, 13);
            this.label5.TabIndex = 112;
            this.label5.Text = "Target Column Name";
            // 
            // MMLineDecoration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(868, 617);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.connectorStencilName);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.connectionsSheetName);
            this.Controls.Add(this.elementTagName);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.shapeName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.errorListBox);
            this.Controls.Add(this.saveConfigButton);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.LoadConfigButton);
            this.Controls.Add(this.Version);
            this.Controls.Add(this.mapName);
            this.Controls.Add(this.mapVersion);
            this.Controls.Add(this.logAtFilePath);
            this.Controls.Add(this.decorationProgressBar);
            this.Controls.Add(this.selectedLogFileName);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.summarizeCheckBox);
            this.Controls.Add(this.targetElementColumnName);
            this.Controls.Add(this.sourceElementColumnName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.connectionExcelFileNameButton);
            this.Controls.Add(this.connectionsFileName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.vsdFileNameButton);
            this.Controls.Add(this.visioFileName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.decorate);
            this.Name = "MMLineDecoration";
            this.Text = "MMLineDecoration";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox logAtFilePath;
        private System.Windows.Forms.ProgressBar decorationProgressBar;
        private System.Windows.Forms.TextBox selectedLogFileName;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.CheckBox summarizeCheckBox;
        private System.Windows.Forms.TextBox targetElementColumnName;
        private System.Windows.Forms.TextBox sourceElementColumnName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button connectionExcelFileNameButton;
        private System.Windows.Forms.TextBox connectionsFileName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button vsdFileNameButton;
        private System.Windows.Forms.TextBox visioFileName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button decorate;
        private System.Windows.Forms.Button saveConfigButton;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button LoadConfigButton;
        private System.Windows.Forms.Label Version;
        private System.Windows.Forms.TextBox mapName;
        private System.Windows.Forms.TextBox mapVersion;
        private System.Windows.Forms.ListBox errorListBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox shapeName;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox elementTagName;
        private System.Windows.Forms.TextBox connectionsSheetName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.OpenFileDialog openConfigFileDialog;
        private System.Windows.Forms.SaveFileDialog saveConfigFileDialog;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox connectorStencilName;
        private System.Windows.Forms.Label label5;
    }
}