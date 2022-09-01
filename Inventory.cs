using System.Windows.Forms;
using System;
using System.Collections.Generic;
using System.Xml.Linq;
using System.IO;
using System.Linq;
using System.Drawing;

namespace RPG
{
	public partial class Inventory : Form
	{

		string chosenItem = "";
		static string save = File.ReadAllText(@"res/Data/CurrentSave.txt");
		XElement tempSave = XElement.Load("res/Data/Temp" + save + ".xml");
		XElement tempInv = XElement.Load("res/Data/TempInventory" + save + ".xml");
		XElement items = XElement.Load("res/Data/Items.xml");

		public Inventory()
		{

			InitializeComponent();
		}

		public void Destroy()
		{

			Updated("Items", "Item" + chosenItem, "ItemName", "", tempInv);
			var controls = GetAll(this, typeof(PictureBox));

			EquipButton.Enabled = false;
			DestroyButton.Enabled = false;
			ItemNameLabel.Text = "Item's Name";
			ItemDescription.Text = "Item's Stats";
			BigItem.BackgroundImage = null;

			foreach (var control in controls)
			{

				if (control.Name == "pictureBox" + chosenItem)
				{

					control.Enabled = false;
					control.BackgroundImage = null;
				}

			}

			chosenItem = "";
		}

		public void Equip(string number, string name, string value, object sender)
		{

			Button btn = sender as Button;

			if (btn.Text == "Equip")
			{

				Updated("Items", "Item" + number, "Equipped", "1", tempInv);

				string effect1 = "";
				string effectStat1 = "";
				string effect2 = "";
				string effectStat2 = "";
				string type = "";

				if (int.Parse(number) <= 25)
				{

					for (int i = 1; i < 26; i++)
					{

						if (i == int.Parse(number))
						{

							continue;
						}

						else
						{

							Updated("Items", "Item" + i.ToString(), "Equipped", "0", tempInv);
						}

					}

					Updated("Player", "EquipStats", "WeaponID", number, tempSave);

					var item = from itm in items.Elements("Weapons").Elements("Weapon") where (string)itm.Element("WeaponName") == name select itm;
					string damage = "";

					foreach (var itm in item)
					{

						damage = itm.Element("WeaponDamage").Value;
						effect1 = itm.Element("WeaponMagicEffect1").Value;
						effectStat1 = itm.Element("WeaponMagicStat1").Value;
						effect2 = itm.Element("WeaponMagicEffect2").Value;
						effectStat2 = itm.Element("WeaponMagicStat2").Value;
					}

					Updated("Player", "EquipStats", "WeaponDamage", damage, tempSave);
					Updated("Player", "EquipStats", "WeaponCritDamage", value, tempSave);
					Updated("Player", "EquipStats", "WeaponCritChance", value, tempSave);
					Updated("Player", "EquipStats", "WeaponLifeSteal", value, tempSave);

					if (effect1 != "")
					{

						Updated("Player", "EquipStats", "Weapon" + effect1, effectStat1, tempSave);
					}

					if (effect2 != "")
					{

						Updated("Player", "EquipStats", "Weapon" + effect2, effectStat2, tempSave);
					}

					CheckEquip("Weapon");
				}

				else if (int.Parse(number) > 25 && int.Parse(number) <= 50)
				{

					for (int i = 25; i < 51; i++)
					{

						if (i == int.Parse(number))
						{

							continue;
						}

						Updated("Items", "Item" + i.ToString(), "Equipped", "0", tempInv);
					}

					var item = from itm in items.Elements("Armors").Elements("Armor") where (string)itm.Element("ArmorName") == name select itm;
					string stat = "";
					string statValue = "";

					foreach (var itm in item)
					{

						stat = itm.Element("ArmorStat").Value;
						type = itm.Element("ArmorType").Value;
						statValue = itm.Element("Armor" + stat).Value;
						effect1 = itm.Element("ArmorMagicEffect1").Value;
						effectStat1 = itm.Element("ArmorMagicStat1").Value;
						effect2 = itm.Element("ArmorMagicEffect2").Value;
						effectStat2 = itm.Element("ArmorMagicStat2").Value;
					}

					Updated("Player", "EquipStats", type + "ID", number, tempSave);
					Updated("Player", "EquipStats", type + stat, statValue, tempSave);
					Updated("Player", "EquipStats", type + "HealthRegen", value, tempSave);
					Updated("Player", "EquipStats", type + "EnergyRegen", value, tempSave);
					Updated("Player", "EquipStats", type + "DodgeChance", value, tempSave);

					if (effect1 != "")
					{

						Updated("Player", "EquipStats", type + effect1, effectStat1, tempSave);
					}

					if (effect2 != "")
					{

						Updated("Player", "EquipStats", type + effect2, effectStat2, tempSave);
					}

					CheckEquip(type);
				}

				else if (int.Parse(number) > 50 && int.Parse(number) <= 75)
				{

					for (int i = 50; i < 76; i++)
					{

						if (i == int.Parse(number))
						{

							continue;
						}

						Updated("Items", "Item" + i.ToString(), "Equipped", "0", tempInv);
					}

					var item = from itm in items.Elements("Accessories").Elements("Accessory") where (string)itm.Element("AccessoryName") == name select itm;

					foreach (var itm in item)
					{

						type = itm.Element("AccessoryType").Value;
						effect1 = itm.Element("AccessoryMagicEffect1").Value;
						effectStat1 = itm.Element("AccessoryMagicStat1").Value;
						effect2 = itm.Element("AccessoryMagicEffect2").Value;
						effectStat2 = itm.Element("AccessoryMagicStat2").Value;
					}

					Updated("Player", "EquipStats", type + "ID", number, tempSave);
					Updated("Player", "EquipStats", type + "Damage", value, tempSave);
					Updated("Player", "EquipStats", type + "Defense", value, tempSave);
					Updated("Player", "EquipStats", type + "Health", value, tempSave);
					Updated("Player", "EquipStats", type + "Energy", value, tempSave);
					Updated("Player", "EquipStats", type + effect1, effectStat1, tempSave);

					if (effect2 != "")
					{

						Updated("Player", "EquipStats", type + effect2, effectStat2, tempSave);
					}

					CheckEquip(type);
				}

				DestroyButton.Enabled = false;
				EquipButton.Text = "Unequip";

			}

			else if (btn.Text == "Use")
			{

				IEnumerable<XElement> stats = tempSave.Elements();
				string health = "";
				string energy = "";
				string maxHealth = "";
				string maxEnergy = "";
				string effect = "";

				foreach (var stat in stats)
				{

					health = stat.Element("CurrentHealth").Value;
					energy = stat.Element("CurrentEnergy").Value;
					maxHealth = stat.Element("MaxHealth").Value;
					maxEnergy = stat.Element("MaxEnergy").Value;
				}

				var item = from itm in items.Elements("Consumables").Elements("Consumable") where (string)itm.Element("ConsumableName") == name select itm;

				foreach (var itm in item)
				{

					effect = itm.Element("ConsumableEffect").Value;
				}

				if (effect == "Health")
				{

					if (health == maxHealth)
					{

						MessageBox.Show("Your health is already full!", "Warning!");
					}

					else
					{

						health = (int.Parse(health) + int.Parse(maxHealth) / 2).ToString();

						if (int.Parse(health) > int.Parse(maxHealth))
						{

							health = maxHealth;
						}

						Updated("Player", "CurrentHealth", "0", health, tempSave);
						Destroy();
					}

				}

				else if (effect == "Energy")
				{

					if (energy == maxEnergy)
					{

						MessageBox.Show("Your energy is already full!", "Warning!");
					}

					else
					{

						energy = (int.Parse(energy) + int.Parse(maxEnergy) / 2).ToString();

						if (int.Parse(energy) > int.Parse(maxEnergy))
						{

							energy = maxEnergy;
						}

						Updated("Player", "CurrentEnergy", "0", energy, tempSave);
						Destroy();
					}

				}

			}

			else if (btn.Text == "Unequip")
			{

				Updated("Items", "Item" + number, "Equipped", value, tempInv);

				string type = "";

				if (int.Parse(number) <= 25)
				{

					Updated("Player", "EquipStats", "WeaponID", value, tempSave);
					Updated("Player", "EquipStats", "WeaponDamage", value, tempSave);
					Updated("Player", "EquipStats", "WeaponCritDamage", value, tempSave);
					Updated("Player", "EquipStats", "WeaponCritChance", value, tempSave);
					Updated("Player", "EquipStats", "WeaponLifeSteal", value, tempSave);

					CheckEquip("Weapon");
				}

				else if (int.Parse(number) > 25 && int.Parse(number) <= 50)
				{

					var item = from itm in items.Elements("Armors").Elements("Armor") where (string)itm.Element("ArmorName") == name select itm;
					string stat = "";

					foreach (var itm in item)
					{

						stat = itm.Element("ArmorStat").Value;
						type = itm.Element("ArmorType").Value;
					}

					Updated("Player", "EquipStats", type + "ID", value, tempSave);
					Updated("Player", "EquipStats", type + stat, value, tempSave);
					Updated("Player", "EquipStats", type + "HealthRegen", value, tempSave);
					Updated("Player", "EquipStats", type + "EnergyRegen", value, tempSave);
					Updated("Player", "EquipStats", type + "DodgeChance", value, tempSave);

					CheckEquip(type);
				}

				else if (int.Parse(number) > 50 && int.Parse(number) <= 75)
				{

					var item = from itm in items.Elements("Accessories").Elements("Accessory") where (string)itm.Element("AccessoryName") == name select itm;

					foreach (var itm in item)
					{

						type = itm.Element("AccessoryType").Value;
					}

					Updated("Player", "EquipStats", type + "ID", number, tempSave);
					Updated("Player", "EquipStats", type + "Damage", value, tempSave);
					Updated("Player", "EquipStats", type + "Defense", value, tempSave);
					Updated("Player", "EquipStats", type + "Health", value, tempSave);
					Updated("Player", "EquipStats", type + "Energy", value, tempSave);

					CheckEquip(type);
				}

				DestroyButton.Enabled = true;
				EquipButton.Text = "Equip";
			}
	
		}

		public void ShowDesc(string number, string equip, string name)
		{

			if (int.Parse(number) <= 25)
			{

				var item = from itm in items.Elements("Weapons").Elements("Weapon") where (string)itm.Element("WeaponName") == name select itm;

				foreach (var Item in item)
				{

					ItemNameLabel.Text = Item.Element("WeaponName").Value;
					ItemDescription.Text = Item.Element("WeaponDescription").Value;
				}

				if (equip == "0")
				{

					EquipButton.Enabled = true;
					DestroyButton.Enabled = true;
					EquipButton.Text = "Equip";
				}

				else
				{

					EquipButton.Enabled = true;
					DestroyButton.Enabled = false;
					EquipButton.Text = "Unequip";
				}

			}

			else if (int.Parse(number) > 25 && int.Parse(number) <= 50)
			{

				var item = from itm in items.Elements("Armors").Elements("Armor") where (string)itm.Element("ArmorName") == name select itm;

				foreach (var Item in item)
				{

					ItemNameLabel.Text = Item.Element("ArmorName").Value;
					ItemDescription.Text = Item.Element("ArmorDescription").Value;
				}

				if (equip == "0")
				{

					EquipButton.Enabled = true;
					DestroyButton.Enabled = true;
					EquipButton.Text = "Equip";
				}

				else
				{

					EquipButton.Enabled = true;
					DestroyButton.Enabled = false;
					EquipButton.Text = "Unequip";
				}
			}

			else if (int.Parse(number) > 50 && int.Parse(number) <= 75)
			{

				var item = from itm in items.Elements("Accessories").Elements("Accessory") where (string)itm.Element("AccessoryName") == name select itm;

				foreach (var Item in item)
				{

					ItemNameLabel.Text = Item.Element("AccessoryName").Value;
					ItemDescription.Text = Item.Element("AccessoryDescription").Value;
				}

				if (equip == "0")
				{

					EquipButton.Enabled = true;
					DestroyButton.Enabled = true;
					EquipButton.Text = "Equip";
				}

				else
				{

					EquipButton.Enabled = true;
					DestroyButton.Enabled = false;
					EquipButton.Text = "Unequip";
				}
			}

			else if (int.Parse(number) > 75 && int.Parse(number) <= 100)
			{

				var item = from itm in items.Elements("Consumables").Elements("Consumable") where (string)itm.Element("ConsumableName") == name select itm;

				foreach (var Item in item)
				{

					ItemNameLabel.Text = Item.Element("ConsumableName").Value;
					ItemDescription.Text = Item.Element("ConsumableDescription").Value;
				}

				EquipButton.Enabled = true;
				DestroyButton.Enabled = false;
				EquipButton.Text = "Use";
			}

			else if (int.Parse(number) > 100 && int.Parse(number) <= 125)
			{

				var item = from itm in items.Elements("QuestItems").Elements("QuestItem") where (string)itm.Element("QuestItemName") == name select itm;

				foreach (var Item in item)
				{

					ItemNameLabel.Text = Item.Element("QuestItemName").Value;
					ItemDescription.Text = Item.Element("QuestItemDescription").Value;
				}

				EquipButton.Enabled = false;
				DestroyButton.Enabled = false;
			}
		}

		public void CheckEquip(string type)
		{

			IEnumerable<XElement> stats = tempSave.Elements();
			IEnumerable<XElement> inv = tempInv.Elements();
			var pictures = GetAll(this, typeof(PictureBox));
			var labels = GetAll(this, typeof(Label));
			string name = "";

			foreach (var item in stats)
			{

				if (item.Element("EquipStats").Element(type + "ID").Value != "0")
				{

					foreach (var picture in pictures)
					{

						if (picture.Name == type)
						{

							picture.Enabled = true;
							
							foreach (var inven in inv)
							{

								name = inven.Element("Item" + item.Element("EquipStats").Element(type + "ID").Value).Element("ItemName").Value;
							}

							picture.BackgroundImage = Image.FromFile("res/Models/Items/" + name + ".png");
						}

					}

					foreach (var label in labels)
					{

						if (label.Name == type + "Label")
						{

							label.Visible = false;
						}

					}

				}

				else
				{

					foreach (var picture in pictures)
					{

						if (picture.Name == type)
						{

							picture.Enabled = false;
							picture.BackgroundImage = null;
						}

					}

					foreach (var label in labels)
					{

						if (label.Name == type + "Label")
						{

							label.Visible = true;
						}

					}
				}

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

		public IEnumerable<Control> GetAll(Control control, Type type)
		{
			var controls = control.Controls.Cast<Control>();

			return controls.SelectMany(ctrl => GetAll(ctrl, type)).Concat(controls).Where(c => c.GetType() == type);
		}

		private void InvItemClick(object sender, EventArgs e)
		{

			IEnumerable<XElement> inventory = tempInv.Elements();
			PictureBox picture = sender as PictureBox;
			chosenItem = picture.Name.Remove(0, 10);
			string number = "Item" + chosenItem;
			string name = "";
			string equip = "";

			BigItem.BackgroundImage = picture.BackgroundImage;

			foreach (var inv in inventory)
			{

				name = inv.Element(number).Element("ItemName").Value;

				if (int.Parse(chosenItem) > 75 && int.Parse(chosenItem) <= 125)
				{

					equip = "0";
				}

				else
				{

					equip = inv.Element(number).Element("Equipped").Value;
				}

			}

			ShowDesc(chosenItem, equip, name);
		}

		private void EquipItemClick(object sender, EventArgs e)
		{

			IEnumerable<XElement> stats = tempSave.Elements();
			IEnumerable<XElement> inv = tempInv.Elements();
			PictureBox picture = sender as PictureBox;
			string pictureName = picture.Name;
			string ID = "";
			string itemName = "";
			string equip = "";

			foreach (var item in stats)
			{

				ID = item.Element("EquipStats").Element(pictureName + "ID").Value;
			}

			foreach (var item in inv)
			{

				itemName = item.Element("Item" + ID).Element("ItemName").Value;
				equip = item.Element("Item" + ID).Element("Equipped").Value;
			}

			ShowDesc(ID, equip, itemName);
		}

		private void Inventory_KeyDown(object sender, KeyEventArgs e)
		{

			if (e.Alt && e.KeyCode == Keys.F4)
			{

				e.Handled = true;
				MessageBox.Show("This function is disabled due to possible file corruption", "Warning!");
			}
		}

		private void StatusButton_Click(object sender, EventArgs e)
		{
			
			Status status = new Status();
			status.Show();
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

		private void Inventory_Load(object sender, EventArgs e)
		{

			IEnumerable<XElement> stats = tempSave.Elements();
			IEnumerable<XElement> inv = tempInv.Elements();
			var controls = GetAll(this, typeof(PictureBox));

			foreach (var stat in stats)
			{

				GoldCountLabel.Text = stat.Element("Gold").Value;
			}

			for (int i = 1; i < 126; i++)
			{

				foreach (var inven in inv)
				{

					if (inven.Element("Item" + i.ToString()).Element("ItemName").Value != "")
					{

						foreach (var control in controls)
						{

							if (control.Name == "pictureBox" + i.ToString())
							{

								control.BackgroundImage = Image.FromFile("res/Models/Items/" + inven.Element("Item" + i.ToString()).Element("ItemName").Value + ".png");
								control.Enabled = true;
							}

						}

					}

				}

			}

			CheckEquip("Weapon");
			CheckEquip("Helmet");
			CheckEquip("Chestplate");
			CheckEquip("Gloves");
			CheckEquip("Boots");
			CheckEquip("Ring");
			CheckEquip("Necklace");

		}

		private void EquipButton_Click(object sender, EventArgs e)
		{

			IEnumerable<XElement> inv = tempInv.Elements();
			string name = "";

			foreach (var item in inv)
			{

				name = item.Element("Item" + chosenItem).Element("ItemName").Value;
			}

			Equip(chosenItem, name, "0", sender);
		}

		private void DestroyButton_Click(object sender, EventArgs e)
		{

			DialogResult result;
			result = MessageBox.Show("Are you sure you want to destroy this item?", "Are you sure?", MessageBoxButtons.YesNo);

			if (result == DialogResult.Yes)
			{

				Destroy();
			}

		}

		private void ItemDescription_Click(object sender, EventArgs e)
		{

			this.ActiveControl = null;
		}
	}
}