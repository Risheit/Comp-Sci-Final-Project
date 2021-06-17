
namespace Comp_Sci_Final_Project
{
    partial class CountdownMemory
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
            this.PointsDisplay = new System.Windows.Forms.Label();
            this.HeaderBar = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.HeaderBar)).BeginInit();
            this.SuspendLayout();
            // 
            // PointsDisplay
            // 
            this.PointsDisplay.AutoSize = true;
            this.PointsDisplay.BackColor = System.Drawing.Color.Silver;
            this.PointsDisplay.Location = new System.Drawing.Point(12, 2);
            this.PointsDisplay.Margin = new System.Windows.Forms.Padding(0);
            this.PointsDisplay.Name = "PointsDisplay";
            this.PointsDisplay.Size = new System.Drawing.Size(63, 17);
            this.PointsDisplay.TabIndex = 0;
            this.PointsDisplay.Text = "Points: 0";
            // 
            // HeaderBar
            // 
            this.HeaderBar.BackColor = System.Drawing.Color.Silver;
            this.HeaderBar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.HeaderBar.Location = new System.Drawing.Point(-7, -1);
            this.HeaderBar.Margin = new System.Windows.Forms.Padding(0);
            this.HeaderBar.Name = "HeaderBar";
            this.HeaderBar.Size = new System.Drawing.Size(601, 17);
            this.HeaderBar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.HeaderBar.TabIndex = 1;
            this.HeaderBar.TabStop = false;
            // 
            // CountdownMemory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.ForestGreen;
            this.ClientSize = new System.Drawing.Size(682, 381);
            this.Controls.Add(this.PointsDisplay);
            this.Controls.Add(this.HeaderBar);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.MaximizeBox = false;
            this.Name = "CountdownMemory";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Memory";
            this.Load += new System.EventHandler(this.CountdownMemory_Load);
            ((System.ComponentModel.ISupportInitialize)(this.HeaderBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label PointsDisplay;
        private System.Windows.Forms.PictureBox HeaderBar;
    }
}

