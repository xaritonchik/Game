using System.Windows.Forms;
using System;
using System.Collections.Generic;
using System.Xml.Linq;
using System.IO;
using System.Linq;

namespace RPG
{
	public partial class Quests : Form
	{

		static string save = File.ReadAllText(@"res/Data/CurrentSave.txt");
		XElement quests = XElement.Load("res/Data/TempQuests" + save + ".xml");

		public Quests()
		{

			InitializeComponent();
		}

		public IEnumerable<Control> GetAll(Control control, Type type)
		{
			var controls = control.Controls.Cast<Control>();

			return controls.SelectMany(ctrl => GetAll(ctrl, type)).Concat(controls).Where(c => c.GetType() == type);
		}

		private void Quests_KeyDown(object sender, KeyEventArgs e)
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
		
		private void Text_Click(object sender, EventArgs e)
		{

			this.ActiveControl = null;
		}

		private void Quests_Load(object sender, EventArgs e)
		{

			var controls = GetAll(this, typeof(Button));
			IEnumerable<XElement> quest = quests.Elements();

			bool appended = false;

			foreach (var q in quest)
			{

				if (q.Element("QuestStatus").Value == "Taken" || q.Element("QuestStatus").Value == "Completed")
				{

					if (q.Element("QuestType").Value == "Secondary")
					{

						foreach (var control in controls)
						{

							for (int i = 1; i < 10; i++)
							{

								if (control.Name == "SecondaryQuest" + i.ToString() && control.Text == "")
								{

									control.Enabled = true;
									control.Text = q.Element("QuestName").Value;
									appended = true;
									break;
								}

							}

							if (appended)
							{

								break;
							}

						}

					}

					else if (q.Element("QuestType").Value == "Main")
					{

						foreach (var control in controls)
						{

							for (int i = 1; i < 10; i++)
							{

								if (control.Name == "MainQuest" + i.ToString() && control.Text == "")
								{

									control.Enabled = true;
									control.Text = q.Element("QuestName").Value;
									appended = true;
									break;
								}

							}

							if (appended)
							{

								break;
							}

						}

					}

					appended = false;
				}

			}

		}

		private void MainQuest_Click(object sender, EventArgs e)
		{

			Button button = sender as Button;

			var quest = from q in quests.Elements("Quest") where (string)q.Element("QuestName") == button.Text select q;

			foreach (var q in quest)
			{

				MainQuestDescription.Text = "Quest description: " + q.Element("QuestDescription").Value + "\n\nQuest goal: "
					+ q.Element("GoalDescription").Value + "\n\nGold reward: " + q.Element("QuestGold").Value
					+ "g\nExperience reward: " + q.Element("QuestExp").Value + "exp\n";

				if (q.Element("QuestReward").Value != "0")
				{

					MainQuestDescription.Text += q.Element("QuestReward").Value;
				}

			}

		}

		private void SecondaryQuest_Click(object sender, EventArgs e)
		{

			Button button = sender as Button;

			var quest = from q in quests.Elements("Quest") where (string)q.Element("QuestName") == button.Text select q;

			foreach (var q in quest)
			{

				SecondaryQuestDescription.Text = "Quest description: " + q.Element("QuestDescription").Value + "\n\nQuest goal: "
					+ q.Element("GoalDescription").Value + "\n\nGold reward: " + q.Element("QuestGold").Value
					+ "g\nExperience reward: " + q.Element("QuestExp").Value + "exp\n";

				if (q.Element("QuestReward").Value != "0")
				{

					SecondaryQuestDescription.Text += q.Element("QuestReward").Value;
				}

				if (q.Element("QuestStatus").Value == "Completed")
				{

					RefuseButton.Enabled = false;
				}

				else
				{

					RefuseButton.Enabled = true;
				}

			}

		}

		private void RefuseButton_Click(object sender, EventArgs e)
		{


		}
	}
}