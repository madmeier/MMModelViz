namespace MM_ModelViz
{
    partial class MMModelVizMain
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
            this.lineDecorationButton = new System.Windows.Forms.Button();
            this.shapeDecorationButton = new System.Windows.Forms.Button();
            this.landscapeToolButton = new System.Windows.Forms.Button();
            this.matrixToolButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lineDecorationButton
            // 
            this.lineDecorationButton.Image = global::MM_ModelViz.Properties.Resources.Line;
            this.lineDecorationButton.Location = new System.Drawing.Point(105, 99);
            this.lineDecorationButton.Name = "lineDecorationButton";
            this.lineDecorationButton.Size = new System.Drawing.Size(87, 78);
            this.lineDecorationButton.TabIndex = 3;
            this.lineDecorationButton.UseVisualStyleBackColor = true;
            this.lineDecorationButton.Click += new System.EventHandler(this.LineDecorationButtonClick);
            // 
            // shapeDecorationButton
            // 
            this.shapeDecorationButton.Image = global::MM_ModelViz.Properties.Resources.Decor;
            this.shapeDecorationButton.Location = new System.Drawing.Point(12, 98);
            this.shapeDecorationButton.Name = "shapeDecorationButton";
            this.shapeDecorationButton.Size = new System.Drawing.Size(87, 79);
            this.shapeDecorationButton.TabIndex = 2;
            this.shapeDecorationButton.UseVisualStyleBackColor = true;
            this.shapeDecorationButton.Click += new System.EventHandler(this.ShapeDecorationButtonClick);
            // 
            // landscapeToolButton
            // 
            this.landscapeToolButton.Image = global::MM_ModelViz.Properties.Resources.Landscape;
            this.landscapeToolButton.Location = new System.Drawing.Point(12, 13);
            this.landscapeToolButton.Name = "landscapeToolButton";
            this.landscapeToolButton.Size = new System.Drawing.Size(87, 79);
            this.landscapeToolButton.TabIndex = 1;
            this.landscapeToolButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.landscapeToolButton.UseVisualStyleBackColor = true;
            this.landscapeToolButton.Click += new System.EventHandler(this.LandscapeToolButton1Click);
            // 
            // matrixToolButton
            // 
            this.matrixToolButton.Image = global::MM_ModelViz.Properties.Resources.Matrix;
            this.matrixToolButton.Location = new System.Drawing.Point(106, 14);
            this.matrixToolButton.Name = "matrixToolButton";
            this.matrixToolButton.Size = new System.Drawing.Size(86, 78);
            this.matrixToolButton.TabIndex = 0;
            this.matrixToolButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.matrixToolButton.UseVisualStyleBackColor = true;
            this.matrixToolButton.Click += new System.EventHandler(this.MatrixToolButtonClick);
            // 
            // MMModelVizMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(213, 198);
            this.Controls.Add(this.lineDecorationButton);
            this.Controls.Add(this.shapeDecorationButton);
            this.Controls.Add(this.landscapeToolButton);
            this.Controls.Add(this.matrixToolButton);
            this.Name = "MMModelVizMain";
            this.Text = "MM Model Viz";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button matrixToolButton;
        private System.Windows.Forms.Button landscapeToolButton;
        private System.Windows.Forms.Button shapeDecorationButton;
        private System.Windows.Forms.Button lineDecorationButton;
    }
}

