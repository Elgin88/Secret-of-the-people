using System;
using UnityEngine;

namespace Enemy.AI.Checkers.Stoppers
{
    public class StopperCheckerAttacking : MonoBehaviour
    {
        [SerializeField] private CheckerAttacking _checkerAttacking;

        private void Awake()
        {
            _checkerAttacking.Off();
        }
    }
}