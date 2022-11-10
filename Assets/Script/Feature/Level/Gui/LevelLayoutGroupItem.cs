using TMPro;
using UnityEngine;
using Edu.Golf.Core;
using UnityEngine.UI;
using Lnco.Unity.Module.Layout;
using UnityEngine.SceneManagement;

namespace Edu.Golf.Level
{
    public sealed class LevelLayoutGroupItem : LayoutGroupItem<LevelLayoutItem>
    {
        [SerializeField]
        private Image _imgLevelLayout = default;

        [SerializeField]
        private Button _btnChooseLevel = default;

        [SerializeField]
        private TextMeshProUGUI _textHighScore = default;

        public override void UpdateContent(LevelLayoutItem levelLayoutItem)
        {
            _imgLevelLayout.sprite = levelLayoutItem.SpriteLevelLayout;
            _btnChooseLevel.onClick.AddListener(() =>
            {
                GameManager.Instance.CurrentLevel = levelLayoutItem.CurrentLevel;
                SceneManager.LoadScene(GameManager.Instance.SceneObjects.Gameplay);
            });
            _textHighScore.text = $"High Score \n {GameManager.Instance.ScoreController.GetHighScore(levelLayoutItem.CurrentLevel):N2} S";
        }
    }
}