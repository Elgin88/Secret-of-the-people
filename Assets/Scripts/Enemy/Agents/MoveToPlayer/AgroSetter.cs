using System;
using StaticData;
using UnityEngine;

namespace Enemy.Agents.MoveToPlayer
{
    public class AgroSetter : MonoBehaviour
    {
        [SerializeField] private MonsterStaticData _staticData;
        [SerializeField] private SphereCollider _agroZone;

        private bool _isEnter = false;

        public event Action Enter;

        public event Action Exit;

        private void Awake() => SetRadiusCollider();

        private void OnTriggerEnter(Collider player)
        {
            if (!_isEnter)
            {
                Enter?.Invoke();
                SetIsEnter(true);
            }
        }

        private void OnTriggerExit(Collider player)
        {
            if (_isEnter)
            {
                Exit?.Invoke();
                SetIsEnter(false);
            }
        }

        private void SetIsEnter(bool status) => _isEnter = status;
        private void SetRadiusCollider() => _agroZone.radius = _staticData.AgroRange;
    }
}