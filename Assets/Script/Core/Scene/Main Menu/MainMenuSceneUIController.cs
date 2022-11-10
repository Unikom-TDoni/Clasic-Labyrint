using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Edu.Golf.Core
{
    [Serializable]
    public sealed class MainMenuSceneUIController
    {
        [SerializeField]
        private Button _btnExit = default;

        [SerializeField]
        private Button _btnSelectLevel = default;

        public void OnAwake()
        {
            _btnExit.onClick.AddListener(() => Application.Quit());
            _btnSelectLevel.onClick.AddListener(() => SceneManager.LoadScene(GameManager.Instance.SceneObjects.LevelSelect));
        }
    }
}
