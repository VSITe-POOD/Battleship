using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
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
        private const int gridRowSize = 10;
        private const int gridColumnSize = 10;
        public readonly List<int> shipLengths = new List<int>() { 5, 4, 4, 3, 3, 3, 2, 2, 2, 2 };
        private Game game;
        private const int gridButtonStartPositionX = 60;
        private const int gridButtonStartPositionY = 90;
        private List<SquareButton> playerSquareButtons;
        private List<SquareButton> cumputerSquareButtons;

        public MainForm()
        {
            InitializeComponent();
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            var startsFirst = WhoStartsFirst();
            Debug.WriteLine($"Button clicked---{sender}");
            buttonStart.Visible = false;
            this.game = new Game(gridRowSize, gridColumnSize, shipLengths);

            playerSquareButtons = DisplayButtonsGrid(Player.Human, gridRowSize, gridColumnSize);
            cumputerSquareButtons = DisplayButtonsGrid(Player.Computer, gridRowSize, gridColumnSize);

            buttonResetShips.Visible = true;
        }

        private List<SquareButton> DisplayButtonsGrid(Player player, int rows, int cols)
        {
            if (player == Player.Computer)
            {
                return DisplayComputerButtons(rows, cols, gridButtonStartPositionX + 540, gridButtonStartPositionY);
            }
            else
            {
                var shipSquares = game.CreatePlayerFleet();
                return DisplayHumanButtons(rows, cols, gridButtonStartPositionX, gridButtonStartPositionY, shipSquares);
            }
        }

        private List<SquareButton> DisplayComputerButtons(int rows, int cols, int positionX, int positionY)
        {
            var squareButtons = new List<SquareButton>();
            for (var row = 0; row < rows; row++)
            {
                for (var col = 0; col < cols; col++)
                {
                    if (row == 0)
                    {
                        DisplayNumberingLabel(positionX + 15 + 40 * col + col, positionY - 15, true, col);
                    }
                    if (col == 0)
                    {
                        DisplayNumberingLabel(positionX - 20, positionY + 15 + row * 40 + row, false, row);
                    }
                    var squareButton = new SquareButton(row, col, Player.Computer, SquareButtonState.Initial);
                    squareButton.Location = new System.Drawing.Point(positionX + col * 40 + col, positionY + row * 40 + row);
                    squareButton.Name = "buttonComputer_" + row + "_" + col;
                    squareButton.Size = new System.Drawing.Size(40, 40);
                    squareButton.Text = "";
                    squareButton.Click += this.ProcessButtonHit;

                    squareButtons.Add(squareButton);
                    this.Controls.Add(squareButton);
                }
            }
            return squareButtons;
        }

        private List<SquareButton> DisplayHumanButtons(int rows, int cols, int positionX, int positionY, IEnumerable<Square> shipSquares)
        {
            var squareButtons = new List<SquareButton>();
            for (var row = 0; row < rows; row++)
            {
                for (var col = 0; col < cols; col++)
                {
                    if (row == 0)
                    {
                        DisplayNumberingLabel(positionX + 15 + 40 * col + col, positionY - 15, true, col);
                    }
                    if (col == 0)
                    {
                        DisplayNumberingLabel(positionX - 20, positionY + 15 + row * 40 + row, false, row);
                    }

                    var squareButton = new SquareButton(row, col, Player.Human, shipSquares.Any(s => s.Row == row && s.Column == col) ? SquareButtonState.Ship : SquareButtonState.Initial);
                    squareButton.Location = new System.Drawing.Point(positionX + col * 40 + col, positionY + row * 40 + row);
                    squareButton.Name = "buttonHuman_" + row + "_" + col;
                    squareButton.Size = new System.Drawing.Size(40, 40);
                    squareButton.Text = "";
                    squareButton.Click += this.ProcessButtonHit;

                    squareButtons.Add(squareButton);
                    this.Controls.Add(squareButton);
                }
            }
            return squareButtons;
        }

        private void DisplayNumberingLabel(int posX, int posY, bool isChar, int num)
        {
            var label = new Label();
            label.AutoSize = true;
            label.Location = new System.Drawing.Point(posX, posY);
            label.Size = new System.Drawing.Size(57, 13);
            if (isChar)
            {
                label.Text = Convert.ToChar('A' + num).ToString();
            }
            else
            {
                label.Text = (num + 1).ToString();
            }
            this.Controls.Add(label);
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

        private void buttonResetShips_Click(object sender, EventArgs e)
        {
            foreach (var squareButton in playerSquareButtons)
            {
                Controls.Remove(squareButton);
            }
            playerSquareButtons = DisplayButtonsGrid(Player.Human, gridRowSize, gridColumnSize);
        }
    }
}
