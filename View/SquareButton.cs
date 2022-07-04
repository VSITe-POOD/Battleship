using System;
using System.Drawing;
using Vsite.Battleship.Model;

namespace View
{
    class SquareButton : System.Windows.Forms.Button
    {
        private readonly int row;
        private readonly int column;
        private readonly Player player;

        public SquareButton(int row, int column, Player player) : base()
        {
            this.row = row;
            this.column = column;
            this.player = player;
            if (player == Player.Human)
            {
                DisableButtonClick();
            }
            UpdateButtonColor();
        }

        public void UpdateButtonColor()
        {
            switch (SquareState)
            {
                case SquareState.Initial:
                    this.BackColor = Color.LightGray;
                    if (player == Player.Computer)
                    {
                        EnableButtonClick();
                    }
                    return;
                case SquareState.Eliminated:
                    this.BackColor = Color.White;
                    break;
                case SquareState.Missed:
                    this.BackColor = Color.DarkGray;
                    break;
                case SquareState.Hit:
                    this.BackColor = Color.Red;
                    break;
                case SquareState.Sunken:
                    this.BackColor = Color.DarkRed;
                    break;
                default:
                    this.BackColor = Color.LightGray;
                    return;
            }
            if (player == Player.Computer)
            {
                DisableButtonClick();
            }
        }

        private void DisableButtonClick()
        {
            this.Enabled = false;
        }

        private void EnableButtonClick()
        {
            this.Enabled = true;
        }

        public int Row => row;
        public int Column => column;
        public Player Player => player;
        public SquareState SquareState { get; set; } = SquareState.Initial;

    }
}
