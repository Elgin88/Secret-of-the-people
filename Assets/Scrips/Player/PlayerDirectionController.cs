using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDirectionController : MonoBehaviour
{
    [SerializeField] private PlayerKeyboardController _playerKeyboardController;

    private Coroutine _setterTargetDirection;
    private float _horizontalAndVertikal = 1;
    private float _diagonal = 0.7063f;
    private Vector3 _targetDirection;
    private Vector3 _currentDirection;
    private Vector3 _urDirection;
    private Vector3 _ulDirection;
    private Vector3 _drDirection;
    private Vector3 _dlDirection;
    private Vector3 _uDirection;
    private Vector3 _dDirection;
    private Vector3 _rDirection;
    private Vector3 _lDirection;
    private Vector3 _nullDirection;

    public Vector3 CurrentDirection => _currentDirection;

    private void Start()
    {
        _urDirection = new Vector3(_diagonal, 0, _diagonal);
        _ulDirection = new Vector3(-_diagonal, 0, _diagonal);
        _drDirection = new Vector3(_diagonal, 0, -_diagonal);
        _dlDirection = new Vector3(-_diagonal, 0, -_diagonal);
        _uDirection = new Vector3(0, 0, _horizontalAndVertikal);
        _dDirection = new Vector3(0, 0, -_horizontalAndVertikal);
        _rDirection = new Vector3(_horizontalAndVertikal, 0, 0);
        _lDirection = new Vector3(-_horizontalAndVertikal, 0, 0);
        _nullDirection = new Vector3(0, 0, 0);

        StartSetterDirection();
    }

    private IEnumerator SetterTargetDirection()
    {
        while (true)
        {
            if (_playerKeyboardController.IsMoveUp & _playerKeyboardController.IsMoveRight)
            {
                _targetDirection = _urDirection;
            }
            else if (_playerKeyboardController.IsMoveUp & _playerKeyboardController.IsMoveLeft)
            {
                _targetDirection = _ulDirection;
            }
            else if (_playerKeyboardController.IsMoveDown & _playerKeyboardController.IsMoveRight)
            {
                _targetDirection = _drDirection;
            }
            else if (_playerKeyboardController.IsMoveDown & _playerKeyboardController.IsMoveLeft)
            {
                _targetDirection = _dlDirection;
            }

            else if (_playerKeyboardController.IsMoveUp)
            {
                _targetDirection = _uDirection;
            }
            else if (_playerKeyboardController.IsMoveDown)
            {
                _targetDirection = _dDirection;
            }
            else if (_playerKeyboardController.IsMoveRight)
            {
                _targetDirection = _rDirection;
            }
            else if (_playerKeyboardController.IsMoveLeft)
            {
                _targetDirection = _lDirection;
            }

            else
            {
                _targetDirection = _nullDirection;
            }

            yield return null;
        }
    }

    public void StartSetterDirection()
    {
        if (_setterTargetDirection == null)
        {
            _setterTargetDirection = StartCoroutine(SetterTargetDirection());
        }
    }

    public void StopSetterDirection()
    {
        if (_setterTargetDirection != null)
        {
            StopCoroutine(_setterTargetDirection);
            _setterTargetDirection = null;
        }

    }
}
