using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Baloons.Game
{
    /// <summary>
    /// ���������� ������������ ����� ������
    /// </summary>
    public class WindowsConrtoller : MonoBehaviour
    {
        [SerializeField]
        private GameObject startWindow = default;
        [SerializeField]
        private GameObject gameWindow = default;
        [SerializeField]
        private GameObject nameWindow = default;
        [SerializeField]
        private GameObject block = default;

        private void Awake() => DisabledAll();

        private void DisabledAll()
        {
            startWindow.SetActive(false);
            gameWindow.SetActive(false);
            nameWindow.SetActive(false);
            block.SetActive(false);
        }

        /// <summary>
        /// �������� �������� ����
        /// </summary>
        public void SetStartWindow()
        {
            startWindow.SetActive(true);
            ChangeBlockStatus(true);
        }

        /// <summary>
        /// �������� ���� � ������
        /// </summary>
        public void SetNameWindow()
        {
            DisabledAll();
            nameWindow.SetActive(true);
        }

        /// <summary>
        /// �������� ��� ��������� ���������� �������
        /// </summary>
        /// <param name="isBlocked"></param>
        public void ChangeBlockStatus(bool isBlocked) => block.SetActive(isBlocked);
    }
}
