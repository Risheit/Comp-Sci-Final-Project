
namespace Comp_Sci_Final_Project
{
    partial class Memory
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
            this.HeaderBar = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // HeaderBar
            // 
            this.HeaderBar.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.HeaderBar.BackColor = System.Drawing.Color.Silver;
            this.HeaderBar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.HeaderBar.Cursor = System.Windows.Forms.Cursors.Default;
            this.HeaderBar.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HeaderBar.ForeColor = System.Drawing.Color.Black;
            this.HeaderBar.Location = new System.Drawing.Point(0, 0);
            this.HeaderBar.Name = "HeaderBar";
            this.HeaderBar.ReadOnly = true;
            this.HeaderBar.Size = new System.Drawing.Size(800, 22);
            this.HeaderBar.TabIndex = 0;
            this.HeaderBar.TabStop = false;
            this.HeaderBar.Text = "Points: 0";
            // 
            // Memory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.ForestGreen;
            this.ClientSize = new System.Drawing.Size(800, 440);
            this.Controls.Add(this.HeaderBar);
            this.Name = "Memory";
            this.Text = "Memory";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox HeaderBar;
    }
}

