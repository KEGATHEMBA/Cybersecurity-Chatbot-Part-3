namespace CyberSecuritybot
{
    public class SentimentDetector
    {
        public string DetectMood(string message)
        {
            message = message.ToLower();

            if (message.Contains("worried"))
            {
                return "I understand your concern.";
            }

            if (message.Contains("happy"))
            {
                return "Glad you are feeling positive.";
            }

            return "";
        }
    }
}