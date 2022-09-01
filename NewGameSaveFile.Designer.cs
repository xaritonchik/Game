namespace RPG
{
    partial class NewGameSaveFile
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
            this.BackToMenuButton = new System.Windows.Forms.Button();
            this.NewSaveSlot3 = new System.Windows.Forms.Button();
            this.NewSaveSlot2 = new System.Windows.Forms.Button();
            this.NewSaveSlot1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BackToMenuButton
            // 
            this.BackToMenuButton.BackColor = System.Drawing.Color.Black;
            this.BackToMenuButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BackToMenuButton.ForeColor = System.Drawing.Color.Red;
            this.BackToMenuButton.Location = new System.Drawing.Point(12, 713);
            this.BackToMenuButton.Name = "BackToMenuButton";
            this.BackToMenuButton.Size = new System.Drawing.Size(231, 66);
            this.BackToMenuButton.TabIndex = 0;
            this.BackToMenuButton.TabStop = false;
            this.BackToMenuButton.Text = "Back to Menu";
            this.BackToMenuButton.UseVisualStyleBackColor = false;
            this.BackToMenuButton.Click += new System.EventHandler(this.BackToMenuButton_Click);
            // 
            // NewSaveSlot3
            // 
            this.NewSaveSlot3.BackColor = System.Drawing.Color.Black;
            this.NewSaveSlot3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NewSaveSlot3.ForeColor = System.Drawing.Color.Red;
            this.NewSaveSlot3.Location = new System.Drawing.Point(991, 84);
            this.NewSaveSlot3.Name = "NewSaveSlot3";
            this.NewSaveSlot3.Size = new System.Drawing.Size(377, 529);
            this.NewSaveSlot3.TabIndex = 7;
            this.NewSaveSlot3.TabStop = false;
            this.NewSaveSlot3.Text = "Save Slot 3";
            this.NewSaveSlot3.UseVisualStyleBackColor = false;
            this.NewSaveSlot3.Click += new System.EventHandler(this.NewSaveSlot3_Click);
            // 
            // NewSaveSlot2
            // 
            this.NewSaveSlot2.BackColor = System.Drawing.Color.Black;
            this.NewSaveSlot2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NewSaveSlot2.ForeColor = System.Drawing.Color.Red;
            this.NewSaveSlot2.Location = new System.Drawing.Point(532, 84);
            this.NewSaveSlot2.Name = "NewSaveSlot2";
            this.NewSaveSlot2.Size = new System.Drawing.Size(377, 529);
            this.NewSaveSlot2.TabIndex = 6;
            this.NewSaveSlot2.TabStop = false;
            this.NewSaveSlot2.Text = "Save Slot 2";
            this.NewSaveSlot2.UseVisualStyleBackColor = false;
            this.NewSaveSlot2.Click += new System.EventHandler(this.NewSaveSlot2_Click);
            // 
            // NewSaveSlot1
            // 
            this.NewSaveSlot1.BackColor = System.Drawing.Color.Black;
            this.NewSaveSlot1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NewSaveSlot1.ForeColor = System.Drawing.Color.Red;
            this.NewSaveSlot1.Location = new System.Drawing.Point(76, 84);
            this.NewSaveSlot1.Name = "NewSaveSlot1";
            this.NewSaveSlot1.Size = new System.Drawing.Size(377, 529);
            this.NewSaveSlot1.TabIndex = 5;
            this.NewSaveSlot1.TabStop = false;
            this.NewSaveSlot1.Text = "Save Slot 1";
            this.NewSaveSlot1.UseVisualStyleBackColor = false;
            this.NewSaveSlot1.Click += new System.EventHandler(this.NewSaveSlot1_Click);
            // 
            // NewGameSaveFile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1445, 789);
            this.ControlBox = false;
            this.Controls.Add(this.NewSaveSlot3);
            this.Controls.Add(this.NewSaveSlot2);
            this.Controls.Add(this.NewSaveSlot1);
            this.Controls.Add(this.BackToMenuButton);
            this.KeyPreview = true;
            this.Name = "NewGameSaveFile";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Typical Adventure";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.NewGame_KeyDown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BackToMenuButton;
        private System.Windows.Forms.Button NewSaveSlot3;
        private System.Windows.Forms.Button NewSaveSlot2;
        private System.Windows.Forms.Button NewSaveSlot1;
    }
}