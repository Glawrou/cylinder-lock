using UnityEngine;
using System;

namespace AndreyNosov.CylinderLock.Game
{
    public class LevelController : MonoBehaviour
    {
        public Action OnWin;
        public Action OnGameOver;

        [SerializeField] private Lock _lock;
        [SerializeField] private Timer _timer;
        [SerializeField] private Tools _tools;

        private void Start()
        {
            _tools.OnUseTool += UseToolsHanler;
            _timer.OnEndTimer += OnEndTimerHandler;
            _lock.OnlockOpen += OnAllPinOpen;
        }

        public void Fill(LevelData level)
        {
            _lock.Fill(level);
            _timer.StartTimer(level);
            _tools.Fill(level);
        }

        private void UseToolsHanler(ToolType toolType)
        {
            _lock.UseTool(toolType);
        }

        private void OnEndTimerHandler()
        {
            OnGameOver?.Invoke();
        }

        private void OnAllPinOpen()
        {
            OnWin?.Invoke();
            _timer.Pause();
        }
    }
}
