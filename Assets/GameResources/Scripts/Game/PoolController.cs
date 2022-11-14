using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Baloons.Game
{
    /// <summary>
    /// Контроллер пула шаров
    /// </summary>
    public class PoolController : MonoBehaviour
    {
        private const float BALOONS_TIME = 0.4f;
        private const float SPAWN_PROBABILITY = 0.9f;

        [SerializeField]
        private Transform parent = null;
        [SerializeField]
        private Transform leftBoarder = null;
        [SerializeField]
        private Transform rightBoarder = null;
        [SerializeField]
        private Baloon prefab = null;

        private bool isReadyForSpawn => Random.Range(0f, 1f) < spawnProbability;
        private Vector3 spawnedPosition => new Vector3(xPosition, 0, 0);

        private List<Baloon> baloons = new List<Baloon>();
        private float xPosition = 0;
        private Baloon spawnedBaloon = null;
        private Coroutine spawnCoroutine = null;
        private float baloonsTime = BALOONS_TIME;
        private float spawnProbability = SPAWN_PROBABILITY;

        /// <summary>
        /// Выпустить шары
        /// </summary>
        /// <param name="baloonsTimeAnimation"></param>
        /// <param name="spawnProbabilityValue"></param>
        public void StartBaloons(float baloonsTimeAnimation = BALOONS_TIME, float spawnProbabilityValue = SPAWN_PROBABILITY, bool isFixedSpeed = false)
        {
            DeleteAllBaloons();
            baloonsTime = baloonsTimeAnimation;
            spawnProbability = spawnProbabilityValue;

            if (spawnCoroutine != null)
            {
                StopCoroutine(spawnCoroutine);
                spawnCoroutine = null;
            }
            spawnCoroutine = StartCoroutine(SpawnBaloons(isFixedSpeed));
        }

        /// <summary>
        /// Остановить шары
        /// </summary>
        public void StopBaloons()
        {
            if (spawnCoroutine != null)
            {
                StopCoroutine(spawnCoroutine);
                spawnCoroutine = null;
            }
        }

        /// <summary>
        /// Уничтожить все шары
        /// </summary>
        public void DeleteAllBaloons()
        {
            foreach (Baloon baloon in baloons)
            {
                Destroy(baloon.gameObject);
            }
            baloons.Clear();
        }

        private IEnumerator SpawnBaloons(bool isFixedSpeed)
        {
            while (enabled)
            {
                yield return new WaitForSeconds(baloonsTime);
                if (isReadyForSpawn)
                {
                    xPosition = Random.Range(leftBoarder.localPosition.x, rightBoarder.localPosition.x);
                    SelectBaloon(isFixedSpeed);
                }
            }
        }

        private void SelectBaloon(bool isFixedSpeed)
        {
            if (baloons.Count > 0)
            {
                foreach (Baloon baloon in baloons)
                {
                    if (!baloon.isActiveAndEnabled)
                    {
                        baloon.gameObject.SetActive(true);
                        baloon.transform.localPosition = spawnedPosition;
                        baloon.StartBaloonMovment(isFixedSpeed);
                        return;
                    }
                }
            }

            CreateBaloon(isFixedSpeed);
        }

        private void CreateBaloon(bool isFixedSpeed)
        {
            spawnedBaloon = Instantiate(prefab, parent);
            spawnedBaloon.transform.localPosition = spawnedPosition;
            spawnedBaloon.StartBaloonMovment(isFixedSpeed);
            baloons.Add(spawnedBaloon);
        }
    }
}
