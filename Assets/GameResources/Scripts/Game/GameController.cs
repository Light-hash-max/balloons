using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Baloons.Game
{
    /// <summary>
    /// Контроллер игры
    /// </summary>
    public class GameController : MonoBehaviour
    {
        private const float BALOONS_TIME_ANIMATION = 0.02F;
        private const float SPAWN_PROPABILITY_VALUE = 1F;
        private const float WAIT_FIRST = 3f;
        private const float WAIT_SECOND = 1f;
        private const float WAIT_THIRD = 3f;
        private const float START_LOGO_FROM = 0f;
        private const float START_LOGO_TO = 1f;
        private const float START_LOGO_TIME = 0.5f;

        [SerializeField]
        private Fader startMenu = default;
        [SerializeField]
        private Fader startLogo = default;
        [SerializeField]
        private Fader clickText = default;
        [SerializeField]
        private GameObject gamePanel = default;
        [SerializeField]
        private Fader nameFader = default;
        [SerializeField]
        private PulseAnimation pulseAnimation = default;
        [SerializeField]
        private Fader interdace = default;

        private WindowsConrtoller windowsConrtoller = default;
        private PoolController poolController = default;
        private Coroutine startGameCoroutine = null;

        private void Awake()
        {
            poolController = FindObjectOfType<PoolController>();
            windowsConrtoller = FindObjectOfType<WindowsConrtoller>();
        }

        private void Start()
        {
            windowsConrtoller.SetStartWindow();
            PlayStartAnimation();
        }

        private void PlayStartAnimation()
        {
            if (startGameCoroutine != null)
            {
                StopCoroutine(startGameCoroutine);
                startGameCoroutine = null;
            }
            startGameCoroutine = StartCoroutine(SetStartBaloons());
            startLogo.FadeOff();
            clickText.FadeOff();
            startLogo.SetIntaractableStatus(false);
        }

        private IEnumerator SetStartBaloons()
        {
            poolController.StartBaloons(BALOONS_TIME_ANIMATION, SPAWN_PROPABILITY_VALUE, true);
            yield return new WaitForSeconds(WAIT_FIRST);
            poolController.StopBaloons();
            yield return new WaitForSeconds(WAIT_SECOND);
            startLogo.Fade(START_LOGO_FROM, START_LOGO_TO, START_LOGO_TIME);
            startLogo.SetIntaractableStatus(true);

            yield return new WaitForSeconds(WAIT_THIRD);

            windowsConrtoller.ChangeBlockStatus(false);

            pulseAnimation.StartPulseAnumation();
        }

        /// <summary>
        /// Начать игру c панели ввода имени
        /// </summary>
        public void StartGameFromNameEnter()
        {
            gamePanel.SetActive(true);
            interdace.Fade(0, 1, 2);
            StartCoroutine(PanelFade(nameFader));
        }

        /// <summary>
        /// Начать игру
        /// </summary>
        public void StartGame()
        {
            gamePanel.SetActive(true);
            interdace.Fade(0, 1, 2);
            StartCoroutine(PanelFade(startMenu));
        }

        private IEnumerator PanelFade(Fader panelFade)
        {
            panelFade.SetIntaractableStatus(false);
            panelFade.Fade(1, 0, 2);
            yield return new WaitForSeconds(2);
            panelFade.gameObject.SetActive(false);
            poolController.StartBaloons();
        }

        /// <summary>
        /// Выключить анимацию пульсирования
        /// </summary>
        public void DisabledPulseAnimation() => pulseAnimation.DisabledPulseAnimation();
    }
}
