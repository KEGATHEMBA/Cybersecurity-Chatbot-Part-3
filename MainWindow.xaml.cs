using System;
using System.Windows;
using System.Windows.Documents;

namespace CyberSecurityBot
{
    public partial class MainWindow : Window
    {
        ChatBot bot = new ChatBot();
        MemoryStore memory = new MemoryStore();
        TaskManager manager = new TaskManager();
        QuizEngine quiz = new QuizEngine();
        ActivityLog activityLog = new ActivityLog();

        public MainWindow()
        {
            InitializeComponent();
            AddBotMessage("Welcome to the Cybersecurity ChatBot!");
        }

        private void BtnSend_Click(object sender, RoutedEventArgs e)
        {
            string userMessage = txtMessage.Text.ToLower();

            if (userMessage.Contains("remind") && userMessage.Contains("password"))
            {
                manager.AddTask(
                    "Update Password",
                    "Change your password to a strong one.");

                activityLog.AddLog("Task added: " + txtTaskTitle.Text);

                AddBotMessage("Task added: Update Password");

            }

            if (userMessage.Contains("privacy"))
            {
                manager.AddTask(
                    "Check Privacy Settings",
                    "Review your privacy settings.");

                AddBotMessage("Task added: Check Privacy Settings");
            }

            if (userMessage.Contains("2fa"))
            {
                manager.AddTask(
                    "Enable 2FA",
                    "Turn on Two-Factor Authentication.");

                AddBotMessage("Task added: Enable 2FA");
            }

            if (string.IsNullOrWhiteSpace(userMessage))
            {
                MessageBox.Show("Please type a message.");
                return;
            }

            AddUserMessage(userMessage);

            if (userMessage.Contains("remind") && userMessage.Contains("password"))
            {
                manager.AddTask("Update Password", "Change your password to a strong one.");
                activityLog.AddLog("Reminder set: Update Password");
                AddBotMessage("✅ Reminder added: Update your password.");
            }

            else if (userMessage.Contains("privacy"))
            {
                manager.AddTask("Check Privacy Settings", "Review your privacy settings.");
                AddBotMessage("✅ Reminder added: Check your privacy settings.");
            }

            else if (userMessage.Contains("2fa"))
            {
                manager.AddTask("Enable 2FA", "Turn on Two-Factor Authentication.");
                AddBotMessage("✅ Task added: Enable 2FA.");
            }

            else if (userMessage.Contains("phishing"))
            {
                AddBotMessage("⚠️ Be cautious of phishing emails. Never click suspicious links or share your password.");
            }

            else if (userMessage.Contains("quiz"))
            {
                quiz.Restart();
                AddBotMessage("Cybersecurity Quiz Started!");
                AddBotMessage(quiz.GetCurrentQuestion());
            }

            string response = bot.GetReply(userMessage);

            AddBotMessage(response);

            txtMessage.Clear();
        }

        private void BtnAddTask_Click(object sender, RoutedEventArgs e)
        {
            manager.AddTask(
                txtTaskTitle.Text,
                txtTaskDescription.Text);

            MessageBox.Show("Task added successfully!");

            txtTaskTitle.Clear();
            txtTaskDescription.Clear();
        }

        private void BtnViewTasks_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("View Tasks feature coming next.");
        }

        private void BtnCompleteTask_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Complete Task feature coming next.");
        }

        private void BtnDeleteTask_Click(object sender, RoutedEventArgs e)
        {

            if (int.TryParse(txtQuizAnswer.Text, out int index))
            {
                bool success = manager.CompleteTask(index - 1);

                if (success)
                {
                    AddBotMessage("Task marked as completed.");
                    activityLog.AddLog("Task completed");
                }
                else
                {
                    AddBotMessage("Invalid task number.");
                }
            }
            else
            {
                MessageBox.Show("Please enter a valid task number.");
            }
        }

        private void AddBotMessage(string message)
        {
            rtbChat.Document.Blocks.Add(new Paragraph(new Run("Bot: " + message)));
        }

        private void AddUserMessage(string message)
        {
            rtbChat.Document.Blocks.Add(new Paragraph(new Run("You: " + message)));
        }

        private void rtbChat_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)

        {

        }

        private void BtnStartQuiz_Click(object sender, RoutedEventArgs e)
        {
            quiz.Restart();
            AddBotMessage("Cybersecurity Quiz Started!");
            AddBotMessage(quiz.GetCurrentQuestion());
            activityLog.AddLog("Quiz started");
        }

        private void BtnSubmitAnswer_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(txtQuizAnswer.Text, out int answer))
            {
                string result = quiz.CheckAnswer(answer - 1);
                AddBotMessage(result);

                if (!quiz.IsFinished())
                {
                    AddBotMessage(quiz.GetCurrentQuestion());
                }
                else
                {
                    AddBotMessage("Quiz completed! Well done on learning cybersecurity safety.");
                    activityLog.AddLog("Quiz completed");
                }


            }
        }
    }
}
        