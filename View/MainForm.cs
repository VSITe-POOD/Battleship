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
        private const int gridSize = 10;
        public MainForm()
        {
            InitializeComponent();
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            var startsFirst = WhoStartsFirst();
            Debug.WriteLine($"Button clicked---{sender}");

            CreateButtonsGrid(Player.Human, gridSize);
            CreateButtonsGrid(Player.Computer, gridSize);
            buttonStart.Visible = false;
            buttonResetShips.Visible = true;
        }

        private void CreateButtonsGrid(Player player, int gridSize)
        {
            var namePrefix = "button";
            var positionX = 60;
            var positionY = 90;
            switch (player)
            {
                case Player.Computer:
                    namePrefix += "Computer";
                    positionX += 540;
                    break;
                case Player.Human:
                    namePrefix += "Human";
                    break;
            }
            for (var row = 0; row < gridSize; row++)
            {
                for (var col = 0; col < gridSize; col++)
                {
                    if (row == 0)
                    {
                        var label = new Label();
                        label.AutoSize = true;
                        label.Location = new System.Drawing.Point(positionX + 15 + 40 * col + col, 75);
                        label.Size = new System.Drawing.Size(57, 13);
                        label.Text = Convert.ToChar('A' + col).ToString();
                        this.Controls.Add(label);
                    }
                    if (col == 0)
                    {
                        var label = new Label();
                        label.AutoSize = true;
                        label.Location = new System.Drawing.Point(positionX - 20, positionY + 15 + row * 40 + row);
                        label.Size = new System.Drawing.Size(57, 13);
                        label.Text = (row + 1).ToString();
                        this.Controls.Add(label);
                    }
                    var squareButton = new SquareButton(row, col, player);
                    squareButton.Location = new System.Drawing.Point(positionX + col * 40 + col, positionY + row * 40 + row);
                    squareButton.Name = namePrefix + "_" + row + "_" + col;
                    squareButton.Size = new System.Drawing.Size(40, 40);
                    squareButton.Text = "";
                    squareButton.Click += this.ProcessButtonHit;
                    
                    this.Controls.Add(squareButton);
                }
            }
        }

        private void ProcessButtonHit(object sender, EventArgs e)
        {
            var squareButton = sender as SquareButton;

            // Game started - no more Ships resets
            if (buttonResetShips.Visible)
            {
                buttonResetShips.Visible = false;
            }
            switch (squareButton.Player)
            {
                default:
                    break;
            }

            Debug.WriteLine($"Button clicked---{squareButton.Name}");
            Debug.WriteLine($"Top location---{squareButton.Top}");
            Debug.WriteLine($"Left location---{squareButton.Left}");
            Debug.WriteLine($"Right location---{squareButton.Right}");
            Debug.WriteLine($"Bottom location---{squareButton.Bottom}");
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
