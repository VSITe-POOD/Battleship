using System.Collections.Generic;
using System.Diagnostics;

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
        private ShootingTactics currentTactics = ShootingTactics.Random;
        private EnemyGrid monitoringGrid;
        private INextTarget targetSelector;
        private SortedSquares squaresHit = new SortedSquares();
        private Square lastTarget = new Square(0, 0);
        private List<int> shipsToShoot;
        private SquareEliminator squareEliminator;

        public Gunnery(int rows, int columns, IEnumerable<int> shipLengths)
        {
            monitoringGrid = new EnemyGrid(rows, columns);
            squareEliminator = new SquareEliminator(rows, columns);
            shipsToShoot = new List<int>(shipLengths);
            ChangeToRandomTactics();
        }

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
                    RecordOnMonitoringGrid(hitResult);
                    return;
                case HitResult.Hit:
                    squaresHit.Add(lastTarget);
                    RecordOnMonitoringGrid(hitResult);
                    switch (ShootingTactics)
                    {
                        case ShootingTactics.Random:
                            ChangeToSurroundingTactics();
                            return;
                        case ShootingTactics.Surrounding:
                            ChangeToInlineTactics();
                            return;
                        case ShootingTactics.Inline:
                            return;
                        default:
                            Debug.Assert(false);
                            break;
                    }
                    return;
                case HitResult.Sunken:
                    squaresHit.Add(lastTarget);
                    shipsToShoot.Remove(squaresHit.Count);
                    RecordOnMonitoringGrid(hitResult);
                    squaresHit.Clear();
                    ChangeToRandomTactics();
                    return;
                default:
                    Debug.Assert(false);
                    break;
            }

        }

        private void RecordOnMonitoringGrid(HitResult hitResult)
        {
            switch (hitResult)
            {
                case HitResult.Missed:
                    monitoringGrid.ChangeSquareState(lastTarget.Row, lastTarget.Column, SquareState.Missed);
                    return;
                case HitResult.Hit:
                    monitoringGrid.ChangeSquareState(lastTarget.Row, lastTarget.Column, SquareState.Hit);
                    return;
                case HitResult.Sunken:
                    foreach (var square in squaresHit)
                    {
                        monitoringGrid.ChangeSquareState(square.Row, square.Column, SquareState.Sunken);
                    }
                    foreach (var square in squareEliminator.ToEliminate(squaresHit))
                    {
                        monitoringGrid.ChangeSquareState(square.Row, square.Column, SquareState.Eliminated);
                    }
                    return;
                default:
                    Debug.Assert(false);
                    break;
            }
        }

        private void ChangeToRandomTactics()
        {
            currentTactics = ShootingTactics.Random;
            targetSelector = new RandomShooting(monitoringGrid, shipsToShoot[0]);
        }

        private void ChangeToSurroundingTactics()
        {
            currentTactics = ShootingTactics.Surrounding;
            targetSelector = new SurroundingShooting(monitoringGrid, squaresHit[0], shipsToShoot[0]);
        }

        private void ChangeToInlineTactics()
        {
            currentTactics = ShootingTactics.Inline;
            targetSelector = new InlineShooting(monitoringGrid, squaresHit, shipsToShoot[0]);
        }

        public ShootingTactics ShootingTactics => currentTactics;
    }
}
