using System;
using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Baloons.Game
{
    /// <summary>
    /// Нажатие на кнопку
    /// </summary>
    public class BaloonButton : MonoBehaviour, IPointerDownHandler
    {
        /// <summary>
        /// По нажатию на шарик
        /// </summary>
        public static event Action onBaloonClicked = delegate { };

        /// <summary>
        /// По нажатию на шарик не статическое
        /// </summary>
        public event Action onBaloonClickedLocal = delegate { };

        private const int WAIT_COUNT = 2;

        [SerializeField]
        private Baloon baloon = default;

        private ParticalController particalController = default;
        private Coroutine stopBaloonCoroutine = default;

        private void Awake() => particalController = FindObjectOfType<ParticalController>();
        void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
        {
            onBaloonClicked();
            onBaloonClickedLocal();
            particalController.PlayPartical(eventData);

            StopCoroutine();
            stopBaloonCoroutine = StartCoroutine(StopMovment());
        }

        private void StopCoroutine()
        {
            if (stopBaloonCoroutine != null)
            {
                StopCoroutine(stopBaloonCoroutine);
                stopBaloonCoroutine = null;
            }
        }

        private void OnDisable() => StopCoroutine();

        private IEnumerator StopMovment()
        {
            int i = 0;
            while (i < WAIT_COUNT)
            {
                yield return null;
                i++;
            }
            baloon.StopMovement();
        }
    }
}