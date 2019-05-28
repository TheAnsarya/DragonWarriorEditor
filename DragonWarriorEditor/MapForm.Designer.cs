namespace DragonWarriorEditor {
    partial class MapForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MapForm));
			this.TilePaletteArea = new System.Windows.Forms.GroupBox();
			this.buttonWriteROM = new System.Windows.Forms.Button();
			this.comboBoxTileTypes = new System.Windows.Forms.ComboBox();
			this.MapArea = new System.Windows.Forms.GroupBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// TilePaletteArea
			// 
			this.TilePaletteArea.Location = new System.Drawing.Point(925, 16);
			this.TilePaletteArea.Name = "TilePaletteArea";
			this.TilePaletteArea.Size = new System.Drawing.Size(45, 617);
			this.TilePaletteArea.TabIndex = 28;
			this.TilePaletteArea.TabStop = false;
			// 
			// buttonWriteROM
			// 
			this.buttonWriteROM.Location = new System.Drawing.Point(825, 14);
			this.buttonWriteROM.Name = "buttonWriteROM";
			this.buttonWriteROM.Size = new System.Drawing.Size(75, 23);
			this.buttonWriteROM.TabIndex = 1;
			this.buttonWriteROM.Text = "&Write ROM";
			this.buttonWriteROM.UseVisualStyleBackColor = true;
			this.buttonWriteROM.Click += new System.EventHandler(this.buttonWriteROM_Click);
			// 
			// comboBoxTileTypes
			// 
			this.comboBoxTileTypes.FormattingEnabled = true;
			this.comboBoxTileTypes.Location = new System.Drawing.Point(698, 15);
			this.comboBoxTileTypes.Name = "comboBoxTileTypes";
			this.comboBoxTileTypes.Size = new System.Drawing.Size(121, 21);
			this.comboBoxTileTypes.TabIndex = 0;
			// 
			// MapArea
			// 
			this.MapArea.Location = new System.Drawing.Point(11, 65);
			this.MapArea.Name = "MapArea";
			this.MapArea.Size = new System.Drawing.Size(908, 924);
			this.MapArea.TabIndex = 27;
			this.MapArea.TabStop = false;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.buttonWriteROM);
			this.groupBox1.Controls.Add(this.comboBoxTileTypes);
			this.groupBox1.Location = new System.Drawing.Point(11, 16);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(908, 43);
			this.groupBox1.TabIndex = 26;
			this.groupBox1.TabStop = false;
			// 
			// MapForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(980, 1004);
			this.Controls.Add(this.TilePaletteArea);
			this.Controls.Add(this.MapArea);
			this.Controls.Add(this.groupBox1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.Name = "MapForm";
			this.Text = "Brecconary";
			this.Shown += new System.EventHandler(this.LoadMap);
			this.groupBox1.ResumeLayout(false);
			this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox TilePaletteArea;
        private System.Windows.Forms.Button buttonWriteROM;
        private System.Windows.Forms.ComboBox comboBoxTileTypes;
        private System.Windows.Forms.GroupBox MapArea;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}