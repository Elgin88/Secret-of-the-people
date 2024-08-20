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
                Debug.Log("PlayHit");

                _animator.SetBool(Static.IsHitHash, GetIsHit(true));
            }
        }

        public void StopPlayHit()
        {
            if (_isHit)
            {
                Debug.Log("StopHit");

                _animator.SetBool(Static.IsHitHash, GetIsHit(false));
            }
        }

        private void OnHitEnded()
        {
            if (_isHit)
            {
                Debug.Log("OnHitEnded");

                StopPlayHit();
            }
        }

        private bool GetIsHit(bool status) => _isHit = status;
    }
}