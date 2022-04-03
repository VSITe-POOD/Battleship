﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using Vsite.Battleship.Model;

namespace Vsite.Battleship
{
    [TestClass]
    public class TestGrid
    {
        [TestMethod]
        public void ConstructoCreatesGridOf100SquaresForAGridWith10Rows10Columns()
        {
            Grid grid = new Grid(10, 10);
            Assert.AreEqual(100, grid.Squares.Count());
            Assert.IsTrue(grid.Squares.Contains(new Square(0, 0)));
            Assert.IsTrue(grid.Squares.Contains(new Square(9, 9)));
            Assert.IsTrue(grid.Squares.Contains(new Square(0, 9)));
            Assert.IsTrue(grid.Squares.Contains(new Square(9, 0)));
        }

        [TestMethod]
        public void GetAvailablePlacementsReturns2PlacementsForAShip3SquaresLongOnGrid1Row4Columns()
        {
            Grid grid = new Grid(1, 4);
            var placements = grid.GetAvailablePlacements(3);
            Assert.AreEqual(2, placements.Count());

        }

        [TestMethod]
        public void GetAvailablePlacementsReturns2PlacmentsForAShip3SquaresLongOnGrid5Rows1Columns()
        {
            var grid = new Grid(5, 1);

            var placements = grid.GetAvailablePlacements(3);

            Assert.AreEqual(3, placements.Count());
        }

        [TestMethod]
        public void GetAvailablePlacemetsReturns3PlacementsForAShip2SquaresLongOnGrid1Row6ColumnsAfterSquareInColumn2IsElimanated()
        {
            Grid grid = new Grid(1, 6);
            grid.EliminateSquare(0, 2);
            Assert.AreEqual(5, grid.Squares.Count());
            var placements = grid.GetAvailablePlacements(2);
            Assert.AreEqual(3, placements.Count());

        }

        [TestMethod]
        public void GetAvailablePlacementsReturns2PlacementsForAShip2SquaresLongOnGrid5Rows1ColumnAfterSquareInRow2IsEliminated()
        {
            Grid grid = new Grid(5, 1);
            grid.EliminateSquare(2, 0);
            Assert.AreEqual(4, grid.Squares.Count());
            var placements = grid.GetAvailablePlacements(2);
            Assert.AreEqual(2, placements.Count());
        }
    }
}
