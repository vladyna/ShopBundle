using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core.Services
{
    public class ServerService : MonoBehaviour
    {
        public static ServerService Instance { get; private set; }

        private const int MaxConcurrent = 5;

        private readonly Queue<Action<bool>> _pending = new();
        private int _activeCount = 0;

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
                return;
            }

            Instance = this;
            DontDestroyOnLoad(gameObject);
        }

        public void SendRequest(Action<bool> onComplete)
        {
            _pending.Enqueue(onComplete);
            TryStartNext();
        }

        private void TryStartNext()
        {
            while (_activeCount < MaxConcurrent && _pending.Count > 0)
            {
                var callback = _pending.Dequeue();
                _activeCount++;

                StartCoroutine(SendRequestCoroutine(result =>
                {
                    callback?.Invoke(result);
                    _activeCount--;
                    TryStartNext();
                }));
            }
        }

        private IEnumerator SendRequestCoroutine(Action<bool> onComplete)
        {
            yield return new WaitForSeconds(3f);
            onComplete?.Invoke(true);
        }
    }
}
