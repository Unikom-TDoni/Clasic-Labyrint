using UnityEngine;
using Edu.Golf.Score;
using Lncodes.Module.Unity.Template;
using UnityEngine.SceneManagement;

namespace Edu.Golf.Core
{
    public sealed class GameManager : SingletonMonoBehavior<GameManager>
    {
        public uint CurrentLevel = default;

        [field: SerializeField]
        public Tags Tags { get; private set; } = default;

        [field: SerializeField]
        public SceneObjects SceneObjects { get; private set; } = default;

        public ScoreController ScoreController { get; private set; } = new();

        protected override void Awake()
        {
            base.Awake();
            ScoreController.OnAwake();
            SceneManager.LoadScene(SceneObjects.MainMenu);
        }
    }
}
