using System;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Enemy.AI.Checkers.Starters
{
    public class StarterCheckerCanAttack : MonoBehaviour
    {
        [SerializeField] private CheckerCanAttack _checkerCanAttack;
        [SerializeField] private CheckerAgro _checkerAgro;

        private void Awake()
        {
            _checkerAgro.OnAgred += OnAgred;
        }

        private void OnDestroy()
        {
            _checkerAgro.OnAgred -= OnAgred;
        }
        
        private void OnAgred()
        {
            _checkerCanAttack.On();
        }
    }
}