using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Baloons.Game
{
    /// <summary>
    /// �������� ������������� ���������� ����
    /// </summary>
    public class DisableContinueAnimation : MonoBehaviour
    {
        private const string TRIGGER_SHAKE = "Shake";

        [SerializeField]
        private Animator animator = default;

        /// <summary>
        /// ������ ��������
        /// </summary>
        public void StartDisableAnimation() => animator.SetTrigger(TRIGGER_SHAKE);
    }
}
