
namespace Comp_Sci_Final_Project
{
    partial class StartPage
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
            System.Windows.Forms.Label Authors;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StartPage));
            this.Title = new System.Windows.Forms.Label();
            this.ButtonHelp = new System.Windows.Forms.Button();
            this.ButtonQuit = new System.Windows.Forms.Button();
            this.ButtonStopwatch = new System.Windows.Forms.Button();
            this.ButtonTimer = new System.Windows.Forms.Button();
            this.CardImage = new System.Windows.Forms.PictureBox();
            Authors = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.CardImage)).BeginInit();
            this.SuspendLayout();
            // 
            // Authors
            // 
            Authors.AutoSize = true;
            Authors.Location = new System.Drawing.Point(212, 144);
            Authors.Name = "Authors";
            Authors.Size = new System.Drawing.Size(141, 34);
            Authors.TabIndex = 0;
            Authors.Text = "Risheit Munshi\r\nDavid Odubor-Okojie\r\n";
            // 
            // Title
            // 
            this.Title.AutoSize = true;
            this.Title.BackColor = System.Drawing.Color.ForestGreen;
            this.Title.Font = new System.Drawing.Font("Baskerville Old Face", 72F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Title.Location = new System.Drawing.Point(177, 27);
            this.Title.Name = "Title";
            this.Title.Size = new System.Drawing.Size(475, 137);
            this.Title.TabIndex = 2;
            this.Title.Text = "Memory";
            // 
            // ButtonHelp
            // 
            this.ButtonHelp.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.ButtonHelp.FlatAppearance.BorderColor = System.Drawing.SystemColors.HotTrack;
            this.ButtonHelp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonHelp.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.ButtonHelp.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.ButtonHelp.Location = new System.Drawing.Point(418, 196);
            this.ButtonHelp.Name = "ButtonHelp";
            this.ButtonHelp.Size = new System.Drawing.Size(197, 101);
            this.ButtonHelp.TabIndex = 3;
            this.ButtonHelp.Text = "Help";
            this.ButtonHelp.UseVisualStyleBackColor = false;
            this.ButtonHelp.Click += new System.EventHandler(this.OpenHelp);
            // 
            // ButtonQuit
            // 
            this.ButtonQuit.BackColor = System.Drawing.Color.DarkRed;
            this.ButtonQuit.FlatAppearance.BorderColor = System.Drawing.Color.Maroon;
            this.ButtonQuit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonQuit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.ButtonQuit.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.ButtonQuit.Location = new System.Drawing.Point(418, 303);
            this.ButtonQuit.Name = "ButtonQuit";
            this.ButtonQuit.Size = new System.Drawing.Size(197, 101);
            this.ButtonQuit.TabIndex = 4;
            this.ButtonQuit.Text = "Quit";
            this.ButtonQuit.UseVisualStyleBackColor = false;
            this.ButtonQuit.Click += new System.EventHandler(this.QuitGame);
            // 
            // ButtonStopwatch
            // 
            this.ButtonStopwatch.BackColor = System.Drawing.Color.Chartreuse;
            this.ButtonStopwatch.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.ButtonStopwatch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonStopwatch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.ButtonStopwatch.ForeColor = System.Drawing.Color.Ivory;
            this.ButtonStopwatch.Location = new System.Drawing.Point(215, 196);
            this.ButtonStopwatch.Name = "ButtonStopwatch";
            this.ButtonStopwatch.Size = new System.Drawing.Size(197, 208);
            this.ButtonStopwatch.TabIndex = 3;
            this.ButtonStopwatch.Text = "Play Memory\r\nUntimed\r\n";
            this.ButtonStopwatch.UseVisualStyleBackColor = false;
            this.ButtonStopwatch.Click += new System.EventHandler(this.UntimedMemory);
            // 
            // ButtonTimer
            // 
            this.ButtonTimer.BackColor = System.Drawing.Color.Gold;
            this.ButtonTimer.FlatAppearance.BorderColor = System.Drawing.Color.Goldenrod;
            this.ButtonTimer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonTimer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonTimer.ForeColor = System.Drawing.Color.Cornsilk;
            this.ButtonTimer.Location = new System.Drawing.Point(12, 196);
            this.ButtonTimer.Name = "ButtonTimer";
            this.ButtonTimer.Size = new System.Drawing.Size(197, 208);
            this.ButtonTimer.TabIndex = 5;
            this.ButtonTimer.Text = "Play Memory\r\nTimed \r\n";
            this.ButtonTimer.UseVisualStyleBackColor = false;
            this.ButtonTimer.Click += new System.EventHandler(this.CountdownMemory);
            // 
            // CardImage
            // 
            this.CardImage.Image = global::Comp_Sci_Final_Project.Properties.Resources.aces;
            this.CardImage.Location = new System.Drawing.Point(9, 26);
            this.CardImage.Name = "CardImage";
            this.CardImage.Size = new System.Drawing.Size(197, 152);
            this.CardImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.CardImage.TabIndex = 1;
            this.CardImage.TabStop = false;
            // 
            // StartPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.ForestGreen;
            this.ClientSize = new System.Drawing.Size(631, 407);
            this.Controls.Add(this.ButtonTimer);
            this.Controls.Add(this.ButtonQuit);
            this.Controls.Add(this.ButtonStopwatch);
            this.Controls.Add(this.ButtonHelp);
            this.Controls.Add(this.CardImage);
            this.Controls.Add(Authors);
            this.Controls.Add(this.Title);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "StartPage";
            this.Text = "StartPage";
            ((System.ComponentModel.ISupportInitialize)(this.CardImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox CardImage;
        private System.Windows.Forms.Label Title;
        private System.Windows.Forms.Button ButtonHelp;
        private System.Windows.Forms.Button ButtonQuit;
        private System.Windows.Forms.Button ButtonStopwatch;
        private System.Windows.Forms.Button ButtonTimer;
    }
}