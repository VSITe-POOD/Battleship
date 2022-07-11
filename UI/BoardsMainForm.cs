using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GUI_Boards;
using Vsite.Battleship.Model;

namespace UI
{
    enum Player
    {
        Human,
        Computer
    }

    public partial class BoardsMainForm : Form
    {
        private const int gridSize = 10;
        public readonly List<int> shipLengths = new List<int>() { 5, 4, 4, 3, 3, 3, 2, 2, 2, 2 };
        private const int gridButtonStartPositionX = 40;
        private const int gridButtonStartPositionY = 40;
        private List<SquareButton> myFleetSquareButtons;
        private List<SquareButton> myEvidenceSquareButtons;
        private int myFleetShipsLeft;
        private int myEvidenceShipsLeft;
        private List<Label> gridLabelsMyFleet = new List<Label>();
        private List<Label> gridLabelsMyEvidence = new List<Label>();
        private Game game;
        private int buttonPlaceFleetCounter;

        public BoardsMainForm()
        {
            InitializeComponent();
            buttonStart.Enabled = false;
            myEvidenceSquareButtons = DisplayButtonsGrid(Player.Computer, gridSize, gridSize);
        }


        private List<SquareButton> DisplayButtonsGrid(Player player, int rows, int cols)
        {
            if (player == Player.Computer)
            {
                return DisplayMyEvidence(rows, cols, gridButtonStartPositionX + 10, gridButtonStartPositionY);
            }

            var shipSquares = game.CreatemyFleet();
            return DisplayMyFleet(rows, cols, gridButtonStartPositionX + 10 , gridButtonStartPositionY, shipSquares);
            

        }

        private List<SquareButton> DisplayMyFleet(int rows, int cols, int positionX, int positionY, IEnumerable<Square> shipSquares)
        {
            var squareButtons = new List<SquareButton>();
            
            for (var row = 0; row < rows; row++)
            {
                for (var col = 0; col < cols; col++)
                {
                    if (row == 0)
                    {
                        DisplayNumberingLabelMyFleet(positionX + 15 + 40 * col + col, positionY - 15, true, col);
                    }
                    if (col == 0)
                    {
                        DisplayNumberingLabelMyFleet(positionX - 20, positionY + 15 + row * 40 + row, false, row);
                    }

                    var squareButton = new SquareButton(row, col, Player.Human, shipSquares.Any(s => s.Row == row && s.Column == col) ? SquareButtonState.Ship : SquareButtonState.Initial);
                    squareButton.Location = new System.Drawing.Point(positionX + col * 40 + col, positionY + row * 40 + row);
                    squareButton.Name = "buttonHuman_" + row + "_" + col;
                    squareButton.Size = new System.Drawing.Size(40, 40);
                    squareButton.Text = "";
                    squareButton.Click += ProcessButtonHit;

                    squareButtons.Add(squareButton);
                    groupBox_MyFleet.Controls.Add(squareButton);
                }
            }
            return squareButtons;
        }

        private List<SquareButton> DisplayMyEvidence(int rows, int cols, int positionX, int positionY)
        {
            var squareButtons = new List<SquareButton>();
            for (var row = 0; row < rows; row++)
            {
                for (var col = 0; col < cols; col++)
                {
                    if (row == 0)
                    {
                        DisplayNumberingLabelMyEvidence(positionX + 15 + 40 * col + col, positionY - 15, true, col);
                    }
                    if (col == 0)
                    {
                        DisplayNumberingLabelMyEvidence(positionX - 20, positionY + 15 + row * 40 + row, false, row);
                    }
                    
                    var squareButton = new SquareButton(row, col, Player.Computer, SquareButtonState.Initial);
                    squareButton.Location = new System.Drawing.Point(positionX + col * 40 + col, positionY + row * 40 + row);
                    squareButton.Name = "buttonComputer_" + row + "_" + col;
                    squareButton.Size = new System.Drawing.Size(40, 40);
                    squareButton.Text = "";
                    squareButton.Click += ProcessButtonHit;
                    squareButton.Enabled = false;
                    
                    squareButtons.Add(squareButton);
                    groupBox_MyEvidence.Controls.Add(squareButton);
                }
            }
            return squareButtons;
        }

        private void DisplayNumberingLabelMyEvidence(int posX, int posY, bool isChar, int num)
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

            gridLabelsMyEvidence.Add(label);
            groupBox_MyEvidence.Controls.Add(label);
        }

        private void DisplayNumberingLabelMyFleet(int posX, int posY, bool isChar, int num)
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

            gridLabelsMyFleet.Add(label);
            groupBox_MyFleet.Controls.Add(label);
        }

        private void ProcessButtonHit(object sender, EventArgs e)
        {
            var squareButton = sender as SquareButton;

            Debug.WriteLine($"Button clicked---{squareButton.Name}");

            var hitResult = game.PlayerShoot(squareButton.Row, squareButton.Column);
            var myEvidenceSquare = myEvidenceSquareButtons.First(c => c.Row == squareButton.Row && c.Column == squareButton.Column);
            switch (hitResult)
            {
                case HitResult.Missed:
                    myEvidenceSquare.SquareButtonState = SquareButtonState.Missed;
                    break;
                case HitResult.Hit:
                    myEvidenceSquare.SquareButtonState = SquareButtonState.Hit;
                    break;
                case HitResult.Sunken:
                    UpdateSunkenComputerShip(game.GetComputerShipSquaresFromSquare(squareButton.Row, squareButton.Column));
                    myEvidenceShipsLeft -= 1;
                    labelShipsLeftMyEvidence.Text = "Ships left: " + myEvidenceShipsLeft;
                    break;
            }

            labelLastTargetMyEvidence.Text = "Last target: " + Convert.ToChar('A' + squareButton.Column).ToString() + (squareButton.Row + 1);

            if (myEvidenceShipsLeft < 1)
            {
                MessageBox.Show("I won!", "Battleship!");
                GameRestart();
                return;
            }

            ComputerPlays();
        }

        private void buttonPlaceFleet_Click(object sender, EventArgs e)
        {
            buttonStart.Enabled = true;

            buttonPlaceFleetCounter += 1;
            if (buttonPlaceFleetCounter > 1)
            {
                ResetMyFleet();
            }
            else
            {
                game = new Game(gridSize, gridSize, shipLengths);
                myFleetSquareButtons = DisplayButtonsGrid(Player.Human, gridSize, gridSize);
            }
            
        }

        private Player GameStart()
        {
            var random = new Random();
            if (random.Next(2) == 0)
            {
                MessageBox.Show("I start the game!", "Battleship");
                return Player.Human;
            }
            MessageBox.Show("Computer starts the game!", "Battleship");
            return Player.Computer;
        }

        private void GameRestart()
        {
            foreach (var squareButton in myFleetSquareButtons)
            {
                groupBox_MyFleet.Controls.Remove(squareButton);
            }

            foreach (var squareButton in myEvidenceSquareButtons)
            {
                groupBox_MyEvidence.Controls.Remove(squareButton);
            }

            foreach (var label in gridLabelsMyEvidence)
            {
                groupBox_MyEvidence.Controls.Remove(label);
            }

            foreach (var label in gridLabelsMyFleet)
            {
                groupBox_MyFleet.Controls.Remove(label);
            }

            labelLastTargetMyFleet.Text = labelLastTargetMyEvidence.Text = "Last Target: ";
            labelShipsLeftMyEvidence.Text = labelShipsLeftMyFleet.Text = "Ships left";

            buttonStart.Enabled = false;
            buttonPlaceFleet.Enabled = true;
            buttonPlaceFleetCounter = 0;
            myEvidenceSquareButtons = DisplayButtonsGrid(Player.Computer, gridSize, gridSize);
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            buttonPlaceFleet.Enabled = buttonStart.Enabled = false;

            myFleetShipsLeft = shipLengths.Count();
            myEvidenceShipsLeft = shipLengths.Count();

            labelShipsLeftMyFleet.Text = "Ships left: " + myFleetShipsLeft;
            labelShipsLeftMyEvidence.Text = "Ships left: " + myEvidenceShipsLeft;

            foreach (var squarebutton in myEvidenceSquareButtons)
            {
                squarebutton.Enabled = true;
            }

            var playerStarting = GameStart();
            if (playerStarting == Player.Computer)
            {
                ComputerPlays();
            }
        }

        private void ResetMyFleet()
        {
            foreach (var squareButton in myFleetSquareButtons)
            {
                groupBox_MyFleet.Controls.Remove(squareButton);
            }
            myFleetSquareButtons = DisplayButtonsGrid(Player.Human, gridSize, gridSize);
        }

        private void ComputerPlays()
        {
            var target = game.GetComputerTarget();
            var hitResult = game.ComputerShoot(target);
            var humanSquare = myFleetSquareButtons.First(s => s.Row == target.Row && s.Column == target.Column);
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
                    myFleetShipsLeft -= 1;
                    labelShipsLeftMyFleet.Text = "Ships left: " + myFleetShipsLeft;
                    break;
            }

            labelLastTargetMyFleet.Text = "Last target: " + Convert.ToChar('A' + target.Column).ToString() + (target.Row + 1);

            if (myFleetShipsLeft < 1)
            {
                MessageBox.Show("The computer won! Better luck next time!", "BattleShip");
                GameRestart();
            }
        }

        private void UpdateHumanSunkenShip(IEnumerable<Square> shipSquares)
        {
            foreach (var sunkenSquare in shipSquares)
            {
                var humanSquare = myFleetSquareButtons.First(s => s.Row == sunkenSquare.Row && s.Column == sunkenSquare.Column);
                humanSquare.SquareButtonState = SquareButtonState.Sunken;
                foreach (var eliminatedSquare in GetAdjacentEliminatedSquares(humanSquare))
                {
                    eliminatedSquare.SquareButtonState = SquareButtonState.Eliminated;
                }
            }
        }

        private IEnumerable<SquareButton> GetAdjacentEliminatedSquares(SquareButton squareButton)
        {
            if (myFleetSquareButtons.Contains(squareButton))
            {
                return myFleetSquareButtons.Where(
                    s => (s.SquareButtonState == SquareButtonState.Initial || s.SquareButtonState == SquareButtonState.Ship) &&
                    (s.Row == squareButton.Row || s.Row + 1 == squareButton.Row || s.Row - 1 == squareButton.Row) &&
                    (s.Column == squareButton.Column || s.Column + 1 == squareButton.Column || s.Column - 1 == squareButton.Column)
                    );
            }
            else
            {
                return myEvidenceSquareButtons.Where(
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
                var myEvidenceSquare = myEvidenceSquareButtons.First(s => s.Row == sunkenSquare.Row && s.Column == sunkenSquare.Column);
                myEvidenceSquare.SquareButtonState = SquareButtonState.Sunken;
                foreach (var eliminatedSquare in GetAdjacentEliminatedSquares(myEvidenceSquare))
                {
                    eliminatedSquare.SquareButtonState = SquareButtonState.Eliminated;
                }
            }
        }
    }
}
