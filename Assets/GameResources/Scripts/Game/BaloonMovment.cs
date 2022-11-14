using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Baloons.Game
{
    /// <summary>
    /// Движение шарика
    /// </summary>
    public class BaloonMovment : MonoBehaviour
    {
        private const float MIN_FORCE_Y = 10;
        private const float MAX_FORCE_Y = 30;
        private const float START_MIN_RORCE_Y = 40f;
        private const float START_MAX_RORCE_Y = 40f;

        [SerializeField]
        private BaloonXMovement baloonXMovement = default;

        private Vector3 forceY = default;
        private Rigidbody2D rigidbody2d = default;
        private float forceYValue = default;

        private void Awake() => rigidbody2d = GetComponent<Rigidbody2D>();

        /// <summary>
        /// Задать движение шариков
        /// </summary>
        public void StartMovment(bool isFixedSpeed)
        {
            forceYValue = isFixedSpeed ? Random.Range(START_MIN_RORCE_Y, START_MAX_RORCE_Y) : Random.Range(MIN_FORCE_Y, MAX_FORCE_Y);
            forceY = new Vector3(0, forceYValue);
            rigidbody2d.AddForce(forceY);
            baloonXMovement.StartXMovement(forceYValue);
        }
    }
}
