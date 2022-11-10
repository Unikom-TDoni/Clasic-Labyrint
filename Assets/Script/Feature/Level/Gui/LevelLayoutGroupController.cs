using UnityEngine;
using Lnco.Unity.Module.Layout;

namespace Edu.Golf.Level
{
    public sealed class LevelLayoutGroupController : LayoutGroupController<LevelLayoutGroupItem, LevelLayoutItem>
    {
        [SerializeField]
        private LevelLayoutItem[] _levelLayoutItems = default;

        private void Awake()
        {
            for (int i = 0; i < _levelLayoutItems.Length; i++) Create();
            TryRefreshContent(_levelLayoutItems);
        }

        protected override LevelLayoutGroupItem InstatiateGroupItem() =>
            Instantiate(GroupItem).GetComponent<LevelLayoutGroupItem>();
    }
}