using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI;
using Vsite.Battleship.Model;

namespace GUI_Boards
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

        public SquareButton()
        {
        }

        public void UpdateButtonColor()
        {
            switch (state)
            {
                case SquareButtonState.Initial:
                    BackColor = Color.LightGray;
                    if (player == Player.Computer)
                    {
                        EnableButtonClick();
                    }
                    return;
                case SquareButtonState.Ship:
                    BackColor = Color.Blue;
                    return;
                case SquareButtonState.Missed:
                    BackColor = Color.DarkGray;
                    break;
                case SquareButtonState.Eliminated:
                    BackColor = Color.White;
                    break;
                case SquareButtonState.Hit:
                    BackColor = Color.Red;
                    break;
                case SquareButtonState.Sunken:
                    BackColor = Color.Black;
                    break;
                default:
                    BackColor = Color.LightGray;
                    return;
            }
            if (player == Player.Computer)
            {
                DisableButtonClick();
            }
        }

        private void DisableButtonClick()
        {
            Enabled = false;
        }

        private void EnableButtonClick()
        {
            Enabled = true;
        }

        public int Row => row;
        public int Column => column;
        public SquareButtonState SquareButtonState
        {
            get => state;
            set
            {
                state = value;
                UpdateButtonColor();
            }
        }
    }
}
