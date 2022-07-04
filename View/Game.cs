using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vsite.Battleship.Model;

namespace View
{
    public class Game
    {
        private Gunnery gunnery;
        private Shipwright shipwright;
        private Fleet playerFleet;
        private Fleet computerFleet;

        public Game(int rows, int columns, IEnumerable<int> shipLengths)
        {
            this.gunnery = new Gunnery(rows, columns, shipLengths);
            this.shipwright = new Shipwright(rows, columns, shipLengths);
            this.computerFleet = shipwright.CreateFleet();
        }

        public IEnumerable<Square> CreatePlayerFleet()
        {
            var shipSquareList = new List<Square>();
            playerFleet = shipwright.CreateFleet();

            foreach (var ship in playerFleet.Ships)
            {
                foreach (var square in ship.Squares)
                {
                    shipSquareList.Add(square);
                }
            }
            return shipSquareList;
        }

        public HitResult PlayerShoot(int row, int col)
        {
            return computerFleet.Shoot(row, col);
        }

        public Square GetComputerTarget()
        {
            return gunnery.NextTarget();

        }

        public HitResult ComputerShoot(Square target)
        {
            var hitResult = playerFleet.Shoot(target.Row, target.Column);
            gunnery.ProcessHitResult(hitResult);
            return hitResult;
        }

        public IEnumerable<Square> GetPlayerShipSquaresFromSquare(int row, int col)
        {
            return playerFleet.Ships.Where(sh => sh.Squares.Any(sq => sq.Row == row && sq.Column == col)).First().Squares;
        }
        public IEnumerable<Square> GetComputerShipSquaresFromSquare(int row, int col)
        {
            return computerFleet.Ships.Where(sh => sh.Squares.Any(sq => sq.Row == row && sq.Column == col)).First().Squares;
        }
    }
}
