﻿using Enemy.Agents.AgentsCheckers;
using Enemy.Animations;
using Infrastructure.Services.Factory;
using Player.Animations;
using Player.Interfaces;
using StaticData;
using UnityEngine;

namespace Enemy.Agents.Agents
{
    public class AgentAttack : MonoBehaviour
    {
        [SerializeField] private EnemyAnimationsSetter _enemyAnimationSetter;
        [SerializeField] private MonsterStaticData _staticData;
        [SerializeField] private Transform _hitPoint;
        [SerializeField] private LayerMask _target;
        [SerializeField] private EndAttackChecker _endAttackChecker;

        private readonly Collider[] _resultOfHit = new Collider[1];
        private IGameFactory _gameFactory;
        private const float _radiusHitSphere = 0.3f;
        private int _damage => _staticData.Damage;

        public void Construct(IGameFactory gameFactory)
        {
            _gameFactory = gameFactory;
        }

        private void Start() => Off();

        private void OnDisable()
        {
            StopPlayAnimation();
        }

        private void FixedUpdate()
        {
            PlayAnimation();
        }

        public void On()
        {
            SetEnabled(true);
        }

        public void Off()
        {
            SetEnabled(false);
        }

        private void OnStartAttack()
        {
        }

        private void OnAttack()
        {
            if (IsHit(out Collider player))
            {
                GiveHit(player);
            }
        }

        private void OnAttackEnded()
        {
            _endAttackChecker.InvokeOnAttackEnded();
        }

        private void SetEnabled(bool status) => enabled = status;
        private void PlayAnimation() => _enemyAnimationSetter.PlayAttack();
        private void StopPlayAnimation() => _enemyAnimationSetter.StopPlayAttack();

        private bool IsHit(out Collider target)
        {
            int count = Physics.OverlapSphereNonAlloc(_hitPoint.position, _radiusHitSphere, _resultOfHit, _target);

            target = _resultOfHit[0];

            return count > 0;
        }

        private void GiveHit(Collider player)
        {
            player.GetComponent<IPlayerHealthChanger>().RemoveHealth(_damage);
            player.GetComponent<IPlayerAnimationsSetter>().PlayHit();
        }
    }
}