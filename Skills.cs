using System.Windows.Forms;
using System;
using System.Collections.Generic;
using System.Xml.Linq;
using System.IO;
using System.Linq;

namespace RPG
{
	public partial class Skills : Form
	{

		static string save = File.ReadAllText(@"res/Data/CurrentSave.txt");
		public string skill = "";
		XElement xelement = XElement.Load("res/Data/Temp" + save + ".xml");
		XElement xElement = XElement.Load("res/Data/Skills.xml");

		public void ShowDesc(string type)
		{

			IEnumerable<XElement> elements = xelement.Elements();

			string level = "";
			string desc = "";
			string desc2 = "";
			string name = "";
			string cost = "";
			var skillSearch = from lvl in xElement.Elements("Skill") where (string)lvl.Element("SkillTag") == type select lvl;

			foreach (var element in elements)
			{

				level = element.Element("Skills").Element(type).Value;
			}

			foreach (var skills in skillSearch)
			{

				name = skills.Element("SkillName").Value;
				cost = skills.Element("SkillCost").Value;
				desc = skills.Element("SkillDescription" + level).Value;

				if (level != "10")
				{

					desc2 = skills.Element("SkillDescription" + (int.Parse(level) + 1).ToString()).Value;
				}
				
			}

			if (SkillPointsCount.Text == "0")
			{

				UpgradeButton.Enabled = false;
			}

			else if (level != "10")
			{

				UpgradeButton.Enabled = true;
			}

			else
			{

				UpgradeButton.Enabled = false;
			}

			if (level != "10")
			{

				SkillDescription.Text = desc + "\n\nCurrent level: " + level + "\n\nSkill energy cost: " + cost + "\n\nNext level: " + desc2;
			}

			else
			{

				SkillDescription.Text = desc + "\n\nCurrent level: " + level + "\n\nSkill energy cost: " + cost;
			}
			
			SkillNameLabel.Text = name;
			skill = type;
		}

		public Skills()
		{

			InitializeComponent();
		}

		private void Skills_KeyDown(object sender, KeyEventArgs e)
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

		private void Skills_Load(object sender, EventArgs e)
		{

			string skillCount = "";
			IEnumerable<XElement> x = xelement.Elements();

			foreach (var xElement in x)
			{

				skillCount = xElement.Element("SkillPoints").Value;
			}

			SkillPointsCount.Text = skillCount;
		}

		private void ActiveSkill1_Click(object sender, EventArgs e)
		{

			ShowDesc("Active1");
		}

		private void ActiveSkill2_Click(object sender, EventArgs e)
		{

			ShowDesc("Active2");
		}

		private void ActiveSkill3_Click(object sender, EventArgs e)
		{

			ShowDesc("Active3");
		}

		private void ActiveSkill4_Click(object sender, EventArgs e)
		{

			ShowDesc("Active4");
		}

		private void PassiveSkill1_Click(object sender, EventArgs e)
		{

			ShowDesc("Passive1");
		}

		private void PassiveSkill2_Click(object sender, EventArgs e)
		{

			ShowDesc("Passive2");
		}

		private void UpgradeButton_Click(object sender, EventArgs e)
		{

			IEnumerable<XElement> elements = xelement.Elements();

			string level = "";
			var skillPointsCount = xelement.Elements("Player").Elements("SkillPoints").ToList();
			var skillLevel = xelement.Elements("Player").Elements("Skills").Elements(skill).ToList();

			foreach (var element in elements)
			{

				level = element.Element("Skills").Element(skill).Value;
			}

			level = (int.Parse(level) + 1).ToString();
			SkillPointsCount.Text = (int.Parse(SkillPointsCount.Text) - 1).ToString();

			foreach (XElement element in skillPointsCount)
			{

				element.ReplaceNodes(SkillPointsCount.Text);
			}

			foreach (XElement element in skillLevel)
			{

				element.ReplaceNodes(level);
			}

			xelement.Save("res/Data/Temp" + save + ".xml");

			ShowDesc(skill);
		}

		private void SkillDescription_Click(object sender, EventArgs e)
		{

			this.ActiveControl = null;
		}
	}
}