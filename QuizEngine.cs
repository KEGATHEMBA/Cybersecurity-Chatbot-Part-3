using System;
using System.Collections.Generic;

namespace CyberSecurityBot
{
    public class QuizEngine
    {
        private List<QuizQuestion> questions = new List<QuizQuestion>();
        private int currentIndex = 0;

        public QuizEngine()
        {
            LoadQuestions();
        }

        private void LoadQuestions()
        {
            questions.Add(new QuizQuestion(
                "What should you do if you receive an email asking for your password?",
                new string[] { "Reply with password", "Delete email", "Report as phishing", "Ignore it" },
                2,
                "Reporting phishing emails helps prevent scams."
            ));

            questions.Add(new QuizQuestion(
                "True or False: Strong passwords should include letters, numbers and symbols.",
                new string[] { "True", "False" },
                0,
                "Strong passwords combine different character types."
            ));

            questions.Add(new QuizQuestion(
                "What is phishing?",
                new string[] { "A fishing hobby", "A scam to steal information", "A virus type", "A firewall" },
                1,
                "Phishing tricks users into giving sensitive information."
            ));

            questions.Add(new QuizQuestion(
                "True or False: You should click unknown links to verify them.",
                new string[] { "True", "False" },
                1,
                "Never click unknown links — they may contain malware."
            ));

            questions.Add(new QuizQuestion(
                "Which is safest for passwords?",
                new string[] { "123456", "Your name", "P@ssw0rd!9X", "qwerty" },
                2,
                "Complex passwords are harder to crack."
            ));

            questions.Add(new QuizQuestion(
                "Social engineering is:",
                new string[] { "A programming language", "Tricking people into giving info", "A firewall tool", "A browser" },
                1,
                "It manipulates human behaviour to steal data."
            ));

            questions.Add(new QuizQuestion(
                "True or False: Public Wi-Fi is always safe.",
                new string[] { "True", "False" },
                1,
                "Public Wi-Fi can be insecure and risky."
            ));

            questions.Add(new QuizQuestion(
                "What should you do with suspicious messages?",
                new string[] { "Open them", "Ignore security warnings", "Report them", "Forward to friends" },
                2,
                "Reporting helps protect others from scams."
            ));

            questions.Add(new QuizQuestion(
                "What does 2FA stand for?",
                new string[] { "Two File Access", "Two Factor Authentication", "Fast Access", "Firewall Access" },
                1,
                "2FA adds an extra security layer."
            ));

            questions.Add(new QuizQuestion(
                "True or False: You should share OTP codes with trusted friends.",
                new string[] { "True", "False" },
                1,
                "OTP codes must NEVER be shared."
            ));
        }

        public string GetCurrentQuestion()
        {
            if (currentIndex < questions.Count)
            {
                return questions[currentIndex].GetFormattedQuestion();
            }

            return "Quiz finished! Great job.";
        }

        public string CheckAnswer(int answerIndex)
        {
            if (currentIndex >= questions.Count)
                return "Quiz already completed.";

            var q = questions[currentIndex];

            if (answerIndex == q.CorrectAnswerIndex)
            {
                currentIndex++;
                return "Correct! " + q.Explanation;
            }
            else
            {
                currentIndex++;
                return "Wrong! " + q.Explanation;
            }
        }

        public bool IsFinished()
        {
            return currentIndex >= questions.Count;
        }

        public void Restart()
        {
            currentIndex = 0;
        }
    }
}
