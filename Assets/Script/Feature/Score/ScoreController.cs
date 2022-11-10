using System;
using UnityEngine;

namespace Edu.Golf.Score
{
    public sealed class ScoreController
    {
        private const string HighScoreKey = "HighScore";

        public float Score { get; private set; } = default;

        private HighScoreHolder _highScoreHolder = default;

        public void OnAwake()
        {
            var jsonObj = PlayerPrefs.GetString(HighScoreKey);
            _highScoreHolder = string.IsNullOrEmpty(jsonObj) ? new() : JsonUtility.FromJson<HighScoreHolder>(jsonObj);
        }

        public void ResetScore() =>
            Score = default;

        public void IncreaseScore() =>
            Score += Time.deltaTime;

        public float GetHighScore(uint currentLevel) =>
             currentLevel < _highScoreHolder.HighScore.Length ? _highScoreHolder.HighScore[currentLevel] : 0;

        public void SaveHighScore(uint currentLevel)
        {
            var highScore = _highScoreHolder.HighScore[currentLevel];
            if (Score > highScore && highScore != 0) return;
            _highScoreHolder.HighScore[currentLevel] = Score;
            var jsonObj = JsonUtility.ToJson(_highScoreHolder);
            PlayerPrefs.SetString(HighScoreKey, jsonObj);
        }
    }
}