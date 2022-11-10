using System;
using UnityEngine;
using Edu.Golf.Core;

namespace Edu.Golf.Level
{
    [Serializable]
    public sealed class LevelSpawner
    {
        [SerializeField]
        private GameObject[] _levelObjects = default;

        public void OnAwake()
        {
            GameObject.Instantiate(_levelObjects[GameManager.Instance.CurrentLevel]);
        }
    }
}