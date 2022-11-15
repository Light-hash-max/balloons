using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Baloons.Game
{
    /// <summary>
    /// Счетчик лопнутых шариков
    /// </summary>
    public class Counter : MonoBehaviour
    {
        /// <summary>
        /// Изменение счетчик
        /// </summary>
        public event Action<int> onValueChanged = delegate { };
        
        /// <summary>
        /// Общий счет
        /// </summary>
        public int AllCounts
        {
            get => allCounts;
            private set
            {
                allCounts = value;
                onValueChanged(allCounts);
            }
        }

        private const int ONE_BALOON_COUNT = 1;

        private int allCounts = 0;

        private void Awake() => BaloonButton.onBaloonClicked += AddPoints;

        private void Start() => AllCounts = 0;

        /// <summary>
        /// Обновить счетчик
        /// </summary>
        public void Reset() => AllCounts = 0;

        private void OnDestroy() => BaloonButton.onBaloonClicked -= AddPoints;

        private void AddPoints() => AllCounts += ONE_BALOON_COUNT;
    }
}
