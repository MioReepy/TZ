using UnityEngine;

namespace PlayerSpace
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private string _tag = "Ground";
        [SerializeField] private float _bulletSpeed = 200;
        private Rigidbody2D _rb;

        private void Start()
        {
            _rb = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            float direction = transform.rotation.y >= 0 ? 1 : -1;
            _rb.linearVelocity = new Vector2(direction * _bulletSpeed * Time.deltaTime, _rb.linearVelocity.y);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag(_tag))
            {
                gameObject.SetActive(false);
            }
        }
    }
}