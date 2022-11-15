using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Baloons.Game
{
    /// <summary>
    /// Анимация пульсирования
    /// </summary>
    [RequireComponent(typeof(Fader))]
    public class PulseAnimation : MonoBehaviour
    {
        private Fader pulseObject = default;
        private Coroutine pulse = null;

        private void Awake() => pulseObject = GetComponent<Fader>();

        /// <summary>
        /// Начать анимацию пульсирования
        /// </summary>
        public void StartPulseAnumation()
        {
            if (pulse != null)
            {
                StopCoroutine(pulse);
                pulse = null;
            }
            pulse = StartCoroutine(PulseCoroutine());
        }

        private IEnumerator PulseCoroutine()
        {
            float start = 0f;
            float end = 1f;
            float time = 1f;

            while (enabled)
            {
                pulseObject.Fade(start, end, time);
                yield return new WaitForSeconds(time);
                (start, end) = (end, start);
            }
        }

        /// <summary>
        /// Выключить анимацию
        /// </summary>
        public void DisabledPulseAnimation()
        {
            if (pulse != null)
            {
                StopCoroutine(pulse);
                pulse = null;
            }
            pulseObject.Fade(1, 0, 0);
        }
    }
}
