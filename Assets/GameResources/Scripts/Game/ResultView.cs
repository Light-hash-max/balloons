using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Baloons.Game
{
    /// <summary>
    /// Отображение всех результатов
    /// </summary>
    public class ResultView : MonoBehaviour
    {
        [SerializeField]
        private NameResult prefab = default;

        private List<NameResult> nameResults = new List<NameResult>();
        private List<string> names = new List<string>();
        private ResultRecorder resultRecorder = default;
        private NameResult nameResult = default;

        private void Awake() => resultRecorder = FindObjectOfType<ResultRecorder>();

        private void OnEnable()
        {
            names = resultRecorder.Names;

            foreach (string name in names)
            {
                if (CheckResultContains(name))
                {
                    continue;
                }
                nameResult = Instantiate(prefab, transform);
                nameResult.SetInfo(name, PlayerPrefs.GetInt(name, 0));
                nameResults.Add(nameResult);
            }
        }

        private bool CheckResultContains(string name)
        {
            foreach (NameResult result in nameResults)
            {
                if (result.ID == name)
                {
                    result.SetInfo(name, PlayerPrefs.GetInt(name, 0));
                    return true;
                }
            }

            return false;
        }
    }
}
