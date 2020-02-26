using UnityEngine;

namespace ZigZagGame
{
    public class EventsManager : MonoBehaviour
    {
        //-----------------------------------------------------------------
        //------------------------GameModeDelegate-------------------------
        //-----------------------------------------------------------------

        public delegate void GameModeDelegate(GameManager.GameMode mode);

        public static event GameModeDelegate Mode;

        public void SetMode(GameManager.GameMode mode)
        {
            Mode?.Invoke(mode);
        }

        //-----------------------------------------------------------------
        //----------------------CrystalDelegate----------------------------
        //-----------------------------------------------------------------

        public delegate void CrystalDelegate(int value);

        public delegate void CrystalDisableDelegate(GameObject value);

        public static event CrystalDelegate CrystalCatch;

        public static event CrystalDelegate CrystalCount;

        public static event CrystalDisableDelegate DisableCrystal;

        public void OnCrystalCatch(int value)
        {
            CrystalCatch?.Invoke(value);
        }
        public void OnCrystalsCount(int value)
        {
            CrystalCount?.Invoke(value);
        }

        public void OnDisableCrystals(GameObject value)
        {
            DisableCrystal?.Invoke(value);
        }

    }
}
