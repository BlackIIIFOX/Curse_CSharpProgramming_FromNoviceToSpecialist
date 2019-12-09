using System;

namespace Curse_CSharpProgramming_FromNoviceToSpecialist.Exercises.Section8.Section8Exercise2Classes.Models
{
    internal class AiPlayer : BasePlayer
    {
        private readonly GameSettings _restrictions;

        public AiPlayer(string name, GameSettings aiRestrictions) : base(name)
        {
            _restrictions = aiRestrictions;
        }

        public override void PickNumber()
        {
            GuessedNumber = new Random().Next(_restrictions.MinNumber, _restrictions.MaxNumber);
        }

        protected override int EnterNumber()
        {
            return new Random().Next(_restrictions.MinNumber, _restrictions.MaxNumber);
        }
    }
}
