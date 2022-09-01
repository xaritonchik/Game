using System.Windows.Forms;
using System;
using System.Collections.Generic;
using System.Xml.Linq;
using System.IO;
using System.Linq;
using System.Drawing;

namespace RPG
{
	public partial class World : Form
	{

		bool walk = false;
		bool rightCollision = false;
		bool leftCollision = false;
		bool upCollision = false;
		bool downCollision = false;
		string defeatedName, village;
		string locationLeft, locationRight, locationUp, locationDown;
		string collision = "";
		string questGiveVillager = "";
		string questReceiveVillager = "";
		static string save = File.ReadAllText(@"res/Data/CurrentSave.txt");
		XElement tempInv = XElement.Load("res/Data/TempInventory" + save + ".xml");
		XElement tempSave = XElement.Load("res/Data/Temp" + save + ".xml");
		XElement map = XElement.Load("res/Data/TempMap" + save + ".xml");
		XElement quests = XElement.Load("res/Data/TempQuests" + save + ".xml");

		public World(string name)
		{

			defeatedName = name;
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

		public void LocationLoad(string name, bool reset)
		{

			var controls = GetAll(this, typeof(PictureBox));
			var location = from loc in map.Elements("Location").Elements("MiniLocation") where (string)loc.Element("MiniLocationTag") == name select loc;
			List<XElement> change;

			if (reset)
			{

				string locName = "";
				IEnumerable<XElement> stats = tempSave.Elements();

				foreach (var stat in stats)
				{

					locName = stat.Element("MiniLocation").Value;
				}

				var locs = from loc in map.Elements("Location").Elements("MiniLocation") where (string)loc.Element("MiniLocationTag") == locName select loc;

				foreach (var loc in locs)
				{

					for (int i = 1; i < 5; i++)
					{

						if (loc.Element("Enemy" + i.ToString() + "Status").Value == "Defeated")
						{

							var temp = locs.Elements("Enemy" + i.ToString() + "Status").ToList();

							foreach (var elem in temp)
							{

								elem.ReplaceNodes("Undefeated");
								map.Save("res/Data/TempMap" + save + ".xml");
							}

						}

					}

				}

			}

			foreach (var loc in location)
			{

				village = loc.Element("Village").Value;
				locationLeft = loc.Element("MiniLocationTagLeft").Value;
				locationRight = loc.Element("MiniLocationTagRight").Value;
				locationUp = loc.Element("MiniLocationTagUp").Value;
				locationDown = loc.Element("MiniLocationTagDown").Value;

				Updated("Player", "MiniLocation", "0", loc.Element("MiniLocationTag").Value, tempSave);

				for (int i = 1; i < 5; i++)
				{

					if (loc.Element("Enemy" + i.ToString()).Value != "0" && loc.Element("Enemy" + i.ToString() + "Status").Value != "Defeated")
					{

						foreach (var control in controls)
						{

							if (control.Name == "Enemy" + i.ToString())
							{

								control.Tag = loc.Element("Enemy" + i.ToString()).Value;
								control.BackgroundImage = Image.FromFile("res/EvilMobs/" + loc.Element("Enemy" + i.ToString()).Value + ".png");
								control.Location = new Point(int.Parse(loc.Element("Enemy" + i.ToString() + "X").Value), int.Parse(loc.Element("Enemy" + i.ToString() + "Y").Value));
								Image image = Image.FromFile("res/EvilMobs/" + loc.Element("Enemy" + i.ToString()).Value + ".png");
								control.Width = image.Width;
								control.Height = image.Height;
							}

						}

					}

					else
					{

						foreach (var control in controls)
						{

							if (control.Name == "Enemy" + i.ToString())
							{

								control.Tag = "0";
								control.BackgroundImage = null;
								control.Location = new Point(0, 0);
							}

						}

					}

					if (loc.Element("Villager" + i.ToString()).Value != "0")
					{

						foreach (var control in controls)
						{

							if (control.Name == "Villager" + i.ToString())
							{

								if (loc.Element("Villager" + i.ToString() + "Type").Value == "Villager")
								{

									control.Tag = "Villager";
									control.BackgroundImage = Image.FromFile("res/NPCs/Villager.png");
									control.Location = new Point(int.Parse(loc.Element("Villager" + i.ToString() + "X").Value), int.Parse(loc.Element("Villager" + i.ToString() + "Y").Value));
									Image image = Image.FromFile("res/NPCs/Villager.png");
									control.Width = image.Width;
									control.Height = image.Height;
								}

								else if (loc.Element("Villager" + i.ToString() + "Type").Value == "Shopkeeper")
								{

									control.Tag = loc.Element("Villager" + i.ToString()).Value;
									control.BackgroundImage = Image.FromFile("res/NPCs/Shopkeeper.png");
									control.Location = new Point(int.Parse(loc.Element("Villager" + i.ToString() + "X").Value), int.Parse(loc.Element("Villager" + i.ToString() + "Y").Value));
									Image image = Image.FromFile("res/NPCs/Shopkeeper.png");
									control.Width = image.Width;
									control.Height = image.Height;
								}

								else if (loc.Element("Villager" + i.ToString() + "Type").Value == "Quest")
								{

									var questGive = from q in quests.Elements("Quest") where (string)q.Element("QuestGiver") == loc.Element("Villager" + i.ToString()).Value select q;
									var questReceive = from q in quests.Elements("Quest") where (string)q.Element("QuestReceiver") == loc.Element("Villager" + i.ToString()).Value select q;
									bool questStat = true;

									foreach (var q in questGive)
									{

										if (q.Element("QuestStatus").Value == "NotTaken")
										{

											questGiveVillager = loc.Element("Villager" + i.ToString()).Value;
											Image image = Image.FromFile("res/NPCs/Villager.png");
											control.Width = image.Width;
											control.Height = image.Height;
											control.Tag = "QuestGiver";
											control.BackgroundImage = Image.FromFile("res/NPCs/Villager.png");
											control.Location = new Point(int.Parse(loc.Element("Villager" + i.ToString() + "X").Value), int.Parse(loc.Element("Villager" + i.ToString() + "Y").Value));
											image = Image.FromFile("res/Models/Icons/UncompletedQuestIcon.png");
											QuestStatus.Width = image.Width;
											QuestStatus.Height = image.Height;
											QuestStatus.Location = new Point(control.Location.X + 15, control.Location.Y - QuestStatus.Height - 5);
											QuestStatus.BackgroundImage = Image.FromFile("res/Models/Icons/UncompletedQuestIcon.png");
											QuestStatus.Tag = "NotTaken";
											questStat = false;
										}

									}

									foreach (var q in questReceive)
									{

										if (q.Element("QuestStatus").Value == "Completed" && loc.Element("Villager" + i.ToString()).Value == q.Element("QuestReceiver").Value)
										{

											questReceiveVillager = loc.Element("Villager" + i.ToString()).Value;
											Image image = Image.FromFile("res/NPCs/Villager.png");
											control.Width = image.Width;
											control.Height = image.Height;
											control.Tag = "QuestReceiver";
											control.BackgroundImage = Image.FromFile("res/NPCs/Villager.png");
											control.Location = new Point(int.Parse(loc.Element("Villager" + i.ToString() + "X").Value), int.Parse(loc.Element("Villager" + i.ToString() + "Y").Value));
											image = Image.FromFile("res/Models/Icons/CompletedQuestIcon.png");
											QuestStatus.Width = image.Width;
											QuestStatus.Height = image.Height;
											QuestStatus.Location = new Point(control.Location.X + 9, control.Location.Y - QuestStatus.Height - 7);
											QuestStatus.BackgroundImage = Image.FromFile("res/Models/Icons/CompletedQuestIcon.png");
											QuestStatus.Tag = "Completed";
											questStat = false;
										}

									}

									if (questStat)
									{

										control.Tag = "Villager";
										control.BackgroundImage = Image.FromFile("res/NPCs/Villager.png");
										control.Location = new Point(int.Parse(loc.Element("Villager" + i.ToString() + "X").Value), int.Parse(loc.Element("Villager" + i.ToString() + "Y").Value));
										Image image = Image.FromFile("res/NPCs/Villager.png");
										control.Width = image.Width;
										control.Height = image.Height;
										QuestStatus.Location = new Point(0, 0);
										QuestStatus.BackgroundImage = null;
										QuestStatus.Tag = "0";
										QuestStatus.Width = 2;
										QuestStatus.Height = 2;
									}

								}

							}

						}

					}

					else
					{

						foreach (var control in controls)
						{

							if (control.Name == "Villager" + i.ToString())
							{

								control.Tag = "0";
								control.BackgroundImage = null;
								control.Location = new Point(0, 0);
							}

						}

					}

				}

			}

			if (defeatedName != "0")
			{

				foreach (var control in controls)
				{

					if (control.Tag.ToString() == defeatedName)
					{

						control.Tag = "0";
						control.BackgroundImage = null;
						control.Location = new Point(0, 0);
					}

				}

				foreach (var loc in location)
				{

					for (int i = 1; i < 5; i++)
					{

						if (loc.Element("Enemy" + i.ToString()).Value == defeatedName)
						{

							change = location.Elements("Enemy" + i.ToString() + "Status").ToList();

							foreach (var ch in change)
							{

								ch.ReplaceNodes("Defeated");
								map.Save("res/Data/TempMap" + save + ".xml");
							}

						}

					}

				}

				defeatedName = "0";
			}

			Structures("Fountain", name);
			Structures("Chest", name);
			Structures("LockedChest", name);
		}

		public void Structures(string struc, string name)
		{

			var controls = GetAll(this, typeof(PictureBox));
			var location = from loc in map.Elements("Location").Elements("MiniLocation") where (string)loc.Element("MiniLocationTag") == name select loc;

			foreach (var loc in location)
			{

				if (loc.Element(struc).Value != "0")
				{

					foreach (var control in controls)
					{

						if (control.Name == struc && loc.Element(struc + "Status").Value == "Enabled")
						{

							control.BackgroundImage = Image.FromFile("res/Models/Objects/" + struc + ".png");
							control.Location = new Point(int.Parse(loc.Element(struc + "X").Value), int.Parse(loc.Element(struc + "Y").Value));
							control.Tag = loc.Element(struc + "Status").Value;
							Image image = Image.FromFile("res/Models/Objects/" + struc + ".png");
							control.Width = image.Width;
							control.Height = image.Height;
						}

						else if (control.Name == struc && loc.Element(struc + "Status").Value == "Disabled")
						{

							control.BackgroundImage = Image.FromFile("res/Models/Objects/" + struc + "Used.png");
							control.Location = new Point(int.Parse(loc.Element(struc + "X").Value), int.Parse(loc.Element(struc + "Y").Value));
							control.Tag = loc.Element(struc + "Status").Value;
							Image image = Image.FromFile("res/Models/Objects/" + struc + "Used.png");
							control.Width = image.Width;
							control.Height = image.Height;
						}

					}

				}

				else
				{

					foreach (var control in controls)
					{

						if (control.Name == struc)
						{

							control.BackgroundImage = null;
							control.Location = new Point(0, 0);
							control.Tag = "0";
						}

					}

				}

			}

		}

		public void HealthEnergy(string temp)
		{

			IEnumerable<XElement> x = tempSave.Elements();
			string temp2 = "";

			foreach (var xElement in x)
			{

				temp2 = xElement.Element("Max" + temp).Value;
			}

			Updated("Player", "Current" + temp, "0", temp2, tempSave);
		}

		public void SaveLoc()
		{

			Updated("Player", "LocationX", "0", Player.Location.X.ToString(), tempSave);
			Updated("Player", "LocationY", "0", Player.Location.Y.ToString(), tempSave);
		}

		public void ChestOpen(string name)
		{

			string locName = "";
			IEnumerable<XElement> stats = tempSave.Elements();
			IEnumerable<XElement> inv = tempInv.Elements();

			foreach (var stat in stats)
			{

				locName = stat.Element("MiniLocation").Value;
			}

			var location = from loc in map.Elements("Location").Elements("MiniLocation") where (string)loc.Element("MiniLocationTag") == locName select loc;
			var saveLoc = location.Elements(name + "Status").ToList();
			var goldSave = tempSave.Elements("Player").Elements("Gold").ToList();
			var expSave = tempSave.Elements("Player").Elements("Experience").ToList();
			int exp = 0;
			int gold = 0;

			if (name == "LockedChest")
			{

				bool opened = false;
				bool gained = false;
				foreach (var item in inv)
				{

					for (int i = 101; i < 126; i++)
					{

						if (item.Element("Item" + i.ToString()).Element("ItemName").Value == "Key")
						{

							foreach (var map in location)
							{

								exp = int.Parse(map.Element(name + "XP").Value);
								gold = int.Parse(map.Element(name + "Gold").Value);
								MessageBox.Show("You gained " + gold.ToString() + "gold!");
								MessageBox.Show("You gained " + exp.ToString() + "experience!");
							}

							foreach (var stat in stats)
							{

								exp += int.Parse(stat.Element("Experience").Value);
								gold += int.Parse(stat.Element("Gold").Value);

								if (exp >= int.Parse(stat.Element("Level").Value) * 100)
								{

									exp -= int.Parse(stat.Element("Level").Value) * 100;
									Updated("Player", "Level", "0", (int.Parse(stat.Element("Level").Value) + 1).ToString(), tempSave);
									Updated("Player", "CurrentHealth", "0", stat.Element("MaxHealth").Value, tempSave);
									Updated("Player", "CurrentEnergy", "0", stat.Element("MaxEnergy").Value, tempSave);

									if (int.Parse(stat.Element("Level").Value) % 10 == 0)
									{

										Updated("Player", "SkillPoints", "0", (int.Parse(stat.Element("SkillPoints").Value) + 2).ToString(), tempSave);
										Updated("Player", "StatusPoints", "0", (int.Parse(stat.Element("StatusPoints").Value) + 4).ToString(), tempSave);
									}

									else
									{

										Updated("Player", "SkillPoints", "0", (int.Parse(stat.Element("SkillPoints").Value) + 1).ToString(), tempSave);
										Updated("Player", "StatusPoints", "0", (int.Parse(stat.Element("StatusPoints").Value) + 2).ToString(), tempSave);
									}

									MessageBox.Show("You have gained a new level!\nHealth and Energy points are restored!\nYou have gained skill and status points!", "New level!");
								}

								Updated("Player", "Gold", "0", gold.ToString(), tempSave);
								Updated("Player", "Experience", "0", exp.ToString(), tempSave);
							}

							foreach (var save in saveLoc)
							{

								save.ReplaceNodes("Disabled");
							}

							Updated("Items", "Item" + i.ToString(), "ItemName", "", tempInv);

							foreach (var map in location)
							{

								if (map.Element("LootType").Value == "Weapon")
								{

									for (int j = 1; j < 26; j++)
									{

										if (item.Element("Item" + j.ToString()).Element("ItemName").Value == "")
										{

											MessageBox.Show("You received item: " + map.Element(name + "Loot").Value + " !", "New Item!");
											Updated("Items", "Item" + j.ToString(), "ItemName", map.Element(name + "Loot").Value, tempInv);
											gained = true;
											break;
										}

									}

								}

								else if (map.Element("LootType").Value == "Armor")
								{

									for (int j = 26; j < 51; j++)
									{

										if (item.Element("Item" + j.ToString()).Element("ItemName").Value == "")
										{

											MessageBox.Show("You received item: " + map.Element(name + "Loot").Value + " !", "New Item!");
											Updated("Items", "Item" + j.ToString(), "ItemName", map.Element(name + "Loot").Value, tempInv);
											gained = true;
											break;
										}

									}

								}

								else if (map.Element("LootType").Value == "Accessory")
								{

									for (int j = 51; j < 76; j++)
									{

										if (item.Element("Item" + j.ToString()).Element("ItemName").Value == "")
										{

											MessageBox.Show("You received item: " + map.Element(name + "Loot").Value + " !", "New Item!");
											Updated("Items", "Item" + j.ToString(), "ItemName", map.Element(name + "Loot").Value, tempInv);
											gained = true;
											break;
										}

									}

								}

								else if (map.Element("LootType").Value == "Consumable")
								{

									for (int j = 76; j < 101; j++)
									{

										if (item.Element("Item" + j.ToString()).Element("ItemName").Value == "")
										{

											MessageBox.Show("You received item: " + map.Element(name + "Loot").Value + " !", "New Item!");
											Updated("Items", "Item" + j.ToString(), "ItemName", map.Element(name + "Loot").Value, tempInv);
											gained = true;
											break;
										}

									}

								}

								if (!gained)
								{

									MessageBox.Show("Item: " + map.Element(name + "Loot").Value + " lost because of full inventory!", "Full inventory!");
								}

							}

							opened = true;
							break;
						}
					}

				}

				if (!opened)
				{

					MessageBox.Show("You must have key to open this chest!", "No key!");
				}

			}

			else
			{

				foreach (var map in location)
				{

					exp = int.Parse(map.Element(name + "XP").Value);
					gold = int.Parse(map.Element(name + "Gold").Value);
					MessageBox.Show("You gained " + gold.ToString() + "gold!");
					MessageBox.Show("You gained " + exp.ToString() + "experience!");
				}

				foreach (var stat in stats)
				{

					exp += int.Parse(stat.Element("Experience").Value);
					gold += int.Parse(stat.Element("Gold").Value);

					if (exp >= int.Parse(stat.Element("Level").Value) * 100)
					{

						exp -= int.Parse(stat.Element("Level").Value) * 100;
						Updated("Player", "Level", "0", (int.Parse(stat.Element("Level").Value) + 1).ToString(), tempSave);
						Updated("Player", "CurrentHealth", "0", stat.Element("MaxHealth").Value, tempSave);
						Updated("Player", "CurrentEnergy", "0", stat.Element("MaxEnergy").Value, tempSave);

						if (int.Parse(stat.Element("Level").Value) % 10 == 0)
						{

							Updated("Player", "SkillPoints", "0", (int.Parse(stat.Element("SkillPoints").Value) + 2).ToString(), tempSave);
							Updated("Player", "StatusPoints", "0", (int.Parse(stat.Element("StatusPoints").Value) + 4).ToString(), tempSave);
						}

						else
						{

							Updated("Player", "SkillPoints", "0", (int.Parse(stat.Element("SkillPoints").Value) + 1).ToString(), tempSave);
							Updated("Player", "StatusPoints", "0", (int.Parse(stat.Element("StatusPoints").Value) + 2).ToString(), tempSave);
						}

						MessageBox.Show("You have gained a new level!\nHealth and Energy points are restored!\nYou have gained skill and status points!", "New level!");
					}

					Updated("Player", "Gold", "0", gold.ToString(), tempSave);
					Updated("Player", "Experience", "0", exp.ToString(), tempSave);
				}

				foreach (var save in saveLoc)
				{

					save.ReplaceNodes("Disabled");
				}
			}

			map.Save("res/Data/TempMap" + save + ".xml");

			Structures(name, locName);
		}

		public void Collission(string fromDirection, string coll)
		{

			var controls = GetAll(this, typeof(PictureBox));

			if (fromDirection != "")
			{

				foreach (var control in controls)
				{

					if (control.Name == coll && control.BackgroundImage != null)
					{

						UpTimer.Stop();
						DownTimer.Stop();
						RightTimer.Stop();
						LeftTimer.Stop();
						walk = false;

						if (fromDirection == "up")
						{

							upCollision = true;
							rightCollision = true;
							leftCollision = true;
							Player.Location = new Point(Player.Location.X, control.Top + control.Height - 5);
						}

						else if (fromDirection == "down")
						{

							downCollision = true;
							rightCollision = true;
							leftCollision = true;
							Player.Location = new Point(Player.Location.X, control.Top - 95);
						}

						else if (fromDirection == "right")
						{

							rightCollision = true;
							upCollision = true;
							downCollision = true;
							Player.Location = new Point(control.Left - 90, Player.Location.Y);
						}

						else if (fromDirection == "left")
						{

							leftCollision = true;
							upCollision = true;
							downCollision = true;
							Player.Location = new Point(control.Left + control.Width - 5, Player.Location.Y);
						}

					}

				}

			}

		}

		public string CheckColl()
		{

			if (UpTimer.Enabled)
			{

				return "up";
			}

			else if (DownTimer.Enabled)
			{

				return "down";
			}

			else if (RightTimer.Enabled)
			{

				return "right";
			}

			else if (LeftTimer.Enabled)
			{

				return "left";
			}

			return "";
		}

		public bool EnemyCollision(string name)
		{

			var controls = GetAll(this, typeof(PictureBox));

			foreach (var control in controls)
			{

				if (control.Name == name)
				{

					if (Player.Location.X + 97 >= control.Location.X && Player.Location.X <= control.Location.X + control.Width
						&& Player.Location.Y + 97 >= control.Location.Y && Player.Location.Y <= control.Location.Y + control.Height
						&& control.Tag.ToString() != "0")
					{

						Player.Left = control.Location.X - 100;
						UpTimer.Enabled = false;
						DownTimer.Enabled = false;
						RightTimer.Enabled = false;
						LeftTimer.Enabled = false;
						SaveLoc();
						Battle battle = new Battle(control.Tag.ToString());
						battle.Show();
						this.Hide();
						return true;
					}

					else
					{

						return false;
					}

				}

			}

			return false;
		}

		public string VillagerCollision(string name)
		{

			var controls = GetAll(this, typeof(PictureBox));

			foreach (var control in controls)
			{

				if (control.Name == name)
				{

					if (Player.Location.X + 97 >= control.Location.X && Player.Location.X <= control.Location.X + control.Width
						&& Player.Location.Y + 97 >= control.Location.Y && Player.Location.Y <= control.Location.Y + control.Height
						&& control.Tag.ToString() == "Villager")
					{

						return "Villager";
					}

					else if (Player.Location.X + 97 >= control.Location.X && Player.Location.X <= control.Location.X + control.Width
						&& Player.Location.Y + 97 >= control.Location.Y && Player.Location.Y <= control.Location.Y + control.Height
						&& control.Tag.ToString() != "Villager")
					{

						return control.Tag.ToString();
					}

					else
					{

						return "";
					}

				}

			}

			return "";
		}

		private void World_KeyDown(object sender, KeyEventArgs e)
		{

			if (e.KeyCode == Keys.E && collision != "")
			{

				if (collision == "Villager" && !Conversation.Visible)
				{

					this.ActiveControl = Conversation;
					this.ActiveControl = null;
					walk = true;
					InventoryButton.Visible = false;
					MapButton.Visible = false;
					QuestsButton.Visible = false;
					SkillsButton.Visible = false;
					Conversation.Visible = true;
					Conversation.Text = "Hello. Good weather isn't it?";
					Conversation.Top -= 200;
				}

				if (collision == "QuestGiver" && QuestStatus.Tag.ToString() != "0")
				{

					InventoryButton.Visible = false;
					MapButton.Visible = false;
					QuestsButton.Visible = false;
					SkillsButton.Visible = false;
					walk = true;

					var quest = from q in quests.Elements("Quest") where (string)q.Element("QuestGiver") == questGiveVillager select q;

					if (QuestStatus.Tag.ToString() == "NotTaken")
					{

						QuestTakePanel.Location = new Point(570, 200);
						QuestTakePanel.Visible = true;

						foreach (var q in quest)
						{

							QuestTakeDescription.Text = "Quest orderer: " + q.Element("QuestGiver").Value + "\n\nStory: "
								+ q.Element("QuestDescription").Value + "\n\nGoal: " + q.Element("GoalDescription").Value
								+ "\n\nReward:\n" + q.Element("QuestGold").Value + "g\n" + q.Element("QuestExp").Value + "exp\n";

							if (q.Element("QuestReward").Value != "0")
							{

								QuestTakeDescription.Text += q.Element("QuestReward").Value;
							}

							if (q.Element("QuestType").Value == "Main")
							{

								DeclineQuestButton.Enabled = false;
							}

							else
							{

								DeclineQuestButton.Enabled = true;
							}

						}

					}

				}

				if (collision == "QuestReceiver" && QuestStatus.Tag.ToString() != "0")
				{

					InventoryButton.Visible = false;
					MapButton.Visible = false;
					QuestsButton.Visible = false;
					SkillsButton.Visible = false;
					walk = true;

					var quest = from q in quests.Elements("Quest") where (string)q.Element("QuestReceiver") == questReceiveVillager select q;

					if (QuestStatus.Tag.ToString() == "Completed")
					{

						QuestCompletePanel.Location = new Point(570, 200);
						QuestCompletePanel.Visible = true;

						foreach (var q in quest)
						{

							QuestCompleteDescription.Text = q.Element("QuestReceiver").Value + ": " + q.Element("QuestCompleteDescription").Value
								+ "\n\nReward:\n" + q.Element("QuestGold").Value + "g\n" + q.Element("QuestExp").Value + "exp\n";

							if (q.Element("QuestReward").Value != "0")
							{

								QuestCompleteDescription.Text += q.Element("QuestReward").Value;
							}

						}

					}

				}

				if (collision == "Shopkeeper1")
				{

					SaveLoc();
					Shop shop = new Shop(VillagerCollision("Villager1"));
					shop.Show();
					this.Hide();
				}

				if (collision == "Shopkeeper2")
				{

					SaveLoc();
					Shop shop = new Shop(VillagerCollision("Villager2"));
					shop.Show();
					this.Hide();
				}

				if (collision == "Shopkeeper3")
				{

					SaveLoc();
					Shop shop = new Shop(VillagerCollision("Villager3"));
					shop.Show();
					this.Hide();
				}

				if (collision == "Shopkeeper4")
				{

					SaveLoc();
					Shop shop = new Shop(VillagerCollision("Villager4"));
					shop.Show();
					this.Hide();
				}

				if (collision == "Fountain" && Fountain.Tag.ToString() == "Enabled")
				{

					HealthEnergy("Health");
					HealthEnergy("Energy");

					tempSave.Save("res/Data/Temp" + save + ".xml");
					MessageBox.Show("Your Health and Energy points were replenished!");

					if (village != "1")
					{

						string locName = "";
						IEnumerable<XElement> stats = tempSave.Elements();

						foreach (var stat in stats)
						{

							locName = stat.Element("MiniLocation").Value;
						}

						var location = from loc in map.Elements("Location").Elements("MiniLocation") where (string)loc.Element("MiniLocationTag") == locName select loc;

						foreach (var loc in location)
						{

							var temp = loc.Elements("FountainStatus").ToList();

							foreach (var stat in temp)
							{

								stat.ReplaceNodes("Disabled");
								map.Save("res/Data/TempMap" + save + ".xml");
							}

						}

						Structures("Fountain", locName);
					}

				}

				if (collision == "Chest" && Chest.Tag.ToString() == "Enabled")
				{

					ChestOpen("Chest");
				}

				if (collision == "LockedChest" && LockedChest.Tag.ToString() == "Enabled")
				{

					ChestOpen("LockedChest");
				}

			}

			if (e.Alt && e.KeyCode == Keys.F4)
			{

				e.Handled = true;
				MessageBox.Show("This function is disabled due to possible file corruption", "Warning!");
			}

			if (e.KeyCode == Keys.A && !walk && !leftCollision)
			{

				walk = true;
				LeftTimer.Enabled = true;
			}

			if (e.KeyCode == Keys.D && !walk && !rightCollision)
			{

				walk = true;
				RightTimer.Enabled = true;
			}

			if (e.KeyCode == Keys.W && !walk && !upCollision)
			{

				walk = true;
				UpTimer.Enabled = true;
			}

			if (e.KeyCode == Keys.S && !walk && !downCollision)
			{

				walk = true;
				DownTimer.Enabled = true;
			}

			if (e.KeyCode == Keys.Escape)
			{

				SaveLoc();
				SystemTab tab = new SystemTab();
				tab.Show();
				this.Hide();
			}

			if (e.KeyCode == Keys.Enter)
			{

				if (collision == "Villager" && Conversation.Visible)
				{

					walk = false;
					InventoryButton.Visible = true;
					MapButton.Visible = true;
					QuestsButton.Visible = true;
					SkillsButton.Visible = true;
					Conversation.Visible = false;
					Conversation.Text = "";
					Conversation.Top += 200;
				}
			}
		}

		private void World_KeyUp(object sender, KeyEventArgs e)
		{

			if (e.KeyCode == Keys.W && UpTimer.Enabled)
			{

				walk = false;
				UpTimer.Enabled = false;
			}

			if (e.KeyCode == Keys.A && LeftTimer.Enabled)
			{

				walk = false;
				LeftTimer.Enabled = false;
			}

			if (e.KeyCode == Keys.S && DownTimer.Enabled)
			{

				walk = false;
				DownTimer.Enabled = false;
			}

			if (e.KeyCode == Keys.D && RightTimer.Enabled)
			{

				walk = false;
				RightTimer.Enabled = false;
			}
		}

		private void UpTimer_Tick(object sender, EventArgs e)
		{

			if (Player.Top <= 0 && locationUp == "0")
			{

				upCollision = true;
				Player.Top = 0;
			}

			else if (Player.Top <= 0 && locationUp != "0")
			{

				LocationLoad(locationUp, true);
				Player.Top = this.Height - 153;
			}

			else
			{

				downCollision = false;
				Player.Top -= 20;
			}

		}

		private void LeftTimer_Tick(object sender, EventArgs e)
		{

			if (Player.Left <= 0 && locationLeft == "0")
			{

				leftCollision = true;
				Player.Left = 0;
			}

			else if (Player.Left <= 0 && locationLeft != "0")
			{

				LocationLoad(locationLeft, true);
				Player.Left = this.Width - 138;
			}

			else
			{

				rightCollision = false;
				Player.Left -= 20;
			}

		}

		private void DownTimer_Tick(object sender, EventArgs e)
		{

			if (Player.Top >= this.Size.Height - 143 && locationDown == "0")
			{

				downCollision = true;
				Player.Top = this.Size.Height - 143;
			}

			else if (Player.Top >= this.Size.Height - 143 && locationDown != "0")
			{

				LocationLoad(locationDown, true);
				Player.Top = 10;
			}

			else
			{

				upCollision = false;
				Player.Top += 20;
			}

		}

		private void RightTimer_Tick(object sender, EventArgs e)
		{

			if (Player.Left >= this.Size.Width - 128 && locationRight == "0")
			{

				rightCollision = true;
				Player.Left = this.Size.Width - 128;
			}

			else if (Player.Left >= this.Size.Width - 128 && locationRight != "0")
			{

				LocationLoad(locationRight, true);
				Player.Left = 10;
			}

			else
			{

				leftCollision = false;
				Player.Left += 20;
			}

		}

		private void InventoryButton_Click(object sender, EventArgs e)
		{

			SaveLoc();
			Inventory inventory = new Inventory();
			inventory.Show();
			this.Hide();
		}

		private void SkillsButton_Click(object sender, EventArgs e)
		{

			SaveLoc();
			Skills skills = new Skills();
			skills.Show();
			this.Hide();
		}

		private void DeclineQuestButton_Click(object sender, EventArgs e)
		{

			InventoryButton.Visible = true;
			MapButton.Visible = true;
			QuestsButton.Visible = true;
			SkillsButton.Visible = true;
			walk = false;
			QuestTakePanel.Visible = false;
		}

		private void AcceptQuestButton_Click(object sender, EventArgs e)
		{

			var questGive = from q in quests.Elements("Quest") where (string)q.Element("QuestGiver") == questGiveVillager select q;
			bool taken = false;
			IEnumerable<XElement> quest = quests.Elements();
			int main = 0;
			int sec = 0;

			foreach (var q in quest)
			{

				if (q.Element("QuestType").Value == "Main" && (q.Element("QuestStatus").Value == "Taken" || q.Element("QuestStatus").Value == "Completed"))
				{

					main++;
				}

				if (q.Element("QuestType").Value == "Secondary" && (q.Element("QuestStatus").Value == "Taken" || q.Element("QuestStatus").Value == "Completed"))
				{

					sec++;
				}

			}

			foreach (var q in questGive)
			{

				if (q.Element("QuestType").Value == "Main" && main == 9)
				{

					MessageBox.Show("Too much quests taken! Complete other main quests to take this!", "Too much quests!");
				}

				else if (q.Element("QuestType").Value == "Secondary" && sec == 9)
				{

					MessageBox.Show("Too much quests taken! Complete other secondary quests to take this!", "Too much quests!");
				}

				else
				{

					if (q.Element("QuestAction").Value == "Deliver")
					{

						IEnumerable<XElement> inv = tempInv.Elements();

						foreach (var x in inv)
						{

							for (int i = 101; i < 126; i++)
							{

								if (x.Element("Item" + i.ToString()).Element("ItemName").Value == "")
								{

									Updated("Items", "Item" + i.ToString(), "ItemName", "Parcel", tempInv);
									taken = true;
									break;
								}

							}

						}

						if (taken)
						{

							var questList = questGive.Elements("QuestStatus").ToList();

							foreach (var ql in questList)
							{

								ql.ReplaceNodes("Completed");
							}

							questList = questGive.Elements("QuestProgress").ToList();

							foreach (var ql in questList)
							{

								ql.ReplaceNodes("1");
							}

							quests.Save("res/Data/TempQuests" + save + ".xml");

							MessageBox.Show("Quest accepted!", "New quest!");

							InventoryButton.Visible = true;
							MapButton.Visible = true;
							QuestsButton.Visible = true;
							SkillsButton.Visible = true;
							walk = false;
							QuestTakePanel.Visible = false;

							SaveLoc();
							World_Load(sender, e);
						}

						else
						{

							MessageBox.Show("No place in inventory to accept item!", "Inventory full!");
						}

					}

					else
					{

						var questList = questGive.Elements("QuestStatus").ToList();

						foreach (var ql in questList)
						{

							ql.ReplaceNodes("Taken");
						}

						quests.Save("res/Data/TempQuests" + save + ".xml");

						MessageBox.Show("Quest accepted!", "New quest!");

						InventoryButton.Visible = true;
						MapButton.Visible = true;
						QuestsButton.Visible = true;
						SkillsButton.Visible = true;
						walk = false;
						QuestTakePanel.Visible = false;

						SaveLoc();
						World_Load(sender, e);
					}

				}
				
			}

		}

		private void CollectRewardButton_Click(object sender, EventArgs e)
		{

			IEnumerable<XElement> stats = tempSave.Elements();
			IEnumerable<XElement> items = tempInv.Elements();
			var questReceive = from q in quests.Elements("Quest") where (string)q.Element("QuestReceiver") == questReceiveVillager select q;
			var questList = questReceive.Elements("QuestStatus").ToList();
			int gold = 0;
			int exp = 0;
			bool gained = false;
			string name = "";

			foreach (var q in questReceive)
			{

				name = q.Element("QuestReward").Value;
				gold = int.Parse(q.Element("QuestGold").Value);
				exp = int.Parse(q.Element("QuestExp").Value);

				foreach (var stat in stats)
				{

					gold += int.Parse(stat.Element("Gold").Value);
					exp += int.Parse(stat.Element("Experience").Value);

					if (exp >= int.Parse(stat.Element("Level").Value) * 100)
					{

						exp -= int.Parse(stat.Element("Level").Value) * 100;
						Updated("Player", "Level", "0", (int.Parse(stat.Element("Level").Value) + 1).ToString(), tempSave);
						Updated("Player", "CurrentHealth", "0", stat.Element("MaxHealth").Value, tempSave);
						Updated("Player", "CurrentEnergy", "0", stat.Element("MaxEnergy").Value, tempSave);

						if (int.Parse(stat.Element("Level").Value) % 10 == 0)
						{

							Updated("Player", "SkillPoints", "0", (int.Parse(stat.Element("SkillPoints").Value) + 2).ToString(), tempSave);
							Updated("Player", "StatusPoints", "0", (int.Parse(stat.Element("StatusPoints").Value) + 4).ToString(), tempSave);
						}

						else
						{

							Updated("Player", "SkillPoints", "0", (int.Parse(stat.Element("SkillPoints").Value) + 1).ToString(), tempSave);
							Updated("Player", "StatusPoints", "0", (int.Parse(stat.Element("StatusPoints").Value) + 2).ToString(), tempSave);
						}

						MessageBox.Show("You have gained a new level!\nHealth and Energy points are restored!\nYou have gained skill and status points!", "New level!");
					}

					Updated("Player", "Gold", "0", gold.ToString(), tempSave);
					Updated("Player", "Experience", "0", exp.ToString(), tempSave);
				}

				foreach (var item in items)
				{

					if (q.Element("RewardType").Value == "Weapon")
					{

						for (int j = 1; j < 26; j++)
						{

							if (item.Element("Item" + j.ToString()).Element("ItemName").Value == "")
							{

								MessageBox.Show("You received item: " + name + " !", "New Item!");
								Updated("Items", "Item" + j.ToString(), "ItemName", name, tempInv);
								gained = true;
								break;
							}

						}

					}

					else if (q.Element("RewardType").Value == "Armor")
					{

						for (int j = 26; j < 51; j++)
						{

							if (item.Element("Item" + j.ToString()).Element("ItemName").Value == "")
							{

								MessageBox.Show("You received item: " + name + " !", "New Item!");
								Updated("Items", "Item" + j.ToString(), "ItemName", name, tempInv);
								gained = true;
								break;
							}

						}

					}

					else if (q.Element("RewardType").Value == "Accessory")
					{

						for (int j = 51; j < 76; j++)
						{

							if (item.Element("Item" + j.ToString()).Element("ItemName").Value == "")
							{

								MessageBox.Show("You received item: " + name + " !", "New Item!");
								Updated("Items", "Item" + j.ToString(), "ItemName", name, tempInv);
								gained = true;
								break;
							}

						}

					}

					else if (q.Element("RewardType").Value == "Consumable")
					{

						for (int j = 76; j < 101; j++)
						{

							if (item.Element("Item" + j.ToString()).Element("ItemName").Value == "")
							{

								MessageBox.Show("You received item: " + name + " !", "New Item!");
								Updated("Items", "Item" + j.ToString(), "ItemName", name, tempInv);
								gained = true;
								break;
							}

						}

					}

					if (!gained && q.Element("RewardType").Value != "0")
					{

						MessageBox.Show("Item: " + name + " lost because of full inventory!", "Full inventory!");
					}

					if (q.Element("QuestAction").Value == "Deliver")
					{

						for (int i = 101; i < 126; i++)
						{

							if (item.Element("Item" + i.ToString()).Element("ItemName").Value == "Parcel")
							{

								Updated("Items", "Item" + i.ToString(), "ItemName", "", tempInv);
								break;
							}

						}

					}

				}

			}

			foreach (var ql in questList)
			{

				ql.ReplaceNodes("Done");
			}

			quests.Save("res/Data/TempQuests" + save + ".xml");

			InventoryButton.Visible = true;
			MapButton.Visible = true;
			QuestsButton.Visible = true;
			SkillsButton.Visible = true;
			walk = false;
			QuestCompletePanel.Visible = false;

			SaveLoc();
			World_Load(sender, e);
		}

		private void Text_Click(object sender, EventArgs e)
		{

			this.ActiveControl = null;
		}

		private void QuestsButton_Click(object sender, EventArgs e)
		{

			SaveLoc();
			Quests quests = new Quests();
			quests.Show();
			this.Hide();
		}

		private void MapButton_Click(object sender, EventArgs e)
		{

			SaveLoc();
			Map map = new Map();
			map.Show();
			this.Hide();
		}

		private void Player_LocationChanged(object sender, EventArgs e)
		{

			if (EnemyCollision("Enemy1"))
			{

				collision = "Enemy";
			}

			else if (EnemyCollision("Enemy2"))
			{

				collision = "Enemy";
			}

			else if (EnemyCollision("Enemy3"))
			{

				collision = "Enemy";
			}

			else if (EnemyCollision("Enemy4"))
			{

				collision = "Enemy";
			}

			else if (VillagerCollision("Villager1") == "Villager")
			{

				collision = "Villager";
				Collission(CheckColl(), "Villager1");
			}

			else if (VillagerCollision("Villager2") == "Villager")
			{

				collision = "Villager";
				Collission(CheckColl(), "Villager2");
			}

			else if (VillagerCollision("Villager3") == "Villager")
			{

				collision = "Villager";
				Collission(CheckColl(), "Villager3");
			}

			else if (VillagerCollision("Villager4") == "Villager")
			{

				collision = "Villager";
				Collission(CheckColl(), "Villager4");
			}

			else if (VillagerCollision("Villager1") == "QuestGiver")
			{

				collision = "QuestGiver";
				Collission(CheckColl(), "Villager1");
			}

			else if (VillagerCollision("Villager2") == "QuestGiver")
			{

				collision = "QuestGiver";
				Collission(CheckColl(), "Villager2");
			}

			else if (VillagerCollision("Villager3") == "QuestGiver")
			{

				collision = "QuestGiver";
				Collission(CheckColl(), "Villager3");
			}

			else if (VillagerCollision("Villager4") == "QuestGiver")
			{

				collision = "QuestGiver";
				Collission(CheckColl(), "Villager4");
			}

			else if (VillagerCollision("Villager1") == "QuestReceiver")
			{

				collision = "QuestReceiver";
				Collission(CheckColl(), "Villager1");
			}

			else if (VillagerCollision("Villager2") == "QuestReceiver")
			{

				collision = "QuestReceiver";
				Collission(CheckColl(), "Villager2");
			}

			else if (VillagerCollision("Villager3") == "QuestReceiver")
			{

				collision = "QuestReceiver";
				Collission(CheckColl(), "Villager3");
			}

			else if (VillagerCollision("Villager4") == "QuestReceiver")
			{

				collision = "QuestReceiver";
				Collission(CheckColl(), "Villager4");
			}

			else if (VillagerCollision("Villager1") != "Villager" && VillagerCollision("Villager1") != "")
			{

				collision = "Shopkeeper1";
				Collission(CheckColl(), "Villager1");
			}

			else if (VillagerCollision("Villager2") != "Villager" && VillagerCollision("Villager2") != "")
			{

				collision = "Shopkeeper2";
				Collission(CheckColl(), "Villager2");
			}

			else if (VillagerCollision("Villager3") != "Villager" && VillagerCollision("Villager3") != "")
			{

				collision = "Shopkeeper3";
				Collission(CheckColl(), "Villager3");
			}

			else if (VillagerCollision("Villager4") != "Villager" && VillagerCollision("Villager4") != "")
			{

				collision = "Shopkeeper4";
				Collission(CheckColl(), "Villager4");
			}

			else if (Player.Location.X + 97 >= Fountain.Location.X && Player.Location.X <= Fountain.Location.X + Fountain.Width
				&& Player.Location.Y + 97 >= Fountain.Location.Y && Player.Location.Y <= Fountain.Location.Y + Fountain.Height)
			{

				collision = "Fountain";
				Collission(CheckColl(), "Fountain");
			}

			else if (Player.Location.X + 97 >= Chest.Location.X && Player.Location.X <= Chest.Location.X + Chest.Width
				&& Player.Location.Y + 97 >= Chest.Location.Y && Player.Location.Y <= Chest.Location.Y + Chest.Height)
			{

				collision = "Chest";
				Collission(CheckColl(), "Chest");
			}

			else if (Player.Location.X + 97 >= LockedChest.Location.X && Player.Location.X <= LockedChest.Location.X + LockedChest.Width
				&& Player.Location.Y + 97 >= LockedChest.Location.Y && Player.Location.Y <= LockedChest.Location.Y + LockedChest.Height)
			{

				collision = "LockedChest";
				Collission(CheckColl(), "LockedChest");
			}

			else
			{

				collision = "";
				upCollision = false;
				downCollision = false;
				rightCollision = false;
				leftCollision = false;
			}

		}

		private void World_Load(object sender, EventArgs e)
		{

			string locName = "";
			IEnumerable<XElement> stats = tempSave.Elements();

			foreach (var stat in stats)
			{

				locName = stat.Element("MiniLocation").Value;
				Player.Location = new Point(int.Parse(stat.Element("LocationX").Value), int.Parse(stat.Element("LocationY").Value));
			}

			LocationLoad(locName, false);
		}
	}
}