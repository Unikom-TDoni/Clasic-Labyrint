using System;
using UnityEngine;
using Edu.Golf.Core;

namespace Edu.Golf.Player
{
    public sealed class PlayerController : MonoBehaviour
    {
        public event Action OnHole = default;

        [SerializeField]
        private float _force = default;

        private Rigidbody _rigidbody = default;

        private bool _isInTheHole = default;

        private Vector3 _direction = default;

        private bool _isSupportGyro = default;

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();

            if (SystemInfo.supportsGyroscope)
            {
                _isSupportGyro = true;
                Input.gyro.enabled = true;
            }
        }

        private void Update()
        {
            if (_isInTheHole) return;
            var inputDir = _isSupportGyro ? Input.gyro.gravity : Input.acceleration;
            _direction = new Vector3(
                inputDir.x,
                inputDir.y,
                inputDir.z
            );

            if (transform.position.y < -10)
                transform.position = Vector3.zero;

        }

        private void FixedUpdate()
        {
            _rigidbody.AddForce(_direction * _force, ForceMode.Acceleration);
        }

        private void OnTriggerEnter(Collider collider)
        {
            if (collider.CompareTag(GameManager.Instance.Tags.Hole))
            {
                _isInTheHole = true;
                collider.GetComponentInParent<BoxCollider>().enabled = false;
                OnHole();
            }
        }
    }
}