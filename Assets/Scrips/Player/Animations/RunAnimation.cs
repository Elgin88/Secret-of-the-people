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

        private float _baseRunSpeed;

        private void Awake()
        {
            SetBaseRunSpeed();
        }

        public void PlayRun()
        {
            SetIsRunTrue();
            SetRunParametr();
        }

        public void StopPlayRun()
        {
            SetIsRunFalse();
        }

        private void SetIsRunTrue() => _animator.SetBool(Static.IsRunHash, true);

        private void SetIsRunFalse() => _animator.SetBool(Static.IsRunHash, false);

        private void SetBaseRunSpeed() => _baseRunSpeed = _staticData.AnimationBaseRunSpeed;

        private void SetRunParametr() => _animator.SetFloat(Static.RunParametrHash, _mover.StartMoveSpeed / _baseRunSpeed);
    }
}