using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Baloons.Game
{
    /// <summary>
    /// Контроллер партиклов
    /// </summary>
    public class ParticalController : MonoBehaviour
    {
        [SerializeField]
        private ParticleSystem prefab = default;
        [SerializeField]
        private Transform parent = default;

        private List<ParticleSystem> particles = new List<ParticleSystem>();
        private ParticleSystem particle = default;

        public void PlayPartical(PointerEventData eventData)
        {
            if (particles.Count <= 0)
            {
                CreatePartical(eventData);
                return;
            }

            foreach (ParticleSystem particle in particles)
            {
                if (!particle.isPlaying)
                {
                    particle.transform.position = eventData.pointerCurrentRaycast.worldPosition;
                    particle.Play();
                    return;
                }
            }

            CreatePartical(eventData);
        }

        private void CreatePartical(PointerEventData eventData)
        {
            particle = Instantiate(prefab, parent);
            PlayPartical(particle, eventData);
            particles.Add(particle);
        }

        private void PlayPartical(ParticleSystem particleSystem, PointerEventData pointerEventData)
        {
            particleSystem.transform.position = pointerEventData.pointerCurrentRaycast.worldPosition;
            particleSystem.Play();
        }
    }
}
