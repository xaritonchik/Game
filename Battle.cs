using System.Windows.Forms;
using System;
using System.Collections.Generic;
using System.Xml.Linq;
using System.IO;
using System.Linq;
using System.Drawing;

namespace RPG
{
	public partial class Battle : Form
	{

		static string save = File.ReadAllText(@"res/Data/CurrentSave.txt");
		XElement tempSave = XElement.Load("res/Data/Temp" + save + ".xml");
		XElement enemies = XElement.Load("res/Data/Enemies.xml");
		XElement tempInv = XElement.Load("res/Data/TempInventory" + save + ".xml");
		XElement skills = XElement.Load("res/Data/Skills.xml");

		int attack, maxHealth, currentHealth, defense, experience, level, gold, dodgeChance;
		int healthRegen, critChance, skillPoints, statusPoints, maxEnergy, currentEnergy, energyRegen;
		float lifeSteal, critDamage;
		string enemyName = "";
		int enemyAttack, enemyDefense, enemyMinimalDamage, enemyGold, enemyExp, loot2Chance, loot1Chance;
		string loot1, loot2, loot1Type, loot2Type;

		public Battle(string name)
		{

			enemyName = name;
			InitializeComponent();
		}

		public void Loot(string type, string name)
		{

			IEnumerable<XElement> inventory = tempInv.Elements();
			int j = 0;
			int x = 0;
			bool accepted = false;

			if (type == "Weapon")
			{

				j = 1;
				x = 26;
			}

			else if (type == "Armor")
			{

				j = 26;
				x = 51;
			}

			else if (type == "Accessory")
			{

				j = 51;
				x = 76;
			}

			else if (type == "Consumable")
			{

				j = 76;
				x = 101;
			}

			for (int i = j; i < x; i++)
			{

				foreach (var inv in inventory)
				{

					if (inv.Element("Item" + i.ToString()).Element("ItemName").Value == "")
					{

						Updated("Items", "Item" + i.ToString(), "ItemName", name, tempInv);
						accepted = true;
						MessageBox.Show("You received item: " + name, "New item!");
						break;
					}

				}

				if (accepted)
				{

					break;
				}

			}

			if (!accepted)
			{

				MessageBox.Show("You lost item: " + name + " because your inventory is full!", "Item lost!");
			}

		}

		public void Regen()
		{

			if (PlayerHP.Value + healthRegen > maxHealth)
			{

				PlayerHP.Value = maxHealth;
			}

			else
			{

				PlayerHP.Value += healthRegen;
			}

			if (PlayerEP.Value + energyRegen > maxEnergy)
			{

				PlayerEP.Value = maxEnergy;
			}

			else
			{

				PlayerEP.Value += energyRegen;
			}
		}

		public bool SkillUse(string name)
		{

			int cost = 0;
			var skill = from sk in skills.Elements("Skill") where (string)sk.Element("SkillTag") == name select sk;

			foreach (var skillItem in skill)
			{

				cost = int.Parse(skillItem.Element("SkillCost").Value);
			}

			if (cost > PlayerEP.Value)
			{

				return false;
			}
			
			else
			{

				PlayerEP.Value -= cost;
				return true;
			}

		}

		public void Updated(string root, string next, string name, string text, XElement elem)
		{

			List<XElement> update;

			if (name == "0")
			{

				update = elem.Elements(root).Elements(next).ToList();
			}

			else
			{

				update = elem.Elements(root).Elements(next).Elements(name).ToList();
			}

			foreach (XElement item in update)
			{

				item.ReplaceNodes(text);
			}

			tempInv.Save("res/Data/TempInventory" + save + ".xml");
			tempSave.Save("res/Data/Temp" + save + ".xml");
		}

		public void EnemyAttack()
		{

			int x = new Random().Next(1, 101);

			if (dodgeChance >= x)
			{

				MessageBox.Show("Enemy missed!");
			}

			else
			{
				if (enemyAttack - defense <= enemyMinimalDamage)
				{

					if (PlayerHP.Value - enemyMinimalDamage <= 0)
					{

						Enemy.Left -= 20;
						PlayerHP.Value = 0;
						Wait(300);
						Enemy.Left += 20;
						MessageBox.Show("You Lost!");
						World world = new World("0");
						world.Show();
						this.Hide();
					}

					else
					{

						Enemy.Left -= 20;
						PlayerHP.Value -= enemyMinimalDamage;
						Wait(300);
						Enemy.Left += 20;
					}

				}

				else if (PlayerHP.Value - (enemyAttack - defense) <= 0)
				{

					Enemy.Left -= 20;
					PlayerHP.Value = 0;
					Wait(300);
					Enemy.Left += 20;
					MessageBox.Show("You Lost!");
					World world = new World("0");
					world.Show();
					this.Hide();
				}

				else
				{

					Enemy.Left -= 20;
					PlayerHP.Value -= (enemyAttack - defense);
					Wait(300);
					Enemy.Left += 20;
				}

			}

		}

		public IEnumerable<Control> GetAll(Control control, Type type)
		{
			var controls = control.Controls.Cast<Control>();

			return controls.SelectMany(ctrl => GetAll(ctrl, type)).Concat(controls).Where(c => c.GetType() == type);
		}

		public void Wait(int milliseconds)
		{

			var timer1 = new Timer();
			if (milliseconds == 0 || milliseconds < 0) return;

			timer1.Interval = milliseconds;
			timer1.Enabled = true;
			timer1.Start();

			timer1.Tick += (s, e) =>
			{

				timer1.Enabled = false;
				timer1.Stop();
			};

			while (timer1.Enabled)
			{

				Application.DoEvents();
			}

		}

		public void Win()
		{

			int x = new Random().Next(1, 101);
			Wait(300);
			Player.Left -= 20;
			MessageBox.Show("You Won!");
			experience += enemyExp;
			MessageBox.Show("Experience gained: " + enemyExp.ToString());
			gold += enemyGold;
			MessageBox.Show("Gold gained: " + enemyGold.ToString());
			currentHealth = PlayerHP.Value;
			currentEnergy = PlayerEP.Value;

			if (experience >= 100 * level)
			{

				experience -= 100 * level;
				level++;
				skillPoints++;
				statusPoints += 2;
				currentHealth = maxHealth;
				currentEnergy = maxEnergy;
				MessageBox.Show("You have gained a new level!\nHealth and Energy points are restored!\nYou have gained skill and status points!", "New level!");

				if (level % 10 == 0)
				{

					skillPoints += 2;
					statusPoints += 4;
				}

				else
				{

					skillPoints++;
					statusPoints += 2;
				}

			}

			if (x <= loot2Chance)
			{

				Loot(loot2Type, loot2);
			}

			if (x <= loot1Chance)
			{

				Loot(loot1Type, loot1);
			}

			Updated("Player", "CurrentEnergy", "0", currentEnergy.ToString(), tempSave);
			Updated("Player", "CurrentHealth", "0", currentHealth.ToString(), tempSave);
			Updated("Player", "Experience", "0", experience.ToString(), tempSave);
			Updated("Player", "Level", "0", level.ToString(), tempSave);
			Updated("Player", "Gold", "0", gold.ToString(), tempSave);
			Updated("Player", "SkillPoints", "0", skillPoints.ToString(), tempSave);
			Updated("Player", "StatusPoints", "0", statusPoints.ToString(), tempSave);

			World world = new World(enemyName);
			world.Show();
			this.Hide();
		}

		private void Battle_KeyDown(object sender, KeyEventArgs e)
		{

			if (e.Alt && e.KeyCode == Keys.F4)
			{

				e.Handled = true;
				MessageBox.Show("This function is disabled due to possible file corruption", "Warning!");
			}
		}

		private void AttackButton_Click(object sender, EventArgs e)
		{

			int x;
			bool consumable = false;
			bool skill = false;

			x = new Random().Next(1, 101);

			AttackButton.Enabled = false;
			DefenseButton.Enabled = false;
			
			if (ConsumablesButton.Enabled)
			{

				consumable = true;
				ConsumablesButton.Enabled = false;
			}

			if (SkillsButton.Enabled)
			{

				skill = true;
				SkillsButton.Enabled = false;
			}

			if (critChance >= x)
			{

				if ((int)Math.Round((attack + 10) * critDamage) - enemyDefense <= 0)
				{

					if (EnemyHP.Value - 1 == 0)
					{

						Player.Left += 20;
						EnemyHP.Value = 0;
						Win();
					}

					else
					{

						Player.Left += 20;
						EnemyHP.Value -= 1;
						Wait(300);
						Player.Left -= 20;
						EnemyAttack();
					}

				}

				else if (EnemyHP.Value - (int) Math.Round((attack + 10) * critDamage) - enemyDefense <= 0)
				{

					Player.Left += 20;
					EnemyHP.Value = 0;

					if (PlayerHP.Value + (int) Math.Round((((attack + 10) * critDamage) - enemyDefense) * lifeSteal) > maxHealth && lifeSteal != 0)
					{

						PlayerHP.Value = maxHealth;
					}

					else if (PlayerHP.Value + (int)Math.Round((((attack + 10) * critDamage) - enemyDefense) * lifeSteal) <= maxHealth && lifeSteal != 0)
					{

						PlayerHP.Value += (int) Math.Round((attack + 10) * critDamage * lifeSteal);
					}

					Win();
				}

				else
				{

					Player.Left += 20;
					EnemyHP.Value -= (int) Math.Round((attack + 10) * critDamage) - enemyDefense;

					if (PlayerHP.Value + (int) Math.Round((((attack + 10) * critDamage) - enemyDefense) * lifeSteal) > maxHealth && lifeSteal != 0)
					{

						PlayerHP.Value = maxHealth;
					}

					else if (PlayerHP.Value + (int) Math.Round((((attack + 10) * critDamage) - enemyDefense) * lifeSteal) <= maxHealth && lifeSteal != 0)
					{

						PlayerHP.Value += (int)Math.Round((attack + 10) * critDamage * lifeSteal);
					}

					Wait(300);
					Player.Left -= 20;

					EnemyAttack();
				}
			}

			else if (attack + 10 - enemyDefense <= 0)
			{

				if (EnemyHP.Value - 1 == 0)
				{

					Player.Left += 20;
					EnemyHP.Value = 0;
					Win();
				}

				else
				{

					Player.Left += 20;
					EnemyHP.Value -= 1;
					Wait(300);
					Player.Left -= 20;
					EnemyAttack();
				}

			}

			else if (EnemyHP.Value - (attack + 10 - enemyDefense) <= 0)
			{

				Player.Left += 20;
				EnemyHP.Value = 0;

				if (PlayerHP.Value + (int)Math.Round((attack + 10 - enemyDefense) * lifeSteal) > maxHealth && lifeSteal != 0)
				{

					PlayerHP.Value = maxHealth;
				}

				else if (PlayerHP.Value + (int)Math.Round((attack + 10 - enemyDefense) * lifeSteal) <= maxHealth && lifeSteal != 0)
				{

					PlayerHP.Value += (int)Math.Round((attack + 10) * lifeSteal);
				}

				Win();
			}

			else if (EnemyHP.Value - (attack + 10 - enemyDefense) > 0)
			{

				Player.Left += 20;
				EnemyHP.Value -= attack + 10 - enemyDefense;

				if (PlayerHP.Value + (int)Math.Round((attack + 10 - enemyDefense) * lifeSteal) > maxHealth && lifeSteal != 0)
				{

					PlayerHP.Value = maxHealth;
				}

				else if (PlayerHP.Value + (int)Math.Round((attack + 10 - enemyDefense) * lifeSteal) <= maxHealth && lifeSteal != 0)
				{

					PlayerHP.Value += (int)Math.Round((attack + 10) * lifeSteal);
				}

				Wait(300);
				Player.Left -= 20;

				EnemyAttack();
			}

			Regen();
			AttackButton.Enabled = true;
			DefenseButton.Enabled = true;

			if (consumable)
			{

				ConsumablesButton.Enabled = true;
			}

			if (skill)
			{

				SkillsButton.Enabled = true;
			}
		}

		private void DefenseButton_Click(object sender, EventArgs e)
		{

			bool consumable = false;
			bool skill = false;

			AttackButton.Enabled = false;
			DefenseButton.Enabled = false;

			if (ConsumablesButton.Enabled)
			{

				consumable = true;
				ConsumablesButton.Enabled = false;
			}

			if (SkillsButton.Enabled)
			{

				skill = true;
				SkillsButton.Enabled = false;
			}

			int x = new Random().Next(1, 101);

			if (dodgeChance >= x)
			{

				MessageBox.Show("Enemy missed!");
			}

			else
			{

				if (enemyAttack - defense <= enemyMinimalDamage || (enemyAttack - defense) / 2 <= enemyMinimalDamage)
				{

					if (PlayerHP.Value - enemyMinimalDamage <= 0)
					{

						Enemy.Left -= 20;
						PlayerHP.Value = 0;
						Wait(300);
						Enemy.Left += 20;
						MessageBox.Show("You Lost!");
						World world = new World("0");
						world.Show();
						this.Hide();
					}

					else
					{

						Enemy.Left -= 20;
						PlayerHP.Value -= enemyMinimalDamage;
						Wait(300);
						Enemy.Left += 20;
					}

				}

				else if (PlayerHP.Value - ((enemyAttack - defense) / 2) <= 0)
				{

					Enemy.Left -= 20;
					PlayerHP.Value = 0;
					Wait(300);
					Enemy.Left += 20;
					MessageBox.Show("You Lost!");
					World world = new World("0");
					world.Show();
					this.Hide();
				}

				else
				{

					Enemy.Left -= 20;
					PlayerHP.Value -= (enemyAttack - defense) / 2;
					Wait(300);
					Enemy.Left += 20;
				}

			}

			Regen();
			AttackButton.Enabled = true;
			DefenseButton.Enabled = true;

			if (consumable)
			{

				ConsumablesButton.Enabled = true;
			}

			if (skill)
			{

				SkillsButton.Enabled = true;
			}
		}

		private void Battle_Load(object sender, EventArgs e)
		{

			IEnumerable<XElement> stats = tempSave.Elements();
			IEnumerable<XElement> inventory = tempInv.Elements();
			var enemy = from enm in enemies.Elements("Enemy") where (string)enm.Element("Name") == enemyName select enm;

			foreach (var stat in stats)
			{

				attack = int.Parse(stat.Element("AttackDamage").Value)
					+ int.Parse(stat.Element("EquipStats").Element("WeaponDamage").Value)
					+ int.Parse(stat.Element("EquipStats").Element("GlovesDamage").Value)
					+ int.Parse(stat.Element("EquipStats").Element("NecklaceDamage").Value)
					+ int.Parse(stat.Element("EquipStats").Element("RingDamage").Value);

				critChance = int.Parse(stat.Element("CritChance").Value)
					+ int.Parse(stat.Element("EquipStats").Element("WeaponCritChance").Value);

				critDamage = float.Parse(stat.Element("CritDamage").Value)
					+ float.Parse(stat.Element("EquipStats").Element("WeaponCritDamage").Value);

				currentEnergy = int.Parse(stat.Element("CurrentEnergy").Value);

				currentHealth = int.Parse(stat.Element("CurrentHealth").Value);

				defense = int.Parse(stat.Element("Defense").Value)
					+ int.Parse(stat.Element("EquipStats").Element("ChestplateDefense").Value)
					+ int.Parse(stat.Element("EquipStats").Element("NecklaceDefense").Value)
					+ int.Parse(stat.Element("EquipStats").Element("RingDefense").Value);

				dodgeChance = int.Parse(stat.Element("DodgeChance").Value)
					+ int.Parse(stat.Element("EquipStats").Element("HelmetDodgeChance").Value)
					+ int.Parse(stat.Element("EquipStats").Element("ChestplateDodgeChance").Value)
					+ int.Parse(stat.Element("EquipStats").Element("GlovesDodgeChance").Value)
					+ int.Parse(stat.Element("EquipStats").Element("BootsDodgeChance").Value);

				energyRegen = int.Parse(stat.Element("EnergyRegen").Value) 
					+ int.Parse(stat.Element("EquipStats").Element("HelmetEnergyRegen").Value)
					+ int.Parse(stat.Element("EquipStats").Element("ChestplateEnergyRegen").Value)
					+ int.Parse(stat.Element("EquipStats").Element("GlovesEnergyRegen").Value)
					+ int.Parse(stat.Element("EquipStats").Element("BootsEnergyRegen").Value);

				experience = int.Parse(stat.Element("Experience").Value);

				gold = int.Parse(stat.Element("Gold").Value);

				healthRegen = int.Parse(stat.Element("EquipStats").Element("HelmetHealthRegen").Value)
					+ int.Parse(stat.Element("EquipStats").Element("ChestplateHealthRegen").Value)
					+ int.Parse(stat.Element("EquipStats").Element("GlovesHealthRegen").Value)
					+ int.Parse(stat.Element("EquipStats").Element("BootsHealthRegen").Value);

				level = int.Parse(stat.Element("Level").Value);

				lifeSteal = float.Parse(stat.Element("EquipStats").Element("WeaponLifeSteal").Value);

				maxEnergy = int.Parse(stat.Element("MaxEnergy").Value)
					+ int.Parse(stat.Element("EquipStats").Element("BootsEnergy").Value)
					+ int.Parse(stat.Element("EquipStats").Element("NecklaceEnergy").Value)
					+ int.Parse(stat.Element("EquipStats").Element("RingEnergy").Value);

				maxHealth = int.Parse(stat.Element("MaxHealth").Value)
					+ int.Parse(stat.Element("EquipStats").Element("HelmetHealth").Value)
					+ int.Parse(stat.Element("EquipStats").Element("NecklaceHealth").Value)
					+ int.Parse(stat.Element("EquipStats").Element("RingHealth").Value);

				skillPoints = int.Parse(stat.Element("SkillPoints").Value);

				statusPoints = int.Parse(stat.Element("StatusPoints").Value);

				for (int i = 1; i < 5; i++)
				{

					if (stat.Element("Skills").Element("Active" + i.ToString()).Value != "0")
					{

						SkillsButton.Enabled = true;
					}

				}

			}

			foreach (var inv in inventory)
			{

				for (int i = 76; i < 101; i++)
				{

					if (inv.Element("Item" + i.ToString()).Element("ItemName").Value != "")
					{

						ConsumablesButton.Enabled = true;
					}

				}

			}

			foreach (var enm in enemy)
			{

				enemyAttack = int.Parse(enm.Element("Damage").Value);
				enemyDefense = int.Parse(enm.Element("Defense").Value);
				enemyExp = int.Parse(enm.Element("Experience").Value);
				enemyGold = int.Parse(enm.Element("Gold").Value);
				enemyMinimalDamage = int.Parse(enm.Element("MinimalDamage").Value);
				loot1 = enm.Element("Loot1").Value;
				loot2 = enm.Element("Loot2").Value;
				loot1Chance = int.Parse(enm.Element("Loot1Chance").Value);
				loot2Chance = int.Parse(enm.Element("Loot2Chance").Value);
				loot1Type = enm.Element("Loot1Type").Value;
				loot2Type = enm.Element("Loot2Type").Value;
				Enemy.Image = Image.FromFile("res/EvilMobs/" + enm.Element("Name").Value + ".png");
				Image image = Image.FromFile("res/EvilMobs/" + enm.Element("Name").Value + ".png");
				Enemy.Width = image.Width - 10;
				Enemy.Height = image.Height - 10;
				EnemyHP.Maximum = int.Parse(enm.Element("Health").Value);
				EnemyHP.Value = int.Parse(enm.Element("Health").Value);
			}

			PlayerHP.Maximum = maxHealth;
			PlayerHP.Value = currentHealth;
			PlayerEP.Maximum = maxEnergy;
			PlayerEP.Value = currentEnergy;
		}

		private void SkillsButton_Click(object sender, EventArgs e)
		{

			IEnumerable<XElement> stats = tempSave.Elements();
			var controls = GetAll(this, typeof(Button));

			string name = "";

			AttackButton.Visible = false;
			DefenseButton.Visible = false;
			SkillsButton.Visible = false;
			ConsumablesButton.Visible = false;
			BackButton.Visible = true;

			for (int i = 1; i < 5; i++)
			{

				foreach (var stat in stats)
				{

					if (stat.Element("Skills").Element("Active" + i.ToString()).Value != "0")
					{

						foreach (var control in controls)
						{

							if (control.Name == "Active" + i.ToString())
							{

								var skill = from sk in skills.Elements("Skill") where (string)sk.Element("SkillTag") == "Active" + i.ToString() select sk;
								control.Visible = true;

								foreach (var sk in skill)
								{

									name = sk.Element("SkillName").Value;
								}

								control.Text = name;
							}

						}

					}

				}

			}

		}

		private void ConsumablesButton_Click(object sender, EventArgs e)
		{

			IEnumerable<XElement> inventory = tempInv.Elements();

			AttackButton.Visible = false;
			DefenseButton.Visible = false;
			SkillsButton.Visible = false;
			ConsumablesButton.Visible = false;
			BackButton.Visible = true;
			Heal.Visible = true;
			Recover.Visible = true;
			Heal.Enabled = false;
			Recover.Enabled = false;

			foreach (var inv in inventory)
			{

				for (int i = 76; i < 101; i++)
				{

					if (inv.Element("Item" + i.ToString()).Element("ItemName").Value == "Health Potion")
					{

						Heal.Enabled = true;
					}

					if (inv.Element("Item" + i.ToString()).Element("ItemName").Value == "Energy Potion")
					{

						Recover.Enabled = true;
					}

				}

			}

		}

		private void BackButton_Click(object sender, EventArgs e)
		{

			AttackButton.Visible = true;
			DefenseButton.Visible = true;
			SkillsButton.Visible = true;
			ConsumablesButton.Visible = true;
			BackButton.Visible = false;
			Active1.Visible = false;
			Active2.Visible = false;
			Active3.Visible = false;
			Active4.Visible = false;
			Heal.Visible = false;
			Recover.Visible = false;
		}

		private void Heal_Click(object sender, EventArgs e)
		{

			if (PlayerHP.Value == maxHealth)
			{

				MessageBox.Show("Your health is already full!", "Warning!");
			}

			else
			{

				IEnumerable<XElement> inventory = tempInv.Elements();

				if (PlayerHP.Value + maxHealth / 2 > PlayerHP.Maximum)
				{

					PlayerHP.Value = PlayerHP.Maximum;
				}
				
				else
				{

					PlayerHP.Value += maxHealth / 2;

				}

				foreach (var inv in inventory)
				{

					for (int i = 76; i < 101; i++)
					{

						if (inv.Element("Item" + i.ToString()).Element("ItemName").Value == "Health Potion")
						{

							Updated("Items", "Item" + i.ToString(), "ItemName", "", tempInv);
						}

					}

				}

				ConsumablesButton_Click(sender, e);
				EnemyAttack();
			}

		}

		private void Recover_Click(object sender, EventArgs e)
		{

			if (PlayerEP.Value == maxEnergy)
			{

				MessageBox.Show("Your energy is already full!", "Warning!");
			}

			else
			{

				IEnumerable<XElement> inventory = tempInv.Elements();

				if (PlayerEP.Value + maxEnergy / 2 > PlayerEP.Maximum)
				{

					PlayerEP.Value = PlayerEP.Maximum;
				}

				else
				{

					PlayerEP.Value += maxEnergy / 2;

				}

				foreach (var inv in inventory)
				{

					for (int i = 76; i < 101; i++)
					{

						if (inv.Element("Item" + i.ToString()).Element("ItemName").Value == "Energy Potion")
						{

							Updated("Items", "Item" + i.ToString(), "ItemName", "", tempInv);
						}

					}

				}

				ConsumablesButton_Click(sender, e);
				EnemyAttack();
			}
		}

		private void Bar_MouseEnter(object sender, EventArgs e)
		{

			ProgressBar bar = sender as ProgressBar;
			ToolTip.SetToolTip(bar, bar.Value.ToString() + "/" + bar.Maximum.ToString());
		}

		private void Bar_MouseLeave(object sender, EventArgs e)
		{

			ProgressBar bar = sender as ProgressBar;
			ToolTip.SetToolTip(bar, null);
		}

		private void Active1_Click(object sender, EventArgs e)
		{

			if (SkillUse("Active1"))
			{

				Active1.Enabled = false;
				Active2.Enabled = false;
				Active3.Enabled = false;
				Active4.Enabled = false;
				BackButton.Enabled = false;

				IEnumerable<XElement> stats = tempSave.Elements();
				int level = 0;

				foreach (var stat in stats)
				{

					level = int.Parse(stat.Element("Skills").Element("Active1").Value);
				}

				if ((int)Math.Round(attack * (1.5 + 0.1 * level)) - enemyDefense <= 0)
				{

					if (EnemyHP.Value - 1 == 0)
					{

						Player.Left += 20;
						EnemyHP.Value = 0;
						Win();
					}

					else
					{

						Player.Left += 20;
						EnemyHP.Value -= 1;
						Wait(300);
						Player.Left -= 20;
						EnemyAttack();
					}

				}

				else if (EnemyHP.Value - ((int)Math.Round(attack * (1.5 + 0.1 * level)) - enemyDefense) <= 0)
				{

					Player.Left += 20;
					EnemyHP.Value = 0;
					Win();
				}

				else
				{

					Player.Left += 20;
					EnemyHP.Value -= (int)Math.Round(attack * (1.5 + 0.1 * level)) - enemyDefense;
					Wait(300);
					Player.Left -= 20;
					EnemyAttack();
					Regen();
				}

				Active1.Enabled = true;
				Active2.Enabled = true;
				Active3.Enabled = true;
				Active4.Enabled = true;
				BackButton.Enabled = true;
			}

			else
			{

				MessageBox.Show("Not enough energy!", "Low energy");
			}

		}

		private void Active2_Click(object sender, EventArgs e)
		{

			if (SkillUse("Active2"))
			{

				Active1.Enabled = false;
				Active2.Enabled = false;
				Active3.Enabled = false;
				Active4.Enabled = false;
				BackButton.Enabled = false;

				IEnumerable<XElement> stats = tempSave.Elements();
				int level = 0;

				foreach (var stat in stats)
				{

					level = int.Parse(stat.Element("Skills").Element("Active2").Value);
				}

				if (PlayerHP.Value == PlayerHP.Maximum)
				{

					PlayerEP.Value += 14;
					MessageBox.Show("Health is already full!", "Warning!");
				}

				else if (PlayerHP.Value + 6 + 2 * level > PlayerHP.Maximum)
				{

					PlayerHP.Value = PlayerHP.Maximum;

					Wait(300);
					EnemyAttack();
					Regen();
				}

				else
				{

					PlayerHP.Value += 6 + 2 * level;
					Wait(300);
					EnemyAttack();
					Regen();
				}

				Active1.Enabled = true;
				Active2.Enabled = true;
				Active3.Enabled = true;
				Active4.Enabled = true;
				BackButton.Enabled = true;
			}

			else
			{

				MessageBox.Show("Not enough energy!", "Low energy");
			}

		}

		private void Active3_Click(object sender, EventArgs e)
		{

			if (SkillUse("Active3"))
			{

				Active1.Enabled = false;
				Active2.Enabled = false;
				Active3.Enabled = false;
				Active4.Enabled = false;
				BackButton.Enabled = false;

				IEnumerable<XElement> stats = tempSave.Elements();
				int level = 0;

				foreach (var stat in stats)
				{

					level = int.Parse(stat.Element("Skills").Element("Active3").Value);
				}

				if (attack + 2 * level - enemyDefense <= 0)
				{

					if (EnemyHP.Value - 1 == 0)
					{

						Player.Left += 20;
						EnemyHP.Value = 0;
						Win();
					}

					else
					{

						Player.Left += 20;
						EnemyHP.Value -= 1;
						Wait(300);
						Player.Left -= 20;
						EnemyAttack();
					}

				}

				else if (EnemyHP.Value - (attack + 2 * level) - enemyDefense <= 0)
				{

					Player.Left += 20;
					EnemyHP.Value = 0;
					Win();
				}

				else
				{

					Player.Left += 20;
					EnemyHP.Value -= attack + 2 * level - enemyDefense;
					Wait(300);
					Player.Left -= 20;

					EnemyAttack();
					Regen();
				}

				Active1.Enabled = true;
				Active2.Enabled = true;
				Active3.Enabled = true;
				Active4.Enabled = true;
				BackButton.Enabled = true;
			}

			else
			{

				MessageBox.Show("Not enough energy!", "Low energy");
			}

		}

		private void Active4_Click(object sender, EventArgs e)
		{

			if (SkillUse("Active4"))
			{

				Active1.Enabled = false;
				Active2.Enabled = false;
				Active3.Enabled = false;
				Active4.Enabled = false;
				BackButton.Enabled = false;

				IEnumerable<XElement> stats = tempSave.Elements();
				int level = 0;

				foreach (var stat in stats)
				{

					level = int.Parse(stat.Element("Skills").Element("Active4").Value);
				}

				if ((attack + level - 1) * 2 - enemyDefense <= 0)
				{

					if (EnemyHP.Value - 2 == 0)
					{

						Player.Left += 20;
						EnemyHP.Value = 0;
						Win();
					}

					else
					{

						Player.Left += 20;
						EnemyHP.Value -= 2;
						Wait(300);
						Player.Left -= 20;
						EnemyAttack();
					}

				}

				if (EnemyHP.Value - ((attack + level - 1) * 2) - enemyDefense <= 0)
				{

					Player.Left += 20;
					EnemyHP.Value = 0;
					Win();
				}

				else
				{

					Player.Left += 20;
					EnemyHP.Value -= (attack + level - 1) * 2 - enemyDefense;
					Wait(300);
					Player.Left -= 20;

					EnemyAttack();
					Regen();
				}

				Active1.Enabled = true;
				Active2.Enabled = true;
				Active3.Enabled = true;
				Active4.Enabled = true;
				BackButton.Enabled = true;
			}

			else
			{

				MessageBox.Show("Not enough energy!", "Low energy");
			}

		}
	}
}