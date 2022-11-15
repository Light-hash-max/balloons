using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Baloons.Game
{
    /// <summary>
    /// Начальная кнопка
    /// </summary>
    public class StartBaloonButton : MonoBehaviour, IPointerDownHandler
    {
        [SerializeField]
        private ParticleSystem particle = default;

        private WindowsConrtoller windowsConrtoller = default;
        private GameController gameController = default;
        private GameVibration gameVibration = default;

        private bool isFirstEnter
        {
            get => PlayerPrefs.GetInt(nameof(isFirstEnter), 1) == 1;
            set
            {
                PlayerPrefs.SetInt(nameof(isFirstEnter), value ? 1 : 0);
            }
        }

        private void Awake()
        {
            windowsConrtoller = FindObjectOfType<WindowsConrtoller>();
            gameController = FindObjectOfType<GameController>();
            gameVibration = FindObjectOfType<GameVibration>();
        }

        private void OnButtonClicked()
        {
            gameVibration.WeakVibration();
            particle.Play();
            gameController.DisabledPulseAnimation();

            if (isFirstEnter)
            {
                windowsConrtoller.SetNameWindow();
            }
            else
            {
                gameController.StartGame();
            }

            gameObject.SetActive(false);
        }

        void IPointerDownHandler.OnPointerDown(PointerEventData eventData) => OnButtonClicked();
    }
}
