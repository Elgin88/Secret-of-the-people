using Scripts.Data;
using Scripts.Infractructure.Services;
using Scripts.Services.Input;
using Scripts.Services.PersistentProgress;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Scripts.PlayerComponents
{
    [RequireComponent(typeof(PlayerAnimation))]
    [RequireComponent(typeof(Player))]

    public class PlayerMover : MonoBehaviour, ISavedProgress
    {
        [SerializeField] private float _movementSpeed;

        private PlayerAnimation _playerAnimation;
        private IInputService _inputService;
        private Quaternion _targetRotation;
        private Quaternion _currentRotation;
        private Vector3 _targetPosition = new Vector3();
        private Vector3 _currentPosition;
        private Player _player;
        private float _currentMovementSpeed;
        private bool _isRun;

        public bool IsRun => _isRun;

        public void UpdateProgress(PlayerGameProgress playerProgress)
        {
            playerProgress.WorldData.PositionOnLevel = new PositionOnLevel(CurrentLevel(), transform.position.AsVectorData());
        }

        public void LoadProgress(PlayerGameProgress playerGameProgress)
        {
            if (CurrentLevel() == playerGameProgress.WorldData.PositionOnLevel.LevelName)
            {
                Vector3Data savedPosition = playerGameProgress.WorldData.PositionOnLevel.Position;

                if (playerGameProgress.WorldData.PositionOnLevel.Position != null)
                {
                    Warp(savedPosition);
                }
            }
        }

        private void Awake()
        {
            _playerAnimation = GetComponent<PlayerAnimation>();
            _player = GetComponent<Player>();

            _inputService = AllServices.Container.Single<IInputService>();

            _currentMovementSpeed = _movementSpeed;
        }

        private void Warp(Vector3Data savedPosition)
        {
            _player.SetPosition(savedPosition.AsUnityVector());
        }

        private static string CurrentLevel() => SceneManager.GetActiveScene().name;

        private void Update()
        {
            _currentPosition = transform.position;
            _currentRotation = transform.rotation;

            SetTargetPosition();
            SetTargetRotation();
            SetIsRunStatus();
            TryPlayRunAnimation();

            _player.SetPosition(_targetPosition);
            _player.SetRotation(_targetRotation);
        }

        private void SetTargetPosition()
        {
            _targetPosition = new Vector3(transform.position.x + _inputService.Axis.x, 0, transform.position.z + _inputService.Axis.y);
            _targetPosition = Vector3.MoveTowards(_currentPosition, _targetPosition, _currentMovementSpeed * Time.deltaTime);
        }

        private void SetTargetRotation()
        {
            if (_targetPosition != _currentPosition)
            {
                _targetRotation = Quaternion.LookRotation(_targetPosition - transform.position, Vector3.up);
            }
            else
            {
                _targetRotation = _currentRotation;
            }
        }

        private void SetIsRunStatus()
        {
            if (_currentPosition == _targetPosition)
            {
                _isRun = false;
            }
            else
            {
                _isRun = true;
            }
        }

        private void TryPlayRunAnimation()
        {
            if (_isRun)
            {
                _playerAnimation.StartRun();
            }
            else
            {
                _playerAnimation.StopRun();
            }
        }
    }
}