using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTargetTranslationSetter : MonoBehaviour
{
    [SerializeField] private PlayerKeyboardController _playerKeyboardController;

    private Coroutine _setTargetTranslation;

    private Vector3 _targetTranslation;
    private float _horizontalAndVertikal = 1;
    private float _diagonal = 0.7063f;   
        
    public Vector3 TargetTranslation => _targetTranslation;

    private void Start()
    {
        StartSetTargetTranslation();
    }

    private IEnumerator SetTargetTranslation()
    {
        while (true)
        {
            if (_playerKeyboardController.IsMoveUp & _playerKeyboardController.IsMoveRight)
            {
                _targetTranslation = new Vector3(_diagonal, 0, _diagonal);
            }
            else if (_playerKeyboardController.IsMoveUp & _playerKeyboardController.IsMoveLeft)
            {
                _targetTranslation = new Vector3(-_diagonal, 0, _diagonal);
            }
            else if (_playerKeyboardController.IsMoveDown & _playerKeyboardController.IsMoveRight)
            {
                _targetTranslation = new Vector3(_diagonal, 0, - _diagonal);
            }
            else if (_playerKeyboardController.IsMoveDown & _playerKeyboardController.IsMoveLeft)
            {
                _targetTranslation = new Vector3(-_diagonal, 0, -_diagonal);
            }

            else if (_playerKeyboardController.IsMoveUp)
            {
                _targetTranslation = new Vector3(0, 0, _horizontalAndVertikal);
            }
            else if (_playerKeyboardController.IsMoveDown)
            {
                _targetTranslation = new Vector3(0, 0, -_horizontalAndVertikal);
            }
            else if (_playerKeyboardController.IsMoveRight)
            {
                _targetTranslation = new Vector3(_horizontalAndVertikal, 0, 0);
            }
            else if (_playerKeyboardController.IsMoveLeft)
            {
                _targetTranslation = new Vector3(-_horizontalAndVertikal, 0, 0);
            }

            else
            {
                _targetTranslation = new Vector3(0, 0, 0);
            }

            yield return null;
        }
    }

    public void StartSetTargetTranslation()
    {
        if (_setTargetTranslation==null)
        {
            _setTargetTranslation = StartCoroutine(SetTargetTranslation());
        }
    }

    public void StopSetTargetTranslation()
    {
        StopCoroutine(_setTargetTranslation);
        _setTargetTranslation = null;
    }
}