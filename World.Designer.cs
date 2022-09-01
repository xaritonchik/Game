namespace RPG
{
    partial class World
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(World));
            this.InventoryButton = new System.Windows.Forms.Button();
            this.SkillsButton = new System.Windows.Forms.Button();
            this.MapButton = new System.Windows.Forms.Button();
            this.QuestsButton = new System.Windows.Forms.Button();
            this.Player = new System.Windows.Forms.PictureBox();
            this.UpTimer = new System.Windows.Forms.Timer(this.components);
            this.LeftTimer = new System.Windows.Forms.Timer(this.components);
            this.DownTimer = new System.Windows.Forms.Timer(this.components);
            this.RightTimer = new System.Windows.Forms.Timer(this.components);
            this.Conversation = new System.Windows.Forms.RichTextBox();
            this.Enemy1 = new System.Windows.Forms.PictureBox();
            this.Fountain = new System.Windows.Forms.PictureBox();
            this.Enemy2 = new System.Windows.Forms.PictureBox();
            this.Enemy3 = new System.Windows.Forms.PictureBox();
            this.Enemy4 = new System.Windows.Forms.PictureBox();
            this.Chest = new System.Windows.Forms.PictureBox();
            this.LockedChest = new System.Windows.Forms.PictureBox();
            this.Villager1 = new System.Windows.Forms.PictureBox();
            this.Villager2 = new System.Windows.Forms.PictureBox();
            this.Villager3 = new System.Windows.Forms.PictureBox();
            this.Villager4 = new System.Windows.Forms.PictureBox();
            this.QuestStatus = new System.Windows.Forms.PictureBox();
            this.QuestTakePanel = new System.Windows.Forms.Panel();
            this.DeclineQuestButton = new System.Windows.Forms.Button();
            this.AcceptQuestButton = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.QuestTakeDescription = new System.Windows.Forms.RichTextBox();
            this.QuestCompletePanel = new System.Windows.Forms.Panel();
            this.CollectRewardButton = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.QuestCompleteDescription = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.Player)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Enemy1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Fountain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Enemy2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Enemy3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Enemy4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Chest)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LockedChest)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Villager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Villager2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Villager3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Villager4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.QuestStatus)).BeginInit();
            this.QuestTakePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.QuestCompletePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // InventoryButton
            // 
            this.InventoryButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.InventoryButton.BackColor = System.Drawing.Color.Black;
            this.InventoryButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.InventoryButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InventoryButton.ForeColor = System.Drawing.Color.Red;
            this.InventoryButton.Location = new System.Drawing.Point(1056, 12);
            this.InventoryButton.Name = "InventoryButton";
            this.InventoryButton.Size = new System.Drawing.Size(86, 62);
            this.InventoryButton.TabIndex = 0;
            this.InventoryButton.TabStop = false;
            this.InventoryButton.Text = "Inventory";
            this.InventoryButton.UseVisualStyleBackColor = false;
            this.InventoryButton.Click += new System.EventHandler(this.InventoryButton_Click);
            // 
            // SkillsButton
            // 
            this.SkillsButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.SkillsButton.BackColor = System.Drawing.Color.Black;
            this.SkillsButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SkillsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SkillsButton.ForeColor = System.Drawing.Color.Red;
            this.SkillsButton.Location = new System.Drawing.Point(1154, 12);
            this.SkillsButton.Name = "SkillsButton";
            this.SkillsButton.Size = new System.Drawing.Size(86, 62);
            this.SkillsButton.TabIndex = 1;
            this.SkillsButton.TabStop = false;
            this.SkillsButton.Text = "Skills";
            this.SkillsButton.UseVisualStyleBackColor = false;
            this.SkillsButton.Click += new System.EventHandler(this.SkillsButton_Click);
            // 
            // MapButton
            // 
            this.MapButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.MapButton.BackColor = System.Drawing.Color.Black;
            this.MapButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.MapButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MapButton.ForeColor = System.Drawing.Color.Red;
            this.MapButton.Location = new System.Drawing.Point(1349, 12);
            this.MapButton.Name = "MapButton";
            this.MapButton.Size = new System.Drawing.Size(86, 62);
            this.MapButton.TabIndex = 2;
            this.MapButton.TabStop = false;
            this.MapButton.Text = "Map";
            this.MapButton.UseVisualStyleBackColor = false;
            this.MapButton.Click += new System.EventHandler(this.MapButton_Click);
            // 
            // QuestsButton
            // 
            this.QuestsButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.QuestsButton.BackColor = System.Drawing.Color.Black;
            this.QuestsButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.QuestsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.QuestsButton.ForeColor = System.Drawing.Color.Red;
            this.QuestsButton.Location = new System.Drawing.Point(1252, 12);
            this.QuestsButton.Name = "QuestsButton";
            this.QuestsButton.Size = new System.Drawing.Size(86, 62);
            this.QuestsButton.TabIndex = 3;
            this.QuestsButton.TabStop = false;
            this.QuestsButton.Text = "Quests";
            this.QuestsButton.UseVisualStyleBackColor = false;
            this.QuestsButton.Click += new System.EventHandler(this.QuestsButton_Click);
            // 
            // Player
            // 
            this.Player.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Player.BackColor = System.Drawing.Color.Transparent;
            this.Player.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.Player.Image = ((System.Drawing.Image)(resources.GetObject("Player.Image")));
            this.Player.Location = new System.Drawing.Point(220, 308);
            this.Player.Name = "Player";
            this.Player.Size = new System.Drawing.Size(128, 128);
            this.Player.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Player.TabIndex = 5;
            this.Player.TabStop = false;
            this.Player.Tag = "Player";
            this.Player.LocationChanged += new System.EventHandler(this.Player_LocationChanged);
            // 
            // UpTimer
            // 
            this.UpTimer.Interval = 50;
            this.UpTimer.Tick += new System.EventHandler(this.UpTimer_Tick);
            // 
            // LeftTimer
            // 
            this.LeftTimer.Interval = 50;
            this.LeftTimer.Tick += new System.EventHandler(this.LeftTimer_Tick);
            // 
            // DownTimer
            // 
            this.DownTimer.Interval = 50;
            this.DownTimer.Tick += new System.EventHandler(this.DownTimer_Tick);
            // 
            // RightTimer
            // 
            this.RightTimer.Interval = 50;
            this.RightTimer.Tick += new System.EventHandler(this.RightTimer_Tick);
            // 
            // Conversation
            // 
            this.Conversation.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.Conversation.BackColor = System.Drawing.Color.Black;
            this.Conversation.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.Conversation.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Conversation.ForeColor = System.Drawing.Color.Red;
            this.Conversation.Location = new System.Drawing.Point(12, 773);
            this.Conversation.Name = "Conversation";
            this.Conversation.ReadOnly = true;
            this.Conversation.Size = new System.Drawing.Size(1423, 263);
            this.Conversation.TabIndex = 27;
            this.Conversation.TabStop = false;
            this.Conversation.Text = "";
            this.Conversation.Visible = false;
            this.Conversation.Click += new System.EventHandler(this.Text_Click);
            this.Conversation.DoubleClick += new System.EventHandler(this.Text_Click);
            // 
            // Enemy1
            // 
            this.Enemy1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Enemy1.BackColor = System.Drawing.Color.Transparent;
            this.Enemy1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Enemy1.Location = new System.Drawing.Point(0, 0);
            this.Enemy1.Name = "Enemy1";
            this.Enemy1.Size = new System.Drawing.Size(2, 2);
            this.Enemy1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Enemy1.TabIndex = 29;
            this.Enemy1.TabStop = false;
            this.Enemy1.Tag = "Demon";
            // 
            // Fountain
            // 
            this.Fountain.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Fountain.BackColor = System.Drawing.Color.Transparent;
            this.Fountain.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Fountain.Location = new System.Drawing.Point(0, 0);
            this.Fountain.Name = "Fountain";
            this.Fountain.Size = new System.Drawing.Size(2, 2);
            this.Fountain.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Fountain.TabIndex = 31;
            this.Fountain.TabStop = false;
            this.Fountain.Tag = "Fountain";
            // 
            // Enemy2
            // 
            this.Enemy2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Enemy2.BackColor = System.Drawing.Color.Transparent;
            this.Enemy2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Enemy2.Location = new System.Drawing.Point(0, 0);
            this.Enemy2.Name = "Enemy2";
            this.Enemy2.Size = new System.Drawing.Size(2, 2);
            this.Enemy2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Enemy2.TabIndex = 32;
            this.Enemy2.TabStop = false;
            // 
            // Enemy3
            // 
            this.Enemy3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Enemy3.BackColor = System.Drawing.Color.Transparent;
            this.Enemy3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Enemy3.Location = new System.Drawing.Point(0, 0);
            this.Enemy3.Name = "Enemy3";
            this.Enemy3.Size = new System.Drawing.Size(2, 2);
            this.Enemy3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Enemy3.TabIndex = 33;
            this.Enemy3.TabStop = false;
            // 
            // Enemy4
            // 
            this.Enemy4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Enemy4.BackColor = System.Drawing.Color.Transparent;
            this.Enemy4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Enemy4.Location = new System.Drawing.Point(0, 0);
            this.Enemy4.Name = "Enemy4";
            this.Enemy4.Size = new System.Drawing.Size(2, 2);
            this.Enemy4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Enemy4.TabIndex = 34;
            this.Enemy4.TabStop = false;
            // 
            // Chest
            // 
            this.Chest.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Chest.BackColor = System.Drawing.Color.Transparent;
            this.Chest.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Chest.Location = new System.Drawing.Point(0, 0);
            this.Chest.Name = "Chest";
            this.Chest.Size = new System.Drawing.Size(2, 2);
            this.Chest.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Chest.TabIndex = 39;
            this.Chest.TabStop = false;
            this.Chest.Tag = "Chest";
            // 
            // LockedChest
            // 
            this.LockedChest.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.LockedChest.BackColor = System.Drawing.Color.Transparent;
            this.LockedChest.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.LockedChest.Location = new System.Drawing.Point(0, 0);
            this.LockedChest.Name = "LockedChest";
            this.LockedChest.Size = new System.Drawing.Size(2, 2);
            this.LockedChest.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.LockedChest.TabIndex = 40;
            this.LockedChest.TabStop = false;
            this.LockedChest.Tag = "LockedChest";
            // 
            // Villager1
            // 
            this.Villager1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Villager1.BackColor = System.Drawing.Color.Transparent;
            this.Villager1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Villager1.Location = new System.Drawing.Point(0, 0);
            this.Villager1.Name = "Villager1";
            this.Villager1.Size = new System.Drawing.Size(2, 2);
            this.Villager1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Villager1.TabIndex = 41;
            this.Villager1.TabStop = false;
            this.Villager1.Tag = "Villager";
            // 
            // Villager2
            // 
            this.Villager2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Villager2.BackColor = System.Drawing.Color.Transparent;
            this.Villager2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Villager2.Location = new System.Drawing.Point(0, 0);
            this.Villager2.Name = "Villager2";
            this.Villager2.Size = new System.Drawing.Size(2, 2);
            this.Villager2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Villager2.TabIndex = 42;
            this.Villager2.TabStop = false;
            this.Villager2.Tag = "Villager";
            // 
            // Villager3
            // 
            this.Villager3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Villager3.BackColor = System.Drawing.Color.Transparent;
            this.Villager3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Villager3.Location = new System.Drawing.Point(0, 0);
            this.Villager3.Name = "Villager3";
            this.Villager3.Size = new System.Drawing.Size(2, 2);
            this.Villager3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Villager3.TabIndex = 43;
            this.Villager3.TabStop = false;
            this.Villager3.Tag = "Villager";
            // 
            // Villager4
            // 
            this.Villager4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Villager4.BackColor = System.Drawing.Color.Transparent;
            this.Villager4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Villager4.Location = new System.Drawing.Point(0, 0);
            this.Villager4.Name = "Villager4";
            this.Villager4.Size = new System.Drawing.Size(2, 2);
            this.Villager4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Villager4.TabIndex = 44;
            this.Villager4.TabStop = false;
            this.Villager4.Tag = "Villager";
            // 
            // QuestStatus
            // 
            this.QuestStatus.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.QuestStatus.BackColor = System.Drawing.Color.Transparent;
            this.QuestStatus.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.QuestStatus.Location = new System.Drawing.Point(0, 0);
            this.QuestStatus.Name = "QuestStatus";
            this.QuestStatus.Size = new System.Drawing.Size(2, 2);
            this.QuestStatus.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.QuestStatus.TabIndex = 45;
            this.QuestStatus.TabStop = false;
            this.QuestStatus.Tag = "0";
            // 
            // QuestTakePanel
            // 
            this.QuestTakePanel.BackColor = System.Drawing.Color.Black;
            this.QuestTakePanel.Controls.Add(this.DeclineQuestButton);
            this.QuestTakePanel.Controls.Add(this.AcceptQuestButton);
            this.QuestTakePanel.Controls.Add(this.pictureBox1);
            this.QuestTakePanel.Controls.Add(this.QuestTakeDescription);
            this.QuestTakePanel.Location = new System.Drawing.Point(456, 124);
            this.QuestTakePanel.Name = "QuestTakePanel";
            this.QuestTakePanel.Size = new System.Drawing.Size(507, 501);
            this.QuestTakePanel.TabIndex = 46;
            this.QuestTakePanel.Visible = false;
            // 
            // DeclineQuestButton
            // 
            this.DeclineQuestButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.DeclineQuestButton.BackColor = System.Drawing.Color.Black;
            this.DeclineQuestButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DeclineQuestButton.Enabled = false;
            this.DeclineQuestButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeclineQuestButton.ForeColor = System.Drawing.Color.Red;
            this.DeclineQuestButton.Location = new System.Drawing.Point(311, 397);
            this.DeclineQuestButton.Name = "DeclineQuestButton";
            this.DeclineQuestButton.Size = new System.Drawing.Size(193, 101);
            this.DeclineQuestButton.TabIndex = 8;
            this.DeclineQuestButton.TabStop = false;
            this.DeclineQuestButton.Text = "Decline Quest";
            this.DeclineQuestButton.UseVisualStyleBackColor = false;
            this.DeclineQuestButton.Click += new System.EventHandler(this.DeclineQuestButton_Click);
            // 
            // AcceptQuestButton
            // 
            this.AcceptQuestButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.AcceptQuestButton.BackColor = System.Drawing.Color.Black;
            this.AcceptQuestButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.AcceptQuestButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AcceptQuestButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.AcceptQuestButton.Location = new System.Drawing.Point(311, 291);
            this.AcceptQuestButton.Name = "AcceptQuestButton";
            this.AcceptQuestButton.Size = new System.Drawing.Size(193, 101);
            this.AcceptQuestButton.TabIndex = 7;
            this.AcceptQuestButton.TabStop = false;
            this.AcceptQuestButton.Text = "Accept Quest";
            this.AcceptQuestButton.UseVisualStyleBackColor = false;
            this.AcceptQuestButton.Click += new System.EventHandler(this.AcceptQuestButton_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(311, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(193, 281);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Tag = "0";
            // 
            // QuestTakeDescription
            // 
            this.QuestTakeDescription.BackColor = System.Drawing.Color.Black;
            this.QuestTakeDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.QuestTakeDescription.ForeColor = System.Drawing.Color.Yellow;
            this.QuestTakeDescription.Location = new System.Drawing.Point(4, 4);
            this.QuestTakeDescription.Name = "QuestTakeDescription";
            this.QuestTakeDescription.ReadOnly = true;
            this.QuestTakeDescription.Size = new System.Drawing.Size(301, 494);
            this.QuestTakeDescription.TabIndex = 0;
            this.QuestTakeDescription.TabStop = false;
            this.QuestTakeDescription.Text = "";
            this.QuestTakeDescription.Click += new System.EventHandler(this.Text_Click);
            this.QuestTakeDescription.DoubleClick += new System.EventHandler(this.Text_Click);
            // 
            // QuestCompletePanel
            // 
            this.QuestCompletePanel.BackColor = System.Drawing.Color.Black;
            this.QuestCompletePanel.Controls.Add(this.CollectRewardButton);
            this.QuestCompletePanel.Controls.Add(this.pictureBox2);
            this.QuestCompletePanel.Controls.Add(this.QuestCompleteDescription);
            this.QuestCompletePanel.Location = new System.Drawing.Point(966, 220);
            this.QuestCompletePanel.Name = "QuestCompletePanel";
            this.QuestCompletePanel.Size = new System.Drawing.Size(507, 388);
            this.QuestCompletePanel.TabIndex = 47;
            this.QuestCompletePanel.Visible = false;
            // 
            // CollectRewardButton
            // 
            this.CollectRewardButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CollectRewardButton.BackColor = System.Drawing.Color.Black;
            this.CollectRewardButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CollectRewardButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CollectRewardButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.CollectRewardButton.Location = new System.Drawing.Point(3, 311);
            this.CollectRewardButton.Name = "CollectRewardButton";
            this.CollectRewardButton.Size = new System.Drawing.Size(500, 72);
            this.CollectRewardButton.TabIndex = 7;
            this.CollectRewardButton.TabStop = false;
            this.CollectRewardButton.Text = "Collect Reward";
            this.CollectRewardButton.UseVisualStyleBackColor = false;
            this.CollectRewardButton.Click += new System.EventHandler(this.CollectRewardButton_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(308, 4);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(196, 301);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 6;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Tag = "0";
            // 
            // QuestCompleteDescription
            // 
            this.QuestCompleteDescription.BackColor = System.Drawing.Color.Black;
            this.QuestCompleteDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.QuestCompleteDescription.ForeColor = System.Drawing.Color.Yellow;
            this.QuestCompleteDescription.Location = new System.Drawing.Point(4, 4);
            this.QuestCompleteDescription.Name = "QuestCompleteDescription";
            this.QuestCompleteDescription.ReadOnly = true;
            this.QuestCompleteDescription.Size = new System.Drawing.Size(298, 301);
            this.QuestCompleteDescription.TabIndex = 0;
            this.QuestCompleteDescription.TabStop = false;
            this.QuestCompleteDescription.Text = "";
            this.QuestCompleteDescription.Click += new System.EventHandler(this.Text_Click);
            this.QuestCompleteDescription.DoubleClick += new System.EventHandler(this.Text_Click);
            // 
            // World
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1447, 808);
            this.ControlBox = false;
            this.Controls.Add(this.QuestCompletePanel);
            this.Controls.Add(this.QuestTakePanel);
            this.Controls.Add(this.Conversation);
            this.Controls.Add(this.QuestsButton);
            this.Controls.Add(this.MapButton);
            this.Controls.Add(this.SkillsButton);
            this.Controls.Add(this.InventoryButton);
            this.Controls.Add(this.Player);
            this.Controls.Add(this.Villager4);
            this.Controls.Add(this.Villager3);
            this.Controls.Add(this.Villager2);
            this.Controls.Add(this.Villager1);
            this.Controls.Add(this.LockedChest);
            this.Controls.Add(this.Chest);
            this.Controls.Add(this.Enemy4);
            this.Controls.Add(this.Enemy3);
            this.Controls.Add(this.Enemy2);
            this.Controls.Add(this.Enemy1);
            this.Controls.Add(this.Fountain);
            this.Controls.Add(this.QuestStatus);
            this.DoubleBuffered = true;
            this.KeyPreview = true;
            this.Name = "World";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Typical Adventure";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.World_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.World_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.World_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.Player)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Enemy1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Fountain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Enemy2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Enemy3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Enemy4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Chest)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LockedChest)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Villager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Villager2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Villager3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Villager4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.QuestStatus)).EndInit();
            this.QuestTakePanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.QuestCompletePanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button InventoryButton;
        private System.Windows.Forms.Button SkillsButton;
        private System.Windows.Forms.Button MapButton;
        private System.Windows.Forms.Button QuestsButton;
        private System.Windows.Forms.PictureBox Player;
        private System.Windows.Forms.Timer UpTimer;
        private System.Windows.Forms.Timer LeftTimer;
        private System.Windows.Forms.Timer DownTimer;
        private System.Windows.Forms.Timer RightTimer;
        private System.Windows.Forms.RichTextBox Conversation;
        private System.Windows.Forms.PictureBox Enemy1;
        private System.Windows.Forms.PictureBox Fountain;
        private System.Windows.Forms.PictureBox Enemy2;
        private System.Windows.Forms.PictureBox Enemy3;
        private System.Windows.Forms.PictureBox Enemy4;
        private System.Windows.Forms.PictureBox Chest;
        private System.Windows.Forms.PictureBox LockedChest;
        private System.Windows.Forms.PictureBox Villager1;
        private System.Windows.Forms.PictureBox Villager2;
        private System.Windows.Forms.PictureBox Villager3;
        private System.Windows.Forms.PictureBox Villager4;
        private System.Windows.Forms.PictureBox QuestStatus;
        private System.Windows.Forms.Panel QuestTakePanel;
        private System.Windows.Forms.Button DeclineQuestButton;
        private System.Windows.Forms.Button AcceptQuestButton;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.RichTextBox QuestTakeDescription;
        private System.Windows.Forms.Panel QuestCompletePanel;
        private System.Windows.Forms.Button CollectRewardButton;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.RichTextBox QuestCompleteDescription;
    }
}