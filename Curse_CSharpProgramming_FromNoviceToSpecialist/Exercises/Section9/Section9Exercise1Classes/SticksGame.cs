using System;
using System.Threading.Tasks;
using Curse_CSharpProgramming_FromNoviceToSpecialist.Exercises.Section9.Section9Exercise1Classes.EventHandlers;
using Curse_CSharpProgramming_FromNoviceToSpecialist.Exercises.Section9.Section9Exercise1Classes.Player;

namespace Curse_CSharpProgramming_FromNoviceToSpecialist.Exercises.Section9.Section9Exercise1Classes
{
    internal class SticksGame
    {
        private readonly IPlayer _firstPlayer;
        private readonly IPlayer _secondPlayer;
        public EventHandler<StatusGameEventArgs> ErrorTakenSticksEventHandler;
        public EventHandler<StatusGameEventArgs> PlayerTakenSticksEventHandler;
        public EventHandler<GameEndEventArgs> GameIsEndEventHandler;

        public SticksGame(IPlayer player, int totalSticksNumber = 10) : this(player, null,
            totalSticksNumber)
        {
            _secondPlayer = new AiPlayer(AiMode.Easy, this);
        }

        public SticksGame(IPlayer firstPlayer, IPlayer secondPlayer,
            int totalSticksNumber = 10)
        {
            _firstPlayer = firstPlayer ?? throw new ArgumentNullException(nameof(firstPlayer));
            _secondPlayer = secondPlayer;

            if (totalSticksNumber <= 6 || totalSticksNumber >= 30)
                throw new ArgumentOutOfRangeException(nameof(totalSticksNumber));

            TurnPlayer = firstPlayer;

            TotalSticksNumber = totalSticksNumber;
            RemainingSticksNumber = totalSticksNumber;
            StatusGame = GameStatuses.NotStarted;
        }

        public GameStatuses StatusGame { get; private set; }

        public int TotalSticksNumber { get; }

        public int RemainingSticksNumber { get; private set; }

        public IPlayer TurnPlayer { get; private set; }

        public async Task StartGameAsync()
        {
            if (StatusGame == GameStatuses.InProgress)
                throw new InvalidOperationException("Game already started.");

            if (StatusGame == GameStatuses.GameOver)
                RemainingSticksNumber = TotalSticksNumber;

            StatusGame = GameStatuses.InProgress;

            while (StatusGame == GameStatuses.InProgress )
            {
                var stickWasTaken =  await TurnPlayer.MakeTurn();
                if (stickWasTaken < 1 || stickWasTaken > 3 || RemainingSticksNumber - stickWasTaken < 0)
                {
                    ErrorTakenSticksEventHandler.Invoke(this,
                        new StatusGameEventArgs()
                        {
                            RemainingSticks = this.RemainingSticksNumber, 
                            TotalSticks = this.TotalSticksNumber,
                            TurnPlayer = this.TurnPlayer,
                            PlayerTaken = stickWasTaken
                        });
                    continue;
                }

                RemainingSticksNumber -= stickWasTaken;

                PlayerTakenSticksEventHandler.Invoke(this,
                    new StatusGameEventArgs()
                    {
                        RemainingSticks = this.RemainingSticksNumber,
                        TotalSticks = this.TotalSticksNumber,
                        TurnPlayer = this.TurnPlayer,
                        PlayerTaken = stickWasTaken
                    });

                if (RemainingSticksNumber == 0)
                {
                    StatusGame = GameStatuses.GameOver;
                    GameIsEndEventHandler?.Invoke(this, new GameEndEventArgs() { Winner = this.TurnPlayer});
                }

                TurnPlayer = TurnPlayer == _firstPlayer ? _secondPlayer : _firstPlayer;
            }
        }
    }
}
