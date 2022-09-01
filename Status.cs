using System.Windows.Forms;
using System;
using System.Collections.Generic;
using System.Xml.Linq;
using System.IO;
using System.Linq;
using System.Drawing;

namespace RPG
{
	public partial class Status : Form
	{

		static string save = File.ReadAllText(@"res/Data/CurrentSave.txt");
		XElement tempSave = XElement.Load("res/Data/Temp" + save + ".xml");

		public void Updated(string name, string text)
		{

			var update = tempSave.Elements("Player").Elements(name).ToList();

			foreach (XElement item in update)
			{

				item.ReplaceNodes(text);
			}

		}

		public void StatusPoint0()
		{

			if (StatusPointsCount.Text == "0")
			{

				DialogResult result;
				result = MessageBox.Show("Are you sure you want to raise these attributes?", "Are you sure?", MessageBoxButtons.YesNo);

				if (result == DialogResult.Yes)
				{

					StrButton.Enabled = false;
					StaButton.Enabled = false;
					DexButton.Enabled = false;
					IntButton.Enabled = false;

					Updated("STR", StrCount.Text);
					Updated("STA", StaCount.Text);
					Updated("DEX", DexCount.Text);
					Updated("INT", IntCount.Text);
					Updated("AttackDamage", ADCount.Text);
					Updated("MaxHealth", MaxHPCount.Text);
					Updated("MaxEnergy", MaxEPCount.Text);
					Updated("Defense", DefenseCount.Text);
					Updated("StatusPoints", StatusPointsCount.Text);

					tempSave.Save("res/Data/Temp" + save + ".xml");

					HPBar.Maximum = int.Parse(MaxHPCount.Text);
					EPBar.Maximum = int.Parse(MaxEPCount.Text);

					ADLabel.ForeColor = Color.Red;
					ADCount.ForeColor = Color.Red;
					DefenseLabel.ForeColor = Color.Red;
					DefenseCount.ForeColor = Color.Red;
					MaxHPLabel.ForeColor = Color.Red;
					MaxHPCount.ForeColor = Color.Red;
					MaxEPLabel.ForeColor = Color.Red;
					MaxEPCount.ForeColor = Color.Red;
					StrCount.ForeColor = Color.Red;
					StaCount.ForeColor = Color.Red;
					DexCount.ForeColor = Color.Red;
					IntCount.ForeColor = Color.Red;
					StatusPointsLabel.ForeColor = Color.Red;
					StatusPointsCount.ForeColor = Color.Red;
				}

				else
				{

					IEnumerable<XElement> stats = tempSave.Elements();

					foreach (var stat in stats)
					{

						ADCount.Text = stat.Element("AttackDamage").Value;
						DefenseCount.Text = stat.Element("Defense").Value;
						MaxEPCount.Text = stat.Element("MaxEnergy").Value;
						MaxHPCount.Text = stat.Element("MaxHealth").Value;
						StatusPointsCount.Text = stat.Element("StatusPoints").Value;
						DexCount.Text = stat.Element("DEX").Value;
						IntCount.Text = stat.Element("INT").Value;
						StaCount.Text = stat.Element("STA").Value;
						StrCount.Text = stat.Element("STR").Value;
					}

					ADLabel.ForeColor = Color.Red;
					ADCount.ForeColor = Color.Red;
					DefenseLabel.ForeColor = Color.Red;
					DefenseCount.ForeColor = Color.Red;
					MaxHPLabel.ForeColor = Color.Red;
					MaxHPCount.ForeColor = Color.Red;
					MaxEPLabel.ForeColor = Color.Red;
					MaxEPCount.ForeColor = Color.Red;
					StrCount.ForeColor = Color.Red;
					StaCount.ForeColor = Color.Red;
					DexCount.ForeColor = Color.Red;
					IntCount.ForeColor = Color.Red;
					StatusPointsLabel.ForeColor = Color.Red;
					StatusPointsCount.ForeColor = Color.Red;
				}

			}

		}

		public Status()
		{

			InitializeComponent();
		}

		private void Status_KeyDown(object sender, KeyEventArgs e)
		{

			if (e.Alt && e.KeyCode == Keys.F4)
			{

				e.Handled = true;
				MessageBox.Show("This function is disabled due to possible file corruption", "Warning!");
			}
		}

		private void InventoryButton_Click(object sender, EventArgs e)
		{

			Inventory inventory = new Inventory();
			inventory.Show();
			this.Hide();
		}

		private void SkillsButton_Click(object sender, EventArgs e)
		{

			Skills skills = new Skills();
			skills.Show();
			this.Hide();
		}

		private void QuestsButton_Click(object sender, EventArgs e)
		{

			Quests quests = new Quests();
			quests.Show();
			this.Hide();
		}

		private void MapButton_Click(object sender, EventArgs e)
		{

			Map map = new Map();
			map.Show();
			this.Hide();
		}

		private void SystemButton_Click(object sender, EventArgs e)
		{

			SystemTab systemTab = new SystemTab();
			systemTab.Show();
			this.Hide();
		}

		private void Status_Load(object sender, EventArgs e)
		{

			IEnumerable<XElement> stats = tempSave.Elements();

			foreach (var stat in stats)
			{

				ADCount.Text = (int.Parse(stat.Element("AttackDamage").Value) 
					+ int.Parse(stat.Element("EquipStats").Element("WeaponDamage").Value) 
					+ int.Parse(stat.Element("EquipStats").Element("GlovesDamage").Value) 
					+ int.Parse(stat.Element("EquipStats").Element("NecklaceDamage").Value)
					+ int.Parse(stat.Element("EquipStats").Element("RingDamage").Value)).ToString();

				CritChanceCount.Text = (int.Parse(stat.Element("CritChance").Value) 
					+ int.Parse(stat.Element("EquipStats").Element("WeaponCritChance").Value)
					+ int.Parse(stat.Element("Skills").Element("Passive1").Value)).ToString();

				CritDamageCount.Text = (float.Parse(stat.Element("CritDamage").Value) 
					+ float.Parse(stat.Element("EquipStats").Element("WeaponCritDamage").Value)).ToString();

				DefenseCount.Text = (int.Parse(stat.Element("Defense").Value)
					+ int.Parse(stat.Element("EquipStats").Element("ChestplateDefense").Value)
					+ int.Parse(stat.Element("EquipStats").Element("NecklaceDefense").Value)
					+ int.Parse(stat.Element("EquipStats").Element("RingDefense").Value)).ToString();

				DodgeChanceCount.Text = (int.Parse(stat.Element("DodgeChance").Value) 
					+ int.Parse(stat.Element("EquipStats").Element("HelmetDodgeChance").Value)
					+ int.Parse(stat.Element("EquipStats").Element("ChestplateDodgeChance").Value)
					+ int.Parse(stat.Element("EquipStats").Element("GlovesDodgeChance").Value)
					+ int.Parse(stat.Element("EquipStats").Element("BootsDodgeChance").Value)
					+ int.Parse(stat.Element("Skills").Element("Passive2").Value)).ToString();

				EnergyRegenCount.Text = (int.Parse(stat.Element("EnergyRegen").Value) 
					+ int.Parse(stat.Element("EquipStats").Element("HelmetEnergyRegen").Value)
					+ int.Parse(stat.Element("EquipStats").Element("ChestplateEnergyRegen").Value)
					+ int.Parse(stat.Element("EquipStats").Element("GlovesEnergyRegen").Value)
					+ int.Parse(stat.Element("EquipStats").Element("BootsEnergyRegen").Value)).ToString();

				ExpCount.Text = stat.Element("Experience").Value;

				HealthRegenCount.Text = (int.Parse(stat.Element("EquipStats").Element("HelmetHealthRegen").Value)
					+ int.Parse(stat.Element("EquipStats").Element("ChestplateHealthRegen").Value)
					+ int.Parse(stat.Element("EquipStats").Element("GlovesHealthRegen").Value)
					+ int.Parse(stat.Element("EquipStats").Element("BootsHealthRegen").Value)).ToString();

				LevelCount.Text = stat.Element("Level").Value;

				LifeStealCount.Text = stat.Element("EquipStats").Element("WeaponLifeSteal").Value;

				MaxEPCount.Text = (int.Parse(stat.Element("MaxEnergy").Value)
					+ int.Parse(stat.Element("EquipStats").Element("BootsEnergy").Value)
					+ int.Parse(stat.Element("EquipStats").Element("NecklaceEnergy").Value)
					+ int.Parse(stat.Element("EquipStats").Element("RingEnergy").Value)).ToString();

				MaxHPCount.Text = (int.Parse(stat.Element("MaxHealth").Value)
					+ int.Parse(stat.Element("EquipStats").Element("HelmetHealth").Value)
					+ int.Parse(stat.Element("EquipStats").Element("NecklaceHealth").Value)
					+ int.Parse(stat.Element("EquipStats").Element("RingHealth").Value)).ToString();

				StatusPointsCount.Text = stat.Element("StatusPoints").Value;
				DexCount.Text = stat.Element("DEX").Value;
				IntCount.Text = stat.Element("INT").Value;
				StaCount.Text = stat.Element("STA").Value;
				StrCount.Text = stat.Element("STR").Value;

				HPBar.Maximum = int.Parse(MaxHPCount.Text);
				EPBar.Maximum = int.Parse(MaxEPCount.Text);
				EPBar.Value = int.Parse(stat.Element("CurrentEnergy").Value);
				HPBar.Value = int.Parse(stat.Element("CurrentHealth").Value);
			}

			if (StatusPointsCount.Text != "0")
			{

				StrButton.Enabled = true;
				StaButton.Enabled = true;
				DexButton.Enabled = true;
				IntButton.Enabled = true;
			}
		}

		private void StrButton_Click(object sender, EventArgs e)
		{

			StatusPointsLabel.ForeColor = Color.Lime;
			StatusPointsCount.ForeColor = Color.Lime;
			StatusPointsCount.Text = (int.Parse(StatusPointsCount.Text) - 1).ToString();
			StrCount.ForeColor = Color.Lime;
			StrCount.Text = (int.Parse(StrCount.Text) + 1).ToString();
			ADLabel.ForeColor = Color.Lime;
			ADCount.ForeColor = Color.Lime;
			ADCount.Text = (int.Parse(ADCount.Text) + 1).ToString();

			StatusPoint0();

		}

		private void DexButton_Click(object sender, EventArgs e)
		{

			StatusPointsLabel.ForeColor = Color.Lime;
			StatusPointsCount.ForeColor = Color.Lime;
			StatusPointsCount.Text = (int.Parse(StatusPointsCount.Text) - 1).ToString();
			DexCount.ForeColor = Color.Lime;
			DexCount.Text = (int.Parse(DexCount.Text) + 1).ToString();
			DefenseLabel.ForeColor = Color.Lime;
			DefenseCount.ForeColor = Color.Lime;
			DefenseCount.Text = (int.Parse(DefenseCount.Text) + 1).ToString();

			StatusPoint0();
		}

		private void StaButton_Click(object sender, EventArgs e)
		{

			StatusPointsLabel.ForeColor = Color.Lime;
			StatusPointsCount.ForeColor = Color.Lime;
			StatusPointsCount.Text = (int.Parse(StatusPointsCount.Text) - 1).ToString();
			StaCount.ForeColor = Color.Lime;
			StaCount.Text = (int.Parse(StaCount.Text) + 1).ToString();
			MaxHPLabel.ForeColor = Color.Lime;
			MaxHPCount.ForeColor = Color.Lime;
			MaxHPCount.Text = (int.Parse(MaxHPCount.Text) + 3).ToString();

			StatusPoint0();
		}

		private void IntButton_Click(object sender, EventArgs e)
		{

			StatusPointsLabel.ForeColor = Color.Lime;
			StatusPointsCount.ForeColor = Color.Lime;
			StatusPointsCount.Text = (int.Parse(StatusPointsCount.Text) - 1).ToString();
			IntCount.ForeColor = Color.Lime;
			IntCount.Text = (int.Parse(IntCount.Text) + 1).ToString();
			MaxEPLabel.ForeColor = Color.Lime;
			MaxEPCount.ForeColor = Color.Lime;
			MaxEPCount.Text = (int.Parse(MaxEPCount.Text) + 2).ToString();

			StatusPoint0();
		}

		private void HPBar_MouseEnter(object sender, EventArgs e)
		{

			HP_EPToolTip.SetToolTip(HPBar, HPBar.Value.ToString() + "/" + HPBar.Maximum.ToString());
		}

		private void HPBar_MouseLeave(object sender, EventArgs e)
		{

			HP_EPToolTip.SetToolTip(HPBar, null);
		}

		private void EPBar_MouseEnter(object sender, EventArgs e)
		{

			HP_EPToolTip.SetToolTip(EPBar, EPBar.Value.ToString() + "/" + EPBar.Maximum.ToString());
		}

		private void EPBar_MouseLeave(object sender, EventArgs e)
		{

			HP_EPToolTip.SetToolTip(EPBar, null);
		}
	}
}