using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Curse_CSharpProgramming_FromNoviceToSpecialist.Exercises.Section9.Section9Exercise3Classes
{
    internal class Player
    {
        private readonly Func<string, Task<bool>> _answer;
        private readonly Func<bool, string, Task> _notificationPlayer;

        public Player(string login, Func<string, Task<bool>> answer, Func<bool, string, Task> notificationPlayer)
        {
            Login = login ?? throw new ArgumentNullException(nameof(login));
            _answer = answer ?? throw new ArgumentNullException(nameof(answer));
            _notificationPlayer = notificationPlayer ?? throw new ArgumentNullException(nameof(notificationPlayer));
        }

        public string Login { get; }

        public Task<bool> AnswerOnQuestion(string question)
        {
            return _answer.Invoke(question);
        }

        public Task NotificationPlayerAboutAnswer(bool isCorrectAnswer, string explanation)
        {
            return _notificationPlayer.Invoke(isCorrectAnswer, explanation);
        }
    }
}
