using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Baloons.Game
{
    /// <summary>
    /// ¬ьюшка счетчика
    /// </summary>
    [RequireComponent(typeof(Text))]
    public class CounterView : MonoBehaviour
    {
        private Counter counter = default;
        private Text text = default;

        private void Awake()
        {
            counter = FindObjectOfType<Counter>();
            text = GetComponent<Text>();
            ChangeView(0);
            counter.onValueChanged += ChangeView;
        }

        private void OnDestroy() => counter.onValueChanged -= ChangeView;

        private void ChangeView(int value) => text.text = value.ToString();
    }
}
