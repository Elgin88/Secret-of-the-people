using System;
using StaticData;
using UnityEngine;

namespace Enemy.Agents.MoveToPlayer
{
    public class AgroZone : MonoBehaviour
    {
        [SerializeField] private MonsterStaticData _staticData;
        [SerializeField] private SphereCollider _agroZone;

        private float _radius;
        private bool _isEnter = false;

        public event Action<Collider> Enter;

        public event Action<Collider> Exit;

        private void Awake()
        {
            SetRadius();
            SetRadiusCollider();
        }

        private void OnTriggerEnter(Collider player)
        {
            if (_isEnter)
            {
                return;
            }
            
            Enter?.Invoke(player);
            _isEnter = true;
        }

        private void OnTriggerExit(Collider player)
        {
            if (!_isEnter)
            {
                return;
            }
            
            Exit?.Invoke(player);
            _isEnter = false;
        }

        private void SetRadius() => _radius = _staticData.AgroRange;
        private void SetRadiusCollider() => _agroZone.radius = _radius;
    }
}