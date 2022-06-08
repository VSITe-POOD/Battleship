using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Vsite.Battleship.Model;

namespace Vsite.Battleship
{
    [TestClass]
    public class TestInlineShooting
    {
        [TestMethod]
        public void NextTargetIsSquare2_3OrSquare5_3AfterSquares3_3And4_3AreHit()
        {
            var enemyGrid = new EnemyGrid(10, 10);
            var inline = new InlineShooting(enemyGrid, new SortedSquares { new Square(3, 3), new Square(4, 3) }, 5);
            var target = inline.NextTarget();
            var expected = new List<Square> { new Square(2, 3), new Square(5, 3) };
            CollectionAssert.Contains(expected, target);
        }

        [TestMethod]
        public void NextTargetIsSquare2_3OrSquare5_3AfterSquares4_3And3_3AreHit()
        {
            var enemyGrid = new EnemyGrid(10, 10);
            var inline = new InlineShooting(enemyGrid, new SortedSquares { new Square(4, 3), new Square(3, 3) }, 5);
            var target = inline.NextTarget();
            var expected = new List<Square> { new Square(2, 3), new Square(5, 3) };
            CollectionAssert.Contains(expected, target);
        }

        [TestMethod]
        public void NextTargetIsSquare4_2OrSquare4_7AfterSquares4_4And4_5And4_6And4_3AreHit()
        {
            var enemyGrid = new EnemyGrid(10, 10);
            var inline = new InlineShooting(enemyGrid, new SortedSquares { new Square(4, 4), new Square(4, 5), new Square(4, 6), new Square(4, 3) }, 5);
            var target = inline.NextTarget();
            var expected = new List<Square> { new Square(4, 2), new Square(4, 7) };
            CollectionAssert.Contains(expected, target);
        }
    }
}
