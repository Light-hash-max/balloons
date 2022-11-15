using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Baloons.Game
{
    /// <summary>
    /// Включение и выключение вибраций
    /// </summary>
    public class VibrationEnabledController : MonoBehaviour
    {
        [SerializeField]
        private Button button = default;
        [SerializeField]
        private GameObject vibrationOn = default;
        [SerializeField]
        private GameObject vibrationOff = default;

        private bool isVibrationEnabled
        {
            get => PlayerPrefs.GetInt(nameof(isVibrationEnabled), 1) == 1;
            set
            {
                PlayerPrefs.SetInt(nameof(isVibrationEnabled), value ? 1 : 0);
                PlayerPrefs.Save();
            }
        }

        private void Awake() => button.onClick.AddListener(ChangeVibrationState);

        private void OnDestroy() => button.onClick.RemoveListener(ChangeVibrationState);

        private void ChangeVibrationState()
        {
            isVibrationEnabled = !isVibrationEnabled;
            vibrationOn.SetActive(isVibrationEnabled);
            vibrationOff.SetActive(!isVibrationEnabled);
        }

        private void OnEnable()
        {
            vibrationOn.SetActive(isVibrationEnabled);
            vibrationOff.SetActive(!isVibrationEnabled);
        }
    }
}