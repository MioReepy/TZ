using System;
using PlayerSpace;
using UnityEngine;
using UnityEngine.InputSystem;

namespace InputSpace
{
    public class InputController : MonoBehaviour
    {
        public static InputController Instance { get; private set; }
        private PlayerMovement _playerMovement;
        private InputAction _move;
        private InputAction _jump;
        private InputAction _attack;
        
        public event Action OnJump;
        public event Action OnAttack;

        private void Awake()
        {
            Instance = this;
            _playerMovement = GetComponent<PlayerMovement>();
            _move = InputSystem.actions.FindAction("Move");
            _jump = InputSystem.actions.FindAction("Jump");
            _attack = InputSystem.actions.FindAction("Attack");
        }

        private void OnEnable()
        {
            _jump.performed += _ => Jump();
            _attack.performed += _ => Attack();
        }

        private void FixedUpdate()
        {
            Vector2 move = _move.ReadValue<Vector2>();
            _playerMovement.MoveInput = move;
            Debug.Log(move);
        }
        
        private void Jump()
        {
            OnJump?.Invoke();
            Debug.Log("jump");
        }
        
        private void Attack()
        {
            OnAttack?.Invoke();
            Debug.Log("attack");
        }
    }
}
