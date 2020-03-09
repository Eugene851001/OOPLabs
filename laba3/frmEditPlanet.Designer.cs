namespace OOPLaba3
{
    partial class frmEditPlanet
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
            this.lbSatellites = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btEditStar = new System.Windows.Forms.Button();
            this.cbStars = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // lbSatellites
            // 
            this.lbSatellites.FormattingEnabled = true;
            this.lbSatellites.ItemHeight = 16;
            this.lbSatellites.Location = new System.Drawing.Point(117, 233);
            this.lbSatellites.Name = "lbSatellites";
            this.lbSatellites.Size = new System.Drawing.Size(120, 84);
            this.lbSatellites.TabIndex = 9;
            this.lbSatellites.SelectedIndexChanged += new System.EventHandler(this.lbSatellites_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(2, 233);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 17);
            this.label1.TabIndex = 11;
            this.label1.Text = "Satellites";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 161);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 17);
            this.label2.TabIndex = 13;
            this.label2.Text = "Star:";
            // 
            // btEditStar
            // 
            this.btEditStar.Location = new System.Drawing.Point(256, 161);
            this.btEditStar.Name = "btEditStar";
            this.btEditStar.Size = new System.Drawing.Size(65, 23);
            this.btEditStar.TabIndex = 14;
            this.btEditStar.Text = "Edit";
            this.btEditStar.UseVisualStyleBackColor = true;
            // 
            // cbStars
            // 
            this.cbStars.FormattingEnabled = true;
            this.cbStars.Location = new System.Drawing.Point(117, 158);
            this.cbStars.Name = "cbStars";
            this.cbStars.Size = new System.Drawing.Size(121, 24);
            this.cbStars.TabIndex = 15;
            // 
            // frmEditPlanet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(417, 450);
            this.Controls.Add(this.cbStars);
            this.Controls.Add(this.btEditStar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbSatellites);
            this.Name = "frmEditPlanet";
            this.Text = "frmEditPlanet";
            this.Load += new System.EventHandler(this.frmEditPlanet_Load);
            this.Controls.SetChildIndex(this.lbSatellites, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.btEditStar, 0);
            this.Controls.SetChildIndex(this.cbStars, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbSatellites;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btEditStar;
        private System.Windows.Forms.ComboBox cbStars;
    }
}