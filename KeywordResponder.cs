namespace CyberSecurityBot
{
    public class KeywordResponder
    {
        public string GetResponse(string message)
        {
            message = message.ToLower();

            if (message.Contains("password"))
            {
                return "Use strong passwords with symbols and numbers.";
            }
            else if (message.Contains("phishing"))
            {
                return "Never click suspicious emails or links.";
            }
            else if (message.Contains("privacy"))
            {
                return "Protect your personal information online.";
            }
            else if (message.Contains("scam"))
            {
                return "Be careful of online scams and fake websites.";
            }
            else
            {
                return "I can help with passwords, phishing, privacy, and scams.";
            }
        }
    }
}