using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Baloons.Game
{
    [RequireComponent(typeof(InputField))]
    public class InputFieldController : MonoBehaviour
    {
        /// <summary>
        /// Текущее имя игрока
        /// </summary>
        public string CurrentName => currentName;

        private string currentName
        {
            get => PlayerPrefs.GetString(nameof(currentName), string.Empty);
            set
            {
                PlayerPrefs.SetString(nameof(currentName), value);
                PlayerPrefs.Save();
            }
        }

        private InputField inputField = default;

        private void Awake()
        {
            inputField = GetComponent<InputField>();
            inputField.onValueChanged.AddListener(SaveName);
        }

        private void OnDestroy() => inputField.onValueChanged.RemoveListener(SaveName);

        private void SaveName(string name)
        {
            if (name != string.Empty)
            {
                currentName = name;
            }
        }
    }
}
