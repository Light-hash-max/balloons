using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Baloons.Game
{
    /// <summary>
    /// Анимация недоступности продолжить игру
    /// </summary>
    public class DisableContinueAnimation : MonoBehaviour
    {
        private const string TRIGGER_SHAKE = "Shake";

        [SerializeField]
        private Animator animator = default;

        /// <summary>
        /// Начать анимацию
        /// </summary>
        public void StartDisableAnimation() => animator.SetTrigger(TRIGGER_SHAKE);
    }
}
