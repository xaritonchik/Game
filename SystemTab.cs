using System.Windows.Forms;
using System;
using System.Xml.Linq;
using System.IO;

namespace RPG
{
	public partial class SystemTab : Form
	{

		static string save = File.ReadAllText(@"res/Data/CurrentSave.txt");

		public SystemTab()
		{

			InitializeComponent();
		}

		private void SystemTab_KeyDown(object sender, KeyEventArgs e)
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

		private void SkillsButton_Click(object sender, EventArgs e)
		{

			Skills skills = new Skills();
			skills.Show();
			this.Hide();
		}

		private void StatusButton_Click(object sender, EventArgs e)
		{

			Status status = new Status();
			status.Show();
			this.Hide();
		}

		private void ExitDesktopButton_Click(object sender, EventArgs e)
		{

			DialogResult result;
			result = MessageBox.Show("Are you sure you want to exit? \nAny unsaved progress will be lost.", "Are you sure?", MessageBoxButtons.YesNo);

			if (result == DialogResult.Yes)
			{

				Application.Exit();
			}
		}

		private void ExitMenuButton_Click(object sender, EventArgs e)
		{

			DialogResult result;
			result = MessageBox.Show("Are you sure you want to exit? \nAny unsaved progress will be lost.", "Are you sure?", MessageBoxButtons.YesNo);

			if (result == DialogResult.Yes)
			{

				MainScreen mainScreen = new MainScreen();
				mainScreen.Show();
				this.Hide();
			}
		}

		private void OptionsButton_Click(object sender, EventArgs e)
		{

			Options options = new Options("System");
			options.Show();
			this.Hide();
		}

		private void ReturnButton_Click(object sender, EventArgs e)
		{

			World world = new World("0");
			world.Show();
			this.Hide();
		}

		private void SaveButton_Click(object sender, EventArgs e)
		{

			XElement temp = XElement.Load("res/Data/Temp" + save + ".xml");
			XElement equip = XElement.Load("res/Data/TempInventory" + save + ".xml");
			XElement map = XElement.Load("res/Data/TempMap" + save + ".xml");
			XElement quests = XElement.Load("res/Data/TempQuests" + save + ".xml");
			temp.Save("res/Data/Save" + save + ".xml");
			equip.Save("res/Data/SaveInventory" + save + ".xml");
			map.Save("res/Data/SaveMap" + save + ".xml");
			quests.Save("res/Data/SaveQuests" + save + ".xml");

			MessageBox.Show("Saved successfully!");
		}

		private void LoadButton_Click(object sender, EventArgs e)
		{

			XElement saves = XElement.Load("res/Data/Save" + save + ".xml");
			XElement equip = XElement.Load("res/Data/SaveInventory" + save + ".xml");
			XElement map = XElement.Load("res/Data/SaveMap" + save + ".xml");
			XElement quests = XElement.Load("res/Data/TempQuests" + save + ".xml");
			saves.Save("res/Data/Temp" + save + ".xml");
			equip.Save("res/Data/TempInventory" + save + ".xml");
			map.Save("res/Data/TempMap" + save + ".xml");
			quests.Save("res/Data/TempQuests" + save + ".xml");

			MessageBox.Show("Successfully loaded previous save!");
		}
	}
}