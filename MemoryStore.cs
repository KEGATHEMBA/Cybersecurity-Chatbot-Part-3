using System.Collections.Generic;

namespace CyberSecurityBot
{
    public class MemoryStore
    {
        private Dictionary<string, string> memory =
            new Dictionary<string, string>();

        public void SaveMemory(string key, string value)
        {
            memory[key] = value;
        }

        public string GetMemory(string key)
        {
            if (memory.ContainsKey(key))
            {
                return memory[key];
            }

            return "";
        }
    }
}