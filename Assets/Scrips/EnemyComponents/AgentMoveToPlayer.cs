using Scripts.CodeBase.Infractructure;
using UnityEngine;
using UnityEngine.AI;

namespace Scripts.EnemyComponents
{
    [RequireComponent(typeof(EnemyAnimator))]
    [RequireComponent(typeof(NavMeshAgent))]

    public class AgentMoveToPlayer : MonoBehaviour
    {
        private const float _currentSpeed = 2;
        private const float _minDistance = 2f;
        private const float _baseSpeed = 0.8f;
        private EnemyAnimator _enemyAnimator;
        private NavMeshAgent _navMeshAgent;
        private GameObject _player;
        private IGameFactory _gameFactory;

        public float NormalizeSpeed => _currentSpeed / _baseSpeed;

        public void AgentOn()
        {
            enabled = true;
            _navMeshAgent.isStopped = false;
        }

        public void AgentOff()
        {
            enabled = false;
            StopMove();
        }

        private void Awake()
        {
            GetComponnents();
            DisableAgentMover();
            SetSpeed();
        }

        private void Update()
        {
            if (!IsEnemyOnNavMesh() || !IsPlayerInitialized())
            {
                return;
            }

            if (IsMinDistance())
            {
                StartMove();
            }
            else
            {
                StopMove();
            }
        }

        private void Start()
        {
            SetGameFactory();

            if (IsGameFactoryInittialized())
            {
                if (IsPlayerCreate())
                {
                    SetPlayer();
                }
                else
                {
                    SetPlayerAfterCreate();
                }
            }
        }

        private void GetComponnents()
        {
            _enemyAnimator = GetComponent<EnemyAnimator>();
            _navMeshAgent = GetComponent<NavMeshAgent>();
        }

        private void StartMove()
        {
            _navMeshAgent.destination = _player.transform.position;
            _navMeshAgent.isStopped = false;
            _enemyAnimator.PlayMove();
        }

        private void StopMove()
        {
            _navMeshAgent.isStopped = true;
            _enemyAnimator.StopPlayMove();
        }

        private bool IsMinDistance() => Vector3.Distance(transform.position, _player.transform.position) > _minDistance;
        private bool IsPlayerInitialized() => _player != null;
        private void SetGameFactory() => _gameFactory = AllServices.Container.Get<IGameFactory>();
        private void SetPlayerAfterCreate() => _gameFactory.PlayerLoaded += SetPlayer;
        private bool IsPlayerCreate() => _gameFactory.Player != null;
        private bool IsGameFactoryInittialized() => _gameFactory != null;
        private void SetPlayer() => _player = _gameFactory.Player;
        private bool IsEnemyOnNavMesh() => _navMeshAgent.isOnNavMesh;
        private void DisableAgentMover() => enabled = false;
        private void SetSpeed() => _navMeshAgent.speed = _currentSpeed;
    }
}