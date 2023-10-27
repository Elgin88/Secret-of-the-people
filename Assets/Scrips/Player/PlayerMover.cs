using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerKeyboardController))]

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private PlayerDirectionSetter _playerTargetTranslationSetter;
    [SerializeField] private PlayerSpeedSetter _playerSpeedSetter;

    private Coroutine _move;
    private bool _isMoving;

    public bool IsMoving => _isMoving;

    private void Start()
    {
        StartMove();
    }

    private IEnumerator Move()
    {
        while (true)
        {
            transform.Translate(_playerTargetTranslationSetter.CurrentTranslation * _playerSpeedSetter.CurrentSpeed * Time.deltaTime, Space.World);

            if (_playerTargetTranslationSetter.CurrentTranslation!=new Vector3(0,0,0) & _playerSpeedSetter.CurrentSpeed != 0)
            {
                _isMoving = true;
            }
            else
            {
                _isMoving = false;
            }

            yield return null;
        }
    }

    public void StartMove()
    {
        if (_move == null)
        {
            _move = StartCoroutine(Move());
        }
    }

    public void StopMove()
    {
        StopCoroutine(_move);
        _move = null;
    }
}