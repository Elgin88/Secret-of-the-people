using System.Collections;
using UnityEngine;

namespace Secret.Infrastructure.Game
{
    public interface ICoroutineRunner
    {
        public Coroutine StartCoroutine(IEnumerator coroutine);
    }
}