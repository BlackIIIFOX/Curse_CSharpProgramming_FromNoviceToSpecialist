using System;
using System.Text;
using Curse_CSharpProgramming_FromNoviceToSpecialist.Exercises.Section8.Section8Exercise3Classes.Player;

namespace Curse_CSharpProgramming_FromNoviceToSpecialist.Exercises.Section8.Section8Exercise3Classes
{
    internal class TicTacToeGame
    {
        private readonly Score _score = new Score();
        private readonly WinnerValidator _winnerValidator = new WinnerValidator();

        public TicTacToeGame(IPlayer player1, AiMode aiMode = AiMode.Easy)
        {
            GameGrid = new GameGrid();
            Player1 = player1;
            Player2 = new AiPlayer(aiMode, GameGrid);
            Player1Symbol = (Symbols)new Random().Next(0, 2);
            Player2Symbol = Player1Symbol == Symbols.O ? Symbols.X : Symbols.O;
        }

        public TicTacToeGame(IPlayer player1, IPlayer player2)
        {
            Player1 = player1;
            Player2 = player2;
            GameGrid = new GameGrid();
            Player1Symbol = (Symbols)new Random().Next(0, 1);
            Player2Symbol = Player1Symbol == Symbols.O ? Symbols.X : Symbols.O;
        }

        public IPlayer Player1 { get; }
        public Symbols Player1Symbol { get; }
        public IPlayer Player2 { get; }
        public Symbols Player2Symbol { get; }
        public GameGrid GameGrid { get; }

        public void StartGame()
        {
            Console.WriteLine("Start new game");
            Console.WriteLine("Grid markup:");
            Console.WriteLine(GetPrintableGridMarkup());
            Console.WriteLine();
            Console.WriteLine($"{Player1.Login} - {Player1Symbol} vs {Player2.Login} - {Player2Symbol}");

            
            while (true)
            {
                var player = new Random().Next(0, 2) == 0 ? Player1 : Player2;
                Console.WriteLine($"{Player1.Login} : {_score.Player1Wins} | {Player2.Login} : {_score.Player2Wins} | Draw : {_score.Draw}");
                
                while (true)
                {
                    Console.WriteLine(GetPrintableGameGrid());
                    Console.WriteLine($"{player.Login} makes a move (enter the cell number from the markup)");
                    var indexMarkupCell = player.MakeTurn();

                    try
                    {
                        GameGrid.SetToCell(player, indexMarkupCell - 1);
                    }
                    catch (OccupiedCellException)
                    {
                        Console.WriteLine($"The cell {indexMarkupCell} is already taken.");
                        continue;
                    }

                    var winner = _winnerValidator.ValidateWinner(GameGrid);
                    if (winner != null)
                    {
                        Console.WriteLine($"{winner.Login} is winner.");
                        if (winner == Player1)
                        {
                            _score.Player1Wins++;
                        }
                        else
                        {
                            _score.Player2Wins++;
                        }

                        break;
                    }

                    if (GameGrid.CountFreeCells == 0)
                    {
                        Console.WriteLine($"The game ended in a draw.");
                        _score.Draw++;
                        break;
                    }

                    player = player == Player1 ? Player2 : Player1;
                }
                GameGrid.ResetGameGrid();

            }
        }

        private string GetPrintableGridMarkup()
        {
            var markup =
                "     |     |     |" + Environment.NewLine +
                "  1  |  2  |  3  |" + Environment.NewLine +
                "_____|_____|_____|" + Environment.NewLine +
                "     |     |     |" + Environment.NewLine +
                "  4  |  5  |  6  |" + Environment.NewLine +
                "_____|_____|_____|" + Environment.NewLine +
                "     |     |     |" + Environment.NewLine +
                "  7  |  8  |  9  |" + Environment.NewLine +
                "_____|_____|_____|";
            return markup;
        }

        private string GetPrintableGameGrid()
        {
            var stringBuilder = new StringBuilder();
            for (var i = 0; i < 3; i++)
            {
                stringBuilder.AppendLine("     |     |     |");
                stringBuilder.AppendLine($"  {GetPlayerSymbolText(GameGrid.GetOwnerCell(i * 3 + 0))}  |" +
                                         $"  {GetPlayerSymbolText(GameGrid.GetOwnerCell(i * 3 + 1))}  |" +
                                         $"  {GetPlayerSymbolText(GameGrid.GetOwnerCell(i * 3 + 2))}  |");
                stringBuilder.AppendLine($"_____|_____|_____|");
            }

            return stringBuilder.ToString();
        }

        private string GetPlayerSymbolText(IPlayer player)
        {
            if (player == null)
            {
                return " ";
            }

            return player == Player1 ? Player1Symbol.ToString() : Player2Symbol.ToString();
        }

        private class Score
        {
            public int Player1Wins { get; set; }
            public int Player2Wins { get; set; }
            public int Draw { get; set; }
        }
    }
}
