using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerKeyboardController))]

public class PlayerMover : MonoBehaviour
{
    private Coroutine _move;
    private bool _isRuninh;

    public bool IsRuning => _isRuninh;

    private void Start()
    {
        StartMove();
    }

    private IEnumerator Move()
    {
        while (true)
        {



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