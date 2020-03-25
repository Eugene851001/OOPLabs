namespace OOPLaba3
{
    partial class frmEditSatellite
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
            this.lbPlanet = new System.Windows.Forms.Label();
            this.cbPlanet = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // lbPlanet
            // 
            this.lbPlanet.AutoSize = true;
            this.lbPlanet.Location = new System.Drawing.Point(17, 163);
            this.lbPlanet.Name = "lbPlanet";
            this.lbPlanet.Size = new System.Drawing.Size(48, 17);
            this.lbPlanet.TabIndex = 9;
            this.lbPlanet.Text = "Planet";
            // 
            // cbPlanet
            // 
            this.cbPlanet.FormattingEnabled = true;
            this.cbPlanet.Location = new System.Drawing.Point(96, 163);
            this.cbPlanet.Name = "cbPlanet";
            this.cbPlanet.Size = new System.Drawing.Size(121, 24);
            this.cbPlanet.TabIndex = 10;
            // 
            // frmEditSatellite
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(331, 420);
            this.Controls.Add(this.cbPlanet);
            this.Controls.Add(this.lbPlanet);
            this.Name = "frmEditSatellite";
            this.Text = "frmEditSatellite";
            this.Load += new System.EventHandler(this.frmEditSatellite_Load);
            this.Controls.SetChildIndex(this.lbPlanet, 0);
            this.Controls.SetChildIndex(this.cbPlanet, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbPlanet;
        private System.Windows.Forms.ComboBox cbPlanet;
    }
}