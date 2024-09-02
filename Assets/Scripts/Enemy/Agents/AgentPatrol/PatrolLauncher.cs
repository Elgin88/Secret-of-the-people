using UnityEngine;

namespace Enemy.Agents.AgentPatrol
{
    public class PatrolLauncher : MonoBehaviour
    {
        private Patrol _patrol;

        private void Start()
        {
            SetComponents();
            On();
        }

        public void On()
        {
            _patrol.On();
        }

        public void Off()
        {
        }

        private void SetComponents() => _patrol = GetComponent<Patrol>();
    }
}