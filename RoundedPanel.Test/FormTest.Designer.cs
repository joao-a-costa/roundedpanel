﻿namespace RoundedPanel.Test
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
            this.roundedPanel2 = new RoundedPanel.RoundedPanel(this.components);
            this.roundedPanel3 = new RoundedPanel.RoundedPanel(this.components);
            this.roundedPanel1 = new RoundedPanel.RoundedPanel(this.components);
            this.SuspendLayout();
            // 
            // roundedPanel2
            // 
            this.roundedPanel2.BackColor = System.Drawing.Color.LightBlue;
            this.roundedPanel2.BorderRadius = 30;
            this.roundedPanel2.Location = new System.Drawing.Point(573, 148);
            this.roundedPanel2.Name = "roundedPanel2";
            this.roundedPanel2.RadiusButtonLeft = 1;
            this.roundedPanel2.RadiusButtonRight = 1;
            this.roundedPanel2.RadiusTopLeft = 60;
            this.roundedPanel2.RadiusTopRight = 60;
            this.roundedPanel2.Size = new System.Drawing.Size(200, 100);
            this.roundedPanel2.TabIndex = 3;
            // 
            // roundedPanel3
            // 
            this.roundedPanel3.BackColor = System.Drawing.Color.LightBlue;
            this.roundedPanel3.BorderRadius = 500;
            this.roundedPanel3.Location = new System.Drawing.Point(68, 221);
            this.roundedPanel3.Name = "roundedPanel3";
            this.roundedPanel3.RadiusButtonLeft = 30;
            this.roundedPanel3.RadiusButtonRight = 30;
            this.roundedPanel3.RadiusTopLeft = 30;
            this.roundedPanel3.RadiusTopRight = 30;
            this.roundedPanel3.Size = new System.Drawing.Size(279, 204);
            this.roundedPanel3.TabIndex = 2;
            // 
            // roundedPanel1
            // 
            this.roundedPanel1.BackColor = System.Drawing.Color.LightBlue;
            this.roundedPanel1.BorderRadius = 30;
            this.roundedPanel1.Location = new System.Drawing.Point(0, 0);
            this.roundedPanel1.Name = "roundedPanel1";
            this.roundedPanel1.RadiusButtonLeft = 30;
            this.roundedPanel1.RadiusButtonRight = 30;
            this.roundedPanel1.RadiusTopLeft = 30;
            this.roundedPanel1.RadiusTopRight = 30;
            this.roundedPanel1.Size = new System.Drawing.Size(279, 204);
            this.roundedPanel1.TabIndex = 0;
            // 
            // FormTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.roundedPanel2);
            this.Controls.Add(this.roundedPanel3);
            this.Controls.Add(this.roundedPanel1);
            this.Name = "FormTest";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private RoundedPanel roundedPanel1;
        private RoundedPanel roundedPanel3;
        private RoundedPanel.RoundedPanel roundedPanel2;
    }
}

