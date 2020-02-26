using UnityEngine;

namespace ZigZagGame
{
    public class MovePlayer : MonoBehaviour
    {
        [SerializeField] private float speed = 10;

        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private Transform _transform;

        [SerializeField] private EventsManager eventsManager;

        private bool isMove = false;

        private Vector3 directionMovement = Vector3.back;

        private void Start()
        {
            _rigidbody.maxAngularVelocity = speed;
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
            if (isMove == true)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    ChangeDirection();
                }

                if (_transform.position.y < 0) eventsManager.SetMode(GameManager.GameMode.Fail);
            }
        }

        private void FixedUpdate()
        {
            if (isMove == true)
            {
                Move();
            }
        }

        private void Move()
        {
            _rigidbody.angularVelocity = directionMovement * speed;
        }

        public void ChangeDirection()
        {
            directionMovement = directionMovement == Vector3.back ? Vector3.right : Vector3.back;
        }

        private void UseGameMode(GameManager.GameMode mode)
        {
            switch (mode)
            {
                case GameManager.GameMode.Start:
                    _rigidbody.isKinematic = true;
                    transform.position = new Vector3(0, 0.25f, 0);
                    directionMovement = Vector3.right;
                    break;

                case GameManager.GameMode.Game:
                    _rigidbody.isKinematic = false;
                    isMove = true;
                    break;

                case GameManager.GameMode.Fail:
                    isMove = false;
                    break;

            }

        }

    }
}
