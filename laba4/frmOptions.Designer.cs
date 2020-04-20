namespace UniverseEditor
{
    partial class frmOptions
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
            this.cbSaveFrom = new System.Windows.Forms.ComboBox();
            this.cbSaveTo = new System.Windows.Forms.ComboBox();
            this.cbLoadFrom = new System.Windows.Forms.ComboBox();
            this.cbLoadTo = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btApply = new System.Windows.Forms.Button();
            this.cbWriteIndent = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // cbSaveFrom
            // 
            this.cbSaveFrom.FormattingEnabled = true;
            this.cbSaveFrom.Location = new System.Drawing.Point(163, 65);
            this.cbSaveFrom.Name = "cbSaveFrom";
            this.cbSaveFrom.Size = new System.Drawing.Size(121, 24);
            this.cbSaveFrom.TabIndex = 0;
            // 
            // cbSaveTo
            // 
            this.cbSaveTo.FormattingEnabled = true;
            this.cbSaveTo.Location = new System.Drawing.Point(337, 65);
            this.cbSaveTo.Name = "cbSaveTo";
            this.cbSaveTo.Size = new System.Drawing.Size(121, 24);
            this.cbSaveTo.TabIndex = 1;
            // 
            // cbLoadFrom
            // 
            this.cbLoadFrom.FormattingEnabled = true;
            this.cbLoadFrom.Location = new System.Drawing.Point(163, 126);
            this.cbLoadFrom.Name = "cbLoadFrom";
            this.cbLoadFrom.Size = new System.Drawing.Size(121, 24);
            this.cbLoadFrom.TabIndex = 2;
            // 
            // cbLoadTo
            // 
            this.cbLoadTo.FormattingEnabled = true;
            this.cbLoadTo.Location = new System.Drawing.Point(337, 126);
            this.cbLoadTo.Name = "cbLoadTo";
            this.cbLoadTo.Size = new System.Drawing.Size(121, 24);
            this.cbLoadTo.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(70, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "Save from";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(299, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "to";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(70, 133);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "Load from";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(299, 133);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(20, 17);
            this.label4.TabIndex = 7;
            this.label4.Text = "to";
            // 
            // btApply
            // 
            this.btApply.Location = new System.Drawing.Point(163, 196);
            this.btApply.Name = "btApply";
            this.btApply.Size = new System.Drawing.Size(121, 38);
            this.btApply.TabIndex = 8;
            this.btApply.Text = "Apply setting";
            this.btApply.UseVisualStyleBackColor = true;
            this.btApply.Click += new System.EventHandler(this.btApply_Click);
            // 
            // cbWriteIndent
            // 
            this.cbWriteIndent.AutoSize = true;
            this.cbWriteIndent.Location = new System.Drawing.Point(426, 203);
            this.cbWriteIndent.Name = "cbWriteIndent";
            this.cbWriteIndent.Size = new System.Drawing.Size(106, 21);
            this.cbWriteIndent.TabIndex = 9;
            this.cbWriteIndent.Text = "Write indent";
            this.cbWriteIndent.UseVisualStyleBackColor = true;
            // 
            // frmOptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(579, 255);
            this.Controls.Add(this.cbWriteIndent);
            this.Controls.Add(this.btApply);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbLoadTo);
            this.Controls.Add(this.cbLoadFrom);
            this.Controls.Add(this.cbSaveTo);
            this.Controls.Add(this.cbSaveFrom);
            this.Name = "frmOptions";
            this.Text = "frmOptions";
            this.Load += new System.EventHandler(this.frmOptions_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbSaveFrom;
        private System.Windows.Forms.ComboBox cbSaveTo;
        private System.Windows.Forms.ComboBox cbLoadFrom;
        private System.Windows.Forms.ComboBox cbLoadTo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btApply;
        private System.Windows.Forms.CheckBox cbWriteIndent;
    }
}