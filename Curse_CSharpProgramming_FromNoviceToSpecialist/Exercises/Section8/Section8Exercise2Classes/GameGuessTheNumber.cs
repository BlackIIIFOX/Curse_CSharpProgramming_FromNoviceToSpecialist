using System;
using Curse_CSharpProgramming_FromNoviceToSpecialist.Exercises.Section8.Section8Exercise2Classes.Models;

namespace Curse_CSharpProgramming_FromNoviceToSpecialist.Exercises.Section8.Section8Exercise2Classes
{
    internal class GameGuessTheNumber
    {
        private readonly GameSettings _gameSettings = new GameSettings();
        private BasePlayer _mysterious;
        private BasePlayer _guessing;

        public GameGuessTheNumber(BasePlayer player) : this(player, null)
        {
        }

        public GameGuessTheNumber(BasePlayer player1, BasePlayer player2)
        {
            if (player2 == null)
            {
                player2 = new AiPlayer("AiPlayer", _gameSettings);
            }

            Console.WriteLine($"Start new Game. {player1.PlayerName} vs {player2.PlayerName}");
            ChosePlayMod(player1, player2);
            CustomizeGame();
            _mysterious.PickNumber();
        }

        public void Play()
        {
            var isGuessed = false;
            var isAllAttemptsUsed = false;

            while (!isAllAttemptsUsed && !isGuessed)
            {
                var number = _guessing.TryGuessNumber();
                isAllAttemptsUsed = _guessing.AttemptsUsed >= _gameSettings.MaxAttempts;

                var resultAttempt = _mysterious.SuggestNumber(number);
                _guessing.AppendResultAttempt(new AttemptModel(_guessing.AttemptsUsed, number, resultAttempt));

                switch (resultAttempt)
                {
                    case GuessingStates.NumberIsLess:
                        Console.WriteLine($"The guessed number is less than {number}.");
                        break;
                    case GuessingStates.NumberIsMore:
                        Console.WriteLine($"The guessed number is more than {number}.");
                        break;
                    case GuessingStates.NumberIsEqual:
                        isGuessed = true;
                        Console.WriteLine($"{_guessing.PlayerName} guessed the number {number}");
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }

            if (!isGuessed)
            {
                Console.WriteLine(
                    $"{_guessing.PlayerName} used {_gameSettings.MaxAttempts} attempts, but the number was not guessed. The number guessed was {_mysterious.GuessedNumber}");
            }
        }

        private void ChosePlayMod(BasePlayer player1, BasePlayer player2)
        {
            Console.WriteLine("Who will guess the number (enter a name)?");

            while (true)
            {
                var name = Console.ReadLine();

                if (player1.PlayerName.Equals(name))
                {
                    _mysterious = player1;
                    _guessing = player2;
                }
                else
                {
                    if (player2.PlayerName.Equals(name))
                    {
                        _mysterious = player2;
                        _guessing = player1;
                    }
                    else
                    {
                        Console.WriteLine(name == null
                            ? $"You have not entered a name."
                            : $"{name} is not involved in the game.");

                        continue;
                    }
                }

                break;
            }

            Console.WriteLine($"{_mysterious.PlayerName} will make up numbers in this game.");
        }

        private void CustomizeGame()
        {
            while (true)
            {
                Console.WriteLine($"Max attempts in game = {_gameSettings.MaxAttempts}");
                Console.WriteLine($"Min number in game = {_gameSettings.MinNumber}");
                Console.WriteLine($"Max number in game = {_gameSettings.MaxNumber}");

                Console.WriteLine("Are you comfortable with the settings? (Y/N)");

                try
                {
                    if (Console.ReadLine().ToLower().StartsWith("N".ToLower()))
                    {
                        Console.WriteLine("Entering new settings.");
                        Console.WriteLine($"Max attempts in game = ");
                        var newMaxAttempts = int.Parse(Console.ReadLine());
                        Console.WriteLine($"Min number in game = ");
                        var newMinNumber = int.Parse(Console.ReadLine());
                        Console.WriteLine($"Max number in game = ");
                        var newMaxNumber = int.Parse(Console.ReadLine());

                        _gameSettings.MaxAttempts = newMaxAttempts;
                        _gameSettings.MinNumber = newMinNumber;
                        _gameSettings.MaxNumber = newMaxNumber;

                        continue;
                    }
                }
                catch
                {
                    Console.WriteLine("Left basic game settings.");
                }

                break;
            }
        }
    }
}