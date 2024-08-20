using System;
using UnityEngine;

namespace Scripts.Player
{
    public class HitAnimation : MonoBehaviour
    {
        [SerializeField] private Animator _animator;

        private bool _isHit = false;

        public bool IsHit => _isHit;

        public void PlayHit()
        {
            if (!_isHit)
            {
                _animator.SetBool(Static.IsHitHash, GetIsHit(true));
            }
        }

        public void StopPlayHit()
        {
            if (_isHit)
            {
                _animator.SetBool(Static.IsHitHash, GetIsHit(false));
            }
        }

        private void OnHitEnded()
        {
            if (_isHit)
            {
                StopPlayHit();
            }
        }

        private bool GetIsHit(bool status) => _isHit = status;
    }
}