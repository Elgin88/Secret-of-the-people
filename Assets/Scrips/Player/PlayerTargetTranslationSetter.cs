using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTargetTranslationSetter : MonoBehaviour
{
    [SerializeField] private PlayerKeyboardController _playerKeyboardController;

    private Coroutine _calculateNextPosition;
    private Vector3 _targetTranslation;
    private float _diagonal = 0.7063f;
    private float _horizontalAndVertikal = 1;

    public Vector3 TargetTranslation => _targetTranslation;

    private void Start()
    {
        StartCalculateNextPosition();
    }

    private IEnumerator CalculateTranlation()
    {
        while (true)
        {
            if (_playerKeyboardController.IsMoveRight & _playerKeyboardController.IsMoveUp)
            {
                _targetTranslation = new Vector3(_diagonal, 0, _diagonal);
            }
            else if (_playerKeyboardController.IsMoveRight & _playerKeyboardController.IsMoveDown)
            {
                _targetTranslation = new Vector3(_diagonal, 0, -_diagonal);
            }
            else if(_playerKeyboardController.IsMoveLeft & _playerKeyboardController.IsMoveUp)
            {
                _targetTranslation = new Vector3(-_diagonal, 0, _diagonal);
            }
            else if (_playerKeyboardController.IsMoveLeft & _playerKeyboardController.IsMoveDown)
            {
                _targetTranslation = new Vector3(-_diagonal, 0, -_diagonal);
            }

            else if(_playerKeyboardController.IsMoveUp)
            {
                _targetTranslation = new Vector3(0, 0, _horizontalAndVertikal);
            }
            else if (_playerKeyboardController.IsMoveDown)
            {
                _targetTranslation = new Vector3(0, 0, -_horizontalAndVertikal);
            }
            else if (_playerKeyboardController.IsMoveLeft)
            {
                _targetTranslation = new Vector3(-_horizontalAndVertikal, 0, 0);
            }
            else if (_playerKeyboardController.IsMoveRight)
            {
                _targetTranslation = new Vector3(_horizontalAndVertikal, 0, 0);
            }

            else
            {
                _targetTranslation = new Vector3(0, 0, 0);
            }

            yield return null;
        }
    }

    private void StartCalculateNextPosition()
    {
        if (_calculateNextPosition == null)
        {
            _calculateNextPosition = StartCoroutine(CalculateTranlation());
        }
    }

    private void StopCalculateNextPosition()
    {
        StopCoroutine(_calculateNextPosition);
        _calculateNextPosition = null;
    }
}
