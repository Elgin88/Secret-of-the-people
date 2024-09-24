using StaticData;
using UnityEngine;

namespace Enemy.AI.Agents.Checkers
{
    public class CkeckerAttackCooldown : MonoBehaviour
    {
        [SerializeField] private MonsterStaticData _monsterStaticData;

        private float _startCooldown => _monsterStaticData.AttackCooldown;
        private float _currentCooldown = 0;
        private bool _isEnd => _currentCooldown <= 0;

        public bool IsEnd => _isEnd;

        private void FixedUpdate()
        {
            UpdateCooldown();
        }

        public void ResetCooldown()
        {
            _currentCooldown = _startCooldown;
        }

        private void UpdateCooldown()
        {
            _currentCooldown -= Time.deltaTime;
        }
    }
}