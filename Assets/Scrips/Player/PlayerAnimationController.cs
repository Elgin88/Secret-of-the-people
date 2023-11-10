using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private PlayerSpeedController _playerSpeedController;

    private Coroutine _setParametrs;

    private string _parametrIsRun = "IsRun";

    private void Start()
    {
        if (_animator == null  || _playerSpeedController == null)
        {
            Debug.Log("No serializefield in " + gameObject.name);
        }

        StartSetBoolAnimator();
    }

    private IEnumerator SetParametrs()
    {
        while (true)
        {
            if (_playerSpeedController.CurrentSpeed > 0)
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

    public void StartSetBoolAnimator()
    {
        if (_setParametrs==null)
        {
            _setParametrs = StartCoroutine(SetParametrs());
        }        
    }

    public void StopSetBoolAnimator()
    {
        if (_setParametrs != null)
        {
            StopCoroutine(_setParametrs);
            _setParametrs = null;
        }
    }
}