using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vsite.Battleship.Model
{
    public class InlineShooting : INextTarget
    {
        private EnemyGrid enemyGrid;
        private SortedSquares squaresHit;
        private Direction direction;

        public InlineShooting(EnemyGrid enemyGrid, SortedSquares squaresAlreadyHit, int shipLength)
        {
            if (squaresAlreadyHit.Count < 2)
            {
                throw new ArgumentException("Inline shooting requires at least 2 squares already hit!");
            }
            this.enemyGrid = enemyGrid;
            this.squaresHit = squaresAlreadyHit;
            this.direction = squaresHit.First().Row == squaresHit.Last().Row ? Direction.Left : Direction.Up;
        }

        public Square NextTarget()
        {
            if (direction == Direction.Left || direction == Direction.Right)
            {
                var row = squaresHit[0].Row;
                var leftColumn = squaresHit.Min(p => p.Column);
                var rightColumn = squaresHit.Max(p => p.Column);

                var availableSquaresLeft = enemyGrid.GetAvailableSquares(row, leftColumn, Direction.Left);
                var availableSquaresRight = enemyGrid.GetAvailableSquares(row, rightColumn, Direction.Right);

                return availableSquaresRight.Count() > availableSquaresLeft.Count() ? availableSquaresRight.First() : availableSquaresLeft.Last();
            }
            else
            {
                var column = squaresHit[0].Column;
                var upRow = squaresHit.Min(p => p.Row);
                var downRow = squaresHit.Max(p => p.Row);

                var availableSquaresUp = enemyGrid.GetAvailableSquares(upRow, column, Direction.Up);
                var availableSquaresDown = enemyGrid.GetAvailableSquares(downRow, column, Direction.Down);

                return availableSquaresUp.Count() > availableSquaresDown.Count() ? availableSquaresUp.Last() : availableSquaresDown.First();
            }
        }
    }
}
