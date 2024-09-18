using System;
using System.Collections;
using Enemy.Animations;
using Player.Animations;
using Player.Interfaces;
using StaticData;
using UnityEngine;

namespace Enemy.AI.Agents
{
    public class AgentAttack : MonoBehaviour
    {
        [SerializeField] private EnemyAnimationsSetter _enemyAnimationSetter;
        [SerializeField] private MonsterStaticData _staticData;
        [SerializeField] private Transform _hitPoint;
        [SerializeField] private LayerMask _target;

        private float _attackRange => _staticData.AttackRange;
        private float _coodown => _staticData.DelayBetweenAttack;
        private float _currentCooldown;

        public void On()
        {
            Enabled();
        }

        public void Off()
        {
            Disabled();
        }

        private void FixedUpdate()
        {
            UpdateCooldown();

            if (IsCooldownEnd())
            {
                PlayAnimationAttack();
            }
        }

        private void OnHit()
        {
            CheckCanIsHit(out Collider target);
            Hit(target);
        }




        private void CheckCanIsHit(out Collider target)
        {
            throw new NotImplementedException();
        }

        private void Hit(Collider target)
        {
            throw new NotImplementedException();
        }





        private void OnAttackEnded()
        {
            _enemyAnimationSetter.StopPlayAttack();
        }

        private void UpdateCooldown() => _currentCooldown -= Time.deltaTime;
        private bool IsCooldownEnd() => _currentCooldown > _coodown;
        private void PlayAnimationAttack() => _enemyAnimationSetter.PlayAttack();

        private void Enabled()
        {
            if (!enabled)
            {
                enabled = true;
            }
        }

        private void Disabled()
        {
            if (enabled)
            {
                enabled = false;
            }
        }
    }
}