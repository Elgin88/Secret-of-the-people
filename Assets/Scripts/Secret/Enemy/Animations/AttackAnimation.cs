using Secret.Enemy.Logic;
using Secret.Enemy.StaticData;
using UnityEngine;

namespace Secret.Enemy.Animations
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