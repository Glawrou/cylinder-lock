using System;
using UnityEngine;

namespace AndreyNosov.CylinderLock.Game
{
    public class Tools : MonoBehaviour
    {
        public Action<ToolType> OnUseTool;

        [SerializeField] private Tool _toolPrefab;

        private Tool[] _tools;

        public void Fill(LevelData level)
        {
            ClearTools();
            var toolsCount = level.ToolsType.Length;
            _tools = new Tool[toolsCount];
            for (var i = 0; i < toolsCount; i++)
            {
                _tools[i] = Instantiate(_toolPrefab, transform);
                _tools[i].Fill(level.ToolsType[i], level.Pins.Length);
            }

            foreach (var tool in _tools)
            {
                tool.OnUseTool += ClickHandler;
            }
        }

        private void ClearTools()
        {
            if (_tools == null)
            {
                return;
            }

            for (var i = 0; i < _tools.Length; i++)
            {
                Destroy(_tools[i].gameObject);
            }
        }

        private void ClickHandler(ToolType toolType)
        {
            OnUseTool?.Invoke(toolType);
        }
    }
}
