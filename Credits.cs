using System;
using System.Windows.Forms;

namespace RPG
{
	public partial class Credits : Form
	{
		public Credits()
		{

			InitializeComponent();
		}

		private void Credits_KeyDown(object sender, KeyEventArgs e)
		{

			if (e.Alt && e.KeyCode == Keys.F4)
			{

				e.Handled = true;
				MessageBox.Show("This function is disabled due to possible file corruption", "Warning!");
			}
		}

        private void MainMenuButton_Click(object sender, EventArgs e)
        {

			MainScreen mainScreen = new MainScreen();
			mainScreen.Show();
			this.Hide();
        }
    }
}
