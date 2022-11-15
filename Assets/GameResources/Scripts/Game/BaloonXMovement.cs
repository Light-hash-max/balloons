using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Baloons.Game
{
    public class BaloonXMovement : MonoBehaviour
    {
        private const int ANIMATION_TIME = 2;
        private const float DEPENDECY_Y_FORCE_FACTOR = 1;

        private Coroutine animationXForceCoroutine = null;
        private float amplitudeX = default;

        /// <summary>
        /// Начать горизонтальные движения
        /// </summary>
        /// <param name="forceYValue"></param>
        public void StartXMovement(float forceYValue)
        {
            amplitudeX = forceYValue * DEPENDECY_Y_FORCE_FACTOR;
            if (animationXForceCoroutine != null)
            {
                StopCoroutine(animationXForceCoroutine);
                animationXForceCoroutine = null;
                if (LeanTween.isTweening(gameObject))
                {
                    LeanTween.cancel(gameObject);
                }
            }
            animationXForceCoroutine = StartCoroutine(ChangeForceDirection());
        }

        private IEnumerator ChangeForceDirection()
        {
            int[] startTurn = { 1, -1 };
            amplitudeX *= startTurn[Random.Range(0, startTurn.Length)];
            LeanTween.moveLocalX(gameObject, amplitudeX, ANIMATION_TIME).setEase(LeanTweenType.easeInOutCubic);
            while (enabled)
            {
                amplitudeX *= -1;
                LeanTween.moveLocalX(gameObject, amplitudeX, ANIMATION_TIME).setEase(LeanTweenType.easeInOutCubic).setDelay(ANIMATION_TIME);
                yield return new WaitForSeconds(ANIMATION_TIME);
            }
        }
    }
}