using CodeBase.Player;
using System.Collections;
using UnityEngine;

namespace Codebase.Camera
{
    public class Camera : MonoBehaviour
    {
        [SerializeField] private PlayerMover _player;

        private Quaternion _startMainCameraCuaternion = new Quaternion(65, 0, 0, 180);
        private float _deltaFromPlayerPositionX = 0;
        private float _deltaFromPlayerPositionY = 11;
        private float _deltaFromPlayerPositionZ = -11;

        private void Start()
        {
            gameObject.transform.rotation = _startMainCameraCuaternion;
        }

        private void Update()
        {
            gameObject.transform.position = new Vector3(_player.transform.position.x + _deltaFromPlayerPositionX, _player.transform.position.y + _deltaFromPlayerPositionY, _player.transform.position.z + _deltaFromPlayerPositionZ);
        }
    }
}