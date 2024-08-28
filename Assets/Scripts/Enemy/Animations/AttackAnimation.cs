using StaticData;
using UnityEngine;

namespace Enemy.Animations
{
    [RequireComponent(typeof(Animator))]

    public class AttackAnimation : MonoBehaviour
    {
        [SerializeField] private MonsterStaticData _staticData;
        [SerializeField] private Animator _animator;

        private float _baseSpeed;

        private void Awake()
        {
            _baseSpeed = _staticData.AttackAnimationSpeed;
        }

        public void Play()
        {
            SetAnimationSpeed();
            SetAttack(true);
        }

        public void StopPlay()
        {
            SetAttack(false);
        }

        private void SetAttack(bool status) => _animator.SetBool(EnemyStatic.IsAttack, status);

        private void SetAnimationSpeed() => _animator.SetFloat(EnemyStatic.AttackAnimationSpeed, _baseSpeed);
    }
}