using System;
using Enemy.AI.Checkers.Starters;
using Enemy.AI.Checkers.Stoppers;
using UnityEngine;

namespace Enemy.AI.Checkers
{
    [RequireComponent(typeof(StarterCheckerEndAttack))]
    [RequireComponent(typeof(StopperCheckerEndAttack))]
    
    public class CheckerEndAttack : MonoBehaviour
    {
        public Action OnAttackEnded;
        
        public Action OnNotAttackEnded;

        public void InvokeOnAttackEnded()
        {
            OnAttackEnded?.Invoke();
        }

        public void On()
        {
            if (!enabled)
            {
                SetEnabled(true);
            }
        }

        public void Off()
        {
            if (enabled)
            {
                SetEnabled(false);
            }
        }

        private void SetEnabled(bool status) => enabled = status;
    }
}