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
        private const int gridRowSize = 10;
        private const int gridColumnSize = 10;
        public readonly List<int> shipLengths = new List<int>() { 5, 4, 4, 3, 3, 3, 2, 2, 2, 2 };
        private const int gridButtonStartPositionX = 40;
        private const int gridButtonStartPositionY = 40;
        private List<SquareButton> humanSquareButtons;
        private List<SquareButton> computerSquareButtons;
        private int humanShipsLeft;
        private int computerShipsLeft;
        private List<Label> gridLabels = new List<Label>();
        private Game game;
        private int buttonPlaceFleetCounter = 0;

        public BoardsMainForm()
        {
            InitializeComponent();
            //computerSquareButtons = DisplayButtonsGrid(Player.Computer, gridRowSize, gridColumnSize);
            //humanSquareButtons = DisplayButtonsGrid(Player.Human, gridRowSize, gridColumnSize);
            //CreateButtonsGrid(Player.Human, 10);
            buttonStart.Enabled = false;

            computerSquareButtons = DisplayButtonsGrid(Player.Computer, gridRowSize, gridColumnSize);
            // humanSquareButtons = DisplayButtonsGrid(Player.Human, gridRowSize, gridColumnSize);
        }


        private List<SquareButton> DisplayButtonsGrid(Player player, int rows, int cols)
        {
            if (player == Player.Computer)
            {
                return DisplayMyEvidence(rows, cols, gridButtonStartPositionX + 10, gridButtonStartPositionY);
            }
            else
            {
                var shipSquares = game.CreatePlayerFleet();
                return DisplayMyFleet(rows, cols, gridButtonStartPositionX + 10 , gridButtonStartPositionY, shipSquares);
            }

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
                    squareButton.Click += this.ProcessButtonHit;

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
                    //var squareButton = new SquareButton();
                    squareButton.Location = new System.Drawing.Point(positionX + col * 40 + col, positionY + row * 40 + row);
                    squareButton.Name = "buttonComputer_" + row + "_" + col;
                    squareButton.Size = new System.Drawing.Size(40, 40);
                    squareButton.Text = "";
                    squareButton.Click += this.ProcessButtonHit;

                    squareButtons.Add(squareButton);
                    groupBox_MyEvidence.Controls.Add(squareButton);
                    //groupBox_MyFleet.Controls.Add(squareButton);
                    //this.Controls.Add(squareButton);
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

            gridLabels.Add(label);
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

            gridLabels.Add(label);
            groupBox_MyFleet.Controls.Add(label);
        }

        private void ProcessButtonHit(object sender, EventArgs e)
        {
            var squareButton = sender as SquareButton;


            Debug.WriteLine($"Button clicked---{squareButton.Name}");
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
                this.game = new Game(gridRowSize, gridColumnSize, shipLengths);
                humanSquareButtons = DisplayButtonsGrid(Player.Human, gridRowSize, gridColumnSize);
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

        private void buttonStart_Click(object sender, EventArgs e)
        {
            buttonPlaceFleet.Enabled = buttonStart.Enabled = false;
            var start = GameStart();
            
        }

        private void ResetMyFleet()
        {
            foreach (var squareButton in humanSquareButtons)
            {
                groupBox_MyFleet.Controls.Remove(squareButton);
            }
            humanSquareButtons = DisplayButtonsGrid(Player.Human, gridRowSize, gridColumnSize);
        }
    }
}
