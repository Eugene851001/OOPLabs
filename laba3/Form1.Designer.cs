namespace OOPLaba3
{
    partial class frmMain
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.btSerialize = new System.Windows.Forms.Button();
            this.btDeserialize = new System.Windows.Forms.Button();
            this.btEdit = new System.Windows.Forms.Button();
            this.lbStars = new System.Windows.Forms.ListBox();
            this.btDelete = new System.Windows.Forms.Button();
            this.btAddStar = new System.Windows.Forms.Button();
            this.btPlanet = new System.Windows.Forms.Button();
            this.OpenFile = new System.Windows.Forms.OpenFileDialog();
            this.SaveFile = new System.Windows.Forms.SaveFileDialog();
            this.btAddSatellite = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btSerialize
            // 
            this.btSerialize.Location = new System.Drawing.Point(655, 25);
            this.btSerialize.Name = "btSerialize";
            this.btSerialize.Size = new System.Drawing.Size(94, 23);
            this.btSerialize.TabIndex = 1;
            this.btSerialize.Text = "Serialize";
            this.btSerialize.UseVisualStyleBackColor = true;
            this.btSerialize.Click += new System.EventHandler(this.btSerialize_Click);
            // 
            // btDeserialize
            // 
            this.btDeserialize.Location = new System.Drawing.Point(655, 80);
            this.btDeserialize.Name = "btDeserialize";
            this.btDeserialize.Size = new System.Drawing.Size(94, 23);
            this.btDeserialize.TabIndex = 2;
            this.btDeserialize.Text = "Deserialize";
            this.btDeserialize.UseVisualStyleBackColor = true;
            this.btDeserialize.Click += new System.EventHandler(this.btDeserialize_Click);
            // 
            // btEdit
            // 
            this.btEdit.Location = new System.Drawing.Point(36, 279);
            this.btEdit.Name = "btEdit";
            this.btEdit.Size = new System.Drawing.Size(75, 23);
            this.btEdit.TabIndex = 3;
            this.btEdit.Text = "Edit";
            this.btEdit.UseVisualStyleBackColor = true;
            this.btEdit.Click += new System.EventHandler(this.btEdit_Click);
            // 
            // lbStars
            // 
            this.lbStars.FormattingEnabled = true;
            this.lbStars.ItemHeight = 16;
            this.lbStars.Location = new System.Drawing.Point(36, 25);
            this.lbStars.Name = "lbStars";
            this.lbStars.Size = new System.Drawing.Size(259, 228);
            this.lbStars.TabIndex = 4;
            this.lbStars.SelectedIndexChanged += new System.EventHandler(this.lbStars_SelectedIndexChanged);
            // 
            // btDelete
            // 
            this.btDelete.Location = new System.Drawing.Point(179, 279);
            this.btDelete.Name = "btDelete";
            this.btDelete.Size = new System.Drawing.Size(75, 23);
            this.btDelete.TabIndex = 5;
            this.btDelete.Text = "Delete";
            this.btDelete.UseVisualStyleBackColor = true;
            this.btDelete.Click += new System.EventHandler(this.btDelete_Click);
            // 
            // btAddStar
            // 
            this.btAddStar.Location = new System.Drawing.Point(328, 25);
            this.btAddStar.Name = "btAddStar";
            this.btAddStar.Size = new System.Drawing.Size(75, 23);
            this.btAddStar.TabIndex = 6;
            this.btAddStar.Text = "Star";
            this.btAddStar.UseVisualStyleBackColor = true;
            this.btAddStar.Click += new System.EventHandler(this.btAddStar_Click);
            // 
            // btPlanet
            // 
            this.btPlanet.Location = new System.Drawing.Point(328, 65);
            this.btPlanet.Name = "btPlanet";
            this.btPlanet.Size = new System.Drawing.Size(75, 28);
            this.btPlanet.TabIndex = 7;
            this.btPlanet.Text = "Planet";
            this.btPlanet.UseVisualStyleBackColor = true;
            this.btPlanet.Click += new System.EventHandler(this.btPlanet_Click);
            // 
            // OpenFile
            // 
            this.OpenFile.FileName = "file.txt";
            // 
            // btAddSatellite
            // 
            this.btAddSatellite.Location = new System.Drawing.Point(328, 109);
            this.btAddSatellite.Name = "btAddSatellite";
            this.btAddSatellite.Size = new System.Drawing.Size(75, 25);
            this.btAddSatellite.TabIndex = 8;
            this.btAddSatellite.Text = "Satellite";
            this.btAddSatellite.UseVisualStyleBackColor = true;
            this.btAddSatellite.Click += new System.EventHandler(this.btAddSatellite_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btAddSatellite);
            this.Controls.Add(this.btPlanet);
            this.Controls.Add(this.btAddStar);
            this.Controls.Add(this.btDelete);
            this.Controls.Add(this.lbStars);
            this.Controls.Add(this.btEdit);
            this.Controls.Add(this.btDeserialize);
            this.Controls.Add(this.btSerialize);
            this.Name = "frmMain";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btSerialize;
        private System.Windows.Forms.Button btDeserialize;
        private System.Windows.Forms.Button btEdit;
        private System.Windows.Forms.ListBox lbStars;
        private System.Windows.Forms.Button btDelete;
        private System.Windows.Forms.Button btAddStar;
        private System.Windows.Forms.Button btPlanet;
        private System.Windows.Forms.OpenFileDialog OpenFile;
        private System.Windows.Forms.SaveFileDialog SaveFile;
        private System.Windows.Forms.Button btAddSatellite;
    }
}

