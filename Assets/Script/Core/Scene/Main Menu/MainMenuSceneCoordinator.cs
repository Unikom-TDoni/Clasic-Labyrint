using UnityEngine;

namespace Edu.Golf.Core
{
    public sealed class MainMenuSceneCoordinator : MonoBehaviour
    {
        [SerializeField]
        private MainMenuSceneUIController _uiController = default;

        private void Awake()
        {
            _uiController.OnAwake();
        }
    }
}
