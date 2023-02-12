using System;
using UnityEngine;
using UnityEngine.UI;

namespace AndreyNosov.CylinderLock.Game
{
    public class Tool : MonoBehaviour
    {
        public Action<ToolType> OnUseTool;

        [SerializeField] private Button _button;
        [SerializeField] private Text _text;
        [SerializeField] private ToolType _toolType;

        private void Awake()
        {
            _button.onClick.AddListener(ClockHandler);
        }

        public void Fill(ToolType toolType, int numberPin)
        {
            _toolType = toolType;
            _text.text = ToolsHanler.GetTextLableTool(_toolType, numberPin);
        }

        private void ClockHandler()
        {
            OnUseTool?.Invoke(_toolType);
        }
    }
}
