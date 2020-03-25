namespace OOPLaba3
{
    partial class frmEditVariableStar
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
            this.tbLuminocity = new System.Windows.Forms.TextBox();
            this.tbDelta = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tbLuminocity
            // 
            this.tbLuminocity.Location = new System.Drawing.Point(117, 293);
            this.tbLuminocity.Name = "tbLuminocity";
            this.tbLuminocity.Size = new System.Drawing.Size(100, 22);
            this.tbLuminocity.TabIndex = 14;
            this.tbLuminocity.TextChanged += new System.EventHandler(this.tbLuminocity_TextChanged);
            // 
            // tbDelta
            // 
            this.tbDelta.Location = new System.Drawing.Point(117, 321);
            this.tbDelta.Name = "tbDelta";
            this.tbDelta.Size = new System.Drawing.Size(100, 22);
            this.tbDelta.TabIndex = 15;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 296);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 17);
            this.label2.TabIndex = 16;
            this.label2.Text = "Luminocity";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 326);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 17);
            this.label3.TabIndex = 17;
            this.label3.Text = "Delta lum";
            // 
            // frmEditVariableStar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(454, 450);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbDelta);
            this.Controls.Add(this.tbLuminocity);
            this.Name = "frmEditVariableStar";
            this.Text = "frmEditVariableStar";
            this.Load += new System.EventHandler(this.frmEditVariableStar_Load);
            this.Controls.SetChildIndex(this.tbLuminocity, 0);
            this.Controls.SetChildIndex(this.tbDelta, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbLuminocity;
        private System.Windows.Forms.TextBox tbDelta;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}