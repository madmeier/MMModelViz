namespace MM_ModelViz
{
    partial class MMShapeDecoration
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
            this.decorSheetName = new System.Windows.Forms.TextBox();
            this.DecorSheetNameLabel = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.decorStencilFileName = new System.Windows.Forms.TextBox();
            this.decorStencilFileNameSelect = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.decorElementCoilumnName = new System.Windows.Forms.TextBox();
            this.decorExcelFileName = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.decorVisioFileName = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.decorElementStencilName = new System.Windows.Forms.TextBox();
            this.decorStencilName = new System.Windows.Forms.TextBox();
            this.decorVisioFileNameSelect = new System.Windows.Forms.Button();
            this.decorMapFileNameSelect = new System.Windows.Forms.Button();
            this.decorGenerate = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.errorListBox = new System.Windows.Forms.ListBox();
            this.selectedLogFileName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.logAtFilePath = new System.Windows.Forms.CheckBox();
            this.saveConfigButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.LoadConfigButton = new System.Windows.Forms.Button();
            this.Version = new System.Windows.Forms.Label();
            this.mapName = new System.Windows.Forms.TextBox();
            this.mapVersion = new System.Windows.Forms.TextBox();
            this.openConfigFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveConfigFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.SuspendLayout();
            // 
            // decorSheetName
            // 
            this.decorSheetName.Location = new System.Drawing.Point(120, 116);
            this.decorSheetName.Name = "decorSheetName";
            this.decorSheetName.Size = new System.Drawing.Size(247, 20);
            this.decorSheetName.TabIndex = 40;
            // 
            // DecorSheetNameLabel
            // 
            this.DecorSheetNameLabel.AutoSize = true;
            this.DecorSheetNameLabel.Location = new System.Drawing.Point(7, 119);
            this.DecorSheetNameLabel.Name = "DecorSheetNameLabel";
            this.DecorSheetNameLabel.Size = new System.Drawing.Size(66, 13);
            this.DecorSheetNameLabel.TabIndex = 39;
            this.DecorSheetNameLabel.Text = "Sheet Name";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(7, 67);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(39, 13);
            this.label14.TabIndex = 36;
            this.label14.Text = "Stencil";
            // 
            // decorStencilFileName
            // 
            this.decorStencilFileName.Location = new System.Drawing.Point(120, 64);
            this.decorStencilFileName.Name = "decorStencilFileName";
            this.decorStencilFileName.Size = new System.Drawing.Size(696, 20);
            this.decorStencilFileName.TabIndex = 37;
            this.decorStencilFileName.TextChanged += new System.EventHandler(this.DecorStencilFileNameTextChanged);
            // 
            // decorStencilFileNameSelect
            // 
            this.decorStencilFileNameSelect.Location = new System.Drawing.Point(824, 63);
            this.decorStencilFileNameSelect.Name = "decorStencilFileNameSelect";
            this.decorStencilFileNameSelect.Size = new System.Drawing.Size(24, 23);
            this.decorStencilFileNameSelect.TabIndex = 38;
            this.decorStencilFileNameSelect.Text = "+";
            this.decorStencilFileNameSelect.UseVisualStyleBackColor = true;
            this.decorStencilFileNameSelect.Click += new System.EventHandler(this.DecorStencilFileNameSelectClick);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(7, 145);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(58, 13);
            this.label13.TabIndex = 35;
            this.label13.Text = "Link Name";
            // 
            // decorElementCoilumnName
            // 
            this.decorElementCoilumnName.Location = new System.Drawing.Point(120, 142);
            this.decorElementCoilumnName.Name = "decorElementCoilumnName";
            this.decorElementCoilumnName.Size = new System.Drawing.Size(247, 20);
            this.decorElementCoilumnName.TabIndex = 34;
            this.decorElementCoilumnName.Text = "Name";
            // 
            // decorExcelFileName
            // 
            this.decorExcelFileName.Location = new System.Drawing.Point(120, 90);
            this.decorExcelFileName.Name = "decorExcelFileName";
            this.decorExcelFileName.Size = new System.Drawing.Size(696, 20);
            this.decorExcelFileName.TabIndex = 26;
            this.decorExcelFileName.TextChanged += new System.EventHandler(this.DecorMapFileNameTextChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(7, 93);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(28, 13);
            this.label9.TabIndex = 25;
            this.label9.Text = "Map";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(7, 41);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(29, 13);
            this.label10.TabIndex = 23;
            this.label10.Text = "Visio";
            // 
            // decorVisioFileName
            // 
            this.decorVisioFileName.Location = new System.Drawing.Point(120, 38);
            this.decorVisioFileName.Name = "decorVisioFileName";
            this.decorVisioFileName.Size = new System.Drawing.Size(696, 20);
            this.decorVisioFileName.TabIndex = 24;
            this.decorVisioFileName.TextChanged += new System.EventHandler(this.DecorVisioFileNameTextChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(448, 119);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(80, 13);
            this.label11.TabIndex = 33;
            this.label11.Text = "Element Stencil";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(448, 145);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(71, 13);
            this.label12.TabIndex = 32;
            this.label12.Text = "Decor Stencil";
            // 
            // decorElementStencilName
            // 
            this.decorElementStencilName.Location = new System.Drawing.Point(566, 116);
            this.decorElementStencilName.Name = "decorElementStencilName";
            this.decorElementStencilName.Size = new System.Drawing.Size(250, 20);
            this.decorElementStencilName.TabIndex = 31;
            this.decorElementStencilName.Text = "Application System";
            // 
            // decorStencilName
            // 
            this.decorStencilName.Location = new System.Drawing.Point(566, 142);
            this.decorStencilName.Name = "decorStencilName";
            this.decorStencilName.Size = new System.Drawing.Size(250, 20);
            this.decorStencilName.TabIndex = 30;
            this.decorStencilName.Text = "CID Status";
            // 
            // decorVisioFileNameSelect
            // 
            this.decorVisioFileNameSelect.Location = new System.Drawing.Point(824, 88);
            this.decorVisioFileNameSelect.Name = "decorVisioFileNameSelect";
            this.decorVisioFileNameSelect.Size = new System.Drawing.Size(24, 23);
            this.decorVisioFileNameSelect.TabIndex = 27;
            this.decorVisioFileNameSelect.Text = "+";
            this.decorVisioFileNameSelect.UseVisualStyleBackColor = true;
            this.decorVisioFileNameSelect.Click += new System.EventHandler(this.DecorFileNameSelectClick);
            // 
            // decorMapFileNameSelect
            // 
            this.decorMapFileNameSelect.Location = new System.Drawing.Point(824, 38);
            this.decorMapFileNameSelect.Name = "decorMapFileNameSelect";
            this.decorMapFileNameSelect.Size = new System.Drawing.Size(23, 23);
            this.decorMapFileNameSelect.TabIndex = 28;
            this.decorMapFileNameSelect.Text = "+";
            this.decorMapFileNameSelect.UseVisualStyleBackColor = true;
            this.decorMapFileNameSelect.Click += new System.EventHandler(this.DecorMapFileNameSelectClick);
            // 
            // decorGenerate
            // 
            this.decorGenerate.Location = new System.Drawing.Point(741, 179);
            this.decorGenerate.Name = "decorGenerate";
            this.decorGenerate.Size = new System.Drawing.Size(75, 23);
            this.decorGenerate.TabIndex = 29;
            this.decorGenerate.Text = "Generate";
            this.decorGenerate.UseVisualStyleBackColor = true;
            this.decorGenerate.Click += new System.EventHandler(this.DecorGenerateClick);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog";
            // 
            // errorListBox
            // 
            this.errorListBox.FormattingEnabled = true;
            this.errorListBox.Location = new System.Drawing.Point(10, 220);
            this.errorListBox.Name = "errorListBox";
            this.errorListBox.Size = new System.Drawing.Size(832, 355);
            this.errorListBox.TabIndex = 89;
            // 
            // selectedLogFileName
            // 
            this.selectedLogFileName.Location = new System.Drawing.Point(83, 593);
            this.selectedLogFileName.Name = "selectedLogFileName";
            this.selectedLogFileName.Size = new System.Drawing.Size(733, 20);
            this.selectedLogFileName.TabIndex = 88;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 596);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 17);
            this.label1.TabIndex = 87;
            this.label1.Text = "Log file";
            this.label1.UseCompatibleTextRendering = true;
            // 
            // logAtFilePath
            // 
            this.logAtFilePath.AutoSize = true;
            this.logAtFilePath.Checked = true;
            this.logAtFilePath.CheckState = System.Windows.Forms.CheckState.Checked;
            this.logAtFilePath.Location = new System.Drawing.Point(827, 596);
            this.logAtFilePath.Name = "logAtFilePath";
            this.logAtFilePath.Size = new System.Drawing.Size(15, 14);
            this.logAtFilePath.TabIndex = 90;
            this.logAtFilePath.UseVisualStyleBackColor = true;
            // 
            // saveConfigButton
            // 
            this.saveConfigButton.Location = new System.Drawing.Point(791, 12);
            this.saveConfigButton.Name = "saveConfigButton";
            this.saveConfigButton.Size = new System.Drawing.Size(27, 23);
            this.saveConfigButton.TabIndex = 96;
            this.saveConfigButton.Text = "S";
            this.saveConfigButton.UseVisualStyleBackColor = true;
            this.saveConfigButton.Click += new System.EventHandler(this.SaveConfigButtonClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 91;
            this.label2.Text = "Name";
            // 
            // LoadConfigButton
            // 
            this.LoadConfigButton.Location = new System.Drawing.Point(824, 12);
            this.LoadConfigButton.Name = "LoadConfigButton";
            this.LoadConfigButton.Size = new System.Drawing.Size(23, 23);
            this.LoadConfigButton.TabIndex = 95;
            this.LoadConfigButton.Text = "+";
            this.LoadConfigButton.UseVisualStyleBackColor = true;
            this.LoadConfigButton.Click += new System.EventHandler(this.LoadConfigButton_Click);
            // 
            // Version
            // 
            this.Version.AutoSize = true;
            this.Version.Location = new System.Drawing.Point(630, 17);
            this.Version.Name = "Version";
            this.Version.Size = new System.Drawing.Size(42, 13);
            this.Version.TabIndex = 92;
            this.Version.Text = "Version";
            // 
            // mapName
            // 
            this.mapName.Location = new System.Drawing.Point(120, 12);
            this.mapName.Name = "mapName";
            this.mapName.Size = new System.Drawing.Size(492, 20);
            this.mapName.TabIndex = 93;
            // 
            // mapVersion
            // 
            this.mapVersion.Location = new System.Drawing.Point(685, 12);
            this.mapVersion.Name = "mapVersion";
            this.mapVersion.Size = new System.Drawing.Size(100, 20);
            this.mapVersion.TabIndex = 94;
            // 
            // MMShapeDecoration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(856, 625);
            this.Controls.Add(this.saveConfigButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.LoadConfigButton);
            this.Controls.Add(this.Version);
            this.Controls.Add(this.mapName);
            this.Controls.Add(this.mapVersion);
            this.Controls.Add(this.logAtFilePath);
            this.Controls.Add(this.errorListBox);
            this.Controls.Add(this.selectedLogFileName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.DecorSheetNameLabel);
            this.Controls.Add(this.decorStencilFileNameSelect);
            this.Controls.Add(this.decorSheetName);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.decorVisioFileNameSelect);
            this.Controls.Add(this.decorExcelFileName);
            this.Controls.Add(this.decorVisioFileName);
            this.Controls.Add(this.decorStencilFileName);
            this.Controls.Add(this.decorMapFileNameSelect);
            this.Controls.Add(this.decorElementCoilumnName);
            this.Controls.Add(this.decorGenerate);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.decorStencilName);
            this.Controls.Add(this.decorElementStencilName);
            this.Controls.Add(this.label11);
            this.Name = "MMShapeDecoration";
            this.Text = "MMShapeDecoration";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox decorSheetName;
        private System.Windows.Forms.Label DecorSheetNameLabel;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox decorStencilFileName;
        private System.Windows.Forms.Button decorStencilFileNameSelect;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox decorElementCoilumnName;
        private System.Windows.Forms.TextBox decorExcelFileName;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox decorVisioFileName;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox decorElementStencilName;
        private System.Windows.Forms.TextBox decorStencilName;
        private System.Windows.Forms.Button decorVisioFileNameSelect;
        private System.Windows.Forms.Button decorMapFileNameSelect;
        private System.Windows.Forms.Button decorGenerate;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.ListBox errorListBox;
        private System.Windows.Forms.TextBox selectedLogFileName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox logAtFilePath;
        private System.Windows.Forms.Button saveConfigButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button LoadConfigButton;
        private System.Windows.Forms.Label Version;
        private System.Windows.Forms.TextBox mapName;
        private System.Windows.Forms.TextBox mapVersion;
        private System.Windows.Forms.OpenFileDialog openConfigFileDialog;
        private System.Windows.Forms.SaveFileDialog saveConfigFileDialog;
    }
}