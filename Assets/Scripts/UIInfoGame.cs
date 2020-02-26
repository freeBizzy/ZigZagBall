using UnityEngine;
using UnityEngine.UI;
namespace ZigZagGame
{
    public class UIInfoGame : MonoBehaviour
    {
        [SerializeField] private Text txtCountCrystals;
        private int countPoints = 0;
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
            countPoints = value;
        }

        private void UseGameMode(GameManager.GameMode mode)
        {
            switch (mode)
            {
                case GameManager.GameMode.Start:
                    txtCountCrystals.text = "\n\nTap to start";
                    break;
                case GameManager.GameMode.Game:
                    txtCountCrystals.text = "";
                    break;
                case GameManager.GameMode.Fail:
                    txtCountCrystals.text = "End Game \nYou Points: " + countPoints.ToString();
                    break;
            }
        }
    }
}
