using System;
using System.Drawing;
using Vsite.Battleship.Model;

namespace View
{
    enum SquareButtonState
    {
        Initial,
        Ship,
        Eliminated,
        Missed,
        Hit,
        Sunken
    }
    class SquareButton : System.Windows.Forms.Button
    {
        private readonly int row;
        private readonly int column;
        private readonly Player player;
        private SquareButtonState state;

        public SquareButton(int row, int column, Player player, SquareButtonState state) : base()
        {
            this.row = row;
            this.column = column;
            this.player = player;
            if (player == Player.Human)
            {
                DisableButtonClick();
            }
            this.state = state;
            UpdateButtonColor();
        }

        public void UpdateButtonColor()
        {
            switch (state)
            {
                case SquareButtonState.Initial:
                    this.BackColor = Color.LightGray;
                    if (player == Player.Computer)
                    {
                        EnableButtonClick();
                    }
                    return;
                case SquareButtonState.Ship:
                    this.BackColor = Color.Blue;
                    return;
                case SquareButtonState.Eliminated:
                    this.BackColor = Color.White;
                    break;
                case SquareButtonState.Missed:
                    this.BackColor = Color.DarkGray;
                    break;
                case SquareButtonState.Hit:
                    this.BackColor = Color.Red;
                    break;
                case SquareButtonState.Sunken:
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
        public SquareButtonState SquareButtonState {
            get => state;
            set { 
                state = value;
                UpdateButtonColor();
            } 
        }

    }
}
