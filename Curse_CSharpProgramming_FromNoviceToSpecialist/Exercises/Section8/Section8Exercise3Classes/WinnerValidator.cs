using Curse_CSharpProgramming_FromNoviceToSpecialist.Exercises.Section8.Section8Exercise3Classes.Player;

namespace Curse_CSharpProgramming_FromNoviceToSpecialist.Exercises.Section8.Section8Exercise3Classes
{
    internal class WinnerValidator
    {
        public IPlayer ValidateWinner(GameGrid gameGrid)
        {
            return ValidateWinnerByTriplet(
                gameGrid,
                (0, 1, 2), (3, 4, 5), (6, 7, 8), // horizontal victory
                (0, 3, 6), (1, 4, 7), (2, 5, 8), // vertical victory
                (0, 4, 8), (2, 4, 6) // crossing victory  
            );
        }

        private IPlayer ValidateWinnerByTriplet(GameGrid gameGrid, params (int indexWin1, int indexWin2, int indexWin3)[] cellWinnerRule)
        {
            foreach (var rule in cellWinnerRule)
            {
                if (gameGrid.GetOwnerCell(rule.indexWin1) == gameGrid.GetOwnerCell(rule.indexWin2) &&
                    gameGrid.GetOwnerCell(rule.indexWin1) == gameGrid.GetOwnerCell(rule.indexWin3))
                {
                    return gameGrid.GetOwnerCell(rule.indexWin1);
                }
            }

            return null;
        }
    }
}