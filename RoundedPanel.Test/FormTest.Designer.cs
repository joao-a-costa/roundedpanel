namespace RoundedPanel.Test
{
    partial class FormTest
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
            this.roundedPanel3 = new RoundedPanel.RoundedPanel(this.components);
            this.SuspendLayout();
            // 
            // roundedPanel3
            // 
            this.roundedPanel3.BackColor = System.Drawing.Color.LightBlue;
            this.roundedPanel3.BorderColor = System.Drawing.Color.DimGray;
            this.roundedPanel3.BorderRadius = 30;
            this.roundedPanel3.BorderThickness = 1;
            this.roundedPanel3.CollapseOnHeaderClick = true;
            this.roundedPanel3.HeaderBottomSeparator = true;
            this.roundedPanel3.HeaderColor = System.Drawing.Color.SteelBlue;
            this.roundedPanel3.HeaderGradientEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.roundedPanel3.HeaderGradientStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(86)))), ((int)(((byte)(110)))));
            this.roundedPanel3.HeaderIcon = null;
            this.roundedPanel3.IsCollapsed = false;
            this.roundedPanel3.Location = new System.Drawing.Point(188, 70);
            this.roundedPanel3.Name = "roundedPanel3";
            this.roundedPanel3.RadiusBottomLeft = 30;
            this.roundedPanel3.RadiusBottomRight = 30;
            this.roundedPanel3.RadiusTopLeft = 30;
            this.roundedPanel3.RadiusTopRight = 30;
            this.roundedPanel3.Size = new System.Drawing.Size(279, 204);
            this.roundedPanel3.TabIndex = 2;
            this.roundedPanel3.TextHeaderColor = System.Drawing.Color.White;
            this.roundedPanel3.TextHeaderFont = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            // 
            // FormTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.roundedPanel3);
            this.Name = "FormTest";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.FormTest_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private RoundedPanel roundedPanel3;
    }
}

