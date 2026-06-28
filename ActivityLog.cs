using System;
using System.Collections.Generic;
using System.Linq;

namespace CyberSecurityBot
{
    public class ActivityLog
    {
        private List<string> activities = new List<string>();

        public void AddLog(string action)
        {
            string log = DateTime.Now.ToString("g") + " - " + action;
            activities.Add(log);
        }

        public string GetRecentLogs()
        {
            if (activities.Count == 0)
                return "No activity recorded yet.";

            var recent = activities.Skip(Math.Max(0, activities.Count - 10));

            return "Here are your recent activities:\n\n"
                   + string.Join("\n", recent);
        }
    }
}
