using System;
using UnityEngine;

namespace Enemy.Agents.AgentsCheckers
{
    public class EndAttackChecker : MonoBehaviour
    {
        public Action AttackEnded;

        public void InvokeOnAttackEnded()
        {
            AttackEnded?.Invoke();
        }
    }
}