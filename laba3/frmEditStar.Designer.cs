﻿namespace OOPLaba3
{
    partial class frmEditStar
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
            this.label1 = new System.Windows.Forms.Label();
            this.lbPlanets = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 171);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 17);
            this.label1.TabIndex = 9;
            this.label1.Text = "Planets";
            // 
            // lbPlanets
            // 
            this.lbPlanets.FormattingEnabled = true;
            this.lbPlanets.ItemHeight = 16;
            this.lbPlanets.Location = new System.Drawing.Point(117, 171);
            this.lbPlanets.Name = "lbPlanets";
            this.lbPlanets.Size = new System.Drawing.Size(120, 116);
            this.lbPlanets.TabIndex = 10;
            // 
            // frmEditStar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(402, 450);
            this.Controls.Add(this.lbPlanets);
            this.Controls.Add(this.label1);
            this.Name = "frmEditStar";
            this.Text = "frmEditStar";
            this.Load += new System.EventHandler(this.frmEditStar_Load);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.lbPlanets, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lbPlanets;
    }
}