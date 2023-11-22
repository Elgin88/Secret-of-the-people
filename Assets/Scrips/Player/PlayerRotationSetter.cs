using System.Collections;
using UnityEngine;

[RequireComponent(typeof(PlayerKeyboardController))]

public class PlayerRotationSetter : MonoBehaviour
{
    private PlayerKeyboardController _playerKeyboardController;
    private Quaternion _currentRotation;
    private Quaternion _targetRotation;
    private Coroutine _setRotation;
    private float _speedOfRotation = 15;

    public Quaternion CurrentRotation => _currentRotation;

    private void Start()
    {
        _playerKeyboardController = GetComponent<PlayerKeyboardController>();

        _currentRotation = transform.rotation;

        StartSetRotation();
    }

    private IEnumerator SetRotation()
    {
        while (true)
        {
            if (_playerKeyboardController.IsMoveUp & _playerKeyboardController.IsMoveRight)
            {
                _targetRotation = StaticPlayerRotationValue.UpAndRightRotation;
            }
            else if (_playerKeyboardController.IsMoveUp & _playerKeyboardController.IsMoveLeft)
            {
                _targetRotation = StaticPlayerRotationValue.UpAndLeftRotation;
            }
            else if (_playerKeyboardController.IsMoveDown & _playerKeyboardController.IsMoveRight)
            {
                _targetRotation = StaticPlayerRotationValue.DownAndRightRotation;
            }
            else if (_playerKeyboardController.IsMoveDown & _playerKeyboardController.IsMoveLeft)
            {
                _targetRotation = StaticPlayerRotationValue.DownAndLeftRotation;
            }
            else if(_playerKeyboardController.IsMoveUp)
            {
                _targetRotation = StaticPlayerRotationValue.UpRotation;
            }
            else if (_playerKeyboardController.IsMoveDown)
            {
                _targetRotation = StaticPlayerRotationValue.DownRotation;
            }
            else if (_playerKeyboardController.IsMoveRight)
            {
                _targetRotation = StaticPlayerRotationValue.RightRotation;
            }
            else if (_playerKeyboardController.IsMoveLeft)
            {
                _targetRotation = StaticPlayerRotationValue.LeftRotation;
            }
            else
            {
                _targetRotation = transform.rotation;
            }

            transform.rotation = Quaternion.Lerp(transform.rotation, _targetRotation, _speedOfRotation * Time.deltaTime);

            _currentRotation = transform.rotation;

           yield return null;
        }
    }

    public void StartSetRotation()
    {
        if (_setRotation == null)
        {
            _setRotation = StartCoroutine(SetRotation());
        }
    }

    public void StopSetRotation()
    {
        if (_setRotation != null)
        {
            StopCoroutine(_setRotation);
            _setRotation = null;
        }
    }
}