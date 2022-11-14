using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Baloons.Game
{
    /// <summary>
    /// Игровые выбирации
    /// </summary>
    public class GameVibration : MonoBehaviour
    {
        private bool isVibrationEnabled
        {
            get => PlayerPrefs.GetInt(nameof(isVibrationEnabled), 1) == 1;
            set
            {
                PlayerPrefs.SetInt(nameof(isVibrationEnabled), value ? 1 : 0);
                PlayerPrefs.Save();
            }
        }

        private void Awake()
        {
            Vibration.Init();
            BaloonButton.onBaloonClicked += WeakVibration;
        }

        private void OnDestroy() => BaloonButton.onBaloonClicked -= WeakVibration;

        /// <summary>
        /// Слабые вибрации
        /// </summary>
        public void WeakVibration()
        {
            if (isVibrationEnabled)
            {
                Vibration.VibratePop();
            }
        }

        /// <summary>
        /// Сильные вибрации
        /// </summary>
        public void StrongVibration()
        {
            if (isVibrationEnabled)
            {
                Vibration.VibratePeek();
            }
        }
    }
}