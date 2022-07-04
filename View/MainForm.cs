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
        private List<SquareButton> humanSquareButtons;
        private List<SquareButton> computerSquareButtons;
        private int humanShipsLeft;
        private int computerShipsLeft;

        public MainForm()
        {
            InitializeComponent();
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            buttonStart.Visible = false;
            this.game = new Game(gridRowSize, gridColumnSize, shipLengths);

            humanSquareButtons = DisplayButtonsGrid(Player.Human, gridRowSize, gridColumnSize);
            computerSquareButtons = DisplayButtonsGrid(Player.Computer, gridRowSize, gridColumnSize);

            var res = MessageBox.Show("Do you want to reroll your Ships placement?", "Ship placement", MessageBoxButtons.YesNo);
            while (res == DialogResult.Yes)
            {
                ResetShips();
                res = MessageBox.Show("Do you want to reroll your Ships placement again?", "Ship placement", MessageBoxButtons.YesNo);
            }

            humanShipsLeft = shipLengths.Count();
            computerShipsLeft = shipLengths.Count();

            labelShipsLeftHuman.Text = "Ships left: " + humanShipsLeft;
            labelShipsLeftComputer.Text = "Ships left: " + computerShipsLeft;

            var startsFirst = WhoStartsFirst();
            if (startsFirst == Player.Computer)
            {
                ComputerPlays();  
            }
        }

        private void ComputerPlays()
        {
            var target = game.GetComputerTarget();
            var hitResult = game.ComputerShoot(target);
            var humanSquare = humanSquareButtons.Where(s => s.Row == target.Row && s.Column == target.Column).First();
            switch (hitResult)
            {
                case HitResult.Missed:
                    humanSquare.SquareButtonState = SquareButtonState.Missed;
                    break;
                case HitResult.Hit:
                    humanSquare.SquareButtonState = SquareButtonState.Hit;
                    break;
                case HitResult.Sunken:
                    UpdateHumanSunkenShip(game.GetPlayerShipSquaresFromSquare(target.Row, target.Column));
                    humanShipsLeft -= 1;
                    labelShipsLeftHuman.Text = "Ships left: " + humanShipsLeft;
                    break;
                default:
                    break;
            }

            labelLastTargetComputer.Text = "Last target: " + Convert.ToChar('A' + target.Column).ToString() + (target.Row + 1);

            if (humanShipsLeft < 1)
            {
                MessageBox.Show("The END, you lose!", "Winner Computer!");
                RestartGame();
                return;
            }
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
            
            Debug.WriteLine($"Square clicked---{squareButton.Name}");

            var hitResult = game.PlayerShoot(squareButton.Row, squareButton.Column);
            var computerSquare = computerSquareButtons.Where(c => c.Row == squareButton.Row && c.Column == squareButton.Column).First();
            switch (hitResult)
            {
                case HitResult.Missed:
                    computerSquare.SquareButtonState = SquareButtonState.Missed;
                    break;
                case HitResult.Hit:
                    computerSquare.SquareButtonState = SquareButtonState.Hit;
                    break;
                case HitResult.Sunken:
                    UpdateSunkenComputerShip(game.GetComputerShipSquaresFromSquare(squareButton.Row, squareButton.Column));
                    computerShipsLeft -= 1;
                    labelShipsLeftComputer.Text = "Ships left: " + computerShipsLeft;
                    break;
                default:
                    break;
            }

            labelLastTargetHuman.Text = "Last target: " + Convert.ToChar('A' + squareButton.Column).ToString() + (squareButton.Row + 1);
            if (computerShipsLeft < 1)
            {
                MessageBox.Show("Congratulations, you win!", "Winner Human!");
                RestartGame();
                return;
            }

            ComputerPlays();
        }

        private void RestartGame()
        {
            foreach (var squareButton in humanSquareButtons)
            {
                Controls.Remove(squareButton);
            }
            foreach (var squareButton in computerSquareButtons)
            {
                Controls.Remove(squareButton);
            }
            buttonStart.Visible = true;
        }

        private void UpdateHumanSunkenShip(IEnumerable<Square> shipSquares)
        {
            foreach (var sunkenSquare in shipSquares)
            {
                var humanSquare = humanSquareButtons.Where(s => s.Row == sunkenSquare.Row && s.Column == sunkenSquare.Column).First();
                humanSquare.SquareButtonState = SquareButtonState.Sunken;
                foreach (var eliminatedSquare in GetAdjacentEliminatedSquares(humanSquare))
                {
                    eliminatedSquare.SquareButtonState = SquareButtonState.Eliminated;
                }
            }
        }

        private IEnumerable<SquareButton> GetAdjacentEliminatedSquares(SquareButton squareButton)
        {
            if (humanSquareButtons.Contains(squareButton))
            {
                return humanSquareButtons.Where(
                    s => (s.SquareButtonState == SquareButtonState.Initial || s.SquareButtonState == SquareButtonState.Ship) &&
                    (s.Row == squareButton.Row || s.Row + 1 == squareButton.Row || s.Row - 1 == squareButton.Row) &&
                    (s.Column == squareButton.Column || s.Column + 1 == squareButton.Column || s.Column - 1 == squareButton.Column)
                    );
            }
            else
            {
                return computerSquareButtons.Where(
                    s => (s.SquareButtonState == SquareButtonState.Initial || s.SquareButtonState == SquareButtonState.Ship) &&
                    (s.Row == squareButton.Row || s.Row + 1 == squareButton.Row || s.Row - 1 == squareButton.Row) &&
                    (s.Column == squareButton.Column || s.Column + 1 == squareButton.Column || s.Column - 1 == squareButton.Column)
                    );
            }
        }

        private void UpdateSunkenComputerShip(IEnumerable<Square> shipSquares)
        {
            foreach (var sunkenSquare in shipSquares)
            {
                var computerSquare = computerSquareButtons.Where(s => s.Row == sunkenSquare.Row && s.Column == sunkenSquare.Column).First();
                computerSquare.SquareButtonState = SquareButtonState.Sunken;
                foreach (var eliminatedSquare in GetAdjacentEliminatedSquares(computerSquare))
                {
                    eliminatedSquare.SquareButtonState = SquareButtonState.Eliminated;
                }
            }
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

        private void ResetShips()
        {
            foreach (var squareButton in humanSquareButtons)
            {
                Controls.Remove(squareButton);
            }
            humanSquareButtons = DisplayButtonsGrid(Player.Human, gridRowSize, gridColumnSize);
        }
    }
}
