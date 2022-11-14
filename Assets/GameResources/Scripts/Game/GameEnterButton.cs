using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Baloons.Game
{
    /// <summary>
    ///  нопка ввода имени
    /// </summary>
    [RequireComponent(typeof(Button))]
    public class GameEnterButton : MonoBehaviour
    {
        [SerializeField]
        private Counter counter = default;

        private bool isFirstEnter
        {
            get => PlayerPrefs.GetInt(nameof(isFirstEnter), 1) == 1;
            set
            {
                PlayerPrefs.SetInt(nameof(isFirstEnter), value ? 1 : 0);
            }
        }

        private Button button = default;
        private GameController gameController = default;
        private InputFieldController inputFieldController = default;
        private DisableContinueAnimation disableContinueAnimation = default;
        private GameVibration gameVibration = default;

        private void Awake()
        {
            button = GetComponent<Button>();
            gameController = FindObjectOfType<GameController>();
            inputFieldController = FindObjectOfType<InputFieldController>();
            gameVibration = FindObjectOfType<GameVibration>();
            disableContinueAnimation = FindObjectOfType<DisableContinueAnimation>();
            button.onClick.AddListener(OnButtonClicked);
        }

        private void OnDestroy() => button.onClick.RemoveListener(OnButtonClicked);

        private void OnButtonClicked()
        {
            if (inputFieldController.CurrentName != string.Empty)
            {
                counter.Reset();
                gameController.StartGameFromNameEnter();
                isFirstEnter = false;
            }
            else
            {
                disableContinueAnimation.StartDisableAnimation();
                gameVibration.StrongVibration();
            }
        }
    }
}