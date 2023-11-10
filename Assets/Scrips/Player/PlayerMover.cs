using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerKeyboardController))]

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private PlayerDirectionController _playerDirectionController;
    [SerializeField] private PlayerSpeedController _playerSpeedController;

    private Coroutine _move;

    private void Start()
    {
        if (_playerDirectionController == null || _playerSpeedController == null)
        {
            Debug.Log("No serializefield in " + gameObject.name);
        }

        StartMove();
    }

    private IEnumerator Move()
    {
        while (true)
        {
            transform.Translate(_playerDirectionController.CurrentDirection * _playerSpeedController.CurrentSpeed/700, Space.World);

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