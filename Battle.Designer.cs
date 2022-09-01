namespace RPG
{
    partial class Battle
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Battle));
            this.Player = new System.Windows.Forms.PictureBox();
            this.Enemy = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Recover = new System.Windows.Forms.Button();
            this.Heal = new System.Windows.Forms.Button();
            this.Active4 = new System.Windows.Forms.Button();
            this.Active2 = new System.Windows.Forms.Button();
            this.Active3 = new System.Windows.Forms.Button();
            this.Active1 = new System.Windows.Forms.Button();
            this.BackButton = new System.Windows.Forms.Button();
            this.ConsumablesButton = new System.Windows.Forms.Button();
            this.SkillsButton = new System.Windows.Forms.Button();
            this.DefenseButton = new System.Windows.Forms.Button();
            this.AttackButton = new System.Windows.Forms.Button();
            this.PlayerHP = new System.Windows.Forms.ProgressBar();
            this.EnemyHP = new System.Windows.Forms.ProgressBar();
            this.PlayerEP = new System.Windows.Forms.ProgressBar();
            this.ToolTip = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.Player)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Enemy)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Player
            // 
            this.Player.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Player.BackColor = System.Drawing.Color.Transparent;
            this.Player.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.Player.Image = ((System.Drawing.Image)(resources.GetObject("Player.Image")));
            this.Player.Location = new System.Drawing.Point(407, 257);
            this.Player.Name = "Player";
            this.Player.Size = new System.Drawing.Size(128, 128);
            this.Player.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Player.TabIndex = 6;
            this.Player.TabStop = false;
            // 
            // Enemy
            // 
            this.Enemy.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Enemy.BackColor = System.Drawing.Color.Transparent;
            this.Enemy.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Enemy.Location = new System.Drawing.Point(901, 257);
            this.Enemy.Name = "Enemy";
            this.Enemy.Size = new System.Drawing.Size(128, 128);
            this.Enemy.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Enemy.TabIndex = 30;
            this.Enemy.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.Controls.Add(this.Recover);
            this.panel1.Controls.Add(this.Heal);
            this.panel1.Controls.Add(this.Active4);
            this.panel1.Controls.Add(this.Active2);
            this.panel1.Controls.Add(this.Active3);
            this.panel1.Controls.Add(this.Active1);
            this.panel1.Controls.Add(this.BackButton);
            this.panel1.Controls.Add(this.ConsumablesButton);
            this.panel1.Controls.Add(this.SkillsButton);
            this.panel1.Controls.Add(this.DefenseButton);
            this.panel1.Controls.Add(this.AttackButton);
            this.panel1.Location = new System.Drawing.Point(12, 576);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1423, 220);
            this.panel1.TabIndex = 31;
            // 
            // Recover
            // 
            this.Recover.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.Recover.BackColor = System.Drawing.Color.Black;
            this.Recover.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Recover.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Recover.ForeColor = System.Drawing.Color.Red;
            this.Recover.Location = new System.Drawing.Point(786, 70);
            this.Recover.Name = "Recover";
            this.Recover.Size = new System.Drawing.Size(231, 66);
            this.Recover.TabIndex = 43;
            this.Recover.TabStop = false;
            this.Recover.Text = "Recover";
            this.Recover.UseVisualStyleBackColor = false;
            this.Recover.Visible = false;
            this.Recover.Click += new System.EventHandler(this.Recover_Click);
            // 
            // Heal
            // 
            this.Heal.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.Heal.BackColor = System.Drawing.Color.Black;
            this.Heal.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Heal.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Heal.ForeColor = System.Drawing.Color.Red;
            this.Heal.Location = new System.Drawing.Point(400, 70);
            this.Heal.Name = "Heal";
            this.Heal.Size = new System.Drawing.Size(231, 66);
            this.Heal.TabIndex = 42;
            this.Heal.TabStop = false;
            this.Heal.Text = "Heal";
            this.Heal.UseVisualStyleBackColor = false;
            this.Heal.Visible = false;
            this.Heal.Click += new System.EventHandler(this.Heal_Click);
            // 
            // Active4
            // 
            this.Active4.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.Active4.BackColor = System.Drawing.Color.Black;
            this.Active4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Active4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Active4.ForeColor = System.Drawing.Color.Red;
            this.Active4.Location = new System.Drawing.Point(1112, 35);
            this.Active4.Name = "Active4";
            this.Active4.Size = new System.Drawing.Size(231, 66);
            this.Active4.TabIndex = 40;
            this.Active4.TabStop = false;
            this.Active4.UseVisualStyleBackColor = false;
            this.Active4.Visible = false;
            this.Active4.Click += new System.EventHandler(this.Active4_Click);
            // 
            // Active2
            // 
            this.Active2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.Active2.BackColor = System.Drawing.Color.Black;
            this.Active2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Active2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Active2.ForeColor = System.Drawing.Color.Red;
            this.Active2.Location = new System.Drawing.Point(420, 35);
            this.Active2.Name = "Active2";
            this.Active2.Size = new System.Drawing.Size(231, 66);
            this.Active2.TabIndex = 39;
            this.Active2.TabStop = false;
            this.Active2.UseVisualStyleBackColor = false;
            this.Active2.Visible = false;
            this.Active2.Click += new System.EventHandler(this.Active2_Click);
            // 
            // Active3
            // 
            this.Active3.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.Active3.BackColor = System.Drawing.Color.Black;
            this.Active3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Active3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Active3.ForeColor = System.Drawing.Color.Red;
            this.Active3.Location = new System.Drawing.Point(767, 35);
            this.Active3.Name = "Active3";
            this.Active3.Size = new System.Drawing.Size(231, 66);
            this.Active3.TabIndex = 36;
            this.Active3.TabStop = false;
            this.Active3.UseVisualStyleBackColor = false;
            this.Active3.Visible = false;
            this.Active3.Click += new System.EventHandler(this.Active3_Click);
            // 
            // Active1
            // 
            this.Active1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.Active1.BackColor = System.Drawing.Color.Black;
            this.Active1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Active1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Active1.ForeColor = System.Drawing.Color.Red;
            this.Active1.Location = new System.Drawing.Point(74, 35);
            this.Active1.Name = "Active1";
            this.Active1.Size = new System.Drawing.Size(231, 66);
            this.Active1.TabIndex = 35;
            this.Active1.TabStop = false;
            this.Active1.UseVisualStyleBackColor = false;
            this.Active1.Visible = false;
            this.Active1.Click += new System.EventHandler(this.Active1_Click);
            // 
            // BackButton
            // 
            this.BackButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.BackButton.BackColor = System.Drawing.Color.Black;
            this.BackButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BackButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BackButton.ForeColor = System.Drawing.Color.Red;
            this.BackButton.Location = new System.Drawing.Point(14, 140);
            this.BackButton.Name = "BackButton";
            this.BackButton.Size = new System.Drawing.Size(149, 66);
            this.BackButton.TabIndex = 34;
            this.BackButton.TabStop = false;
            this.BackButton.Text = "Back";
            this.BackButton.UseVisualStyleBackColor = false;
            this.BackButton.Visible = false;
            this.BackButton.Click += new System.EventHandler(this.BackButton_Click);
            // 
            // ConsumablesButton
            // 
            this.ConsumablesButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.ConsumablesButton.BackColor = System.Drawing.Color.Black;
            this.ConsumablesButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ConsumablesButton.Enabled = false;
            this.ConsumablesButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ConsumablesButton.ForeColor = System.Drawing.Color.Red;
            this.ConsumablesButton.Location = new System.Drawing.Point(1112, 35);
            this.ConsumablesButton.Name = "ConsumablesButton";
            this.ConsumablesButton.Size = new System.Drawing.Size(231, 66);
            this.ConsumablesButton.TabIndex = 4;
            this.ConsumablesButton.TabStop = false;
            this.ConsumablesButton.Text = "Consumables";
            this.ConsumablesButton.UseVisualStyleBackColor = false;
            this.ConsumablesButton.Click += new System.EventHandler(this.ConsumablesButton_Click);
            // 
            // SkillsButton
            // 
            this.SkillsButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.SkillsButton.BackColor = System.Drawing.Color.Black;
            this.SkillsButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SkillsButton.Enabled = false;
            this.SkillsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SkillsButton.ForeColor = System.Drawing.Color.Red;
            this.SkillsButton.Location = new System.Drawing.Point(766, 35);
            this.SkillsButton.Name = "SkillsButton";
            this.SkillsButton.Size = new System.Drawing.Size(231, 66);
            this.SkillsButton.TabIndex = 3;
            this.SkillsButton.TabStop = false;
            this.SkillsButton.Text = "Skills";
            this.SkillsButton.UseVisualStyleBackColor = false;
            this.SkillsButton.Click += new System.EventHandler(this.SkillsButton_Click);
            // 
            // DefenseButton
            // 
            this.DefenseButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.DefenseButton.BackColor = System.Drawing.Color.Black;
            this.DefenseButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DefenseButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DefenseButton.ForeColor = System.Drawing.Color.Red;
            this.DefenseButton.Location = new System.Drawing.Point(420, 35);
            this.DefenseButton.Name = "DefenseButton";
            this.DefenseButton.Size = new System.Drawing.Size(231, 66);
            this.DefenseButton.TabIndex = 2;
            this.DefenseButton.TabStop = false;
            this.DefenseButton.Text = "Defense";
            this.DefenseButton.UseVisualStyleBackColor = false;
            this.DefenseButton.Click += new System.EventHandler(this.DefenseButton_Click);
            // 
            // AttackButton
            // 
            this.AttackButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.AttackButton.BackColor = System.Drawing.Color.Black;
            this.AttackButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.AttackButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AttackButton.ForeColor = System.Drawing.Color.Red;
            this.AttackButton.Location = new System.Drawing.Point(74, 35);
            this.AttackButton.Name = "AttackButton";
            this.AttackButton.Size = new System.Drawing.Size(231, 66);
            this.AttackButton.TabIndex = 1;
            this.AttackButton.TabStop = false;
            this.AttackButton.Text = "Attack";
            this.AttackButton.UseVisualStyleBackColor = false;
            this.AttackButton.Click += new System.EventHandler(this.AttackButton_Click);
            // 
            // PlayerHP
            // 
            this.PlayerHP.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.PlayerHP.Location = new System.Drawing.Point(422, 447);
            this.PlayerHP.Maximum = 0;
            this.PlayerHP.Name = "PlayerHP";
            this.PlayerHP.Size = new System.Drawing.Size(100, 23);
            this.PlayerHP.TabIndex = 32;
            this.PlayerHP.MouseEnter += new System.EventHandler(this.Bar_MouseEnter);
            this.PlayerHP.MouseLeave += new System.EventHandler(this.Bar_MouseLeave);
            // 
            // EnemyHP
            // 
            this.EnemyHP.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.EnemyHP.Location = new System.Drawing.Point(915, 447);
            this.EnemyHP.Maximum = 0;
            this.EnemyHP.Name = "EnemyHP";
            this.EnemyHP.Size = new System.Drawing.Size(100, 23);
            this.EnemyHP.TabIndex = 33;
            this.EnemyHP.MouseEnter += new System.EventHandler(this.Bar_MouseEnter);
            this.EnemyHP.MouseLeave += new System.EventHandler(this.Bar_MouseLeave);
            // 
            // PlayerEP
            // 
            this.PlayerEP.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.PlayerEP.Location = new System.Drawing.Point(422, 477);
            this.PlayerEP.Maximum = 0;
            this.PlayerEP.Name = "PlayerEP";
            this.PlayerEP.Size = new System.Drawing.Size(100, 14);
            this.PlayerEP.TabIndex = 34;
            this.PlayerEP.MouseEnter += new System.EventHandler(this.Bar_MouseEnter);
            this.PlayerEP.MouseLeave += new System.EventHandler(this.Bar_MouseLeave);
            // 
            // Battle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1447, 808);
            this.ControlBox = false;
            this.Controls.Add(this.PlayerEP);
            this.Controls.Add(this.EnemyHP);
            this.Controls.Add(this.PlayerHP);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.Enemy);
            this.Controls.Add(this.Player);
            this.DoubleBuffered = true;
            this.KeyPreview = true;
            this.Name = "Battle";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Typical Adventure";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Battle_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Battle_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.Player)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Enemy)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox Player;
        private System.Windows.Forms.PictureBox Enemy;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ProgressBar PlayerHP;
        private System.Windows.Forms.ProgressBar EnemyHP;
        private System.Windows.Forms.Button BackButton;
        private System.Windows.Forms.Button Recover;
        private System.Windows.Forms.Button Heal;
        private System.Windows.Forms.Button ConsumablesButton;
        private System.Windows.Forms.Button SkillsButton;
        private System.Windows.Forms.Button DefenseButton;
        private System.Windows.Forms.Button AttackButton;
        private System.Windows.Forms.Button Active4;
        private System.Windows.Forms.Button Active2;
        private System.Windows.Forms.Button Active3;
        private System.Windows.Forms.Button Active1;
        private System.Windows.Forms.ProgressBar PlayerEP;
        private System.Windows.Forms.ToolTip ToolTip;
    }
}