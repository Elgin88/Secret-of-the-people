using System.Collections;
using UnityEngine;

public class PlayerSpeedController : MonoBehaviour
{
    [SerializeField] private float _maxSpeed;
    [SerializeField] private PlayerKeyboardController _playerKeyboardController;

    private Coroutine _setSpeed;
    private float _currentSpeed;

    public float CurrentSpeed => _currentSpeed;

    private void Start()
    {
        if (_maxSpeed == 0 || _playerKeyboardController == null)
        {
            Debug.Log("No serializefield in " + gameObject.name);
        }

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
