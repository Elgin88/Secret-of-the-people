using UnityEngine;

namespace Enemy.AI.Agents.Checkers
{
    public class CheckerIdle : MonoBehaviour
    {
        public bool IsIdle { get; private set; }

        private void Awake()
        {
            IsIdle = false;
        }

        public void SetIsIdle()
        {
            IsIdle = true;
        }

        public void SetIsNotIdle()
        {
            IsIdle = false;
        }
    }
}