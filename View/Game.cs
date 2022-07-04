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
        private readonly int rows;
        private readonly int columns;
        private EnemyGrid enemyGrid;
        private Gunnery gunnery;
        private Shipwright shipwright;
        private Fleet playerFleet;
        private Fleet computerFleet;

        public Game(int rows, int columns, IEnumerable<int> shipLengths)
        {
            this.rows = rows;
            this.columns = columns;
            this.enemyGrid = new EnemyGrid(rows, columns);
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
    }
}
