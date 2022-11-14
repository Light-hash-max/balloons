using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Baloons.Game
{
    /// <summary>
    /// Изменение имени
    /// </summary>
    public class NameChanger : MonoBehaviour
    {
        [SerializeField]
        private Button button = default;
        [SerializeField]
        private Fader nameFader = default;
        [SerializeField]
        private GameObject menu = default;
        [SerializeField]
        private PoolController poolController = default;
        [SerializeField]
        private Fader interfaceFader = default;

        private void Awake() => button.onClick.AddListener(ChangeName);

        private void OnDestroy() => button.onClick.RemoveListener(ChangeName);

        private void ChangeName()
        {
            StartCoroutine(PanelFade(nameFader));
            menu.SetActive(false);
            interfaceFader.FadeOff();
        }

        private IEnumerator PanelFade(Fader panelFade)
        {
            panelFade.gameObject.SetActive(true);
            panelFade.SetIntaractableStatus(false);
            panelFade.Fade(0, 1, 2);
            yield return new WaitForSeconds(2);
            panelFade.SetIntaractableStatus(true);
            poolController.StopBaloons();
            poolController.DeleteAllBaloons();
        }
    }
}