using UnityEngine;

namespace ZigZagGame
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private EventsManager eventsManager;
        [SerializeField] private GameMode gameMode = GameMode.Start;
        public enum GameMode
        {
            Start,
            Game,
            Fail
        }
        private void Start()
        {
            eventsManager.SetMode(gameMode);
        }

        private void OnEnable()
        {
            EventsManager.Mode += this.UseGameMode;
        }

        private void OnDisable()
        {
            EventsManager.Mode -= this.UseGameMode;
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                switch (gameMode)
                {
                    case GameManager.GameMode.Start:
                        gameMode = GameManager.GameMode.Game;
                        eventsManager.SetMode(gameMode);
                        break;

                    case GameManager.GameMode.Fail:
                        gameMode = GameManager.GameMode.Start;
                        eventsManager.SetMode(gameMode);
                        break;

                }
            }
        }

        private void UseGameMode(GameManager.GameMode mode)
        {
            switch (mode)
            {
                case GameManager.GameMode.Fail:
                    gameMode = GameManager.GameMode.Fail;
                    break;
            }

        }

    }
}
