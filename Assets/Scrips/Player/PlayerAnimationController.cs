using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private PlayerMover _playerMover;

    private Coroutine _checkStatusParametrs;

    private string _parametrIsRun = "IsRun";

    private void Start()
    {
        if (_animator==null || _playerMover==null)
        {
            Debug.Log("No serializefield in " + gameObject.name);
        }

        StartCheckStatusParametrs();
    }

    private IEnumerator CheckStatusParametrs()
    {
        while (true)
        {
            if (_playerMover.IsRuning)
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
