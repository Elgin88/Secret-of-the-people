using System.Collections;
using Enemy.AI.Agents.Starters;
using Enemy.AI.Agents.Stoppers;
using Enemy.Animations;
using Player.Animations;
using Player.Interfaces;
using StaticData;
using UnityEngine;

namespace Enemy.AI.Agents
{
    [RequireComponent(typeof(StarterAgentAttack))]
    [RequireComponent(typeof(StopperAgentAttack))]

    public class AgentAttack : MonoBehaviour
    {
        [SerializeField] private EnemyAnimationsSetter _enemyAnimationSetter;
        [SerializeField] private MonsterStaticData _staticData;
        [SerializeField] private Transform _hitPoint;
        [SerializeField] private LayerMask _target;

        private readonly Collider[] _resultOfHit = new Collider[1];
        private const float _radiusOfHitSphere = 0.3f;
        private int _damage => _staticData.Damage;
        private float _delay;

        private void Awake()
        {
            SetDelay();
        }

        private void OnEnable()
        {
            PlayAnimationIdle();
            PlayAnimationAttack();
        }

        public void On()
        {
            if (!enabled)
            {
                SetEnabled(true);

                UnityEngine.Debug.Log("StartAgentAttack");
            }
        }

        public void Off()
        {
            if (enabled)
            {
                SetEnabled(false);

                UnityEngine.Debug.Log("StopAgentAttack");
            }
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
            PlayAttackAfterDelay();
        }


        private void PlayAnimationAttack() => _enemyAnimationSetter.PlayAttack();
        private void PlayAnimationIdle() => _enemyAnimationSetter.PlayIdle();
        private void SetEnabled(bool status) => enabled = status;
        private void SetDelay() => _delay = _staticData.DelayBetweenAttack;

        private bool IsHit(out Collider target)
        {
            int count = Physics.OverlapSphereNonAlloc(_hitPoint.position, _radiusOfHitSphere, _resultOfHit, _target);

            target = _resultOfHit[0];

            return count > 0;
        }

        private void GiveHit(Collider player)
        {
            player.GetComponent<IPlayerHealthChanger>().RemoveHealth(_damage);
            player.GetComponent<IPlayerAnimationsSetter>().PlayHit();
        }

        private void PlayAttackAfterDelay()
        {
            StartCoroutine(StartDelay());
        }

        private IEnumerator StartDelay()
        {
            yield return new WaitForSeconds(_delay);

            PlayAnimationIdle();
            PlayAnimationAttack();
        }
    }
}