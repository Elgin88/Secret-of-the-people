using System;
using Scripts.StaticData;
using UnityEngine;

namespace Scripts.Player
{
    public class RunAnimation : MonoBehaviour
    {
        [SerializeField] private PlayerStaticData _staticData;
        [SerializeField] private Animator _animator;
        [SerializeField] private Mover _mover;

        public void PlayRun()
        {
            SetAnimationSpeed();
            _animator.SetBool(Static.IsRunHash, true);
        }

        public void StopPlayRun()
        {
            _animator.SetBool(Static.IsRunHash, false);
        }

        private void SetAnimationSpeed() => _animator.SetFloat(Static.RunParametrHash, _mover.StartMoveSpeed / _staticData.AnimationBaseRunSpeed);
    }
}