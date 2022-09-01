using System.Windows.Forms;
using System;
using System.Collections.Generic;
using System.Xml.Linq;
using System.IO;

namespace RPG
{
	public partial class ContinueSaveFile : Form
	{

		public void Write(string save)
		{

			XElement saves = XElement.Load("res/Data/Save" + save + ".xml");
			XElement equip = XElement.Load("res/Data/SaveInventory" + save + ".xml");
			XElement map = XElement.Load("res/Data/SaveMap" + save + ".xml");
			XElement quests = XElement.Load("res/Data/SaveQuests" + save + ".xml");
			saves.Save("res/Data/Temp" + save + ".xml");
			equip.Save("res/Data/TempInventory" + save + ".xml");
			map.Save("res/Data/TempMap" + save + ".xml");
			quests.Save("res/Data/TempQuests" + save + ".xml");

			File.WriteAllText(@"res/Data/CurrentSave.txt", save);

			World world = new World("0");
			world.Show();
			this.Hide();
		}

		public string Check(string save)
		{

			string x = "";

			XElement xelement = XElement.Load(@"res/Data/" + save + ".xml");
			IEnumerable<XElement> players = xelement.Elements();

			foreach (var player in players)
			{

				x = player.Element("Saved").Value;
			}

			return x;
		}

		public ContinueSaveFile()
		{

			InitializeComponent();
		}

		private void Continue_KeyDown(object sender, KeyEventArgs e)
		{

			if (e.Alt && e.KeyCode == Keys.F4)
			{

				e.Handled = true;
				MessageBox.Show("This function is disabled due to possible file corruption", "Warning!");
			}
		}

		private void BackToMenuButton_Click(object sender, EventArgs e)
		{

			MainScreen mainScreen = new MainScreen();
			mainScreen.Show();
			this.Hide();
		}

		private void ContinueSaveFile_Load(object sender, EventArgs e)
		{

			if (Check("Save1") != "0")
			{

				ContinueSaveSlot1.Enabled = true;
			}

			if (Check("Save2") != "0")
			{

				ContinueSaveSlot2.Enabled = true;
			}

			if (Check("Save3") != "0")
			{

				ContinueSaveSlot3.Enabled = true;
			}
		}

		private void ContinueSaveSlot1_Click(object sender, EventArgs e)
		{

			Write("1");
		}

		private void ContinueSaveSlot2_Click(object sender, EventArgs e)
		{

			Write("2");
		}

		private void ContinueSaveSlot3_Click(object sender, EventArgs e)
		{

			Write("3");
		}
	}
}