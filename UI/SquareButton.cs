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
            switch (SquareState)
            {
                case SquareState.Initial:
                    this.BackColor = Color.LightGray;
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

        public int Row => row;
        public int Column => column;
        public SquareState SquareState { get; set; } = SquareState.Initial;
    }
}
