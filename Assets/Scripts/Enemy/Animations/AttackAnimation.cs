using StaticData;
using UnityEngine;

namespace Enemy.Animations
{
    [RequireComponent(typeof(Animator))]

    public class AttackAnimation : MonoBehaviour
    {
        [SerializeField] private MonsterStaticData _staticData;
        
        private Animator _animator;

        private float _baseSpeed => _staticData.AttackAnimationSpeed;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
            
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

        private void SetAnimationSpeed() => _animator?.SetFloat(EnemyStatic.AttackAnimationSpeed, _baseSpeed);

        private void SetAttack(bool status) => _animator?.SetBool(EnemyStatic.IsAttack, status);
    }
}