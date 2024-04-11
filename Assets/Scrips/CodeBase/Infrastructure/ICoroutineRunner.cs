using System.Collections;
using UnityEngine;

namespace Scripts.CodeBase.Infractructure
{
    public interface ICoroutineRunner
    {
        Coroutine StartCoroutine(IEnumerator coroutine);
    }
}