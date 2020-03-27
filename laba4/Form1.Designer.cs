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
            this.btEdit = new System.Windows.Forms.Button();
            this.lbStars = new System.Windows.Forms.ListBox();
            this.btDelete = new System.Windows.Forms.Button();
            this.btAddStar = new System.Windows.Forms.Button();
            this.btPlanet = new System.Windows.Forms.Button();
            this.OpenFile = new System.Windows.Forms.OpenFileDialog();
            this.SaveFile = new System.Windows.Forms.SaveFileDialog();
            this.btAddSatellite = new System.Windows.Forms.Button();
            this.btBlackHole = new System.Windows.Forms.Button();
            this.btVariableStar = new System.Windows.Forms.Button();
            this.btChangeFile = new System.Windows.Forms.Button();
            this.tbFilePath = new System.Windows.Forms.TextBox();
            this.btLoadAll = new System.Windows.Forms.Button();
            this.btLoadPlugin = new System.Windows.Forms.Button();
            this.OpenPluginFile = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
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
            this.OpenFile.FileOk += new System.ComponentModel.CancelEventHandler(this.OpenFile_FileOk);
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
            // btBlackHole
            // 
            this.btBlackHole.Location = new System.Drawing.Point(435, 25);
            this.btBlackHole.Name = "btBlackHole";
            this.btBlackHole.Size = new System.Drawing.Size(79, 23);
            this.btBlackHole.TabIndex = 9;
            this.btBlackHole.Text = "BlackHole";
            this.btBlackHole.UseVisualStyleBackColor = true;
            this.btBlackHole.Click += new System.EventHandler(this.btBlackHole_Click);
            // 
            // btVariableStar
            // 
            this.btVariableStar.Location = new System.Drawing.Point(435, 49);
            this.btVariableStar.Name = "btVariableStar";
            this.btVariableStar.Size = new System.Drawing.Size(79, 44);
            this.btVariableStar.TabIndex = 10;
            this.btVariableStar.Text = "Variable star";
            this.btVariableStar.UseVisualStyleBackColor = true;
            this.btVariableStar.Click += new System.EventHandler(this.btVariableStar_Click);
            // 
            // btChangeFile
            // 
            this.btChangeFile.Location = new System.Drawing.Point(435, 352);
            this.btChangeFile.Name = "btChangeFile";
            this.btChangeFile.Size = new System.Drawing.Size(114, 23);
            this.btChangeFile.TabIndex = 11;
            this.btChangeFile.Text = "Choose file";
            this.btChangeFile.UseVisualStyleBackColor = true;
            this.btChangeFile.Click += new System.EventHandler(this.btChangeFile_Click);
            // 
            // tbFilePath
            // 
            this.tbFilePath.Location = new System.Drawing.Point(435, 311);
            this.tbFilePath.Name = "tbFilePath";
            this.tbFilePath.Size = new System.Drawing.Size(114, 22);
            this.tbFilePath.TabIndex = 12;
            // 
            // btLoadAll
            // 
            this.btLoadAll.Location = new System.Drawing.Point(435, 381);
            this.btLoadAll.Name = "btLoadAll";
            this.btLoadAll.Size = new System.Drawing.Size(110, 23);
            this.btLoadAll.TabIndex = 13;
            this.btLoadAll.Text = "Load";
            this.btLoadAll.UseVisualStyleBackColor = true;
            this.btLoadAll.Click += new System.EventHandler(this.btLoadAll_Click);
            // 
            // btLoadPlugin
            // 
            this.btLoadPlugin.Location = new System.Drawing.Point(435, 415);
            this.btLoadPlugin.Name = "btLoadPlugin";
            this.btLoadPlugin.Size = new System.Drawing.Size(110, 23);
            this.btLoadPlugin.TabIndex = 14;
            this.btLoadPlugin.Text = "Load Plugin";
            this.btLoadPlugin.UseVisualStyleBackColor = true;
            this.btLoadPlugin.Click += new System.EventHandler(this.btLoadPlugin_Click);
            // 
            // OpenPluginFile
            // 
            this.OpenPluginFile.FileName = "openFileDialog1";
            this.OpenPluginFile.Filter = "Dll файлы (*.dll)|*.dll";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(583, 450);
            this.Controls.Add(this.btLoadPlugin);
            this.Controls.Add(this.btLoadAll);
            this.Controls.Add(this.tbFilePath);
            this.Controls.Add(this.btChangeFile);
            this.Controls.Add(this.btVariableStar);
            this.Controls.Add(this.btBlackHole);
            this.Controls.Add(this.btAddSatellite);
            this.Controls.Add(this.btPlanet);
            this.Controls.Add(this.btAddStar);
            this.Controls.Add(this.btDelete);
            this.Controls.Add(this.lbStars);
            this.Controls.Add(this.btEdit);
            this.Name = "frmMain";
            this.Text = "Astronomical Editor";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btEdit;
        private System.Windows.Forms.ListBox lbStars;
        private System.Windows.Forms.Button btDelete;
        private System.Windows.Forms.Button btAddStar;
        private System.Windows.Forms.Button btPlanet;
        private System.Windows.Forms.OpenFileDialog OpenFile;
        private System.Windows.Forms.SaveFileDialog SaveFile;
        private System.Windows.Forms.Button btAddSatellite;
        private System.Windows.Forms.Button btBlackHole;
        private System.Windows.Forms.Button btVariableStar;
        private System.Windows.Forms.Button btChangeFile;
        private System.Windows.Forms.TextBox tbFilePath;
        private System.Windows.Forms.Button btLoadAll;
        private System.Windows.Forms.Button btLoadPlugin;
        private System.Windows.Forms.OpenFileDialog OpenPluginFile;
    }
}

