using System;
using UnityEngine;

namespace Edu.Golf.Level
{
    [Serializable]
    public struct LevelLayoutItem
    {
        [SerializeField]
        internal uint CurrentLevel;

        [SerializeField]
        internal Sprite SpriteLevelLayout;
    }
}