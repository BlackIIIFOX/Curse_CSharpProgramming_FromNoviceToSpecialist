namespace Curse_CSharpProgramming_FromNoviceToSpecialist.Exercises.Section9.Section9Exercise3Classes
{
    internal class QuestionModel
    {
        public string Question { get; set; }
        public bool IsCorrect { get; set; }
        public string Explanation { get; set; }

        public static QuestionModel CreateFromCsvString(string csvQuestion)
        {
            var data = csvQuestion.Split(";");

            return new QuestionModel()
            {
                Question = data[0],
                IsCorrect = data[1] == "Yes",
                Explanation = data[2]
            };
        }
    }
}