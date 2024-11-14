using UnityEngine;

namespace PlayerSpace
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float _playerSpeed;
        private Rigidbody2D _playerRigidbody;
        private Boundary _boundary;
        private Vector2 _moveInput;

        public Vector2 MoveInput
        {
            set
            {
                _moveInput.x = value.x;
                _moveInput.y = value.y;
            }
        }

        private void Awake()
        {
            _playerRigidbody = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            Movement();
        }

        private void Movement()
        {
            _playerRigidbody.linearVelocity = new Vector2(_moveInput.x * _playerSpeed, _playerRigidbody.linearVelocity.y);
        }
    }
}