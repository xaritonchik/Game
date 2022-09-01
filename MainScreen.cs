using System.Windows.Forms;
using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace RPG
{
	public partial class MainScreen : Form
	{

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

		public MainScreen()
		{

			InitializeComponent();
		}

		private void MainScreen_KeyDown(object sender, KeyEventArgs e)
		{

			if (e.Alt && e.KeyCode == Keys.F4)
			{
				e.Handled = true;
				MessageBox.Show("This function is disabled due to possible file corruption", "Warning!");
			}
		}

		private void ExitGameButton_Click(object sender, EventArgs e)
		{

			DialogResult result;
			result = MessageBox.Show("Are you sure you want to exit?", "Are you sure?", MessageBoxButtons.YesNo);

			if (result == DialogResult.Yes)
			{

				Application.Exit();
			}
		}

		private void NewGameButton_Click(object sender, EventArgs e)
		{

			if (ContinueButton.Enabled == true)
			{

				DialogResult result;
				result = MessageBox.Show("You have saved game. Are you sure you want to start a new one?", "Are you sure?", MessageBoxButtons.YesNo);

				if (result == DialogResult.Yes)
				{

					NewGameSaveFile newGameSaveFile = new NewGameSaveFile();
					newGameSaveFile.Show();
					this.Hide();
				}
			}
			
			else
			{

				NewGameSaveFile newGameSaveFile = new NewGameSaveFile();
				newGameSaveFile.Show();
				this.Hide();
			}
		}

		private void OptionsButton_Click(object sender, EventArgs e)
		{

			Options options = new Options("MainMenu");
			options.Show();
			this.Hide();
		}

		private void ContinueButton_Click(object sender, EventArgs e)
		{

			ContinueSaveFile continueSave = new ContinueSaveFile();
			continueSave.Show();
			this.Hide();
		}

		private void MainScreen_Load(object sender, EventArgs e)
		{

			string save1 = Check("Save1");
			string save2 = Check("Save2");
			string save3 = Check("Save3");

			if (save1 != "0" || save2 != "0" || save3 != "0")
			{

				ContinueButton.Enabled = true;
			}

		}

		private void CreditsButton_Click(object sender, EventArgs e)
		{

			Credits credits = new Credits();
			credits.Show();
			this.Hide();
		}
	}
}