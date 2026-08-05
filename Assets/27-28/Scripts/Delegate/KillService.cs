using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace _27_28.Scripts.Delegate
{
    public class KillService
    {
        private readonly MonoBehaviour _coroutineRunner;
        
        private readonly Dictionary<IKillable, List<Coroutine>> _killablesDictionary = new();

        public KillService(MonoBehaviour coroutineRunner)
        {
            _coroutineRunner = coroutineRunner;
        }
        
        public int Count => _killablesDictionary.Count;
        
        public void KillWhen(IKillable killable, Func<bool> func)
        {
            if (!_killablesDictionary.ContainsKey(killable))
                _killablesDictionary.Add(killable, new List<Coroutine>());
            
            List<Coroutine> coroutines = _killablesDictionary[killable];
            
            coroutines.Add(_coroutineRunner.StartCoroutine(KillCoroutine(killable, func)));
        }

        private IEnumerator KillCoroutine(IKillable killable, Func<bool> func)
        {
            yield return new WaitUntil(func);
            
            List<Coroutine> coroutines = _killablesDictionary[killable];
            
            foreach (Coroutine coroutine in coroutines)
            {
                _coroutineRunner.StopCoroutine(coroutine);
            }
            
            _killablesDictionary.Remove(killable);
            
            killable.Kill();
        }
    }
}
