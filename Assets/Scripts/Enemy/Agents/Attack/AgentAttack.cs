using System.Collections;
using Enemy.Animations;
using Scripts.CodeBase.Logic;
using Scripts.Enemy;
using Scripts.StaticData;
using UnityEngine;

namespace Enemy.Agents.Attack
{
    public class AgentAttack : MonoBehaviour, IAgent
    {
        [SerializeField] private MonsterStaticData _staticData;
        [SerializeField] private AnimationSetter _enemyAnimator;
        [SerializeField] private LayerMask _targetMask;
        [SerializeField] private HitSphere _hitArea;

        private Player.Interfaces.IHealthChanger _healthChanger;
        private readonly Collider[] _resultOfHit = new Collider[1];
        private IGameFactory _gameFactory;
        private Coroutine _attackAfterCooldown;
        private float _currentCooldown;
        private float _attackCooldown;
        private int _damage;

        private void Start()
        {
            SetParameters();
            Disable();
        }

        public void Construct(IGameFactory gameFactory) => _gameFactory = gameFactory;

        public void EnableAgent()
        {
            Enable();
            PlayAnimationAttack();
        }

        public void DisableAgent() => enabled = false;

        private bool IsAlive() => _healthChanger.CurrentHealth > 0;

        private void Enable() => enabled = true;

        private void Disable() => enabled = false;

        private void UpdateCooldown() => _currentCooldown -= Time.deltaTime;

        private void ResetCooldown() => _currentCooldown = _attackCooldown;

        private bool IsHit(out Collider hitCollider)
        {
            int count = Physics.OverlapSphereNonAlloc(_hitArea.transform.position, _hitArea.Radius, _resultOfHit, _targetMask);

            hitCollider = _resultOfHit[0];

            return count > 0;
        }

        private void SetParameters()
        {
            _attackCooldown = _staticData.AttackCooldawn;
            _currentCooldown = _attackCooldown;
            _damage = _staticData.Damage;
            
            _healthChanger = _gameFactory.Player.GetComponent<Player.Interfaces.IHealthChanger>();
        }

        private void PlayAnimationAttack()
        {
            if (!IsAlive())
                return;
            
            _enemyAnimator.PlayAttack();
        }

        private void PlayerTakeHit(Collider player)
        {
            player.GetComponent<Player.Interfaces.IHealthChanger>().RemoveCurrentHealth(_damage);
            player.GetComponent<Player.HitTaker>().Hit();
        }

        private void OnAttack()
        {
            if (IsHit(out Collider player))
            {
                PlayerTakeHit(player);
            }
        }

        private void OnAttackEnded() => _attackAfterCooldown ??= StartCoroutine(AttackAfterCooldown());

        private IEnumerator AttackAfterCooldown()
        {
            yield return new WaitForSeconds(_currentCooldown);

            DisableAgent();
        }
    }
}