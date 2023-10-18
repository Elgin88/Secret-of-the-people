using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpeedSetter : MonoBehaviour
{
    [SerializeField] private float _currentSpeed;

    public float CurrentSpeed => _currentSpeed;

}
