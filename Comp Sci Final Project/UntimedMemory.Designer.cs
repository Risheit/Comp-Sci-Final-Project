
namespace Comp_Sci_Final_Project
{
    partial class UntimedMemory
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UntimedMemory));
            this.PointsDisplay = new System.Windows.Forms.Label();
            this.Statistics = new System.Windows.Forms.Label();
            this.Quit = new System.Windows.Forms.Button();
            this.StatisticsHeader = new System.Windows.Forms.Label();
            this.GameEnd = new System.Windows.Forms.Label();
            this.HeaderBar = new System.Windows.Forms.PictureBox();
            this.GameTimer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.HeaderBar)).BeginInit();
            this.SuspendLayout();
            // 
            // PointsDisplay
            // 
            this.PointsDisplay.AutoSize = true;
            this.PointsDisplay.BackColor = System.Drawing.Color.Silver;
            this.PointsDisplay.Location = new System.Drawing.Point(12, 0);
            this.PointsDisplay.Margin = new System.Windows.Forms.Padding(0);
            this.PointsDisplay.Name = "PointsDisplay";
            this.PointsDisplay.Size = new System.Drawing.Size(63, 17);
            this.PointsDisplay.TabIndex = 0;
            this.PointsDisplay.Text = "Points: 0";
            // 
            // Statistics
            // 
            this.Statistics.AutoSize = true;
            this.Statistics.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Statistics.Location = new System.Drawing.Point(11, 159);
            this.Statistics.Name = "Statistics";
            this.Statistics.Size = new System.Drawing.Size(510, 140);
            this.Statistics.TabIndex = 2;
            this.Statistics.Text = "Points:\r\nLongest Failed Matches in a Row:\r\nTotal Matches Attempted:\r\nTotal Matche" +
    "s Made:\r\n\r\nClose this Window or use the quit button to return to the Start Page\r" +
    "\n\r\n";
            this.Statistics.Visible = false;
            // 
            // Quit
            // 
            this.Quit.BackColor = System.Drawing.Color.DarkRed;
            this.Quit.FlatAppearance.BorderColor = System.Drawing.Color.Maroon;
            this.Quit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Quit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.Quit.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.Quit.Location = new System.Drawing.Point(221, 319);
            this.Quit.Name = "Quit";
            this.Quit.Size = new System.Drawing.Size(197, 38);
            this.Quit.TabIndex = 5;
            this.Quit.Text = "Quit";
            this.Quit.UseVisualStyleBackColor = false;
            this.Quit.Visible = false;
            this.Quit.Click += new System.EventHandler(this.Quit_Click);
            // 
            // StatisticsHeader
            // 
            this.StatisticsHeader.AutoSize = true;
            this.StatisticsHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StatisticsHeader.Location = new System.Drawing.Point(10, 130);
            this.StatisticsHeader.Name = "StatisticsHeader";
            this.StatisticsHeader.Size = new System.Drawing.Size(118, 29);
            this.StatisticsHeader.TabIndex = 6;
            this.StatisticsHeader.Text = "Statistics";
            this.StatisticsHeader.Visible = false;
            // 
            // GameEnd
            // 
            this.GameEnd.AutoSize = true;
            this.GameEnd.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Bold);
            this.GameEnd.ForeColor = System.Drawing.SystemColors.Control;
            this.GameEnd.Location = new System.Drawing.Point(15, 39);
            this.GameEnd.Name = "GameEnd";
            this.GameEnd.Size = new System.Drawing.Size(426, 91);
            this.GameEnd.TabIndex = 7;
            this.GameEnd.Text = "Game End";
            this.GameEnd.Visible = false;
            // 
            // HeaderBar
            // 
            this.HeaderBar.BackColor = System.Drawing.Color.Silver;
            this.HeaderBar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.HeaderBar.Location = new System.Drawing.Point(-1, -1);
            this.HeaderBar.Margin = new System.Windows.Forms.Padding(0);
            this.HeaderBar.Name = "HeaderBar";
            this.HeaderBar.Size = new System.Drawing.Size(601, 20);
            this.HeaderBar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.HeaderBar.TabIndex = 1;
            this.HeaderBar.TabStop = false;
            // 
            // GameTimer
            // 
            this.GameTimer.Enabled = true;
            this.GameTimer.Interval = 1000;
            this.GameTimer.Tick += new System.EventHandler(this.GameTimer_Tick);
            // 
            // UntimedMemory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.ForestGreen;
            this.ClientSize = new System.Drawing.Size(682, 381);
            this.Controls.Add(this.GameEnd);
            this.Controls.Add(this.StatisticsHeader);
            this.Controls.Add(this.Quit);
            this.Controls.Add(this.Statistics);
            this.Controls.Add(this.PointsDisplay);
            this.Controls.Add(this.HeaderBar);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "UntimedMemory";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Memory";
            this.Load += new System.EventHandler(this.UntimedMemory_Load);
            ((System.ComponentModel.ISupportInitialize)(this.HeaderBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label PointsDisplay;
        private System.Windows.Forms.PictureBox HeaderBar;
        private System.Windows.Forms.Label Statistics;
        private System.Windows.Forms.Button Quit;
        private System.Windows.Forms.Label StatisticsHeader;
        private System.Windows.Forms.Label GameEnd;
        private System.Windows.Forms.Timer GameTimer;
    }
}

