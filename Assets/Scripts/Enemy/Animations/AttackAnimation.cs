using Enemy.Logic;
using StaticData;
using UnityEngine;

namespace Enemy.Animations
{
    public class AttackAnimation : MonoBehaviour
    {
        [SerializeField] private MonsterStaticData _staticData;
        [SerializeField] private Animator _animator;

        private float _baseAnimationSpeed => _staticData.AttackAnimationSpeed;

        private void Awake()
        {
            SetAnimationSpeed();
        }

        public void Play()
        {
            SetAttack(true);
        }

        public void StopPlay()
        {
            SetAttack(false);
        }

        private void SetAnimationSpeed() => _animator.SetFloat(EnemyStatic.AttackAnimationSpeed, _baseAnimationSpeed);

        private void SetAttack(bool status) => _animator.SetBool(EnemyStatic.IsAttack, status);
    }
}