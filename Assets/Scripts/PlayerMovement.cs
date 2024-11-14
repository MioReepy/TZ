using System;
using InputSpace;
using UnityEngine;

namespace PlayerSpace
{
    public class PlayerMovement : MonoBehaviour
    {
        [Header("Movement")]
        [SerializeField] private float _playerSpeed;
        [SerializeField] private float _jumpForce = 5f;
        private InputController _inputController;
        internal Rigidbody2D _playerRigidbody;
        private Boundary _boundary;
        private Vector2 _moveInput;
        private bool _isFlip;
        private int _jumpCount = 2;
        internal bool isMoving;
        
        [Header("ColisionInfo")]
        [SerializeField] private Transform _groundCheckTransform;
        [SerializeField] private float _groundCheckRadius;
        [SerializeField] private LayerMask _groundLayerMask;
        internal bool _isGround;

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
            _inputController = GetComponent<InputController>();
        }

        private void OnEnable()
        {
            _inputController.OnJump += Jump;
            _inputController.OnAttack += Attack;
        }
        
        private void FixedUpdate()
        {
            GroudColisionCheck();
            isMoving = _playerRigidbody.linearVelocity.x != 0;
            Movement();
            Flip();
            Debug.Log(_isGround);
        }

        private void Movement()
        {
            _playerRigidbody.linearVelocity = new Vector2(_moveInput.x * _playerSpeed, _playerRigidbody.linearVelocity.y);
        }
        
        private void Flip()
        {
            if ((_playerRigidbody.linearVelocity.x > 0 && _isFlip) || (_playerRigidbody.linearVelocity.x < 0 && !_isFlip))
            {
                _isFlip = !_isFlip;
                transform.Rotate(0, 180, 0);
            }
            
            Debug.Log(_isFlip);
        }

        private void Jump()
        {
            if (_isGround)
            {
                _jumpCount = 2;
            }

            if (_jumpCount > 0)
            {
                _playerRigidbody.linearVelocity = new Vector2(_playerRigidbody.linearVelocity.x, _jumpForce);
                _jumpCount--;
            }
        }
        
        private void Attack()
        {
            throw new NotImplementedException();
        }
        
        private void GroudColisionCheck()
        {
            _isGround = Physics2D.OverlapCircle(_groundCheckTransform.position, _groundCheckRadius, _groundLayerMask);
        }
        
        private void OnDrawGizmos()
        {
            Gizmos.DrawWireSphere(_groundCheckTransform.position, _groundCheckRadius);
        }
        
        private void OnDisable()
        {
            _inputController.OnJump -= Jump;
            _inputController.OnAttack -= Attack;
        }
    }
}
