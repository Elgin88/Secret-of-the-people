using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    private Player _player;
    private Coroutine _cameraFollowingThePlayer;

    private Vector3 _startPlayerPosition;

    private float _deltaPositionX = 0;
    private float _deltaPositionY = 10;
    private float _deltaPositionZ = -14;

    private float _deltaRotationX = 30;
    private float _deltaRotaitonY = 0;
    private float _deltaRotationZ = 0;


    private void Start()
    {
        _player = FindObjectOfType<Player>();
        _startPlayerPosition = _player.transform.position;
    }

    private IEnumerator CameraFollowingThePlayer()
    {
        while (true)
        {
            yield return null;
        }
    }

    private void StartCameraFollowingThePlayer()
    {
        if (_cameraFollowingThePlayer == null)
        {
            _cameraFollowingThePlayer = StartCoroutine(CameraFollowingThePlayer());
        }
    }

    private void StopCameraFollowingThePlayer()
    {
        StopCoroutine(_cameraFollowingThePlayer);
        _cameraFollowingThePlayer = null;
    }
}
