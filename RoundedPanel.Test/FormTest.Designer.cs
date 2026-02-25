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
            this.roundedPanel1 = new RoundedPanel(this.components);
            this.roundedPanel2 = new RoundedPanel(this.components);
            this.roundedPanel3 = new RoundedPanel(this.components);
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.roundedPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // roundedPanel1
            // 
            this.roundedPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.roundedPanel1.BorderColor = System.Drawing.Color.Red;
            this.roundedPanel1.BorderRadius = 25;
            this.roundedPanel1.BorderThickness = 2;
            this.roundedPanel1.Controls.Add(this.textBox1);
            this.roundedPanel1.Location = new System.Drawing.Point(149, 51);
            this.roundedPanel1.Name = "roundedPanel1";
            this.roundedPanel1.RadiusBottomLeft = 25;
            this.roundedPanel1.RadiusBottomRight = 25;
            this.roundedPanel1.RadiusTopLeft = 25;
            this.roundedPanel1.RadiusTopRight = 25;
            this.roundedPanel1.Size = new System.Drawing.Size(299, 47);
            this.roundedPanel1.TabIndex = 0;
            // 
            // roundedPanel2
            // 
            this.roundedPanel2.BackColor = System.Drawing.Color.LightBlue;
            this.roundedPanel2.BorderColor = System.Drawing.Color.DimGray;
            this.roundedPanel2.BorderRadius = 60;
            this.roundedPanel2.BorderThickness = 1;
            this.roundedPanel2.Location = new System.Drawing.Point(573, 148);
            this.roundedPanel2.Name = "roundedPanel2";
            this.roundedPanel2.RadiusBottomLeft = 1;
            this.roundedPanel2.RadiusBottomRight = 1;
            this.roundedPanel2.RadiusTopLeft = 60;
            this.roundedPanel2.RadiusTopRight = 60;
            this.roundedPanel2.Size = new System.Drawing.Size(200, 100);
            this.roundedPanel2.TabIndex = 3;
            // 
            // roundedPanel3
            // 
            this.roundedPanel3.BackColor = System.Drawing.Color.LightBlue;
            this.roundedPanel3.BorderColor = System.Drawing.Color.DimGray;
            this.roundedPanel3.BorderRadius = 30;
            this.roundedPanel3.BorderThickness = 1;
            this.roundedPanel3.Location = new System.Drawing.Point(68, 221);
            this.roundedPanel3.Name = "roundedPanel3";
            this.roundedPanel3.RadiusBottomLeft = 30;
            this.roundedPanel3.RadiusBottomRight = 30;
            this.roundedPanel3.RadiusTopLeft = 30;
            this.roundedPanel3.RadiusTopRight = 30;
            this.roundedPanel3.Size = new System.Drawing.Size(279, 204);
            this.roundedPanel3.TabIndex = 2;
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Location = new System.Drawing.Point(11, 14);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(278, 20);
            this.textBox1.TabIndex = 0;
            this.textBox1.Text = "Texto pretendido...";
            // 
            // FormTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.roundedPanel2);
            this.Controls.Add(this.roundedPanel3);
            this.Controls.Add(this.roundedPanel1);
            this.Name = "FormTest";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.FormTest_Load);
            this.roundedPanel1.ResumeLayout(false);
            this.roundedPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private RoundedPanel roundedPanel1;
        private RoundedPanel roundedPanel3;
        private RoundedPanel roundedPanel2;
        private System.Windows.Forms.TextBox textBox1;
    }
}

