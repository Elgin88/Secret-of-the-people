using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDirectionController : MonoBehaviour
{
    [SerializeField] private PlayerKeyboardController _playerKeycoardController;

    private Coroutine _setDirection;
    private Vector3 _currentDirecton;
    private Vector3 _upDirection = new Vector3 (0, 0, 1);
    private Vector3 _downDirection = new Vector3 (0, 0, -1);
    private Vector3 _rigthDirection = new Vector3 (1, 0, 0);
    private Vector3 _leftDirection = new Vector3 (-1, 0, 0);
    private Vector3 _upAndRightDirection = new Vector3 (0.707f, 0, 0.707f);
    private Vector3 _upAndLeftDirection = new Vector3 (-0.707f, 0, 0.707f);
    private Vector3 _downAndRightDirection = new Vector3 (0.707f, 0, -0.707f);
    private Vector3 _downAndLeftDirection = new Vector3 (-0.707f, 0, -0.707f);
    private Vector3 _null = new Vector3(0, 0, 0);

    public Vector3 CurrentDirection => _currentDirecton;

    private void Start()
    {
        StartSetDirection();
    }

    private IEnumerator SetDirection()
    {
        while (true)
        {
            if (_playerKeycoardController.IsMoveUp & _playerKeycoardController.IsMoveRight)
            {
                _currentDirecton = _upAndRightDirection;
            }
            else if (_playerKeycoardController.IsMoveUp & _playerKeycoardController.IsMoveLeft)
            {
                _currentDirecton = _upAndLeftDirection;
            }
            else if (_playerKeycoardController.IsMoveDown & _playerKeycoardController.IsMoveRight)
            {
                _currentDirecton = _downAndRightDirection;
            }
            else if (_playerKeycoardController.IsMoveDown & _playerKeycoardController.IsMoveLeft)
            {
                _currentDirecton = _downAndLeftDirection;
            }
            else if(_playerKeycoardController.IsMoveUp)
            {
                _currentDirecton = _upDirection;
            }
            else if (_playerKeycoardController.IsMoveDown)
            {
                _currentDirecton = _downDirection;
            }
            else if (_playerKeycoardController.IsMoveRight)
            {
                _currentDirecton = _rigthDirection;
            }
            else if (_playerKeycoardController.IsMoveLeft)
            {
                _currentDirecton = _leftDirection;
            }
            else
            {
                _currentDirecton = _null;
            }            

            yield return null;
        }
    }

    private void StartSetDirection()
    {
        if (_setDirection==null)
        {
            _setDirection = StartCoroutine(SetDirection());
        }
    }

    private void StopSetDirection()
    {
        if (_setDirection!=null)
        {
            StopCoroutine(_setDirection);
            _setDirection = null;
        }
    }
}