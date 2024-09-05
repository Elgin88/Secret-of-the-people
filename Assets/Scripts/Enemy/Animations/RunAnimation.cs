using Enemy.Logic;
using StaticData;
using UnityEngine;

namespace Enemy.Animations
{
    [RequireComponent(typeof(SpeedSetter))]
    [RequireComponent(typeof(Animator))]

    public class RunAnimation : MonoBehaviour
    {
        [SerializeField] private MonsterStaticData _staticData;
        [SerializeField] private SpeedSetter _speedSetter;
        [SerializeField] private Animator _animator;

        public void Play()
        {
            SetAnimationSpeed();
            PlayAnimation(true);
        }

        public void StopPlay()
        {
            PlayAnimation(false);
        }

        private void PlayAnimation(bool status) => _animator?.SetBool(EnemyStatic.IsRun, status);
        private void SetAnimationSpeed() => _animator?.SetFloat(EnemyStatic.RunAnimationSpeed, _speedSetter.CurrentSpeed * _staticData.RunAnimationSpeed);
    }
}