using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerKeyboardController : MonoBehaviour
{
    private Coroutine _checkPressedButtons;

    private bool _isMoveUp;
    private bool _isMoveDown;
    private bool _isMoveRight;
    private bool _isMoveLeft;

    public bool IsMoveUp => _isMoveUp;
    public bool IsMoveDown => _isMoveDown;
    public bool IsMoveRight => _isMoveRight;
    public bool IsMoveLeft => _isMoveLeft;

    private void Start()
    {
        StartCheckButtonKey();
    }

    private IEnumerator CheckPressedButtons()
    {
        while (true)
        {
            if (Input.GetKey(KeyCode.W))
                _isMoveUp = true;
            else
                _isMoveUp = false;

            if (Input.GetKey(KeyCode.S))
                _isMoveDown = true;
            else
                _isMoveDown = false;

            if (Input.GetKey(KeyCode.D))
                _isMoveRight = true;
            else
                _isMoveRight = false;

            if (Input.GetKey(KeyCode.A))
                _isMoveLeft = true;
            else
                _isMoveLeft = false;

            yield return null;
        }
    }

    private void StartCheckButtonKey()
    {
        if (_checkPressedButtons == null)
        {
            _checkPressedButtons = StartCoroutine(CheckPressedButtons());
        }        
    }

    private void StopCheckButtonKey()
    {
        StopCoroutine(_checkPressedButtons);
        _checkPressedButtons = null;
    }
}