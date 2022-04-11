﻿using System.Collections.Generic;
using System.Linq;

namespace Vsite.Battleship.Model
{
    public class Ship
    {
        public readonly IEnumerable<Square> Squares;

        public HitResult Shoot(int row, int column)
        {
            if (!Squares.Contains(new Square(row, column)))
            {
                return HitResult.Missed;
            }
            var hitSquare = Squares.First(s => s.Row == row && s.Column == column);
            hitSquare.ChangeState(SquareState.Hit);
            int squaresHit = Squares.Count(s => s.SquareState != SquareState.Missed || s.SquareState != SquareState.Initial);
            if (squaresHit == Squares.Count())
            {
                foreach (var square in Squares)
                {
                    square.ChangeState(SquareState.Sunken);
                }
                return HitResult.Sunken;
            }
            return HitResult.Hit;
        }
        public Ship(IEnumerable<Square> squares)
        {
            this.Squares = squares;
        }
    }
}
