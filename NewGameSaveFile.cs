using System.Windows.Forms;
using System;
using System.Collections.Generic;
using System.Xml.Linq;
using System.IO;

namespace RPG
{
	public partial class NewGameSaveFile : Form
	{

		public void Write(string save)
		{

			XElement startStats = XElement.Load("res/Data/StartStats.xml");
			XElement nullEquip = XElement.Load("res/Data/NullInventory.xml");
			XElement startMap = XElement.Load("res/Data/StartMap.xml");
			XElement startQuests = XElement.Load("res/Data/StartQuests.xml");
			startStats.Save("res/Data/Save" + save + ".xml");
			startStats.Save("res/Data/Temp" + save + ".xml");
			nullEquip.Save("res/Data/SaveInventory" + save + ".xml");
			nullEquip.Save("res/Data/TempInventory" + save + ".xml");
			startMap.Save("res/Data/SaveMap" + save + ".xml");
			startMap.Save("res/Data/TempMap" + save + ".xml");
			startQuests.Save("res/Data/SaveQuests" + save + ".xml");
			startQuests.Save("res/Data/TempQuests" + save + ".xml");

			File.WriteAllText(@"res/Data/CurrentSave.txt", save);

			World world = new World("0");
			world.Show();
			this.Hide();
		}

		public string Check(string save)
		{

			string x = "";

			XElement xelement = XElement.Load("res/Data/" + save + ".xml");
			IEnumerable<XElement> players = xelement.Elements();

			foreach (var player in players)
			{

				x = player.Element("Saved").Value;
			}

			return x;
		}

		public NewGameSaveFile()
		{

			InitializeComponent();
		}

		private void BackToMenuButton_Click(object sender, EventArgs e)
		{

			MainScreen mainScreen = new MainScreen();
			mainScreen.Show();
			this.Hide();
		}

		private void NewGame_KeyDown(object sender, KeyEventArgs e)
		{

			if (e.Alt && e.KeyCode == Keys.F4)
			{
				e.Handled = true;
				MessageBox.Show("This function is disabled due to possible file corruption", "Warning!");
			}
		}

		private void NewSaveSlot1_Click(object sender, EventArgs e)
		{

			if (Check("Save1") != "0")
			{

				DialogResult result;
				result = MessageBox.Show("This save file already exists.\nAre you sure that you want to rewrite it?", "Are you sure?", MessageBoxButtons.YesNo);

				if (result == DialogResult.Yes)
				{

					Write("1");
				}

			}

			else
			{

				Write("1");
			}
			
		}

		private void NewSaveSlot2_Click(object sender, EventArgs e)
		{

			if (Check("Save2") != "0")
			{

				DialogResult result;
				result = MessageBox.Show("This save file already exists.\nAre you sure that you want to rewrite it?", "Are you sure?", MessageBoxButtons.YesNo);

				if (result == DialogResult.Yes)
				{

					Write("2");
				}

			}

			else
			{

				Write("2");
			}

		}

		private void NewSaveSlot3_Click(object sender, EventArgs e)
		{

			if (Check("Save3") != "0")
			{

				DialogResult result;
				result = MessageBox.Show("This save file already exists.\nAre you sure that you want to rewrite it?", "Are you sure?", MessageBoxButtons.YesNo);

				if (result == DialogResult.Yes)
				{

					Write("3");
				}

			}

			else
			{

				Write("3");
			}

		}
	}
}