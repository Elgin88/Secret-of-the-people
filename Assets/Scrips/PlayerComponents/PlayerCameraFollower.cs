using UnityEngine;

namespace Scripts.PlayerComponents
{
    public class PlayerCameraFollower : MonoBehaviour
    {
        private float _diagonalOffset = 12;
        private float _verticalOffset = 0;
        private float _angleInRadian = 45 * Mathf.PI / 180;
        private float _horizontal;
        private float _vertical;
        private Camera _camera;

        private void Awake()
        {
            _camera = Camera.main;
            _horizontal = Mathf.Cos(_angleInRadian) * _diagonalOffset;
            _vertical = Mathf.Sin(_angleInRadian) * _diagonalOffset * -1;
        }

        private void LateUpdate()
        {
            _camera.transform.position = new Vector3(transform.position.x, transform.position.y + _horizontal + _verticalOffset, transform.position.z + _vertical);

            _camera.transform.rotation.SetLookRotation(transform.position);
        }
    }
}