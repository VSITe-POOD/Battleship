using System;
using System.Diagnostics;
using System.Windows.Forms;
using Vsite.Battleship.Model;

namespace View
{
    enum Player
    {
        Human,
        Computer
    }

    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            var startsFirst = WhoStartsFirst();
            Debug.WriteLine($"Button clicked---{sender}");
        }

        private Player WhoStartsFirst()
        {
            var random = new Random();
            if (random.Next(2) == 0)
            {
                MessageBox.Show("Human starts first! Go ahead!", "Coin Flip");
                return Player.Human;
            }
            MessageBox.Show("Computer starts first! Prepare to lose!", "Coin Flip");
            return Player.Computer;
        }

        private FleetGrid fleetGrid = new FleetGrid(10, 10);
        private EnemyGrid enemyGrid = new EnemyGrid(10, 10);
    }
}
