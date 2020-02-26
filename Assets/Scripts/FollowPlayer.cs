using UnityEngine;

namespace ZigZagGame
{
    public class FollowPlayer : MonoBehaviour
    {
        [SerializeField] private Transform transformPlayer;
        [SerializeField] private Transform _transform;
        [SerializeField] private float speed = 10f;

        private void FixedUpdate()
        {
            _transform.position = Vector3.Lerp(_transform.position, transformPlayer.position, speed * Time.fixedDeltaTime);
            _transform.position = new Vector3(_transform.position.x, 0, _transform.position.z);
        }
    }
}
