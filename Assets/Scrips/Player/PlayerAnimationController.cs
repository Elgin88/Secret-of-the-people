using System.Collections;
using UnityEngine;

[RequireComponent(typeof(PlayerSpeedSetter))]
[RequireComponent(typeof(Animator))]

public class PlayerAnimationController : MonoBehaviour
{
    private PlayerSpeedSetter _playerSpeedSetter;
    private Coroutine _setParametrs;
    private Animator _animator;
    private string _parametrIsRun = "IsRun";

    private void Start()
    {
        _playerSpeedSetter = GetComponent<PlayerSpeedSetter>();
        _animator = GetComponent<Animator>();

        StartSetBoolAnimator();
    }

    private IEnumerator SetParametrs()
    {
        while (true)
        {
            if (_playerSpeedSetter.CurrentSpeed > 0)
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