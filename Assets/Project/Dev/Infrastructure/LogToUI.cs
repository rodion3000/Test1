using UnityEngine;
using System.Collections.Generic;

namespace Project.Dev.Infrastructure
{
    public class LogToUI : MonoBehaviour
    {
        private List<string> logs = new List<string>();
        public int maxLogs = 100; // Максимальное число сообщений для отображения

        void OnEnable()
        {
            Application.logMessageReceived += HandleLog;
        }

        void OnDisable()
        {
            Application.logMessageReceived -= HandleLog;
        }

        void HandleLog(string logString, string stackTrace, LogType type)
        {
            if (logs.Count > maxLogs)
                logs.RemoveAt(0);
            logs.Add(logString);
        }

        void OnGUI()
        {
            GUILayout.BeginVertical();
            foreach (var log in logs)
            {
                GUILayout.Label(log);
            }

            GUILayout.EndVertical();
        }
    }
}
