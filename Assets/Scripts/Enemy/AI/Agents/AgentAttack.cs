using System;
using Enemy.Animations;
using StaticData;
using UnityEngine;

namespace Enemy.AI.Agents
{
    public class AgentAttack : MonoBehaviour
    {
        [SerializeField] private EnemyAnimationsSetter _enemyAnimationsSetter;
        [SerializeField] private EnemyStaticData _enemyStaticData;

        private float _startCooldown => _enemyStaticData.DelayBetweenShoots;
        private float _currentCooldown;

        private void Awake() => _currentCooldown = 0;

        private void FixedUpdate()
        {
            UpdateCooldown();

            if (IsCooldownEnd())
            {
                _enemyAnimationsSetter.PlayAttack();
            }
        }

        private void UpdateCooldown() => _currentCooldown -= Time.deltaTime;

        private bool IsCooldownEnd()
        {
            return _currentCooldown <= 0;
        }

        public void On()
        {
            if (!enabled)
            {
                enabled = true;
            }
        }

        public void Off()
        {
            if (enabled)
            {
                enabled = false;
            }
        }

        private void OnAttackStarted()
        {
        }

        private void OnHit()
        {
        }

        private void OnAttackEnded()
        {
        }
    }
}