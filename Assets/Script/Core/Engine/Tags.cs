using System;
using UnityEngine;
using Lncodes.Module.Unity.Editor;

namespace Edu.Golf.Core
{
    [Serializable]
    public struct Tags
    {
        [TagSelector]
        [SerializeField]
        private string _hole;

        public string Hole { get => _hole; }
    }
}
