namespace OOPLaba3
{
    partial class frmEditAstro
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
            this.tbName = new System.Windows.Forms.TextBox();
            this.lbName = new System.Windows.Forms.Label();
            this.lbPosition = new System.Windows.Forms.Label();
            this.btOk = new System.Windows.Forms.Button();
            this.tbMass = new System.Windows.Forms.TextBox();
            this.lbMass = new System.Windows.Forms.Label();
            this.tbX = new System.Windows.Forms.TextBox();
            this.tbY = new System.Windows.Forms.TextBox();
            this.tbSize = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(117, 22);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(139, 22);
            this.tbName.TabIndex = 0;
            this.tbName.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // lbName
            // 
            this.lbName.AutoSize = true;
            this.lbName.Location = new System.Drawing.Point(22, 25);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(45, 17);
            this.lbName.TabIndex = 1;
            this.lbName.Text = "Name";
            // 
            // lbPosition
            // 
            this.lbPosition.AutoSize = true;
            this.lbPosition.Location = new System.Drawing.Point(22, 71);
            this.lbPosition.Name = "lbPosition";
            this.lbPosition.Size = new System.Drawing.Size(36, 17);
            this.lbPosition.TabIndex = 3;
            this.lbPosition.Text = "Pos:";
            // 
            // btOk
            // 
            this.btOk.Location = new System.Drawing.Point(25, 364);
            this.btOk.Name = "btOk";
            this.btOk.Size = new System.Drawing.Size(75, 23);
            this.btOk.TabIndex = 4;
            this.btOk.Text = "Ok";
            this.btOk.UseVisualStyleBackColor = true;
            this.btOk.Click += new System.EventHandler(this.btOk_Click);
            // 
            // tbMass
            // 
            this.tbMass.Location = new System.Drawing.Point(117, 109);
            this.tbMass.Name = "tbMass";
            this.tbMass.Size = new System.Drawing.Size(100, 22);
            this.tbMass.TabIndex = 5;
            // 
            // lbMass
            // 
            this.lbMass.AutoSize = true;
            this.lbMass.Location = new System.Drawing.Point(22, 114);
            this.lbMass.Name = "lbMass";
            this.lbMass.Size = new System.Drawing.Size(41, 17);
            this.lbMass.TabIndex = 6;
            this.lbMass.Text = "Mass";
            // 
            // tbX
            // 
            this.tbX.Location = new System.Drawing.Point(117, 66);
            this.tbX.Name = "tbX";
            this.tbX.Size = new System.Drawing.Size(31, 22);
            this.tbX.TabIndex = 7;
            this.tbX.TextChanged += new System.EventHandler(this.tbX_TextChanged);
            // 
            // tbY
            // 
            this.tbY.Location = new System.Drawing.Point(183, 66);
            this.tbY.Name = "tbY";
            this.tbY.Size = new System.Drawing.Size(34, 22);
            this.tbY.TabIndex = 8;
            // 
            // tbSize
            // 
            this.tbSize.AccessibleDescription = "ed";
            this.tbSize.Location = new System.Drawing.Point(297, 109);
            this.tbSize.Name = "tbSize";
            this.tbSize.Size = new System.Drawing.Size(100, 22);
            this.tbSize.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(245, 112);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 17);
            this.label1.TabIndex = 10;
            this.label1.Text = "Radius";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // frmEditAstro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(461, 399);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbSize);
            this.Controls.Add(this.tbY);
            this.Controls.Add(this.tbX);
            this.Controls.Add(this.lbMass);
            this.Controls.Add(this.tbMass);
            this.Controls.Add(this.btOk);
            this.Controls.Add(this.lbPosition);
            this.Controls.Add(this.lbName);
            this.Controls.Add(this.tbName);
            this.Name = "frmEditAstro";
            this.Text = "                                                                                 " +
    "                                            ";
            this.Load += new System.EventHandler(this.frmEditAstro_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.Label lbName;
        private System.Windows.Forms.Label lbPosition;
        private System.Windows.Forms.Button btOk;
        private System.Windows.Forms.TextBox tbMass;
        private System.Windows.Forms.Label lbMass;
        private System.Windows.Forms.TextBox tbX;
        private System.Windows.Forms.TextBox tbY;
        private System.Windows.Forms.TextBox tbSize;
        private System.Windows.Forms.Label label1;
    }
}