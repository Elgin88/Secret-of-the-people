using System.Collections;
using Enemy.Animations;
using Scripts.CodeBase.Logic;
using Scripts.Enemy;
using Scripts.StaticData;
using UnityEngine;

namespace Enemy.Agents.Attack
{
    [RequireComponent(typeof(AnimationSetter))]
    public class AgentAttack : MonoBehaviour, IAgent
    {
        [SerializeField] private MonsterStaticData _staticData;
        [SerializeField] private AnimationSetter _enemyAnimator;
        [SerializeField] private LayerMask _targetMask;
        [SerializeField] private HitSphere _hitArea;

        private Player.Interfaces.IHealthChanger _playerHealthChanger;
        private readonly Collider[] _resultOfHit = new Collider[1];
        private IGameFactory _gameFactory;
        private Coroutine _disableAgentAfterCooldown;
        private float _attackCooldown;
        private int _damage;

        private void Awake()
        {
            SetParameters();
            Disable();
        }

        public void Construct(IGameFactory gameFactory) => _gameFactory = gameFactory;

        public void EnableAgent()
        {
            Enable();
            PlayAttackAnimation();
        }

        public void DisableAgent() => enabled = false;
        private bool IsAlive() => _playerHealthChanger.CurrentHealth > 0;
        private void Enable() => enabled = true;
        private void Disable() => enabled = false;
        private bool IsHit(out Collider hitCollider)
        {
            int count = Physics.OverlapSphereNonAlloc(_hitArea.transform.position, _hitArea.Radius, _resultOfHit, _targetMask);

            hitCollider = _resultOfHit[0];

            return count > 0;
        }
        private void SetParameters()
        {
            _attackCooldown = _staticData.AttackCooldawn;
            _damage = _staticData.Damage;
            
            _playerHealthChanger = _gameFactory.Player.GetComponent<Player.Interfaces.IHealthChanger>();
        }
        private void PlayAttackAnimation() => _enemyAnimator.PlayAttack();
        private void PlayerTakeHit(Collider player)
        {
            player.GetComponent<Player.Interfaces.IHealthChanger>().RemoveCurrentHealth(_damage);
            player.GetComponent<Player.Animations.AnimationSetter>().PlayHit();
        }
        private void OnAttack()
        {
            if (IsHit(out Collider player))
            {
                PlayerTakeHit(player);
            }
        }
        private void OnAttackEnded()
        {
            if (_disableAgentAfterCooldown == null)
            {
                _disableAgentAfterCooldown = StartCoroutine(DisableAgentAfterCooldown());
            }
        }
        private IEnumerator DisableAgentAfterCooldown()
        {
            yield return new WaitForSeconds(_attackCooldown);
            DisableAgent();
        }
    }
}