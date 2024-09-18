using UnityEngine;

namespace Enemy.AI.Agents.Checkers
{
    public class CheckerAttackEnded : MonoBehaviour
    {
        public bool IsAttackEnded { get; private set; }

        private void Awake()
        {
            SetIsNotEndHit();
        }

        public void SetIsAttackEnded()
        {
            IsAttackEnded = true;
        }

        public void SetIsNotEndHit()
        {
            IsAttackEnded = false;
        }

        private void OnAttackEnded()
        {
            IsAttackEnded = true;
        }
    }
}