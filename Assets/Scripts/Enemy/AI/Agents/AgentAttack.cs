using Enemy.Animations;
using UnityEngine;

namespace Enemy.AI.Agents
{
    public class AgentAttack : MonoBehaviour
    {
        [SerializeField] private EnemyAnimationsSetter _enemyAnimationsSetter;
        
        private void FixedUpdate()
        {
            Debug.Log("Attack");
            _enemyAnimationsSetter.PlayAttack();
        }

        public void On()
        {
            if (!enabled)
            {
                enabled = true;
            }
        }

        public void Off()
        {
            if (enabled)
            {
                enabled = false;
            }
        }

        private void OnAttackStarted()
        {
        }

        private void OnHit()
        {
        }

        private void OnAttackEnded()
        {
        }
    }
}