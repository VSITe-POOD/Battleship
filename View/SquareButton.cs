using System;
using System.Drawing;
using Vsite.Battleship.Model;

namespace View
{
    class SquareButton : System.Windows.Forms.Button
    {
        private readonly int row;
        private readonly int column;

        public SquareButton(int row, int column) : base()
        {
            this.row = row;
            this.column = column;
            UpdateButtonColor();
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
            this.Enabled = false;
        }

        private void DisableButtonClick()
        {
            throw new NotImplementedException();
        }

        public int Row => row;
        public int Column => column;
        public SquareState SquareState { get; set; } = SquareState.Initial;

    }
}
