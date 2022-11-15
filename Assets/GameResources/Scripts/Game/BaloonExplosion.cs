using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Baloons.Game
{
    /// <summary>
    /// Физический взрыв
    /// </summary>
    [RequireComponent(typeof(BaloonButton))]
    public class BaloonExplosion : MonoBehaviour
    {

        private const int WAIT_COUNT = 1;

        [SerializeField]
        private GameObject explosionPrefab = default;

        private BaloonButton baloonButton = default;
        private Coroutine explosionCoroutine = default;

        private void Awake()
        {
            baloonButton = GetComponent<BaloonButton>();
            baloonButton.onBaloonClickedLocal += StartExplosion;
        }

        private void OnDestroy() => baloonButton.onBaloonClickedLocal -= StartExplosion;

        private void StartExplosion()
        {
            StopCoroutine();
            explosionCoroutine = StartCoroutine(MakeExplosion());
        }

        private void StopCoroutine()
        {
            if (explosionCoroutine != null)
            {
                explosionPrefab.SetActive(false);
                StopCoroutine(explosionCoroutine);
                explosionCoroutine = null;
            }
        }

        private void OnDisable() => StopCoroutine();

        private IEnumerator MakeExplosion()
        {
            explosionPrefab.SetActive(true);
            int i = 0;
            while (i < WAIT_COUNT)
            {
                yield return null;
                i++;
            }
            explosionPrefab.SetActive(false);
        }
    }
}
