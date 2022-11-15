using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Baloons.Game
{
    /// <summary>
    /// Изменяет картинку на рондомную
    /// </summary>
    [RequireComponent(typeof(Image))]
    public class IconChanger : MonoBehaviour
    {
        [SerializeField]
        private Sprite[] sprites;

        private Image image;

        private void Awake() => image = GetComponent<Image>();

        /// <summary>
        /// Изменить картинку
        /// </summary>
        public void ChangeImage() => image.sprite = sprites[Random.Range(0, sprites.Length)];
    }
}
