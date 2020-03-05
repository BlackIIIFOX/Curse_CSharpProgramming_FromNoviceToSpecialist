using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Curse_CSharpProgramming_FromNoviceToSpecialist.Exercises.Section9
{
    internal class Section9Exercise2 : IExercise
    {
        private const string PathToFile = @"Exercises\Section9\Section9Exercise2Classes\Resources\Top100ChessPlayers.csv";

        public async Task DoExercise()
        {
            File.ReadAllLines(PathToFile)
                .Skip(1)
                .Select(ChessPlayer.CreateChessPlayer)
                .Where(player => player.Country == "RUS")
                .OrderBy(player => player.BirthYear)
                .ToList()
                .ForEach(player => Console.WriteLine(player.ToString()));

            Console.ReadLine();
        }

        private class ChessPlayer
        {
            //Rank;Name;Title;Country;Rating;Games;B-Year,
            public int Rank { get; private set; }

            public string Name { get; private set; }

            public string Title { get; private set; }

            public string Country { get; private set; }

            public int Rating { get; private set; }

            public int Games { get; private set; }

            public int BirthYear { get; private set; }

            public static ChessPlayer CreateChessPlayer(string playerStringCsv)
            {
                var dataPlayer = playerStringCsv.Split(";");
                return new ChessPlayer()
                {
                    Rank = int.Parse(dataPlayer[0]),
                    Name = dataPlayer[1],
                    Title = dataPlayer[2],
                    Country = dataPlayer[3],
                    Rating = int.Parse(dataPlayer[4]),
                    Games = int.Parse(dataPlayer[5]),
                    BirthYear = int.Parse(dataPlayer[6])
                };
            }

            public override string ToString()
            {
                return $"{nameof(Rank)} : {Rank}; " +
                       $"{nameof(Name)} : {Name}; " +
                       $"{nameof(Title)} : {Title}; " +
                       $"{nameof(Country)} : {Country}; " +
                       $"{nameof(Rating)} : {Rating}; " +
                       $"{nameof(Games)} : {Games}; " +
                       $"{nameof(BirthYear)} : {BirthYear};";
            }
        }
    }
}
