using UnityEngine;

namespace Scripts.Camera
{
    public class Camera : MonoBehaviour
    {
        [SerializeField] private Transform _playerTransform;
        [SerializeField] private float _deltaX;
        [SerializeField] private float _deltaY;
        [SerializeField] private float _deltaZ;

        private void LateUpdate()
        {
            if (_playerTransform == null)
            {
                return;
            }
            
            transform.position = new Vector3(_playerTransform.position.x + _deltaX, _playerTransform.position.y + _deltaY, _playerTransform.position.z + _deltaZ);
        }
    }
}