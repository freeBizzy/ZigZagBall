using UnityEngine;

namespace ZigZagGame
{
    public class Crystal : MonoBehaviour
    {
        [SerializeField] private protected int points = 1;
        public virtual int GetPoints()
        {
            return points;
        }
    }
}
