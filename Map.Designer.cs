namespace RPG
{
    partial class Map
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
            this.StatusButton = new System.Windows.Forms.Button();
            this.SystemButton = new System.Windows.Forms.Button();
            this.MapButton = new System.Windows.Forms.Button();
            this.QuestsButton = new System.Windows.Forms.Button();
            this.SkillsButton = new System.Windows.Forms.Button();
            this.InventoryButton = new System.Windows.Forms.Button();
            this.InteractiveMap = new System.Windows.Forms.PictureBox();
            this.Location1Picture = new System.Windows.Forms.PictureBox();
            this.Location2Picture = new System.Windows.Forms.PictureBox();
            this.Location3Picture = new System.Windows.Forms.PictureBox();
            this.Location1Name = new System.Windows.Forms.Label();
            this.Location2Name = new System.Windows.Forms.Label();
            this.Location3Name = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.InteractiveMap)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Location1Picture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Location2Picture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Location3Picture)).BeginInit();
            this.SuspendLayout();
            // 
            // StatusButton
            // 
            this.StatusButton.BackColor = System.Drawing.Color.Black;
            this.StatusButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StatusButton.ForeColor = System.Drawing.Color.Red;
            this.StatusButton.Location = new System.Drawing.Point(12, 12);
            this.StatusButton.Name = "StatusButton";
            this.StatusButton.Size = new System.Drawing.Size(231, 66);
            this.StatusButton.TabIndex = 12;
            this.StatusButton.TabStop = false;
            this.StatusButton.Text = "Status";
            this.StatusButton.UseVisualStyleBackColor = false;
            this.StatusButton.Click += new System.EventHandler(this.StatusButton_Click);
            // 
            // SystemButton
            // 
            this.SystemButton.BackColor = System.Drawing.Color.Black;
            this.SystemButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SystemButton.ForeColor = System.Drawing.Color.Red;
            this.SystemButton.Location = new System.Drawing.Point(1197, 12);
            this.SystemButton.Name = "SystemButton";
            this.SystemButton.Size = new System.Drawing.Size(234, 66);
            this.SystemButton.TabIndex = 11;
            this.SystemButton.TabStop = false;
            this.SystemButton.Text = "System";
            this.SystemButton.UseVisualStyleBackColor = false;
            this.SystemButton.Click += new System.EventHandler(this.SystemButton_Click);
            // 
            // MapButton
            // 
            this.MapButton.BackColor = System.Drawing.Color.Black;
            this.MapButton.Enabled = false;
            this.MapButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MapButton.ForeColor = System.Drawing.Color.Red;
            this.MapButton.Location = new System.Drawing.Point(960, 12);
            this.MapButton.Name = "MapButton";
            this.MapButton.Size = new System.Drawing.Size(231, 66);
            this.MapButton.TabIndex = 10;
            this.MapButton.TabStop = false;
            this.MapButton.Text = "Map";
            this.MapButton.UseVisualStyleBackColor = false;
            // 
            // QuestsButton
            // 
            this.QuestsButton.BackColor = System.Drawing.Color.Black;
            this.QuestsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.QuestsButton.ForeColor = System.Drawing.Color.Red;
            this.QuestsButton.Location = new System.Drawing.Point(723, 12);
            this.QuestsButton.Name = "QuestsButton";
            this.QuestsButton.Size = new System.Drawing.Size(231, 66);
            this.QuestsButton.TabIndex = 9;
            this.QuestsButton.TabStop = false;
            this.QuestsButton.Text = "Quests";
            this.QuestsButton.UseVisualStyleBackColor = false;
            this.QuestsButton.Click += new System.EventHandler(this.QuestsButton_Click);
            // 
            // SkillsButton
            // 
            this.SkillsButton.BackColor = System.Drawing.Color.Black;
            this.SkillsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SkillsButton.ForeColor = System.Drawing.Color.Red;
            this.SkillsButton.Location = new System.Drawing.Point(486, 12);
            this.SkillsButton.Name = "SkillsButton";
            this.SkillsButton.Size = new System.Drawing.Size(231, 66);
            this.SkillsButton.TabIndex = 8;
            this.SkillsButton.TabStop = false;
            this.SkillsButton.Text = "Skills";
            this.SkillsButton.UseVisualStyleBackColor = false;
            this.SkillsButton.Click += new System.EventHandler(this.SkillsButton_Click);
            // 
            // InventoryButton
            // 
            this.InventoryButton.BackColor = System.Drawing.Color.Black;
            this.InventoryButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InventoryButton.ForeColor = System.Drawing.Color.Red;
            this.InventoryButton.Location = new System.Drawing.Point(249, 12);
            this.InventoryButton.Name = "InventoryButton";
            this.InventoryButton.Size = new System.Drawing.Size(231, 66);
            this.InventoryButton.TabIndex = 7;
            this.InventoryButton.TabStop = false;
            this.InventoryButton.Text = "Inventory";
            this.InventoryButton.UseVisualStyleBackColor = false;
            this.InventoryButton.Click += new System.EventHandler(this.InventoryButton_Click);
            // 
            // InteractiveMap
            // 
            this.InteractiveMap.BackColor = System.Drawing.Color.DimGray;
            this.InteractiveMap.Cursor = System.Windows.Forms.Cursors.Default;
            this.InteractiveMap.Location = new System.Drawing.Point(12, 84);
            this.InteractiveMap.Name = "InteractiveMap";
            this.InteractiveMap.Size = new System.Drawing.Size(1419, 712);
            this.InteractiveMap.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.InteractiveMap.TabIndex = 14;
            this.InteractiveMap.TabStop = false;
            // 
            // Location1Picture
            // 
            this.Location1Picture.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.Location1Picture.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Location1Picture.Location = new System.Drawing.Point(188, 229);
            this.Location1Picture.Name = "Location1Picture";
            this.Location1Picture.Size = new System.Drawing.Size(128, 128);
            this.Location1Picture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Location1Picture.TabIndex = 15;
            this.Location1Picture.TabStop = false;
            // 
            // Location2Picture
            // 
            this.Location2Picture.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.Location2Picture.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Location2Picture.Location = new System.Drawing.Point(589, 540);
            this.Location2Picture.Name = "Location2Picture";
            this.Location2Picture.Size = new System.Drawing.Size(128, 128);
            this.Location2Picture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Location2Picture.TabIndex = 16;
            this.Location2Picture.TabStop = false;
            // 
            // Location3Picture
            // 
            this.Location3Picture.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.Location3Picture.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Location3Picture.Location = new System.Drawing.Point(1021, 328);
            this.Location3Picture.Name = "Location3Picture";
            this.Location3Picture.Size = new System.Drawing.Size(128, 128);
            this.Location3Picture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Location3Picture.TabIndex = 17;
            this.Location3Picture.TabStop = false;
            // 
            // Location1Name
            // 
            this.Location1Name.AutoSize = true;
            this.Location1Name.BackColor = System.Drawing.Color.Black;
            this.Location1Name.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Location1Name.ForeColor = System.Drawing.Color.Red;
            this.Location1Name.Location = new System.Drawing.Point(174, 360);
            this.Location1Name.Name = "Location1Name";
            this.Location1Name.Size = new System.Drawing.Size(155, 25);
            this.Location1Name.TabIndex = 26;
            this.Location1Name.Text = "Forgotten Forest";
            // 
            // Location2Name
            // 
            this.Location2Name.AutoSize = true;
            this.Location2Name.BackColor = System.Drawing.Color.Black;
            this.Location2Name.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Location2Name.ForeColor = System.Drawing.Color.Red;
            this.Location2Name.Location = new System.Drawing.Point(600, 671);
            this.Location2Name.Name = "Location2Name";
            this.Location2Name.Size = new System.Drawing.Size(103, 25);
            this.Location2Name.TabIndex = 27;
            this.Location2Name.Text = "Graveyard";
            // 
            // Location3Name
            // 
            this.Location3Name.AutoSize = true;
            this.Location3Name.BackColor = System.Drawing.Color.Black;
            this.Location3Name.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Location3Name.ForeColor = System.Drawing.Color.Red;
            this.Location3Name.Location = new System.Drawing.Point(1017, 459);
            this.Location3Name.Name = "Location3Name";
            this.Location3Name.Size = new System.Drawing.Size(137, 25);
            this.Location3Name.TabIndex = 28;
            this.Location3Name.Text = "Cursed Beach";
            // 
            // Map
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1447, 808);
            this.ControlBox = false;
            this.Controls.Add(this.Location3Name);
            this.Controls.Add(this.Location2Name);
            this.Controls.Add(this.Location1Name);
            this.Controls.Add(this.Location3Picture);
            this.Controls.Add(this.Location2Picture);
            this.Controls.Add(this.Location1Picture);
            this.Controls.Add(this.InteractiveMap);
            this.Controls.Add(this.StatusButton);
            this.Controls.Add(this.SystemButton);
            this.Controls.Add(this.MapButton);
            this.Controls.Add(this.InventoryButton);
            this.Controls.Add(this.QuestsButton);
            this.Controls.Add(this.SkillsButton);
            this.KeyPreview = true;
            this.Name = "Map";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Typical Adventure";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Map_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.InteractiveMap)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Location1Picture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Location2Picture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Location3Picture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button StatusButton;
        private System.Windows.Forms.Button SystemButton;
        private System.Windows.Forms.Button MapButton;
        private System.Windows.Forms.Button QuestsButton;
        private System.Windows.Forms.Button SkillsButton;
        private System.Windows.Forms.Button InventoryButton;
        private System.Windows.Forms.PictureBox InteractiveMap;
        private System.Windows.Forms.PictureBox Location1Picture;
        private System.Windows.Forms.PictureBox Location2Picture;
        private System.Windows.Forms.PictureBox Location3Picture;
        private System.Windows.Forms.Label Location1Name;
        private System.Windows.Forms.Label Location2Name;
        private System.Windows.Forms.Label Location3Name;
    }
}