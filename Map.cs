using System.Windows.Forms;

namespace RPG
{
    public partial class Map : Form
    {
        public Map()
        {
            InitializeComponent();
        }

        private void Map_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.Alt && e.KeyCode == Keys.F4)
            {

                e.Handled = true;
                MessageBox.Show("This function is disabled due to possible file corruption", "Warning!");
            }
        }

        private void StatusButton_Click(object sender, System.EventArgs e)
        {

            Status status = new Status();
            status.Show();
            this.Hide();
        }

        private void InventoryButton_Click(object sender, System.EventArgs e)
        {

            Inventory inventory = new Inventory();
            inventory.Show();
            this.Hide();
        }

        private void QuestsButton_Click(object sender, System.EventArgs e)
        {

            Quests quests = new Quests();
            quests.Show();
            this.Hide();
        }

        private void SkillsButton_Click(object sender, System.EventArgs e)
        {

            Skills skills = new Skills();
            skills.Show();
            this.Hide();
        }

        private void SystemButton_Click(object sender, System.EventArgs e)
        {

            SystemTab systemTab = new SystemTab();
            systemTab.Show();
            this.Hide();
        }
    }
}
