using System;
using UnityEngine;

namespace Enemy.AI.Checkers.Stoppers
{
    public class StopperCheckerEndAttack : MonoBehaviour
    {
        [SerializeField] private CheckerEndAttack _checkerEndAttack;

        private void Awake()
        {
            _checkerEndAttack.Off();
        }
    }
}