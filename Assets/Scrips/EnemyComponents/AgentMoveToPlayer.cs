using Scripts.CodeBase.Infractructure;
using UnityEngine;
using UnityEngine.AI;

namespace Scripts.EnemyComponents
{
    [RequireComponent(typeof(EnemyAnimator))]
    [RequireComponent(typeof(NavMeshAgent))]

    public class AgentMoveToPlayer : MonoBehaviour
    {
        private const float _currentSpeed = 3;
        private const float _minDistance = 1.5f;
        private const float _baseSpeed = 0.8f;
        private EnemyAnimator _enemyAnimator;
        private NavMeshAgent _navMeshAgent;
        private GameObject _player = null;
        private IGameFactory _gameFactory = null;

        public float NormalizeSpeed => _currentSpeed / _baseSpeed;

        private void Awake()
        {
            _enemyAnimator = GetComponent<EnemyAnimator>();
            _navMeshAgent = GetComponent<NavMeshAgent>();
            _navMeshAgent.speed = _currentSpeed;
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

        private void Update()
        {
            if (!IsOnNavMesh() || !IsInitializePlayer())
            {
                return;
            }

            if (CheckMinDistance())
            {
                Move();
                _enemyAnimator.PlayMove();
            }
            else
            {
                _enemyAnimator.StopPlayMove();
            }
        }

        private void Move()
        {
            _navMeshAgent.destination = _player.transform.position;
        }

        private bool CheckMinDistance() => Vector3.Distance(transform.position, _player.transform.position) > _minDistance;
        private bool IsInitializePlayer() => _player != null;
        private void SetGameFactory() => _gameFactory = AllServices.Container.Get<IGameFactory>();
        private void SetPlayerAfterCreate() => _gameFactory.PlayerLoaded += SetPlayer;
        private bool IsPlayerCreate() => _gameFactory.Player != null;
        private bool IsGameFactoryInittialized() => _gameFactory != null;
        private void SetPlayer() => _player = _gameFactory.Player;
        private bool IsOnNavMesh() => _navMeshAgent.isOnNavMesh;
    }
}