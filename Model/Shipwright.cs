using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vsite.Battleship.Model
{
    public class Shipwright
    {
        public Shipwright(int rows, int columns, IEnumerable<int> shipLengths)
        {
            _fleetGrid = new FleetGrid(rows, columns);
            this.shipLengths = shipLengths;
            squareEliminator = new SquareEliminator(rows, columns);
        }

        private FleetGrid _fleetGrid;
        private IEnumerable<int> shipLengths;
        private Random random = new Random();
        private SquareEliminator squareEliminator;

        //public Fleet CreateFleet()
        //{
        //    for (int i = 0; i < 3; i++)
        //    {
        //        Fleet fleet = new Fleet();
        //        foreach (var shipLength in shipLengths)
        //        {
        //            var availablePlacements = _fleetGrid.GetAvailablePlacements(shipLength);
        //            if (availablePlacements.Count() == 0)
        //            {
        //                // DZ
        //                break;
        //            }
        //            int index = random.Next(availablePlacements.Count());
        //            var selectedPlacement = availablePlacements.ElementAt(index);
        //            fleet.CreateShip(selectedPlacement);
        //            var toEliminate = squareEliminator.ToEliminate(selectedPlacement);
        //            foreach (var square in toEliminate)
        //            {
        //                _fleetGrid.EliminateSquare(square.Row, square.Column);
        //            }
        //        }

        //        return fleet;
        //    }
        //    return null;
        //}

        public Fleet CreateFleet()
        {
            var fleet = new Fleet();
            do
            {
                foreach (var shipLength in shipLengths)
                {
                    var availablePlacements = _fleetGrid.GetAvailablePlacements(shipLength);
                    if (availablePlacements.Count() == 0)
                    {
                        fleet = new Fleet();
                        _fleetGrid = new FleetGrid(_fleetGrid.Rows, _fleetGrid.Rows);
                        squareEliminator = new SquareEliminator(_fleetGrid.Rows, _fleetGrid.Rows);
                        break;
                    }

                    int index = random.Next(availablePlacements.Count());
                    var selectedPlacement = availablePlacements.ElementAt(index);
                    fleet.CreateShip(selectedPlacement);

                    var squaresToEliminate = squareEliminator.ToEliminate(selectedPlacement);
                    foreach (var square in squaresToEliminate)
                    {
                        _fleetGrid.EliminateSquare(square.Row, square.Column);
                    }
                }
            } while (fleet.Ships.Count() != shipLengths.Count());

            return fleet;
        }
    }
}
