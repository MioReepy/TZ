using InputSpace;
using UnityEngine;

namespace PlayerSpace
{
    public class Gun : MonoBehaviour
    {
        private InputController _inputController;
        private PoolObject _poolObject;
        [SerializeField] private GameObject _gun;
        [SerializeField] private Transform _barrel;
        [SerializeField] private float _spawnInterval = 0.5f;
        private float _timer;
        private bool _isPoof;

        private void Awake()
        {
            _poolObject = GetComponent<PoolObject>();
            _inputController = GetComponent<InputController>();
            _inputController.OnAttack += Attack;
        }

        private void Update()
        {
            _timer += Time.deltaTime;
        
            if (_timer >= _spawnInterval && _isPoof)
            {
                _gun.SetActive(true);
                Shoot();
                _timer = 0f;
            }
        
            if (_timer >= 0.1f)
            {
                _gun.SetActive(false);
            }
        }

        private void Attack()
        {
            _isPoof = true;
        }
        
        protected virtual void Shoot()
        {
            GameObject bulletObject = _poolObject.GetPoolObject();

            if (bulletObject == null) return;
            
            bulletObject.transform.parent = _poolObject.spawnObject;
            bulletObject.transform.position = _barrel.transform.position;
            bulletObject.transform.rotation = _barrel.transform.rotation;
            bulletObject.SetActive(true);
            _isPoof = false;
        }

        private void OnDisable()
        {
            _inputController.OnAttack -= Attack;
        }
    }
}