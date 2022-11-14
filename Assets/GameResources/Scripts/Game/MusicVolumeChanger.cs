using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Baloons.Game
{
    /// <summary>
    /// Изменение громкости музыки
    /// </summary>
    public class MusicVolumeChanger : MonoBehaviour
    {
        /// <summary>
        /// Изменение громкости
        /// </summary>
        public static event Action<float> onValueChanged = delegate { };
        private float musicVolume
        {
            get => PlayerPrefs.GetFloat(nameof(musicVolume), 0.5f);
            set
            {
                PlayerPrefs.SetFloat(nameof(musicVolume), value);
                PlayerPrefs.Save();
            }
        }

        private float lastVolume
        {
            get => PlayerPrefs.GetFloat(nameof(lastVolume), 0.5f);
            set
            {
                PlayerPrefs.SetFloat(nameof(lastVolume), value);
                PlayerPrefs.Save();
            }
        }

        [SerializeField]
        private Slider slider = default;
        [SerializeField]
        private Button button = default;
        [SerializeField]
        private GameObject onMusic = default;
        [SerializeField]
        private GameObject OffMusic = default;

        private void Awake()
        {
            slider.onValueChanged.AddListener(ChangeColume);
            button.onClick.AddListener(ChangeVolumeButton);
        }

        private void OnDestroy()
        {
            slider.onValueChanged.RemoveListener(ChangeColume);
            button.onClick.RemoveListener(ChangeVolumeButton);
        }

        private void OnEnable()
        {
            slider.value = musicVolume;
            ChangeVolumeIcon();
        }

        private void ChangeVolumeButton()
        {
            if (musicVolume != 0)
            {
                lastVolume = musicVolume;
                musicVolume = 0;
            }
            else
            {
                musicVolume = lastVolume;
            }

            slider.value = musicVolume;
            onValueChanged(musicVolume);
        }

        private void ChangeVolumeIcon()
        {
            onMusic.SetActive(musicVolume != 0);
            OffMusic.SetActive(musicVolume == 0);
        }

        private void ChangeColume(float value)
        {
            musicVolume = value;
            onValueChanged(value);
            ChangeVolumeIcon();
        }
    }
}
