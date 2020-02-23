using System;
using Curse_CSharpProgramming_FromNoviceToSpecialist.Exercises.Section8.Section8Exercise3Classes.Player;

namespace Curse_CSharpProgramming_FromNoviceToSpecialist.Exercises.Section8.Section8Exercise3Classes
{
    internal class GameGrid
    {
        private readonly GridCell[,] _gridCells = new GridCell[3, 3];

        public GameGrid()
        {
            ResetGameGrid();
        }

        public int CountFreeCells { get; private set; }

        public void SetToCell(IPlayer player, int indexMarkupCell)
        {
            if (player == null) throw new ArgumentNullException();

            var (indexRow, indexColumn) = IndexMarkupConverter(indexMarkupCell);
            var cell = _gridCells[indexRow, indexColumn];
            cell.Owner = cell.Owner == null
                ? player
                : throw new OccupiedCellException(
                    $"The Cell[{indexRow}, {indexColumn}] is occupied by the other owner."
                );

            CountFreeCells--;
        }

        public IPlayer GetOwnerCell(int indexMarkupCell)
        {
            var (indexRow, indexColumn) = IndexMarkupConverter(indexMarkupCell);
            return _gridCells[indexRow, indexColumn].Owner;
        }

        public void ResetGameGrid()
        {
            for (var i = 0; i < 3; i++)
            {
                for (var j = 0; j < 3; j++)
                {
                    _gridCells[i, j] = new GridCell();
                }
            }

            CountFreeCells = 9;
        }

        private (int indexRow, int indexColumn) IndexMarkupConverter(int indexMarkupCell)
        {
            return (indexMarkupCell / 3, indexMarkupCell % 3);
        }

        private class GridCell
        {
            public IPlayer Owner { get; set; }
        }
    }
}