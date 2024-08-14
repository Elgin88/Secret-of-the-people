using UnityEngine;

namespace Scripts.PlayerComponents
{
    public class CameraFollower : MonoBehaviour
    {
        private const float _diagonalOffset = 12;
        private const float _verticalOffset = 0;
        private const float _angleInRadian = 45 * Mathf.PI / 180;
        private float _horizontal;
        private float _vertical;
        private Camera _camera;

        private void Awake()
        {
            Enabled();
            SetCamera();
            CalculateOffsets();
        }

        private void LateUpdate()
        {
            SetCameraPosition();
            SetCameraRotation();
        }

        private void SetCameraRotation() => _camera.transform.rotation.SetLookRotation(transform.position);

        private void SetCameraPosition() => _camera.transform.position = new Vector3(transform.position.x, transform.position.y + _horizontal + _verticalOffset, transform.position.z + _vertical);

        private void SetCamera() => _camera = Camera.main;

        private void Enabled() => enabled = true;

        private void CalculateOffsets()
        {
            _horizontal = Mathf.Cos(_angleInRadian) * _diagonalOffset;
            _vertical = Mathf.Sin(_angleInRadian) * _diagonalOffset * -1;
        }
    }
}