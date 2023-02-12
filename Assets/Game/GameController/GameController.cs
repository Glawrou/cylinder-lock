using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AndreyNosov.CylinderLock.Game
{
    public class GameController : MonoBehaviour
    {
        [SerializeField] private LevelController _levelController;
        [SerializeField] private WindowManager _windowManager;

        private LevelData[] _levels = new LevelData[]
        {
            new LevelData(
                new PinData[] { new PinData(5, 0), new PinData(3, 0), new PinData(7, 0) },
                60,
                new ToolType[] { ToolType.Magnet }),
            new LevelData(
                new PinData[] { new PinData(3, 10), new PinData(2, 10), new PinData(6, 10) },
                60,
                new ToolType[] { ToolType.ReMagnet }),
            new LevelData(
                new PinData[] { new PinData(4, 1), new PinData(3, 8), new PinData(2, 0) },
                60,
                new ToolType[] { ToolType.Sin })
        };

        private int currentLevel = 1;

        private void Start()
        {
            _levelController.OnWin += WinHandler;
            _levelController.OnGameOver += GameOverHandler;
            _windowManager.OnNextLevel += ClickNextLevelHandler;
            _windowManager.OnFirstLevel += ClickGoFirstLevelHandler;
            _windowManager.OnExit += ClickExitHandler;
            OpenLevel(currentLevel);
        }

        private void WinHandler()
        {
            _windowManager.OpenWinWindow();
        }

        private void GameOverHandler()
        {
            _windowManager.OpenWinWindow();
        }

        private void OpenLevel(int numberLevel)
        {
            if (numberLevel > _levels.Length)
            {
                return;
            }

            _levelController.Fill(_levels[numberLevel - 1]);
        }

        private void ClickNextLevelHandler()
        {
            currentLevel++;
            OpenLevel(currentLevel);
        }

        private void ClickExitHandler()
        {
            
        }

        private void ClickGoFirstLevelHandler()
        {
            currentLevel = 0;
            OpenLevel(currentLevel);
        }
    }
}
