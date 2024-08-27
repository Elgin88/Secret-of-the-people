﻿using UnityEngine;

namespace Enemy.Animations
{
    public class HitAnimation : MonoBehaviour
    {
        [SerializeField] private Animator _animator;

        private bool _isHit = false;

        public bool IsHit => _isHit;

        public void Play() => SetHit(true);

        public void StopPlay() => SetHit(false);

        private void SetHit(bool status)
        {
            _isHit = status;
            _animator.SetBool(global::Enemy.Static.IsHit, status);
        }
    }
}