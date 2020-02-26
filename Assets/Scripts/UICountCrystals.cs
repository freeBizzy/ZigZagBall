using UnityEngine;
using UnityEngine.UI;

namespace ZigZagGame
{
    public class UICountCrystals : MonoBehaviour
    {
        [SerializeField] private Text txtCountCrystals;

        private void OnEnable()
        {
            EventsManager.CrystalCount += this.ShowCountCrystals;
            EventsManager.Mode += this.UseGameMode;
        }

        private void OnDisable()
        {
            EventsManager.CrystalCount -= this.ShowCountCrystals;
            EventsManager.Mode -= this.UseGameMode;
        }

        private void ShowCountCrystals(int value)
        {
            txtCountCrystals.text = value.ToString();
        }

        private void UseGameMode(GameManager.GameMode mode)
        {
            switch (mode)
            {
                case GameManager.GameMode.Start:

                    ShowCountCrystals(0);
                    break;
            }
        }
    }
}
