using UnityEngine;

namespace ZigZagGame
{
    public class BagCristals : MonoBehaviour
    {
        [SerializeField] private EventsManager eventsManager;
        [SerializeField] private int countCrystal = 0;

        void OnEnable()
        {
            EventsManager.CrystalCatch += this.AddCrystals;
            EventsManager.Mode += this.UseGameMode;
        }

        void OnDisable()
        {
            EventsManager.CrystalCatch -= this.AddCrystals;
            EventsManager.Mode -= this.UseGameMode;
        }

        private void AddCrystals(int value)
        {
            countCrystal += value;
            eventsManager.OnCrystalsCount(countCrystal);
        }

        private void UseGameMode(GameManager.GameMode mode)
        {
            switch (mode)
            {
                case GameManager.GameMode.Start:
                    countCrystal = 0;
                    break;
            }
        }
    }
}
