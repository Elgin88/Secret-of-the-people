using System.Collections;
using Enemy.Animations;
using Player.Animations;
using Player.Interfaces;
using StaticData;
using UnityEngine;

namespace Enemy.Agents.Attack
{
    [RequireComponent(typeof(EnemyAnimationsSetter))]

    public class AgentAttack : MonoBehaviour, IEnemyAgent
    {
        [SerializeField] private EnemyAnimationsSetter _enemyAnimationSetter;
        [SerializeField] private MonsterStaticData _staticData;
        [SerializeField] private LayerMask _targetMask;
        [SerializeField] private HitSphere _hitArea;

        private readonly Collider[] _resultOfHit = new Collider[1];
        private float _attackCooldown => _staticData.AttackCooldown;
        private int _damage => _staticData.Damage;

        private void Awake()
        {
            DisableAgent();
        }

        public void EnableAgent()
        {
            Enable();
            PlayAnimation();
        }

        public void DisableAgent()
        {
            StopPlayAnimation();
            Disable();
        }

        private void Disable() => enabled = false;

        private void StopPlayAnimation() => _enemyAnimationSetter.StopPlayAttack();

        private void PlayAnimation() => _enemyAnimationSetter.PlayAttack();

        private void Enable() => enabled = true;

        private bool IsHit(out Collider hitCollider)
        {
            int count = Physics.OverlapSphereNonAlloc(_hitArea.transform.position, _hitArea.Radius, _resultOfHit, _targetMask);

            hitCollider = _resultOfHit[0];

            return count > 0;
        }

        private void TakeHit(Collider player)
        {
            player.GetComponent<IPlayerHealthChanger>().RemoveHealth(_damage);
            player.GetComponent<IPlayerAnimationsSetter>().PlayHit();
        }

        private IEnumerator AttackAfterCooldown()
        {
            yield return new WaitForSeconds(_attackCooldown);

            PlayAnimation();
        }

        private void OnAttack()
        {
            if (IsHit(out Collider player))
            {
                TakeHit(player);
            }
        }

        private void OnAttackEnded()
        {
            StartCoroutine(AttackAfterCooldown());
        }
    }
}