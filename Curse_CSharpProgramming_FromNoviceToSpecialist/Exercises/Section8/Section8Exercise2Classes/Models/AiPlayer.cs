using System;
using System.Linq;

namespace Curse_CSharpProgramming_FromNoviceToSpecialist.Exercises.Section8.Section8Exercise2Classes.Models
{
    internal class AiPlayer : BasePlayer
    {
        private readonly GameSettings _restrictions;

        public AiPlayer(string name, GameSettings aiRestrictions) : base(name)
        {
            _restrictions = (GameSettings)aiRestrictions.Clone();
        }

        public override void PickNumber()
        {
            GuessedNumber = new Random().Next(_restrictions.MinNumber, _restrictions.MaxNumber);
            Console.WriteLine($"{PlayerName} picked a number");
        }

        protected override int EnterNumber()
        {
            // Binary search algorithm.
            var lastResult = _attempts.LastOrDefault();

            switch (lastResult?.Result)
            {
                case GuessingStates.NumberIsLess:
                    _restrictions.MaxNumber = lastResult.Number;
                    break;
                case GuessingStates.NumberIsMore:
                    _restrictions.MinNumber = lastResult.Number;
                    break;
                case GuessingStates.NumberIsEqual:
                    throw new InvalidOperationException($"The game should already be over. {PlayerName} guessed the number last time.");
                case null:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            return (_restrictions.MaxNumber + _restrictions.MinNumber) / 2;
        }
    }
}
