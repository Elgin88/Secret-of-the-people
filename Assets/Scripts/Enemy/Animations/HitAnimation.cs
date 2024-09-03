using System;
using UnityEngine;

namespace Enemy.Animations
{
    [RequireComponent(typeof(Animator))]

    public class HitAnimation : MonoBehaviour
    {
        [SerializeField] private Animator _animator;

        public void Play()
        {
            SetHit(true);
        }

        public void StopPlay()
        {
            SetHit(false);
        }

        private void SetHit(bool status) => _animator.SetBool(EnemyStatic.IsHit, status);
    }
}