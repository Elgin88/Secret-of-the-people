using UnityEngine;

namespace Scripts.Logic
{
    public class CameraFollower : MonoBehaviour
    {
        [SerializeField] private float _rotationAngleX;
        [SerializeField] private float _distance;
        [SerializeField] private float _offsetY;

        private Transform _playerTransform;

        internal void Follow(Transform transform) => _playerTransform = transform;

        private void LateUpdate()
        {
            if (_playerTransform == null)
            {
                return;
            }

            Quaternion rotation = Quaternion.Euler(_rotationAngleX, 0, 0);

            Vector3 playerPosition = _playerTransform.position;
            playerPosition.y += _offsetY;

            Vector3 position = rotation * new Vector3(0, 0, -_distance) + playerPosition;

            transform.rotation = rotation;
            transform.position = position;
        }
    }
}