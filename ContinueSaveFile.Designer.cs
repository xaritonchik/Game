namespace RPG
{
    partial class ContinueSaveFile
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
            this.ContinueSaveSlot1 = new System.Windows.Forms.Button();
            this.ContinueSaveSlot2 = new System.Windows.Forms.Button();
            this.ContinueSaveSlot3 = new System.Windows.Forms.Button();
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
            this.BackToMenuButton.TabIndex = 1;
            this.BackToMenuButton.TabStop = false;
            this.BackToMenuButton.Text = "Back to Menu";
            this.BackToMenuButton.UseVisualStyleBackColor = false;
            this.BackToMenuButton.Click += new System.EventHandler(this.BackToMenuButton_Click);
            // 
            // ContinueSaveSlot1
            // 
            this.ContinueSaveSlot1.BackColor = System.Drawing.Color.Black;
            this.ContinueSaveSlot1.Enabled = false;
            this.ContinueSaveSlot1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ContinueSaveSlot1.ForeColor = System.Drawing.Color.Red;
            this.ContinueSaveSlot1.Location = new System.Drawing.Point(77, 87);
            this.ContinueSaveSlot1.Name = "ContinueSaveSlot1";
            this.ContinueSaveSlot1.Size = new System.Drawing.Size(377, 529);
            this.ContinueSaveSlot1.TabIndex = 2;
            this.ContinueSaveSlot1.TabStop = false;
            this.ContinueSaveSlot1.Text = "Save Slot 1";
            this.ContinueSaveSlot1.UseVisualStyleBackColor = false;
            this.ContinueSaveSlot1.Click += new System.EventHandler(this.ContinueSaveSlot1_Click);
            // 
            // ContinueSaveSlot2
            // 
            this.ContinueSaveSlot2.BackColor = System.Drawing.Color.Black;
            this.ContinueSaveSlot2.Enabled = false;
            this.ContinueSaveSlot2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ContinueSaveSlot2.ForeColor = System.Drawing.Color.Red;
            this.ContinueSaveSlot2.Location = new System.Drawing.Point(533, 87);
            this.ContinueSaveSlot2.Name = "ContinueSaveSlot2";
            this.ContinueSaveSlot2.Size = new System.Drawing.Size(377, 529);
            this.ContinueSaveSlot2.TabIndex = 3;
            this.ContinueSaveSlot2.TabStop = false;
            this.ContinueSaveSlot2.Text = "Save Slot 2";
            this.ContinueSaveSlot2.UseVisualStyleBackColor = false;
            this.ContinueSaveSlot2.Click += new System.EventHandler(this.ContinueSaveSlot2_Click);
            // 
            // ContinueSaveSlot3
            // 
            this.ContinueSaveSlot3.BackColor = System.Drawing.Color.Black;
            this.ContinueSaveSlot3.Enabled = false;
            this.ContinueSaveSlot3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ContinueSaveSlot3.ForeColor = System.Drawing.Color.Red;
            this.ContinueSaveSlot3.Location = new System.Drawing.Point(992, 87);
            this.ContinueSaveSlot3.Name = "ContinueSaveSlot3";
            this.ContinueSaveSlot3.Size = new System.Drawing.Size(377, 529);
            this.ContinueSaveSlot3.TabIndex = 4;
            this.ContinueSaveSlot3.TabStop = false;
            this.ContinueSaveSlot3.Text = "Save Slot 3";
            this.ContinueSaveSlot3.UseVisualStyleBackColor = false;
            this.ContinueSaveSlot3.Click += new System.EventHandler(this.ContinueSaveSlot3_Click);
            // 
            // ContinueSaveFile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1445, 789);
            this.ControlBox = false;
            this.Controls.Add(this.ContinueSaveSlot3);
            this.Controls.Add(this.ContinueSaveSlot2);
            this.Controls.Add(this.ContinueSaveSlot1);
            this.Controls.Add(this.BackToMenuButton);
            this.KeyPreview = true;
            this.Name = "ContinueSaveFile";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Typical Adventure";
            this.Load += new System.EventHandler(this.ContinueSaveFile_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Continue_KeyDown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BackToMenuButton;
        private System.Windows.Forms.Button ContinueSaveSlot1;
        private System.Windows.Forms.Button ContinueSaveSlot2;
        private System.Windows.Forms.Button ContinueSaveSlot3;
    }
}