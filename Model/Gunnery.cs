﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vsite.Battleship.Model
{
    public enum ShootingTactics
    {
        Random,
        Surrounding,
        Inline
    }

    public class Gunnery
    {
        public Gunnery(int rows, int columns, IEnumerable<int> shipLengths)
        {
            monitoringGrid = new Grid(rows, columns);
            ChangeToRandomTactics();
        }

        private Grid monitoringGrid;
        private List<Square> squaresHit = new List<Square>();
        private Square lastTarget;

        public Square NextTarget()
        {
            lastTarget = targetSelector.NextTarget();
            return lastTarget;
        }

        public void ProcessHitResult(HitResult hitResult)
        {
            switch (hitResult)
            {
                case HitResult.Missed:
                    return;
                case HitResult.Hit:
                    squaresHit.Add(lastTarget);
                    if (currentTactics == ShootingTactics.Inline)
                        return;
                    break;
                case HitResult.Sunken:
                    squaresHit.Clear();
                    break;
                default:
                    Debug.Assert(false);
                    return;
            }
            ChangeCurrentTactics(hitResult);
        }

        private ShootingTactics currentTactics = ShootingTactics.Random;
        public ShootingTactics ShootingTactics
        {
            get { return currentTactics; }
        }

        private void ChangeCurrentTactics(HitResult hitResult)
        {
            if (hitResult == HitResult.Sunken)
            {
                ChangeToRandomTactics();
            }
            else
            {
                switch (currentTactics)
                {
                    case ShootingTactics.Random:
                        ChangeToSurroundingTactics();
                        break;
                    case ShootingTactics.Surrounding:
                        ChangeToInlineTactics();
                        break;
                    default:
                        Debug.Assert(false);
                        break;
                }
            }
        }

        private void ChangeToSurroundingTactics()
        {
            currentTactics = ShootingTactics.Surrounding;
            targetSelector = new SurroundingShooting(monitoringGrid, squaresHit.First());
        }

        private void ChangeToInlineTactics()
        {
            currentTactics = ShootingTactics.Inline;
            targetSelector = new InlineShooting(monitoringGrid, squaresHit);
        }

        private void ChangeToRandomTactics()
        {
            currentTactics = ShootingTactics.Random;
            targetSelector = new RandomShooting(monitoringGrid);
        }

        private INextTarget targetSelector;
    }
}
