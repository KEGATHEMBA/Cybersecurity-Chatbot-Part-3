
using CyberSecuritybot;
using CyberSecurityBot;
using System;
using System.Collections.Generic;

namespace CyberSecurityBot
{
    public class ChatBot
    {
        private Dictionary<string, string> keywordResponses =
            new Dictionary<string, string>()
        {
            {"password","Remember to use a strong password and never share it."},
            {"phishing","Be careful of phishing emails. Never click suspicious links."},
            {"2fa","Two-Factor Authentication greatly improves account security."},
            {"privacy","Review your privacy settings regularly."},
            {"quiz","Type 'Start Quiz' to test your cybersecurity knowledge."}
        };
        private KeywordResponder responder =
            new KeywordResponder();

        private SentimentDetector sentiment =
            new SentimentDetector();

        public string GetReply(string message)
        {
            message = message.ToLower();

            if (message.Contains("hello") || message.Contains("hi"))
                return "Hello! how can i help you with Cybersecurity today?";

            if (message.Contains("password"))
                return "Use a strong password with letters, numbers and symbols.";

            if (message.Contains("phishing"))
                return "Never click suspicious links or attachments.";

            if (message.Contains("privacy"))
                return "Review your privacy settings regularly.";

            return "i am sorry, i dont understand. please ask about passwords, phishing, privacy or scams.";

            if ((message.Contains("add") || message.Contains("create")) && message.Contains("task"))
            { 
                return "I can help you add a task. Please enter the task title and description.";
            }
            if ((message.Contains("remind") || message.Contains("reminder")) && message.Contains("password")) 
            { 
                return "Reminder recognised: Update your password.";
            }
            if ((message.Contains("remind") || message.Contains("reminder")) && message.Contains("privacy"))
            { 
                return "Reminder recognised: Check your privacy settings.";
            }
            if ((message.Contains("remind") || message.Contains("reminder")) && message.Contains("2fa"))
            { 
                return "Reminder recognised: Enable Two-Factor Authentication.";
            }



        }
    }
}