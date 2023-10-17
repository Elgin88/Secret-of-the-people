using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerKeyboardController))]

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private PlayerTargetTranslationSetter _playerTargetTranslationSetter;
    [SerializeField] private PlayerSpeedSetter _playerSpeedSetter;

    private Coroutine _move;

    private void Start()
    {
        StartMove();
    }

    private IEnumerator Move()
    {
        while (true)
        {
            transform.Translate(_playerTargetTranslationSetter.TargetTranslation * _playerSpeedSetter.CurrentSpeed * Time.deltaTime, Space.World);

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