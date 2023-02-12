using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AndreyNosov.CylinderLock.Game
{
    public class GameController : MonoBehaviour
    {
        [SerializeField] private Lock _lock;
        [SerializeField] private Timer _timer;
        [SerializeField] private Tools _tools;

        public void Start()
        {
            var pinData = new PinData[] { new PinData(5, 0), new PinData(3, 0), new PinData(7, 0) };
            var level = new LevelData(pinData, 60, new ToolType[] { ToolType.Magnet });
            _lock.Fill(level);
            _timer.StartTimer(level);
            _tools.Fill(level);
            _tools.OnUseTool += UseToolsHanler;
        }

        private void UseToolsHanler(ToolType toolType)
        {
            _lock.UseTool(toolType);
        }
    }
}
