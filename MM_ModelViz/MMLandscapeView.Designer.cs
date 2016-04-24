namespace MM_ModelViz
{
    partial class MmLandscapeView
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
            this.configNameLabel = new System.Windows.Forms.Label();
            this.configVersionLabel = new System.Windows.Forms.Label();
            this.mapName = new System.Windows.Forms.TextBox();
            this.mapVersion = new System.Windows.Forms.TextBox();
            this.visioFileNameLabel = new System.Windows.Forms.Label();
            this.visioFileName = new System.Windows.Forms.TextBox();
            this.stencilFileNameLabel = new System.Windows.Forms.Label();
            this.stencilFileName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.mapFileName = new System.Windows.Forms.TextBox();
            this.visioStencilSelect = new System.Windows.Forms.Button();
            this.visioFileSelect = new System.Windows.Forms.Button();
            this.mapFileSelect = new System.Windows.Forms.Button();
            this.generateLandscapeButton = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.logAtFilePath = new System.Windows.Forms.CheckBox();
            this.selectedLogFileName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.mapStencilName = new System.Windows.Forms.TextBox();
            this.elementStencilName = new System.Windows.Forms.TextBox();
            this.mapStencilLabel = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.Prepare = new System.Windows.Forms.Button();
            this.spaceText = new System.Windows.Forms.TextBox();
            this.labelspaceLabel = new System.Windows.Forms.Label();
            this.LoadConfigButton = new System.Windows.Forms.Button();
            this.saveConfigButton = new System.Windows.Forms.Button();
            this.saveConfigFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.openConfigFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.optimitzeElementLayoutCheckBox = new System.Windows.Forms.CheckBox();
            this.freezeMapCheckBox = new System.Windows.Forms.CheckBox();
            this.titleSpaceCheckBox = new System.Windows.Forms.CheckBox();
            this.LayoutLabel = new System.Windows.Forms.Label();
            this.titleRowCheckBox = new System.Windows.Forms.CheckBox();
            this.mappingSheetName = new System.Windows.Forms.TextBox();
            this.mappingMapNameColumnName = new System.Windows.Forms.TextBox();
            this.mappingElementNameColumnName = new System.Windows.Forms.TextBox();
            this.MappingLabel = new System.Windows.Forms.Label();
            this.mapNameColumnName = new System.Windows.Forms.TextBox();
            this.mapNameColumnLabel = new System.Windows.Forms.Label();
            this.mapSheetName = new System.Windows.Forms.TextBox();
            this.mapSheetNameLabel = new System.Windows.Forms.Label();
            this.mapLabel = new System.Windows.Forms.Label();
            this.elementNameColumnName = new System.Windows.Forms.TextBox();
            this.elemenNameColumnNameLabel = new System.Windows.Forms.Label();
            this.sheetNameLabel = new System.Windows.Forms.Label();
            this.elementSheetName = new System.Windows.Forms.TextBox();
            this.elementsLabel = new System.Windows.Forms.Label();
            this.errorListBox = new System.Windows.Forms.ListBox();
            this.columnsFirstCheckBox = new System.Windows.Forms.CheckBox();
            this.showDescriptionsCheckBox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // configNameLabel
            // 
            this.configNameLabel.AutoSize = true;
            this.configNameLabel.Location = new System.Drawing.Point(11, 24);
            this.configNameLabel.Name = "configNameLabel";
            this.configNameLabel.Size = new System.Drawing.Size(35, 13);
            this.configNameLabel.TabIndex = 0;
            this.configNameLabel.Text = "Name";
            // 
            // configVersionLabel
            // 
            this.configVersionLabel.AutoSize = true;
            this.configVersionLabel.Location = new System.Drawing.Point(542, 24);
            this.configVersionLabel.Name = "configVersionLabel";
            this.configVersionLabel.Size = new System.Drawing.Size(42, 13);
            this.configVersionLabel.TabIndex = 1;
            this.configVersionLabel.Text = "Version";
            // 
            // mapName
            // 
            this.mapName.Location = new System.Drawing.Point(84, 21);
            this.mapName.Name = "mapName";
            this.mapName.Size = new System.Drawing.Size(452, 20);
            this.mapName.TabIndex = 2;
            // 
            // mapVersion
            // 
            this.mapVersion.Location = new System.Drawing.Point(590, 21);
            this.mapVersion.Name = "mapVersion";
            this.mapVersion.Size = new System.Drawing.Size(100, 20);
            this.mapVersion.TabIndex = 3;
            // 
            // visioFileNameLabel
            // 
            this.visioFileNameLabel.AutoSize = true;
            this.visioFileNameLabel.Location = new System.Drawing.Point(11, 51);
            this.visioFileNameLabel.Name = "visioFileNameLabel";
            this.visioFileNameLabel.Size = new System.Drawing.Size(29, 13);
            this.visioFileNameLabel.TabIndex = 4;
            this.visioFileNameLabel.Text = "Visio";
            // 
            // visioFileName
            // 
            this.visioFileName.Location = new System.Drawing.Point(84, 48);
            this.visioFileName.Name = "visioFileName";
            this.visioFileName.Size = new System.Drawing.Size(640, 20);
            this.visioFileName.TabIndex = 5;
            this.visioFileName.TextChanged += new System.EventHandler(this.VisioFileNameTextChanged);
            // 
            // stencilFileNameLabel
            // 
            this.stencilFileNameLabel.AutoSize = true;
            this.stencilFileNameLabel.Location = new System.Drawing.Point(10, 78);
            this.stencilFileNameLabel.Name = "stencilFileNameLabel";
            this.stencilFileNameLabel.Size = new System.Drawing.Size(39, 13);
            this.stencilFileNameLabel.TabIndex = 6;
            this.stencilFileNameLabel.Text = "Stencil";
            // 
            // stencilFileName
            // 
            this.stencilFileName.Location = new System.Drawing.Point(84, 75);
            this.stencilFileName.Name = "stencilFileName";
            this.stencilFileName.Size = new System.Drawing.Size(640, 20);
            this.stencilFileName.TabIndex = 7;
            this.stencilFileName.TextChanged += new System.EventHandler(this.StencilFileNameTextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 104);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(28, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Map";
            // 
            // mapFileName
            // 
            this.mapFileName.Location = new System.Drawing.Point(84, 101);
            this.mapFileName.Name = "mapFileName";
            this.mapFileName.Size = new System.Drawing.Size(640, 20);
            this.mapFileName.TabIndex = 9;
            this.mapFileName.TextChanged += new System.EventHandler(this.MapFileNameTextChanged);
            // 
            // visioStencilSelect
            // 
            this.visioStencilSelect.Location = new System.Drawing.Point(730, 73);
            this.visioStencilSelect.Name = "visioStencilSelect";
            this.visioStencilSelect.Size = new System.Drawing.Size(24, 23);
            this.visioStencilSelect.TabIndex = 10;
            this.visioStencilSelect.Text = "+";
            this.visioStencilSelect.UseVisualStyleBackColor = true;
            this.visioStencilSelect.Click += new System.EventHandler(this.VisioStencilSelectClick);
            // 
            // visioFileSelect
            // 
            this.visioFileSelect.Location = new System.Drawing.Point(730, 46);
            this.visioFileSelect.Name = "visioFileSelect";
            this.visioFileSelect.Size = new System.Drawing.Size(24, 23);
            this.visioFileSelect.TabIndex = 11;
            this.visioFileSelect.Text = "+";
            this.visioFileSelect.UseVisualStyleBackColor = true;
            this.visioFileSelect.Click += new System.EventHandler(this.VisioFileSelectClick);
            // 
            // mapFileSelect
            // 
            this.mapFileSelect.Location = new System.Drawing.Point(731, 99);
            this.mapFileSelect.Name = "mapFileSelect";
            this.mapFileSelect.Size = new System.Drawing.Size(23, 23);
            this.mapFileSelect.TabIndex = 12;
            this.mapFileSelect.Text = "+";
            this.mapFileSelect.UseVisualStyleBackColor = true;
            this.mapFileSelect.Click += new System.EventHandler(this.MapFileSelectClick);
            // 
            // generateLandscapeButton
            // 
            this.generateLandscapeButton.Location = new System.Drawing.Point(649, 347);
            this.generateLandscapeButton.Name = "generateLandscapeButton";
            this.generateLandscapeButton.Size = new System.Drawing.Size(75, 23);
            this.generateLandscapeButton.TabIndex = 13;
            this.generateLandscapeButton.Text = "Generate";
            this.generateLandscapeButton.UseVisualStyleBackColor = true;
            this.generateLandscapeButton.Click += new System.EventHandler(this.GenerateLandscapeButtonClick);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog";
            // 
            // logAtFilePath
            // 
            this.logAtFilePath.AutoSize = true;
            this.logAtFilePath.Checked = true;
            this.logAtFilePath.CheckState = System.Windows.Forms.CheckState.Checked;
            this.logAtFilePath.Location = new System.Drawing.Point(749, 717);
            this.logAtFilePath.Name = "logAtFilePath";
            this.logAtFilePath.Size = new System.Drawing.Size(15, 14);
            this.logAtFilePath.TabIndex = 18;
            this.logAtFilePath.UseVisualStyleBackColor = true;
            // 
            // selectedLogFileName
            // 
            this.selectedLogFileName.Location = new System.Drawing.Point(84, 717);
            this.selectedLogFileName.Name = "selectedLogFileName";
            this.selectedLogFileName.Size = new System.Drawing.Size(640, 20);
            this.selectedLogFileName.TabIndex = 17;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 720);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 17);
            this.label5.TabIndex = 16;
            this.label5.Text = "Log file";
            this.label5.UseCompatibleTextRendering = true;
            // 
            // mapStencilName
            // 
            this.mapStencilName.Location = new System.Drawing.Point(198, 262);
            this.mapStencilName.Name = "mapStencilName";
            this.mapStencilName.Size = new System.Drawing.Size(264, 20);
            this.mapStencilName.TabIndex = 19;
            // 
            // elementStencilName
            // 
            this.elementStencilName.Location = new System.Drawing.Point(198, 175);
            this.elementStencilName.Name = "elementStencilName";
            this.elementStencilName.Size = new System.Drawing.Size(264, 20);
            this.elementStencilName.TabIndex = 20;
            // 
            // mapStencilLabel
            // 
            this.mapStencilLabel.AutoSize = true;
            this.mapStencilLabel.Location = new System.Drawing.Point(81, 265);
            this.mapStencilLabel.Name = "mapStencilLabel";
            this.mapStencilLabel.Size = new System.Drawing.Size(63, 13);
            this.mapStencilLabel.TabIndex = 21;
            this.mapStencilLabel.Text = "Map Stencil";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(81, 178);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(70, 13);
            this.label7.TabIndex = 22;
            this.label7.Text = "Stencil Name";
            // 
            // Prepare
            // 
            this.Prepare.Location = new System.Drawing.Point(649, 318);
            this.Prepare.Name = "Prepare";
            this.Prepare.Size = new System.Drawing.Size(75, 23);
            this.Prepare.TabIndex = 23;
            this.Prepare.Text = "Prepare";
            this.Prepare.UseVisualStyleBackColor = true;
            this.Prepare.Click += new System.EventHandler(this.PrepareClick);
            // 
            // spaceText
            // 
            this.spaceText.Location = new System.Drawing.Point(198, 315);
            this.spaceText.Name = "spaceText";
            this.spaceText.Size = new System.Drawing.Size(58, 20);
            this.spaceText.TabIndex = 24;
            this.spaceText.Text = "0.3";
            this.spaceText.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // labelspaceLabel
            // 
            this.labelspaceLabel.AutoSize = true;
            this.labelspaceLabel.Location = new System.Drawing.Point(81, 318);
            this.labelspaceLabel.Name = "labelspaceLabel";
            this.labelspaceLabel.Size = new System.Drawing.Size(38, 13);
            this.labelspaceLabel.TabIndex = 25;
            this.labelspaceLabel.Text = "Space";
            // 
            // LoadConfigButton
            // 
            this.LoadConfigButton.Location = new System.Drawing.Point(731, 19);
            this.LoadConfigButton.Name = "LoadConfigButton";
            this.LoadConfigButton.Size = new System.Drawing.Size(23, 23);
            this.LoadConfigButton.TabIndex = 27;
            this.LoadConfigButton.Text = "+";
            this.LoadConfigButton.UseVisualStyleBackColor = true;
            this.LoadConfigButton.Click += new System.EventHandler(this.LoadConfigButtonClick);
            // 
            // saveConfigButton
            // 
            this.saveConfigButton.Location = new System.Drawing.Point(697, 19);
            this.saveConfigButton.Name = "saveConfigButton";
            this.saveConfigButton.Size = new System.Drawing.Size(27, 23);
            this.saveConfigButton.TabIndex = 28;
            this.saveConfigButton.Text = "S";
            this.saveConfigButton.UseVisualStyleBackColor = true;
            this.saveConfigButton.Click += new System.EventHandler(this.SaveConfigButtonClick);
            // 
            // optimitzeElementLayoutCheckBox
            // 
            this.optimitzeElementLayoutCheckBox.AutoSize = true;
            this.optimitzeElementLayoutCheckBox.Location = new System.Drawing.Point(391, 341);
            this.optimitzeElementLayoutCheckBox.Name = "optimitzeElementLayoutCheckBox";
            this.optimitzeElementLayoutCheckBox.Size = new System.Drawing.Size(112, 17);
            this.optimitzeElementLayoutCheckBox.TabIndex = 47;
            this.optimitzeElementLayoutCheckBox.Text = "Optimize Elements";
            this.optimitzeElementLayoutCheckBox.UseVisualStyleBackColor = true;
            this.optimitzeElementLayoutCheckBox.CheckedChanged += new System.EventHandler(this.OptimitzeElementLayoutCheckBoxCheckedChanged);
            // 
            // freezeMapCheckBox
            // 
            this.freezeMapCheckBox.AutoSize = true;
            this.freezeMapCheckBox.Location = new System.Drawing.Point(305, 341);
            this.freezeMapCheckBox.Name = "freezeMapCheckBox";
            this.freezeMapCheckBox.Size = new System.Drawing.Size(82, 17);
            this.freezeMapCheckBox.TabIndex = 46;
            this.freezeMapCheckBox.Text = "Freeze Map";
            this.freezeMapCheckBox.UseVisualStyleBackColor = true;
            // 
            // titleSpaceCheckBox
            // 
            this.titleSpaceCheckBox.AutoSize = true;
            this.titleSpaceCheckBox.Location = new System.Drawing.Point(305, 317);
            this.titleSpaceCheckBox.Name = "titleSpaceCheckBox";
            this.titleSpaceCheckBox.Size = new System.Drawing.Size(80, 17);
            this.titleSpaceCheckBox.TabIndex = 45;
            this.titleSpaceCheckBox.Text = "Title Space";
            this.titleSpaceCheckBox.UseVisualStyleBackColor = true;
            // 
            // LayoutLabel
            // 
            this.LayoutLabel.AutoSize = true;
            this.LayoutLabel.Location = new System.Drawing.Point(15, 318);
            this.LayoutLabel.Name = "LayoutLabel";
            this.LayoutLabel.Size = new System.Drawing.Size(39, 13);
            this.LayoutLabel.TabIndex = 44;
            this.LayoutLabel.Text = "Layout";
            // 
            // titleRowCheckBox
            // 
            this.titleRowCheckBox.AutoSize = true;
            this.titleRowCheckBox.Location = new System.Drawing.Point(391, 317);
            this.titleRowCheckBox.Name = "titleRowCheckBox";
            this.titleRowCheckBox.Size = new System.Drawing.Size(71, 17);
            this.titleRowCheckBox.TabIndex = 43;
            this.titleRowCheckBox.Text = "Title Row";
            this.titleRowCheckBox.UseVisualStyleBackColor = true;
            // 
            // mappingSheetName
            // 
            this.mappingSheetName.Location = new System.Drawing.Point(485, 152);
            this.mappingSheetName.Name = "mappingSheetName";
            this.mappingSheetName.Size = new System.Drawing.Size(239, 20);
            this.mappingSheetName.TabIndex = 42;
            // 
            // mappingMapNameColumnName
            // 
            this.mappingMapNameColumnName.Location = new System.Drawing.Point(485, 285);
            this.mappingMapNameColumnName.Name = "mappingMapNameColumnName";
            this.mappingMapNameColumnName.Size = new System.Drawing.Size(239, 20);
            this.mappingMapNameColumnName.TabIndex = 41;
            // 
            // mappingElementNameColumnName
            // 
            this.mappingElementNameColumnName.Location = new System.Drawing.Point(485, 202);
            this.mappingElementNameColumnName.Name = "mappingElementNameColumnName";
            this.mappingElementNameColumnName.Size = new System.Drawing.Size(239, 20);
            this.mappingElementNameColumnName.TabIndex = 40;
            // 
            // MappingLabel
            // 
            this.MappingLabel.AutoSize = true;
            this.MappingLabel.Location = new System.Drawing.Point(482, 132);
            this.MappingLabel.Name = "MappingLabel";
            this.MappingLabel.Size = new System.Drawing.Size(48, 13);
            this.MappingLabel.TabIndex = 39;
            this.MappingLabel.Text = "Mapping";
            // 
            // mapNameColumnName
            // 
            this.mapNameColumnName.Location = new System.Drawing.Point(198, 289);
            this.mapNameColumnName.Name = "mapNameColumnName";
            this.mapNameColumnName.Size = new System.Drawing.Size(264, 20);
            this.mapNameColumnName.TabIndex = 38;
            // 
            // mapNameColumnLabel
            // 
            this.mapNameColumnLabel.AutoSize = true;
            this.mapNameColumnLabel.Location = new System.Drawing.Point(81, 292);
            this.mapNameColumnLabel.Name = "mapNameColumnLabel";
            this.mapNameColumnLabel.Size = new System.Drawing.Size(104, 13);
            this.mapNameColumnLabel.TabIndex = 37;
            this.mapNameColumnLabel.Text = "Name Column Name";
            // 
            // mapSheetName
            // 
            this.mapSheetName.Location = new System.Drawing.Point(198, 232);
            this.mapSheetName.Name = "mapSheetName";
            this.mapSheetName.Size = new System.Drawing.Size(264, 20);
            this.mapSheetName.TabIndex = 36;
            // 
            // mapSheetNameLabel
            // 
            this.mapSheetNameLabel.AutoSize = true;
            this.mapSheetNameLabel.Location = new System.Drawing.Point(81, 235);
            this.mapSheetNameLabel.Name = "mapSheetNameLabel";
            this.mapSheetNameLabel.Size = new System.Drawing.Size(66, 13);
            this.mapSheetNameLabel.TabIndex = 35;
            this.mapSheetNameLabel.Text = "Sheet Name";
            // 
            // mapLabel
            // 
            this.mapLabel.AutoSize = true;
            this.mapLabel.Location = new System.Drawing.Point(15, 232);
            this.mapLabel.Name = "mapLabel";
            this.mapLabel.Size = new System.Drawing.Size(28, 13);
            this.mapLabel.TabIndex = 34;
            this.mapLabel.Text = "Map";
            // 
            // elementNameColumnName
            // 
            this.elementNameColumnName.Location = new System.Drawing.Point(198, 202);
            this.elementNameColumnName.Name = "elementNameColumnName";
            this.elementNameColumnName.Size = new System.Drawing.Size(264, 20);
            this.elementNameColumnName.TabIndex = 33;
            // 
            // elemenNameColumnNameLabel
            // 
            this.elemenNameColumnNameLabel.AutoSize = true;
            this.elemenNameColumnNameLabel.Location = new System.Drawing.Point(81, 205);
            this.elemenNameColumnNameLabel.Name = "elemenNameColumnNameLabel";
            this.elemenNameColumnNameLabel.Size = new System.Drawing.Size(104, 13);
            this.elemenNameColumnNameLabel.TabIndex = 32;
            this.elemenNameColumnNameLabel.Text = "Name Column Name";
            // 
            // sheetNameLabel
            // 
            this.sheetNameLabel.AutoSize = true;
            this.sheetNameLabel.Location = new System.Drawing.Point(81, 152);
            this.sheetNameLabel.Name = "sheetNameLabel";
            this.sheetNameLabel.Size = new System.Drawing.Size(66, 13);
            this.sheetNameLabel.TabIndex = 31;
            this.sheetNameLabel.Text = "Sheet Name";
            // 
            // elementSheetName
            // 
            this.elementSheetName.Location = new System.Drawing.Point(198, 149);
            this.elementSheetName.Name = "elementSheetName";
            this.elementSheetName.Size = new System.Drawing.Size(264, 20);
            this.elementSheetName.TabIndex = 30;
            // 
            // elementsLabel
            // 
            this.elementsLabel.AutoSize = true;
            this.elementsLabel.Location = new System.Drawing.Point(11, 152);
            this.elementsLabel.Name = "elementsLabel";
            this.elementsLabel.Size = new System.Drawing.Size(50, 13);
            this.elementsLabel.TabIndex = 29;
            this.elementsLabel.Text = "Elements";
            // 
            // errorListBox
            // 
            this.errorListBox.FormattingEnabled = true;
            this.errorListBox.Location = new System.Drawing.Point(13, 422);
            this.errorListBox.Name = "errorListBox";
            this.errorListBox.Size = new System.Drawing.Size(760, 277);
            this.errorListBox.TabIndex = 30;
            // 
            // columnsFirstCheckBox
            // 
            this.columnsFirstCheckBox.AutoSize = true;
            this.columnsFirstCheckBox.Location = new System.Drawing.Point(305, 365);
            this.columnsFirstCheckBox.Name = "columnsFirstCheckBox";
            this.columnsFirstCheckBox.Size = new System.Drawing.Size(88, 17);
            this.columnsFirstCheckBox.TabIndex = 48;
            this.columnsFirstCheckBox.Text = "Columns First";
            this.columnsFirstCheckBox.UseVisualStyleBackColor = true;
            // 
            // showDescriptionsCheckBox
            // 
            this.showDescriptionsCheckBox.AutoSize = true;
            this.showDescriptionsCheckBox.Location = new System.Drawing.Point(391, 365);
            this.showDescriptionsCheckBox.Name = "showDescriptionsCheckBox";
            this.showDescriptionsCheckBox.Size = new System.Drawing.Size(78, 17);
            this.showDescriptionsCheckBox.TabIndex = 49;
            this.showDescriptionsCheckBox.Text = "Desriptions";
            this.showDescriptionsCheckBox.UseVisualStyleBackColor = true;
            // 
            // MmLandscapeView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(794, 748);
            this.Controls.Add(this.showDescriptionsCheckBox);
            this.Controls.Add(this.columnsFirstCheckBox);
            this.Controls.Add(this.optimitzeElementLayoutCheckBox);
            this.Controls.Add(this.errorListBox);
            this.Controls.Add(this.freezeMapCheckBox);
            this.Controls.Add(this.titleSpaceCheckBox);
            this.Controls.Add(this.logAtFilePath);
            this.Controls.Add(this.LayoutLabel);
            this.Controls.Add(this.selectedLogFileName);
            this.Controls.Add(this.titleRowCheckBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.mappingSheetName);
            this.Controls.Add(this.mapName);
            this.Controls.Add(this.mappingMapNameColumnName);
            this.Controls.Add(this.generateLandscapeButton);
            this.Controls.Add(this.mappingElementNameColumnName);
            this.Controls.Add(this.mapFileSelect);
            this.Controls.Add(this.MappingLabel);
            this.Controls.Add(this.visioFileSelect);
            this.Controls.Add(this.mapNameColumnName);
            this.Controls.Add(this.mapStencilName);
            this.Controls.Add(this.mapNameColumnLabel);
            this.Controls.Add(this.visioStencilSelect);
            this.Controls.Add(this.mapSheetName);
            this.Controls.Add(this.elementStencilName);
            this.Controls.Add(this.mapSheetNameLabel);
            this.Controls.Add(this.stencilFileName);
            this.Controls.Add(this.mapLabel);
            this.Controls.Add(this.mapStencilLabel);
            this.Controls.Add(this.elementNameColumnName);
            this.Controls.Add(this.stencilFileNameLabel);
            this.Controls.Add(this.elemenNameColumnNameLabel);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.sheetNameLabel);
            this.Controls.Add(this.visioFileName);
            this.Controls.Add(this.elementSheetName);
            this.Controls.Add(this.Prepare);
            this.Controls.Add(this.elementsLabel);
            this.Controls.Add(this.visioFileNameLabel);
            this.Controls.Add(this.mapFileName);
            this.Controls.Add(this.spaceText);
            this.Controls.Add(this.saveConfigButton);
            this.Controls.Add(this.mapVersion);
            this.Controls.Add(this.configNameLabel);
            this.Controls.Add(this.labelspaceLabel);
            this.Controls.Add(this.LoadConfigButton);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.configVersionLabel);
            this.Name = "MmLandscapeView";
            this.Text = "Architecture Map Generator";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label configNameLabel;
        private System.Windows.Forms.Label configVersionLabel;
        private System.Windows.Forms.TextBox mapName;
        private System.Windows.Forms.TextBox mapVersion;
        private System.Windows.Forms.Label visioFileNameLabel;
        private System.Windows.Forms.TextBox visioFileName;
        private System.Windows.Forms.Label stencilFileNameLabel;
        private System.Windows.Forms.TextBox stencilFileName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox mapFileName;
        private System.Windows.Forms.Button visioStencilSelect;
        private System.Windows.Forms.Button visioFileSelect;
        private System.Windows.Forms.Button mapFileSelect;
        private System.Windows.Forms.Button generateLandscapeButton;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.CheckBox logAtFilePath;
        private System.Windows.Forms.TextBox selectedLogFileName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox mapStencilName;
        private System.Windows.Forms.TextBox elementStencilName;
        private System.Windows.Forms.Label mapStencilLabel;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button Prepare;
        private System.Windows.Forms.TextBox spaceText;
        private System.Windows.Forms.Label labelspaceLabel;
        private System.Windows.Forms.Button LoadConfigButton;
        private System.Windows.Forms.Button saveConfigButton;
        private System.Windows.Forms.SaveFileDialog saveConfigFileDialog;
        private System.Windows.Forms.OpenFileDialog openConfigFileDialog;
        private System.Windows.Forms.TextBox elementNameColumnName;
        private System.Windows.Forms.Label elemenNameColumnNameLabel;
        private System.Windows.Forms.Label sheetNameLabel;
        private System.Windows.Forms.TextBox elementSheetName;
        private System.Windows.Forms.Label elementsLabel;
        private System.Windows.Forms.Label mapLabel;
        private System.Windows.Forms.TextBox mapNameColumnName;
        private System.Windows.Forms.Label mapNameColumnLabel;
        private System.Windows.Forms.TextBox mapSheetName;
        private System.Windows.Forms.Label mapSheetNameLabel;
        private System.Windows.Forms.TextBox mappingMapNameColumnName;
        private System.Windows.Forms.TextBox mappingElementNameColumnName;
        private System.Windows.Forms.Label MappingLabel;
        private System.Windows.Forms.TextBox mappingSheetName;
        private System.Windows.Forms.Label LayoutLabel;
        private System.Windows.Forms.CheckBox titleRowCheckBox;
        private System.Windows.Forms.ListBox errorListBox;
        private System.Windows.Forms.CheckBox titleSpaceCheckBox;
        private System.Windows.Forms.CheckBox optimitzeElementLayoutCheckBox;
        private System.Windows.Forms.CheckBox freezeMapCheckBox;
        private System.Windows.Forms.CheckBox columnsFirstCheckBox;
        private System.Windows.Forms.CheckBox showDescriptionsCheckBox;
    }
}

