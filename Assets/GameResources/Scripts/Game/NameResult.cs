using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Baloons.Game
{
    /// <summary>
    /// ����������� ������ ���������� ������
    /// </summary>
    public class NameResult : MonoBehaviour
    {
        public string ID { get; private set; } = default;

        [SerializeField]
        private Text nameText = default;
        [SerializeField]
        private Text resultText = default;

        /// <summary>
        /// ��������� ������ ���������� ������
        /// </summary>
        /// <param name="name"></param>
        /// <param name="result"></param>
        public void SetInfo(string name, int result)
        {
            nameText.text = name;
            ID = name;
            resultText.text = result.ToString();
        }
    }
}
