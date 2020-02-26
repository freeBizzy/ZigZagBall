using UnityEngine;
namespace ZigZagGame
{
    public class Platform : MonoBehaviour
    {
        [SerializeField] private protected Transform _transform;
        public virtual Vector3 GetPosition()
        {
            return _transform.position;
        }

        public virtual void SetPosition(Vector3 position)
        {
            _transform.position = position;
        }

        public virtual void SetPosition(Vector3 position, bool isStartPosition)
        {

        }

        public virtual void SetPosition(Vector3 position, bool isStartPosition, int sizePlatform)
        {

        }

        public virtual void SetScale(Vector3 scale)
        {
            _transform.localScale = scale;
        }

        public virtual Vector3 GetScale()
        {
            return _transform.localScale;
        }
    }
}
