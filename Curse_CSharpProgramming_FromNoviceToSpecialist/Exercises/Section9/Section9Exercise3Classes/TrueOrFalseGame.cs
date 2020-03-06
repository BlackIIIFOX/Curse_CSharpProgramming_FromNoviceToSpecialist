using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Curse_CSharpProgramming_FromNoviceToSpecialist.Exercises.Section9.Section9Exercise3Classes.Enums;

namespace Curse_CSharpProgramming_FromNoviceToSpecialist.Exercises.Section9.Section9Exercise3Classes
{
    internal class TrueOrFalseGame
    {
        private readonly Player _player;
        private readonly string _fileQuestionPath;
        private List<QuestionModel> _questions;

        public TrueOrFalseGame(Player player, string fileQuestionPath, int maxAttempts = 2)
        {
            _player = player;
            _fileQuestionPath = fileQuestionPath;
            MaxAttempts = maxAttempts;
            GameStatus = GameStatuses.NotStarted;
        }

        public GameStatuses GameStatus { get; private set; }

        public int CurrentAttempt { get; private set; }

        public int MaxAttempts { get; }

        public async Task StartGame()
        {
            GameStatus = GameStatuses.InProgress;
            await LoadQuestionsAsync();

            foreach (var question in _questions)
            {
                var answer = await _player.AnswerOnQuestion(question.Question);
                var answerIsCorrect = answer == question.IsCorrect;
                
                if (!answerIsCorrect)
                {
                    CurrentAttempt++;
                }

                await _player.NotificationPlayerAboutAnswer(answerIsCorrect, question.Explanation);

                if (CurrentAttempt > MaxAttempts)
                {
                    GameStatus = GameStatuses.IsLose;
                    break;
                }
            }

            if (GameStatus != GameStatuses.IsLose)
            {
                GameStatus = GameStatuses.IsWin;
            }
        }

        private async Task LoadQuestionsAsync()
        {
            var lines = await File.ReadAllLinesAsync(_fileQuestionPath);
            _questions = lines.Select(QuestionModel.CreateFromCsvString).ToList();

        }
    }
}
