using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private PlayerSpeedSetter _playerSpeedSetter;
    [SerializeField] private PlayerTargetTranslationSetter _playerTargetTranslationSetter;

    private Coroutine _checkStatusParametrs;

    private string _parametrIsRun = "IsRun";
    private string _parametrIsShoot = "IsShoot";

    private void Start()
    {
        StartCheckStatusParametrs();
    }

    private IEnumerator CheckStatusParametrs()
    {
        while (true)
        {
            if (_playerTargetTranslationSetter.IsMovingCommand & _playerSpeedSetter.CurrentSpeed != 0)
            {
                _animator.SetBool(_parametrIsRun, true);
            }
            else
            {
                _animator.SetBool(_parametrIsRun, false);
            }


            yield return null;
        }
    }

    public void StartCheckStatusParametrs()
    {
        if (_checkStatusParametrs==null)
        {
            _checkStatusParametrs = StartCoroutine(CheckStatusParametrs());
        }        
    }

    public void StopCheckStatusParametrs()
    {
        StopCoroutine(_checkStatusParametrs);
        _checkStatusParametrs = null;
    }




    private void ChangeStatusParametrs(string parametr, bool status)
    {
        _animator.SetBool(parametr, status);
    }
}
