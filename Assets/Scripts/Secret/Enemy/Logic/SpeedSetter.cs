using Secret.Enemy.StaticData;
using UnityEngine;

namespace Secret.Enemy.Logic
{
    public class SpeedSetter : MonoBehaviour
    {
        [SerializeField] private MonsterStaticData _staticData;

        private float _moveToPlayerSpeed => _staticData.MoveToPlayerSpeed;
        private float _patrolSpeed => _staticData.PatrolSpeed;

        public float CurrentSpeed { get; private set; }

        public void SetPatrolSpeed() => CurrentSpeed = _patrolSpeed;

        public void SetRunSpeed() => CurrentSpeed = _moveToPlayerSpeed;
    }
}