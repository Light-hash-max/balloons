using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Baloons.Game
{
    /// <summary>
    /// Музыка в приложении
    /// </summary>
    [RequireComponent(typeof(AudioSource))]
    public class MusicController : MonoBehaviour
    {
        [SerializeField]
        private AudioClip[] audioClips = default;

        private AudioSource audioSource = default;
        private int currentIndex = 0;
        private Coroutine musicCoroutine = null;

        private float musicVolume
        {
            get => PlayerPrefs.GetFloat(nameof(musicVolume), 0.5f);
            set
            {
                PlayerPrefs.SetFloat(nameof(musicVolume), value);
                PlayerPrefs.Save();
            }
        }

        private void Awake()
        {
            audioSource = GetComponent<AudioSource>();
            MusicVolumeChanger.onValueChanged += ChangeVolume;
        }

        private void OnDestroy() => MusicVolumeChanger.onValueChanged -= ChangeVolume;

        private void ChangeVolume(float value) => audioSource.volume = value;

        private void Start()
        {
            if (musicCoroutine != null)
            {
                StopCoroutine(musicCoroutine);
                musicCoroutine = null;
            }
            musicCoroutine = StartCoroutine(MusicChanger());
            ChangeVolume(musicVolume);
        }

        private IEnumerator MusicChanger()
        {
            currentIndex = 0;
            while (enabled)
            {
                audioSource.clip = audioClips[currentIndex];
                audioSource.Play();
                yield return new WaitForSecondsRealtime(audioSource.clip.length);
                currentIndex++;
                if (currentIndex >= audioClips.Length)
                {
                    currentIndex = 0;
                }
            }
        }
    }
}
