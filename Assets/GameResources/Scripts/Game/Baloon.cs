using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Baloons.Game
{
    /// <summary>
    /// Управление шаром
    /// </summary>
    [RequireComponent(typeof(BaloonMovment))]
    public class Baloon : MonoBehaviour
    {
        [SerializeField]
        private IconChanger iconChanger = default;

        private BaloonMovment baloonMovment = default;
        private void Awake() => baloonMovment = GetComponent<BaloonMovment>();

        /// <summary>
        /// Задать движение шарика
        /// </summary>
        public void StartBaloonMovment(bool isFixedSpeed)
        {
            iconChanger.ChangeImage();
            baloonMovment.StartMovment(isFixedSpeed);
        }

        /// <summary>
        /// Остановить шарик
        /// </summary>
        public void StopMovement() => gameObject.SetActive(false);

    }
}
