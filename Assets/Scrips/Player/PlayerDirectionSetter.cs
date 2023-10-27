using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDirectionSetter : MonoBehaviour
{
    
    [SerializeField] private PlayerDirectionController _playerDirectionController;

    private Coroutine _setCurrentDirection;

    private Vector3 _currentDirection;

        
    public Vector3 CurrentTranslation => _currentDirection;

    private void Start()
    {
        StartSetTargetTranslation();
    }

    private IEnumerator SetCurrentDirection()
    {
        while (true)
        {
            _currentDirection = _playerDirectionController.CurrentDirection;




        }
    }

    public void StartSetTargetTranslation()
    {
        if (_setCurrentDirection==null)
        {
            _setCurrentDirection = StartCoroutine(SetCurrentDirection());
        }
    }

    public void StopSetTargetTranslation()
    {
        StopCoroutine(_setCurrentDirection);
        _setCurrentDirection = null;
    }
}