using System.Windows.Forms;
using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace RPG
{
	public partial class Options : Form
	{

		string temp;

		public void Reset(string save, object sender)
		{

			DialogResult result;
			result = MessageBox.Show("Are you sure you want to reset this save file?", "Are you sure?", MessageBoxButtons.YesNo);

			if (result == DialogResult.Yes)
			{

				XElement nullSaves = XElement.Load("res/Data/NullStats.xml");
				XElement nullInv = XElement.Load("res/Data/NullInventory.xml");
				XElement startMap = XElement.Load("res/Data/StartMap.xml");
				XElement startQuests = XElement.Load("res/Data/StartQuests.xml");
				nullSaves.Save("res/Data/Save" + save + ".xml");
				nullSaves.Save("res/Data/Temp" + save + ".xml");
				nullInv.Save("res/Data/SaveInventory" + save + ".xml");
				nullInv.Save("res/Data/TempInventory" + save + ".xml");
				startMap.Save("res/Data/SaveMap" + save + ".xml");
				startMap.Save("res/Data/TempMap" + save + ".xml");
				startQuests.Save("res/Data/SaveQuests" + save + ".xml");
				startQuests.Save("res/Data/TempQuests" + save + ".xml");

				MessageBox.Show("Save file had been reset successfully");

				Button btn = sender as Button;
				btn.Enabled = false;

				if (!ResetSave1.Enabled && !ResetSave2.Enabled && !ResetSave3.Enabled)
				{

					ResetButton.Enabled = false;
				}
			}

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

		public Options(string direction)
		{

			temp = direction;
			InitializeComponent();
		}

		private void MainMenuButton_Click(object sender, EventArgs e)
		{
			if (temp == "MainMenu")
			{

				MainScreen mainScreen = new MainScreen();
				mainScreen.Show();
				this.Hide();
			}

			else
			{

				World world = new World("0");
				world.Show();
				this.Hide();
			}
			
		}

		private void ResetButton_Click(object sender, EventArgs e)
		{

			ResetSave1.Visible = true;
			ResetSave2.Visible = true;
			ResetSave3.Visible = true;

			if (Check("Save1") != "0")
			{

				ResetSave1.Enabled = true;
			}

			if (Check("Save2") != "0")
			{

				ResetSave2.Enabled = true;
			}

			if (Check("Save3") != "0")
			{

				ResetSave3.Enabled = true;
			}

		}

		private void Options_KeyDown(object sender, KeyEventArgs e)
		{

			if (e.Alt && e.KeyCode == Keys.F4)
			{

				e.Handled = true;
				MessageBox.Show("This function is disabled due to possible file corruption", "Warning!");
			}
		}

		private void Options_Load(object sender, EventArgs e)
		{

			if (Check("Save1") != "0" || Check("Save2") != "0" || Check("Save3") != "0")
			{

				ResetButton.Enabled = true;
			}

		}

		private void ResetSave1_Click(object sender, EventArgs e)
		{

			Reset("1", sender);
		}

		private void ResetSave2_Click(object sender, EventArgs e)
		{

			Reset("2", sender);
		}

		private void ResetSave3_Click(object sender, EventArgs e)
		{

			Reset("3", sender);
		}
	}
}