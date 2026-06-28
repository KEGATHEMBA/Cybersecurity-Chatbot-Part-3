namespace CyberSecurityBot
{
    public class QuizQuestion
    {
        public string Question { get; set; }
        public string[] Options { get; set; }
        public int CorrectAnswerIndex { get; set; }
        public string Explanation { get; set; }

        public QuizQuestion(string question, string[] options, int correctIndex, string explanation)
        {
            Question = question;
            Options = options;
            CorrectAnswerIndex = correctIndex;
            Explanation = explanation;
        }

        public string GetFormattedQuestion()
        {
            string text = Question + "\n";

            for (int i = 0; i < Options.Length; i++)
            {
                text += $"{i + 1}. {Options[i]}\n";
            }

            return text;
        }
    }
}
