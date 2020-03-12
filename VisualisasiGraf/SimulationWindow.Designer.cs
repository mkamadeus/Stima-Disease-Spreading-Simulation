namespace VisualisasiGraf
{
    partial class SimulationWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SimulationWindow));
            this.SimulateButton = new System.Windows.Forms.Button();
            this.InputLabel = new System.Windows.Forms.Label();
            this.DayInputField = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.graphPanel = new System.Windows.Forms.Panel();
            this.pathLabel = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // SimulateButton
            // 
            this.SimulateButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.SimulateButton.Location = new System.Drawing.Point(649, 412);
            this.SimulateButton.Name = "SimulateButton";
            this.SimulateButton.Size = new System.Drawing.Size(125, 39);
            this.SimulateButton.TabIndex = 0;
            this.SimulateButton.Text = "Simulate";
            this.SimulateButton.UseVisualStyleBackColor = true;
            this.SimulateButton.Click += new System.EventHandler(this.simulateButton_Click);
            // 
            // InputLabel
            // 
            this.InputLabel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.InputLabel.AutoSize = true;
            this.InputLabel.Location = new System.Drawing.Point(493, 412);
            this.InputLabel.Name = "InputLabel";
            this.InputLabel.Size = new System.Drawing.Size(146, 13);
            this.InputLabel.TabIndex = 1;
            this.InputLabel.Text = "Input the day to be simulated:";
            this.InputLabel.Click += new System.EventHandler(this.label1_Click);
            // 
            // DayInputField
            // 
            this.DayInputField.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.DayInputField.Location = new System.Drawing.Point(496, 428);
            this.DayInputField.Name = "DayInputField";
            this.DayInputField.Size = new System.Drawing.Size(145, 20);
            this.DayInputField.TabIndex = 2;
            this.DayInputField.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(498, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(276, 122);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click_2);
            // 
            // graphPanel
            // 
            this.graphPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.graphPanel.BackColor = System.Drawing.SystemColors.ControlLight;
            this.graphPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.graphPanel.Location = new System.Drawing.Point(12, 12);
            this.graphPanel.Name = "graphPanel";
            this.graphPanel.Size = new System.Drawing.Size(475, 436);
            this.graphPanel.TabIndex = 6;
            this.graphPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.graphPanel_Paint);
            // 
            // pathLabel
            // 
            this.pathLabel.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pathLabel.Location = new System.Drawing.Point(3, 0);
            this.pathLabel.Name = "pathLabel";
            this.pathLabel.Size = new System.Drawing.Size(258, 243);
            this.pathLabel.TabIndex = 7;
            this.pathLabel.Text = "Welcome to PANTAT.";
            this.pathLabel.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.panel1.BackColor = System.Drawing.SystemColors.Window;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.pathLabel);
            this.panel1.Location = new System.Drawing.Point(498, 140);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(276, 266);
            this.panel1.TabIndex = 8;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // SimulationWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(786, 473);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.graphPanel);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.DayInputField);
            this.Controls.Add(this.InputLabel);
            this.Controls.Add(this.SimulateButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SimulationWindow";
            this.Text = "Pandemic Act of Nonexistent Troublesome Ache Tracing";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button SimulateButton;
        private System.Windows.Forms.Label InputLabel;
        private System.Windows.Forms.TextBox DayInputField;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel graphPanel;
        private System.Windows.Forms.Label pathLabel;
        private System.Windows.Forms.Panel panel1;
    }
}

