using Core.Abstractions;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Core.PlayerData
{
    public class PlayerData : MonoBehaviour
    {
        public static PlayerData Instance { get; private set; }

        private Dictionary<object, object> data = new Dictionary<object, object>();
        public event Action OnDataChanged;

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

        public T Get<T>(ValueKey<T> key)
        {
            if (data.TryGetValue(key, out var value))
                return (T)value;
            return default;
        }

        public bool Contains<T>(ValueKey<T> key)
        {
            return data.ContainsKey(key);
        }

        public void Set<T>(ValueKey<T> key, T value)
        {
            data[key] = value;
            OnDataChanged?.Invoke();
        }

        public void Modify<T>(ValueKey<T> key, Func<T, T> modifier)
        {
            T old = Get(key);
            Set(key, modifier(old));
        }
    }
}