using UnityEngine;

namespace Scripts.EnemyComponents
{
    public class AgentAttack : MonoBehaviour, IAgent
    {
        [SerializeField] private AgentMoveToPlayer _agentMoverToPlayer;

        private void Awake()
        {
            enabled = false;
        }

        private void Update()
        {

        }

        public void AgentOn()
        {
            enabled = true;
            _agentMoverToPlayer.AgentOff();
        }

        public void AgentOff()
        {
            enabled = false;
            _agentMoverToPlayer.AgentOn();
        }
    }
}