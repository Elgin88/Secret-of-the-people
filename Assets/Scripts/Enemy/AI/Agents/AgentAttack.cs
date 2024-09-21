using System;
using UnityEngine;

namespace Enemy.AI.Agents
{
    public class AgentAttack : MonoBehaviour
    {
        private void FixedUpdate()
        {
            Debug.Log("AgentAttack");
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