using System.Windows.Forms;
using System;
using System.Collections.Generic;
using System.Xml.Linq;
using System.IO;
using System.Linq;
using System.Drawing;

namespace RPG
{
	public partial class Shop : Form
	{

		string shopTag = "";
		string chosenItem = "";
		static string save = File.ReadAllText(@"res/Data/CurrentSave.txt");
		XElement tempSave = XElement.Load("res/Data/Temp" + save + ".xml");
		XElement shopkeepers = XElement.Load("res/Data/Shopkeepers.xml");
		XElement items = XElement.Load("res/Data/Items.xml");
		XElement tempInv = XElement.Load("res/Data/TempInventory" + save + ".xml");

		public Shop(string tag)
		{

			shopTag = tag;
			InitializeComponent();
		}

		public IEnumerable<Control> GetAll(Control control, Type type)
		{
			var controls = control.Controls.Cast<Control>();

			return controls.SelectMany(ctrl => GetAll(ctrl, type)).Concat(controls).Where(c => c.GetType() == type);
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

		public void InvLoad()
		{

			IEnumerable<XElement> stats = tempSave.Elements();
			IEnumerable<XElement> inv = tempInv.Elements();
			var controls = GetAll(this, typeof(PictureBox));

			foreach (var stat in stats)
			{

				for (int i = 1; i < 76; i++)
				{

					if (i.ToString() == stat.Element("EquipStats").Element("WeaponID").Value
						|| i.ToString() == stat.Element("EquipStats").Element("HelmetID").Value
						|| i.ToString() == stat.Element("EquipStats").Element("ChestplateID").Value
						|| i.ToString() == stat.Element("EquipStats").Element("GlovesID").Value
						|| i.ToString() == stat.Element("EquipStats").Element("BootsID").Value
						|| i.ToString() == stat.Element("EquipStats").Element("NecklaceID").Value
						|| i.ToString() == stat.Element("EquipStats").Element("RingID").Value)
					{

						continue;
					}

					foreach (var inven in inv)
					{

						if (inven.Element("Item" + i.ToString()).Element("ItemName").Value != "")
						{

							foreach (var control in controls)
							{

								if (control.Name == "pictureBox" + (i + 25).ToString())
								{

									control.BackgroundImage = Image.FromFile("res/Models/Items/" + inven.Element("Item" + i.ToString()).Element("ItemName").Value + ".png");
									control.Enabled = true;
								}

							}

						}

					}

				}

				GoldCountLabel.Text = stat.Element("Gold").Value;
			}
		}

		public void Destroy()
		{

			Updated("Items", "Item" + (int.Parse(chosenItem) - 25).ToString(), "ItemName", "", tempInv);
			var controls = GetAll(this, typeof(PictureBox));

			ItemDescription.Text = "Item's Stats";

			foreach (var control in controls)
			{

				if (control.Name == "pictureBox" + chosenItem)
				{

					control.Enabled = false;
					control.BackgroundImage = null;
				}

			}

			BuySellButton.Enabled = false;
			chosenItem = "";
		}

		public void ShowDesc(string type, string name, string action)
		{

			if (type == "Weapon")
			{

				var item = from itm in items.Elements("Weapons").Elements("Weapon") where (string)itm.Element("WeaponName") == name select itm;

				foreach (var Item in item)
				{

					ItemDescription.Text = "Item's name: " + Item.Element("WeaponName").Value + "\n\n" + Item.Element("WeaponDescription").Value;

					if (action == "Buy")
					{

						BuySellButton.Enabled = true;
						BuySellButton.Text = "Buy";
						ShopKeeperConversation.Text = "This will cost you " + Item.Element("BuyPrice").Value + " gold my dear friend!";
						ItemDescription.Text += "\n\nItem's cost: " + Item.Element("BuyPrice").Value + " gold";
					}

					else if (action == "Sell")
					{

						BuySellButton.Enabled = true;
						BuySellButton.Text = "Sell";
						ShopKeeperConversation.Text = "I will buy this from you for " + Item.Element("SellPrice").Value + " gold my dear customer!";
						ItemDescription.Text += "\n\nItem's sell price: " + Item.Element("SellPrice").Value + " gold";
					}

				}

			}

			else if (type == "Armor")
			{

				var item = from itm in items.Elements("Armors").Elements("Armor") where (string)itm.Element("ArmorName") == name select itm;

				foreach (var Item in item)
				{

					ItemDescription.Text = "Item's name: " + Item.Element("ArmorName").Value + "\n\n" + Item.Element("ArmorDescription").Value;

					if (action == "Buy")
					{

						BuySellButton.Enabled = true;
						BuySellButton.Text = "Buy";
						ShopKeeperConversation.Text = "This will cost you " + Item.Element("BuyPrice").Value + " gold my dear friend!";
						ItemDescription.Text += "\n\nItem's cost: " + Item.Element("BuyPrice").Value + " gold";
					}

					else if (action == "Sell")
					{

						BuySellButton.Enabled = true;
						BuySellButton.Text = "Sell";
						ShopKeeperConversation.Text = "I will buy this from you for " + Item.Element("SellPrice").Value + " gold my dear customer!";
						ItemDescription.Text += "\n\nItem's sell price: " + Item.Element("SellPrice").Value + " gold";
					}

				}

			}

			else if (type == "Accessory")
			{

				var item = from itm in items.Elements("Accessories").Elements("Accessory") where (string)itm.Element("AccessoryName") == name select itm;

				foreach (var Item in item)
				{

					ItemDescription.Text = "Item's name: " + Item.Element("AccessoryName").Value + "\n\n" + Item.Element("AccessoryDescription").Value;

					if (action == "Buy")
					{

						BuySellButton.Enabled = true;
						BuySellButton.Text = "Buy";
						ShopKeeperConversation.Text = "This will cost you " + Item.Element("BuyPrice").Value + " gold my dear friend!";
						ItemDescription.Text += "\n\nItem's cost: " + Item.Element("BuyPrice").Value + " gold";
					}

					else if (action == "Sell")
					{

						BuySellButton.Enabled = true;
						BuySellButton.Text = "Sell";
						ShopKeeperConversation.Text = "I will buy this from you for " + Item.Element("SellPrice").Value + " gold my dear customer!";
						ItemDescription.Text += "\n\nItem's sell price: " + Item.Element("SellPrice").Value + " gold";
					}

				}

			}

		}

		private void ShopItemClick(object sender, EventArgs e)
		{

			IEnumerable<XElement> sKeepers = shopkeepers.Elements();
			PictureBox picture = sender as PictureBox;
			chosenItem = picture.Name.Remove(0, 10);
			string number = "Item" + chosenItem;
			string name = "";
			string type = "";

			foreach (var keep in sKeepers)
			{

				name = keep.Element(number).Value;
				type = keep.Element(number + "Type").Value;
			}

			ShowDesc(type, name, "Buy");
		}

		private void WeaponSellClick(object sender, EventArgs e)
		{

			IEnumerable<XElement> inventory = tempInv.Elements();
			PictureBox picture = sender as PictureBox;
			chosenItem = picture.Name.Remove(0, 10);
			string number = "Item" + (int.Parse(chosenItem) - 25).ToString();
			string name = "";

			foreach (var inv in inventory)
			{

				name = inv.Element(number).Element("ItemName").Value;
			}

			ShowDesc("Weapon", name, "Sell");
		}

		private void ArmorSellClick(object sender, EventArgs e)
		{

			IEnumerable<XElement> inventory = tempInv.Elements();
			PictureBox picture = sender as PictureBox;
			chosenItem = picture.Name.Remove(0, 10);
			string number = "Item" + (int.Parse(chosenItem) - 25).ToString();
			string name = "";

			foreach (var inv in inventory)
			{

				name = inv.Element(number).Element("ItemName").Value;
			}

			ShowDesc("Armor", name, "Sell");
		}

		private void AccessorySellClick(object sender, EventArgs e)
		{

			IEnumerable<XElement> inventory = tempInv.Elements();
			PictureBox picture = sender as PictureBox;
			chosenItem = picture.Name.Remove(0, 10);
			string number = "Item" + (int.Parse(chosenItem) - 25).ToString();
			string name = "";

			foreach (var inv in inventory)
			{

				name = inv.Element(number).Element("ItemName").Value;
			}

			ShowDesc("Accessory", name, "Sell");
		}

		private void BackButton_Click(object sender, EventArgs e)
		{

			World world = new World("0");
			world.Show();
			this.Hide();
		}

		private void Shop_Load(object sender, EventArgs e)
		{

			ShopKeeperConversation.Text = "Greetings traveler. Feel free to look upon these items!";

			IEnumerable<XElement> stats = tempSave.Elements();
			var sKeepers = from keep in shopkeepers.Elements("Shopkeeper") where (string)keep.Element("ShopkeeperTag") == shopTag select keep;
			var controls = GetAll(this, typeof(PictureBox));
			
			for (int i = 1; i < 26; i++)
			{

				foreach (var keeper in sKeepers)
				{

					if (keeper.Element("Item" + i.ToString()).Value != "")
					{

						foreach (var control in controls)
						{

							if (control.Name == "pictureBox" + i.ToString())
							{

								control.BackgroundImage = Image.FromFile("res/Models/Items/" + keeper.Element("Item" + i.ToString()).Value + ".png");
								control.Enabled = true;
							}

						}

					}

					else
					{

						foreach (var control in controls)
						{

							if (control.Name == "pictureBox" + i.ToString())
							{

								control.BackgroundImage = null;
								control.Enabled = false;
							}

						}

					}

				}

			}

			InvLoad();
		}

		private void BuySellButton_Click(object sender, EventArgs e)
		{

			IEnumerable<XElement> inv = tempInv.Elements();
			IEnumerable<XElement> stats = tempSave.Elements();

			if (BuySellButton.Text == "Buy")
			{

				string name = "";
				string type = "";
				string cost = "";
				var sKeepers = from keep in shopkeepers.Elements("Shopkeeper") where (string)keep.Element("ShopkeeperTag") == shopTag select keep;

				foreach (var keep in sKeepers)
				{

					name = keep.Element("Item" + chosenItem).Value;
					type = keep.Element("Item" + chosenItem + "Type").Value;
				}

				if (type == "Weapon")
				{

					var item = from itm in items.Elements("Weapons").Elements("Weapon") where (string)itm.Element("WeaponName") == name select itm;

					foreach (var Item in item)
					{

						cost = Item.Element("BuyPrice").Value;
					}

				}

				else if (type == "Armor")
				{

					var item = from itm in items.Elements("Armors").Elements("Armor") where (string)itm.Element("ArmorName") == name select itm;

					foreach (var Item in item)
					{

						cost = Item.Element("BuyPrice").Value;
					}

				}

				else if (type == "Accessory")
				{

					var item = from itm in items.Elements("Accessories").Elements("Accessory") where (string)itm.Element("AccessoryName") == name select itm;

					foreach (var Item in item)
					{

						cost = Item.Element("BuyPrice").Value;
					}

				}

				if (int.Parse(cost) > int.Parse(GoldCountLabel.Text))
				{

					ShopKeeperConversation.Text = "Wow wow, my friend. You don't have money for this!";
				}

				else
				{

					bool bought = false;

					if (type == "Weapon")
					{

						for (int i = 1; i < 26; i++)
						{

							foreach (var inven in inv)
							{

								if (inven.Element("Item" + i.ToString()).Element("ItemName").Value == "")
								{

									Updated("Items", "Item" + i.ToString(), "ItemName", name, tempInv);
									bought = true;
								}

							}

							if (bought)
							{

								Updated("Player", "Gold", "0", (int.Parse(GoldCountLabel.Text) - int.Parse(cost)).ToString(), tempSave);
								ShopKeeperConversation.Text = "Greeting for buying a new item, my dear friend!";
								InvLoad();
								break;
							}

						}

					}

					else if (type == "Armor")
					{

						for (int i = 26; i < 51; i++)
						{

							foreach (var inven in inv)
							{

								if (inven.Element("Item" + i.ToString()).Element("ItemName").Value == "")
								{

									Updated("Items", "Item" + i.ToString(), "ItemName", name, tempInv);
									bought = true;
								}

							}

							if (bought)
							{

								Updated("Player", "Gold", "0", (int.Parse(GoldCountLabel.Text) - int.Parse(cost)).ToString(), tempSave);
								ShopKeeperConversation.Text = "Greeting for buying a new item, my dear friend!";
								InvLoad();
								break;
							}

						}

					}

					else if (type == "Accessory")
					{

						for (int i = 51; i < 76; i++)
						{

							foreach (var inven in inv)
							{

								if (inven.Element("Item" + i.ToString()).Element("ItemName").Value == "")
								{

									Updated("Items", "Item" + i.ToString(), "ItemName", name, tempInv);
									bought = true;
								}

							}

							if (bought)
							{

								Updated("Player", "Gold", "0", (int.Parse(GoldCountLabel.Text) - int.Parse(cost)).ToString(), tempSave);
								ShopKeeperConversation.Text = "Greeting for buying a new item, my dear friend!";
								InvLoad();
								break;
							}

						}

					}

					if (!bought)
					{

						ShopKeeperConversation.Text = "Wait wait, you don't have enough space in your inventory!";
					}

					else
					{

						ShopKeeperConversation.Text = "Thank you for your support!";
					}

				}

			}

			else if (BuySellButton.Text == "Sell")
			{

				string name = "";
				string cost = "";

				foreach (var inven in inv)
				{

					name = inven.Element("Item" + (int.Parse(chosenItem) - 25).ToString()).Element("ItemName").Value;
				}

				if (int.Parse(chosenItem) > 25 && int.Parse(chosenItem) < 51)
				{

					var item = from itm in items.Elements("Weapons").Elements("Weapon") where (string)itm.Element("WeaponName") == name select itm;

					foreach (var Item in item)
					{

						cost = Item.Element("SellPrice").Value;
					}

				}

				else if (int.Parse(chosenItem) > 50 && int.Parse(chosenItem) < 76)
				{

					var item = from itm in items.Elements("Armors").Elements("Armor") where (string)itm.Element("ArmorName") == name select itm;

					foreach (var Item in item)
					{

						cost = Item.Element("SellPrice").Value;
					}

				}

				else if (int.Parse(chosenItem) > 75 && int.Parse(chosenItem) < 101)
				{

					var item = from itm in items.Elements("Accessories").Elements("Accessory") where (string)itm.Element("AccessoryName") == name select itm;

					foreach (var Item in item)
					{

						cost = Item.Element("SellPrice").Value;
					}

				}

				Destroy();

				foreach (var stat in stats)
				{

					cost = (int.Parse(cost) + int.Parse(stat.Element("Gold").Value)).ToString();
				}

				Updated("Player", "Gold", "0", cost, tempSave);

				InvLoad();

				ShopKeeperConversation.Text = "Thank you for your support!";
			}

		}

		private void ShopKeeperConversation_Click(object sender, EventArgs e)
		{

			this.ActiveControl = null;
		}

		private void ItemDescription_Click(object sender, EventArgs e)
		{

			this.ActiveControl = null;
		}
	}
}