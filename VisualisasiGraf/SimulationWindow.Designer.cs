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
            this.PathOutput = new System.Windows.Forms.TextBox();
            this.graphPanel = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // SimulateButton
            // 
            this.SimulateButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
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
            this.InputLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
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
            this.DayInputField.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DayInputField.Location = new System.Drawing.Point(496, 428);
            this.DayInputField.Name = "DayInputField";
            this.DayInputField.Size = new System.Drawing.Size(145, 20);
            this.DayInputField.TabIndex = 2;
            this.DayInputField.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(498, 25);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(276, 109);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click_2);
            // 
            // PathOutput
            // 
            this.PathOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PathOutput.Location = new System.Drawing.Point(498, 140);
            this.PathOutput.Multiline = true;
            this.PathOutput.Name = "PathOutput";
            this.PathOutput.ReadOnly = true;
            this.PathOutput.Size = new System.Drawing.Size(276, 253);
            this.PathOutput.TabIndex = 5;
            // 
            // graphPanel
            // 
            this.graphPanel.Location = new System.Drawing.Point(12, 12);
            this.graphPanel.Name = "graphPanel";
            this.graphPanel.Size = new System.Drawing.Size(475, 436);
            this.graphPanel.TabIndex = 6;
            // 
            // SimulationWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(786, 473);
            this.Controls.Add(this.graphPanel);
            this.Controls.Add(this.PathOutput);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.DayInputField);
            this.Controls.Add(this.InputLabel);
            this.Controls.Add(this.SimulateButton);
            this.Name = "SimulationWindow";
            this.Text = "Disease Spreading Simulation";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button SimulateButton;
        private System.Windows.Forms.Label InputLabel;
        private System.Windows.Forms.TextBox DayInputField;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox PathOutput;
        private System.Windows.Forms.Panel graphPanel;
    }
}

