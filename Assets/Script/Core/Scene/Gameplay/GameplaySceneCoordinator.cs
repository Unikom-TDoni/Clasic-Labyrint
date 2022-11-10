using UnityEngine;
using Edu.Golf.Level;
using Edu.Golf.Player;

namespace Edu.Golf.Core
{
    public sealed class GameplaySceneCoordinator : MonoBehaviour
    {
        [SerializeField]
        private LevelSpawner _levelSpawner = default;

        [SerializeField]
        private GameplaySceneUIController _uiController = default;

        [SerializeField]
        private PlayerController _playerController = default;

        private bool _isGameOver = default;

        private void Awake()
        {
            _levelSpawner.OnAwake();
            _uiController.OnAwake();
            _playerController.OnHole += () =>
            {
                _isGameOver = true;
                var highScore = GameManager.Instance.ScoreController.GetHighScore(GameManager.Instance.CurrentLevel);
                _uiController.ShowGameOver(GameManager.Instance.ScoreController.Score, highScore);
                GameManager.Instance.ScoreController.ResetScore();
            };
        }

        private void Update()
        {
            if (_isGameOver) return;
            GameManager.Instance.ScoreController.IncreaseScore();
            _uiController.UpdateScore(GameManager.Instance.ScoreController.Score);
        }
    }
}