using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Baloons.Game
{
    /// <summary>
    /// �������� �������� �� ���������
    /// </summary>
    [RequireComponent(typeof(Image))]
    public class IconChanger : MonoBehaviour
    {
        [SerializeField]
        private Sprite[] sprites;

        private Image image;

        private void Awake() => image = GetComponent<Image>();

        /// <summary>
        /// �������� ��������
        /// </summary>
        public void ChangeImage() => image.sprite = sprites[Random.Range(0, sprites.Length)];
    }
}
