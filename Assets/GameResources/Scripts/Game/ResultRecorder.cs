using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Baloons.Game
{
    /// <summary>
    /// Результаты
    /// </summary>
    public class ResultRecorder : MonoBehaviour
    {
        /// <summary>
        /// Имена всех локальных игроков
        /// </summary>
        public List<string> Names => names;

        private const string NAMES_COUNT_KEY = "NAMES_COUNT_KEY";

        private Counter counter = default;
        private List<string> names = new List<string>();

        private string currentName
        {
            get => PlayerPrefs.GetString(nameof(currentName), string.Empty);
            set
            {
                PlayerPrefs.SetString(nameof(currentName), value);
                PlayerPrefs.Save();
            }
        }

        private void Awake()
        {
            counter = FindObjectOfType<Counter>();
            counter.onValueChanged += RecordResult;
        }

        private void OnDestroy() => counter.onValueChanged -= RecordResult;

        private void OnEnable() => LoadNames();

        private void OnDisable() => SaveNames();

        private void RecordResult(int result)
        {
            if (PlayerPrefs.GetInt(currentName, 0) < result)
            {
                PlayerPrefs.SetInt(currentName, result);
            }

            if (!names.Contains(currentName) && currentName != string.Empty)  
            {
                names.Add(currentName);
            }

            SaveNames();

            PlayerPrefs.Save();
        }

        private void LoadNames()
        {
            int namesCount = PlayerPrefs.GetInt(NAMES_COUNT_KEY, 0);
            names = new List<string>();

            for (int i = 0; i < namesCount; i++)
            {
                if (PlayerPrefs.HasKey(nameof(names) + i)) 
                {
                    names.Add(PlayerPrefs.GetString(nameof(names) + i));
                }
            }
        }

        private void SaveNames()
        {
            for (int i = 0; i < names.Count; i++)
            {
                PlayerPrefs.SetString(nameof(names) + i, names[i]);
            }

            PlayerPrefs.SetInt(NAMES_COUNT_KEY, names.Count);

            PlayerPrefs.Save();
        }
    }
}