using System.Collections;
using UnityEngine;

namespace Scripts.CodeBase.Logic
{
    public interface ICoroutineRunner
    {
        public Coroutine StartCoroutine(IEnumerator coroutine);
    }
}