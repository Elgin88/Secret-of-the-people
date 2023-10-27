using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotationSetter : MonoBehaviour
{
    [SerializeField] private PlayerKeyboardController _playerKeyboardController;
    [SerializeField] private PlayerDirectionController _playerRotationController;

    private Coroutine _setRotation;

    private Quaternion _upAndRightRotation = new Quaternion(0, 0.38f, 0, 0.923f);
    private Quaternion _upAndLeftRotation = new Quaternion(0, -0.38f, 0, 0.923f);
    private Quaternion _downAndRightRotation = new Quaternion(0, 0.924f, 0, 0.383f);
    private Quaternion _downAndLeftRotation = new Quaternion(0, 0.924f, 0, -0.383f);

    private Quaternion _upRotation;
    private Quaternion _dowmRotation;
    private Quaternion _righRotation;
    private Quaternion _leftRotation;

    private void Start()
    {
        StartSetRotation();
    }

    private IEnumerator SetRotation()
    {
        while (true)
        {
            if (_playerKeyboardController.IsMoveUp & _playerKeyboardController.IsMoveRight)
            {
                transform.rotation = _upAndRightRotation;
            }
            else if (_playerKeyboardController.IsMoveUp & _playerKeyboardController.IsMoveLeft)
            {
                transform.rotation = _upAndLeftRotation;
            }
            else if (_playerKeyboardController.IsMoveDown & _playerKeyboardController.IsMoveRight)
            {
                transform.rotation = _downAndRightRotation;
            }
            else if (_playerKeyboardController.IsMoveDown & _playerKeyboardController.IsMoveLeft)
            {
                transform.rotation = _downAndLeftRotation;
            }

            else if (_playerKeyboardController.IsMoveUp)
            {
                transform.rotation = new Quaternion(0, 0, 0, 0);
            }
            else if (_playerKeyboardController.IsMoveDown)
            {
                transform.rotation = new Quaternion(0, 1, 0, 0);
            }
            else if (_playerKeyboardController.IsMoveRight)
            {
                transform.rotation = new Quaternion(0, 0.71f, 0, 0.71f);
            }
            else if (_playerKeyboardController.IsMoveLeft)
            {
                transform.rotation = new Quaternion(0, 0.71f, 0, -0.71f);
            }


            yield return null;
        }
    }

    public void StartSetRotation()
    {
        if (_setRotation==null)
        {
            _setRotation = StartCoroutine(SetRotation());
        }
    }

    public void StopSetRotation()
    {
        StopCoroutine(_setRotation);
        _setRotation = null;
    }
}