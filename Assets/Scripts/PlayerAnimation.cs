using UnityEngine;

namespace PlayerSpace
{
    public class PlayerAnimationController : MonoBehaviour
    {
        private PlayerMovement _playerMovement;
        private Animator _playerAnimator;
		
        private void Start()
        {
            _playerMovement = GetComponent<PlayerMovement>();
            _playerAnimator = GetComponent<Animator>();
        }
		
        private void Update()
        {
            _playerAnimator.SetBool("isMove", _playerMovement.isMoving);
            _playerAnimator.SetBool("isGrounded", _playerMovement._isGround);
            _playerAnimator.SetFloat("velosityY", _playerMovement._playerRigidbody.linearVelocity.y);
        }
    }
}