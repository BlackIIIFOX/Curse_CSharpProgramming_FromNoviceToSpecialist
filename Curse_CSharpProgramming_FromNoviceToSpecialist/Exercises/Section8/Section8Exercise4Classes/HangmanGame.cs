using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using Curse_CSharpProgramming_FromNoviceToSpecialist.Exercises.Section8.Section8Exercise4Classes.Enums;
using Curse_CSharpProgramming_FromNoviceToSpecialist.Exercises.Section8.Section8Exercise4Classes.Interfaces;

namespace Curse_CSharpProgramming_FromNoviceToSpecialist.Exercises.Section8.Section8Exercise4Classes
{
    internal class HangmanGame : IHangmanGame
    {
        private string _hiddenWord;
        private Dictionary<int, char> _guessedLetter;
        private List<char> _triedLetters;

        public HangmanGame(int maxTotalAttempts = 6)
        {
            GameStatus = GameStatuses.NotStarted;
            MaximumTotalAttempts = maxTotalAttempts;
            ResetGame();
        }

        public GameStatuses GameStatus { get; private set; }
        public int MaximumTotalAttempts { get; }
        public int AttemptsUsed { get; private set; }
        public int WordLength { get; private set; }

        public IReadOnlyDictionary<int, char> GuessedLetter => new ReadOnlyDictionary<int, char>(_guessedLetter);
        public IReadOnlyCollection<char> TriedLetters => new ReadOnlyCollection<char>(_triedLetters);

        public bool TryToGuessLetter(char letter)
        {
            // If already included.
            if (_triedLetters.Contains(letter))
                return true;

            _triedLetters.Add(letter);
            var isGuessed = false;
            for (var i = 0; i < WordLength; i++)
            {
                if (_hiddenWord[i] == letter)
                {
                    _guessedLetter.Add(i, letter);
                    isGuessed = true;
                }
            }

            if (!isGuessed)
            {
                AttemptsUsed++;
            }

            if (AttemptsUsed == MaximumTotalAttempts || _guessedLetter.Count == WordLength)
            {
                GameStatus = _guessedLetter.Count == WordLength ? GameStatuses.IsWin : GameStatuses.IsLoss;
            }

            return isGuessed;
        }

        public void ResetGame()
        {
            MakeNewWord();
            _triedLetters = new List<char>();
            AttemptsUsed = 0;
            GameStatus = GameStatuses.InProgress;
        }

        public string GetWordIfGameEnd()
        {
            if (GameStatus == GameStatuses.IsWin || GameStatus == GameStatuses.IsLoss)
                return _hiddenWord;

            throw new InvalidOperationException("Game not end.");
        }

        private void MakeNewWord()
        {
            _hiddenWord = GetRandomWordFromDictionary();
            WordLength = _hiddenWord.Length;
            _guessedLetter = new Dictionary<int, char>();
        }

        private static string GetRandomWordFromDictionary()
        {
            var words = File.ReadAllLines(
                "Exercises\\Section8\\Section8Exercise4Classes\\Resources\\WordsStockRus.txt");
            var randomIndex = new Random(DateTime.Now.Millisecond).Next(words.Length);
            return words[randomIndex];
        }
    }
}