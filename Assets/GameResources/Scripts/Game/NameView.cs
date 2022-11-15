using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Baloons.Game
{
    /// <summary>
    /// Отображение текущего имени
    /// </summary>
    [RequireComponent(typeof(Text))]
    public class NameView : MonoBehaviour
    {
        private string currentName
        {
            get => PlayerPrefs.GetString(nameof(currentName), string.Empty);
            set
            {
                PlayerPrefs.SetString(nameof(currentName), value);
                PlayerPrefs.Save();
            }
        }

        private Text text = default;

        private void Awake() => text = GetComponent<Text>();

        private void OnEnable() => text.text = currentName;
    }
}
