using Secret.Enemy.Animations;
using UnityEngine;

namespace Secret.Enemy.AI.Agents
{
    public class AgentEdle : MonoBehaviour
    {
        [SerializeField] private EnemyAnimationsSetter _enemyAnimationsSetter;

        private void FixedUpdate()
        {
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