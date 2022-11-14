using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Baloons.Game
{
    /// <summary>
    /// Контроллер вылета за верхнюю границу
    /// </summary>
    public class OutOfRange : MonoBehaviour
    {
        private Baloon baloon = default;
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent<Baloon>(out baloon))
            {
                baloon.StopMovement();
            }
        }
    }
}
