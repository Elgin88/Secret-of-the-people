using Enemy.Animations;
using UnityEngine;

namespace Enemy.AI.Agents
{
    public class AgentEdle : MonoBehaviour
    {
        [SerializeField] private EnemyAnimationsSetter _enemyAnimationsSetter;

        private void FixedUpdate()
        {
            Debug.Log("AgentEdle");

            _enemyAnimationsSetter.PlayIdle();
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
    }
}