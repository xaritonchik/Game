namespace RPG
{
    partial class Options
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
            this.ResetButton = new System.Windows.Forms.Button();
            this.MainMenuButton = new System.Windows.Forms.Button();
            this.ResetSave1 = new System.Windows.Forms.Button();
            this.ResetSave2 = new System.Windows.Forms.Button();
            this.ResetSave3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ResetButton
            // 
            this.ResetButton.BackColor = System.Drawing.Color.Black;
            this.ResetButton.Enabled = false;
            this.ResetButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ResetButton.ForeColor = System.Drawing.Color.Red;
            this.ResetButton.Location = new System.Drawing.Point(608, 371);
            this.ResetButton.Name = "ResetButton";
            this.ResetButton.Size = new System.Drawing.Size(231, 66);
            this.ResetButton.TabIndex = 8;
            this.ResetButton.TabStop = false;
            this.ResetButton.Text = "Reset Save";
            this.ResetButton.UseVisualStyleBackColor = false;
            this.ResetButton.Click += new System.EventHandler(this.ResetButton_Click);
            // 
            // MainMenuButton
            // 
            this.MainMenuButton.BackColor = System.Drawing.Color.Black;
            this.MainMenuButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainMenuButton.ForeColor = System.Drawing.Color.Red;
            this.MainMenuButton.Location = new System.Drawing.Point(12, 730);
            this.MainMenuButton.Name = "MainMenuButton";
            this.MainMenuButton.Size = new System.Drawing.Size(231, 66);
            this.MainMenuButton.TabIndex = 9;
            this.MainMenuButton.TabStop = false;
            this.MainMenuButton.Text = "Main Menu";
            this.MainMenuButton.UseVisualStyleBackColor = false;
            this.MainMenuButton.Click += new System.EventHandler(this.MainMenuButton_Click);
            // 
            // ResetSave1
            // 
            this.ResetSave1.BackColor = System.Drawing.Color.Black;
            this.ResetSave1.Enabled = false;
            this.ResetSave1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ResetSave1.ForeColor = System.Drawing.Color.Red;
            this.ResetSave1.Location = new System.Drawing.Point(432, 449);
            this.ResetSave1.Name = "ResetSave1";
            this.ResetSave1.Size = new System.Drawing.Size(170, 50);
            this.ResetSave1.TabIndex = 10;
            this.ResetSave1.TabStop = false;
            this.ResetSave1.Text = "Save 1";
            this.ResetSave1.UseVisualStyleBackColor = false;
            this.ResetSave1.Visible = false;
            this.ResetSave1.Click += new System.EventHandler(this.ResetSave1_Click);
            // 
            // ResetSave2
            // 
            this.ResetSave2.BackColor = System.Drawing.Color.Black;
            this.ResetSave2.Enabled = false;
            this.ResetSave2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ResetSave2.ForeColor = System.Drawing.Color.Red;
            this.ResetSave2.Location = new System.Drawing.Point(640, 449);
            this.ResetSave2.Name = "ResetSave2";
            this.ResetSave2.Size = new System.Drawing.Size(170, 50);
            this.ResetSave2.TabIndex = 11;
            this.ResetSave2.TabStop = false;
            this.ResetSave2.Text = "Save 2";
            this.ResetSave2.UseVisualStyleBackColor = false;
            this.ResetSave2.Visible = false;
            this.ResetSave2.Click += new System.EventHandler(this.ResetSave2_Click);
            // 
            // ResetSave3
            // 
            this.ResetSave3.BackColor = System.Drawing.Color.Black;
            this.ResetSave3.Enabled = false;
            this.ResetSave3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ResetSave3.ForeColor = System.Drawing.Color.Red;
            this.ResetSave3.Location = new System.Drawing.Point(845, 449);
            this.ResetSave3.Name = "ResetSave3";
            this.ResetSave3.Size = new System.Drawing.Size(170, 50);
            this.ResetSave3.TabIndex = 12;
            this.ResetSave3.TabStop = false;
            this.ResetSave3.Text = "Save 3";
            this.ResetSave3.UseVisualStyleBackColor = false;
            this.ResetSave3.Visible = false;
            this.ResetSave3.Click += new System.EventHandler(this.ResetSave3_Click);
            // 
            // Options
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1447, 808);
            this.ControlBox = false;
            this.Controls.Add(this.ResetSave3);
            this.Controls.Add(this.ResetSave2);
            this.Controls.Add(this.ResetSave1);
            this.Controls.Add(this.MainMenuButton);
            this.Controls.Add(this.ResetButton);
            this.KeyPreview = true;
            this.Name = "Options";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Typical Adventure";
            this.Load += new System.EventHandler(this.Options_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Options_KeyDown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button ResetButton;
        private System.Windows.Forms.Button MainMenuButton;
        private System.Windows.Forms.Button ResetSave1;
        private System.Windows.Forms.Button ResetSave2;
        private System.Windows.Forms.Button ResetSave3;
    }
}