using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCameraSetterPosition : MonoBehaviour
{
    private Player _player;
    private Coroutine _cameraFollowingThePlayer;

    private float _deltaFromPlayerPositionX = 0;
    private float _deltaFromPlayerPositionY = 10;
    private float _deltaFromPlayerPositionZ = -14;
    private Quaternion _startMainCameraCuaternion = new Quaternion(48.3f, 0, 0, 180);

    private void Start()
    {
        _player = FindObjectOfType<Player>();

        gameObject.transform.rotation = _startMainCameraCuaternion;

        StartCameraFollowingThePlayer();
    }

    private IEnumerator CameraFollowingThePlayer()
    {
        while (true)
        {
            gameObject.transform.position = new Vector3(
                _player.transform.position.x + _deltaFromPlayerPositionX,
                _player.transform.position.y + _deltaFromPlayerPositionY,
                _player.transform.position.z + _deltaFromPlayerPositionZ); 

            yield return null;
        }
    }

    public void StartCameraFollowingThePlayer()
    {
        if (_cameraFollowingThePlayer == null)
        {
            _cameraFollowingThePlayer = StartCoroutine(CameraFollowingThePlayer());
        }
    }

    public void StopCameraFollowingThePlayer()
    {
        StopCoroutine(_cameraFollowingThePlayer);
        _cameraFollowingThePlayer = null;
    }
}
