using System.Collections;
using UnityEngine;

[RequireComponent(typeof(PlayerDirectionSetter))]
[RequireComponent(typeof(PlayerSpeedSetter))]

public class PlayerMover : MonoBehaviour
{
    private PlayerDirectionSetter _playerDirectionSetter;
    private PlayerSpeedSetter _playerSpeedController;
    private Coroutine _move;

    private void Start()
    {
        _playerDirectionSetter = GetComponent<PlayerDirectionSetter>();
        _playerSpeedController = GetComponent<PlayerSpeedSetter>();

        StartMove();
    }

    private IEnumerator Move()
    {
        while (true)
        {
            transform.Translate(_playerDirectionSetter.CurrentDirection * _playerSpeedController.CurrentSpeed/700, Space.World);

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
        if (_move != null)
        {
            StopCoroutine(_move);
            _move = null;
        }
    }
}