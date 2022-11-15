using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Baloons.Game
{

    /// <summary>
    /// Плавное изменение прозрачности
    /// </summary>
    [RequireComponent(typeof(CanvasGroup))]
    public class Fader : MonoBehaviour
    {
        private CanvasGroup canvasGroup = default;
        private float startFadeValue = default;
        private float endfadeValue = default;
        private float fadeTime = default;

        private void Awake() => canvasGroup = GetComponent<CanvasGroup>();

        /// <summary>
        /// Сделать обект невидимым
        /// </summary>
        public void FadeOff() => canvasGroup.alpha = 0;

        /// <summary>
        /// Изменить прозрачность в заданном отрезке за заданное время
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="time"></param>
        public void Fade(float from, float to, float time)
        {
            startFadeValue = from;
            endfadeValue = to;
            fadeTime = time;
            ChangeFade();
        }

        /// <summary>
        /// Изменить состояния интерактивности
        /// </summary>
        /// <param name="isIntaractable"></param>
        public void SetIntaractableStatus(bool isIntaractable)
        {
            canvasGroup.interactable = isIntaractable;
            canvasGroup.blocksRaycasts = isIntaractable;
        }

        private void ChangeFade()
        {
            if (LeanTween.isTweening(gameObject))
            {
                LeanTween.cancel(gameObject);
            }

            LeanTween.value(gameObject, startFadeValue, endfadeValue, fadeTime).setEase(LeanTweenType.linear).setOnUpdate((float value) =>
            {
                canvasGroup.alpha = value;
            });
        }
    }
}
