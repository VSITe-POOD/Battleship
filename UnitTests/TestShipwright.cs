﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using Vsite.Battleship.Model;

namespace Vsite.Battleship
{
    [TestClass]
    public class TestShipwright
    {
        [TestMethod]
        public void CreateFleetCreatesFleetForShipLengthsProvided()
        {
            var shipLengths = new List<int>() { 5, 4, 4, 3, 3, 3, 2, 2, 2 };
            var shipwright = new Shipwright(10, 10, shipLengths);

            var fleet = shipwright.CreateFleet();

            Assert.AreEqual(9, fleet.Ships.Count());
            Assert.AreEqual(1, fleet.Ships.Count(ship => ship.Squares.Count() == 5));
            Assert.AreEqual(2, fleet.Ships.Count(ship => ship.Squares.Count() == 4));
            Assert.AreEqual(3, fleet.Ships.Count(ship => ship.Squares.Count() == 3));
            Assert.AreEqual(3, fleet.Ships.Count(ship => ship.Squares.Count() == 2));
        }
    }
}
