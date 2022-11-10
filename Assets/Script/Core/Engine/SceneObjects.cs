using System;
using UnityEngine;
using Lncodes.Module.Unity.Editor;

namespace Edu.Golf.Core
{
    [Serializable]
    public struct SceneObjects
    {
        [SerializeField]
        private SceneObject mainMenu;

        [SerializeField]
        private SceneObject gameplay;

        [SerializeField]
        private SceneObject levelSelect;

        public SceneObject MainMenu { get => mainMenu; private set => mainMenu = value; }

        public SceneObject Gameplay { get => gameplay; private set => gameplay = value; }

        public SceneObject LevelSelect { get => levelSelect; private set => levelSelect = value; }
    }
}
