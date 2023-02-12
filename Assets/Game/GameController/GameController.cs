using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace AndreyNosov.CylinderLock.Game
{
    public class GameController : MonoBehaviour
    {
        [SerializeField] private LevelController _levelController;
        [SerializeField] private WindowManager _windowManager;

        [Header("Sound")]
        [SerializeField] private AudioSource _win;
        [SerializeField] private AudioSource _lose;

        private const string MenuSceneName = "Menu";

        private LevelData[] _levels = new LevelData[]
        {
            new LevelData(
                new PinData[] { new PinData(5, 0), new PinData(3, 0), new PinData(7, 0) },
                25,
                new ToolType[] { ToolType.Magnet }),
            new LevelData(
                new PinData[] { new PinData(3, 10), new PinData(2, 10), new PinData(6, 10) },
                25,
                new ToolType[] { ToolType.ReMagnet }),
            new LevelData(
                new PinData[] { new PinData(4, 1), new PinData(3, 6), new PinData(2, 0) },
                25,
                new ToolType[] { ToolType.Sin }),
            new LevelData(
                new PinData[] { new PinData(4, 6), new PinData(3, 1), new PinData(2, 4) },
                25,
                new ToolType[] { ToolType.ReSin })
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
            _win.Play();
            _windowManager.OpenWinWindow();
        }

        private void GameOverHandler()
        {
            _lose.Play();
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
            SceneManager.LoadScene(MenuSceneName);
        }

        private void ClickGoFirstLevelHandler()
        {
            currentLevel = 0;
            OpenLevel(currentLevel);
        }
    }
}
