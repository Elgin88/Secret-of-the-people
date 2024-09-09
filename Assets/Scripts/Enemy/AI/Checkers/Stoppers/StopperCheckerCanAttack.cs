using System;
using UnityEngine;

namespace Enemy.AI.Checkers.Stoppers
{
    public class StopperCheckerCanAttack : MonoBehaviour
    {
        [SerializeField] private CheckerCanAttack _checkerCanAttack;
        [SerializeField] private CheckerAgro _checkerAgro;

        private void Awake()
        {
            _checkerAgro.OnNotAgred += OnNotAgred;
            _checkerCanAttack.Off();
        }

        private void OnDestroy()
        {
            _checkerAgro.OnNotAgred -= OnNotAgred;
        }

        private void OnNotAgred()
        {
            _checkerCanAttack.Off();
        }
    }
}