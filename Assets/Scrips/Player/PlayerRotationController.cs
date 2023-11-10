using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotationController : MonoBehaviour
{
    [SerializeField] private PlayerKeyboardController _playerKeyboardController;
    [SerializeField] private float _speedOfRotation;

    private Coroutine _setRotation;
    private Quaternion _currentRotation;
    private Quaternion _targetRotation;
    private Quaternion _upAndRightRotation = new Quaternion(0, 0.38f, 0, 0.923f);
    private Quaternion _upAndLeftRotation = new Quaternion(0, -0.38f, 0, 0.923f);
    private Quaternion _downAndRightRotation = new Quaternion(0, 0.924f, 0, 0.383f);
    private Quaternion _downAndLeftRotation = new Quaternion(0, 0.924f, 0, -0.383f);
    private Quaternion _upRotation = new Quaternion(0, 0, 0, 1);
    private Quaternion _downRotation = new Quaternion(0, 1, 0, 0);
    private Quaternion _rightRotation = new Quaternion(0, 0.70711f, 0, 0.70711f);
    private Quaternion _leftRotation = new Quaternion(0, 0.70711f, 0, -0.70711f);

    public Quaternion CurrentRotation => _currentRotation;

    private void Start()
    {
        if (_playerKeyboardController == null || _speedOfRotation == 0)
        {
            Debug.Log("No serializefield in " + gameObject.name);
        }

        _currentRotation = transform.rotation;

        StartSetRotation();
    }

    private IEnumerator SetRotation()
    {
        while (true)
        {
            if (_playerKeyboardController.IsMoveUp & _playerKeyboardController.IsMoveRight)
            {
                _targetRotation = _upAndRightRotation;
            }
            else if (_playerKeyboardController.IsMoveUp & _playerKeyboardController.IsMoveLeft)
            {
                _targetRotation = _upAndLeftRotation;
            }
            else if (_playerKeyboardController.IsMoveDown & _playerKeyboardController.IsMoveRight)
            {
                _targetRotation = _downAndRightRotation;
            }
            else if (_playerKeyboardController.IsMoveDown & _playerKeyboardController.IsMoveLeft)
            {
                _targetRotation = _downAndLeftRotation;
            }
            else if(_playerKeyboardController.IsMoveUp)
            {
                _targetRotation = _upRotation;
            }
            else if (_playerKeyboardController.IsMoveDown)
            {
                _targetRotation = _downRotation;
            }
            else if (_playerKeyboardController.IsMoveRight)
            {
                _targetRotation = _rightRotation;
            }
            else if (_playerKeyboardController.IsMoveLeft)
            {
                _targetRotation = _leftRotation;
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