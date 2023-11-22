using System.Collections;
using UnityEngine;

[RequireComponent(typeof(PlayerKeyboardController))]

public class PlayerSpeedSetter : MonoBehaviour
{
    private PlayerKeyboardController _playerKeyboardController;
    private Coroutine _setSpeed;
    private float _maxSpeed = 10;
    private float _currentSpeed;

    public float CurrentSpeed => _currentSpeed;

    private void Start()
    {
        _playerKeyboardController = GetComponent<PlayerKeyboardController>();

        StartSetSpeed();
    }

    private IEnumerator SetSpeed()
    {
        while (true)
        {
            if (_playerKeyboardController.IsMoveUp ||
                _playerKeyboardController.IsMoveDown ||
                _playerKeyboardController.IsMoveRight ||
                _playerKeyboardController.IsMoveLeft)
            {
                _currentSpeed = _maxSpeed;
            }
            else
            {
                _currentSpeed = 0;
            }

            yield return null;
        }
    }

    private void StartSetSpeed()
    {
        if (_setSpeed == null)
        {
            _setSpeed = StartCoroutine(SetSpeed());
        }
    }

    private void StopSetSpeed()
    {
        if (_setSpeed!= null)
        {
            StopCoroutine(_setSpeed);
            _setSpeed = null;
        }
    }
}