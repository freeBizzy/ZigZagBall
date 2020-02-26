using UnityEngine;

namespace ZigZagGame
{
    public class CrystalCollector : MonoBehaviour
    {
        [SerializeField] private EventsManager eventsManager;

        void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent<Crystal>(out var crystal))
            {
                int value = crystal.GetPoints();
                eventsManager.OnCrystalCatch(value);
                eventsManager.OnDisableCrystals(other.gameObject);
            }
        }
    }
}
