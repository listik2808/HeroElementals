using System.Collections;
using UnityEngine;

namespace Screpts
{
    public interface ICoroutineRunner
    {
        Coroutine StartCoroutine(IEnumerator coroutine);
    }
}