using System.Collections.Generic;
using System.Linq;
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
                new PinData[] { new PinData(10, 4)},
                25,
                new ToolType[] { ToolType.Sin }),
            new LevelData(
                new PinData[] { new PinData(4, 6), new PinData(3, 1), new PinData(2, 4) },
                40,
                new ToolType[] { ToolType.ReSin, ToolType.Sin, ToolType.Reset }),
            new LevelData(
                new PinData[] { new PinData(5, 0), new PinData(3, 0)},
                25,
                new ToolType[] { ToolType.Magnet }),
            new LevelData(
                new PinData[] { new PinData(5, 4), new PinData(5, 6), new PinData(5, 3), new PinData(5, 7)},
                120,
                new ToolType[] { ToolType.Sin, ToolType.Frozen, ToolType.Reset }),
            new LevelData(
                new PinData[] { new PinData(6, 3), new PinData(3, 0), new PinData(2, 3) },
                25,
                new ToolType[] { ToolType.ReSin, ToolType.Magnet }),
            new LevelData(
                new PinData[] { new PinData(3, 10), new PinData(2, 10), new PinData(6, 10) },
                25,
                new ToolType[] { ToolType.ReMagnet }),
            new LevelData(
                new PinData[] { new PinData(3, 3), new PinData(3, 0), new PinData(2, 3),  new PinData(2, 0) },
                60,
                new ToolType[] { ToolType.ReSin, ToolType.Sin, ToolType.Magnet }),
            new LevelData(
                new PinData[] { new PinData(8, 3)},
                10,
                new ToolType[] { ToolType.Random }),
            new LevelData(
                new PinData[] { new PinData(3, 4), new PinData(8, 7), new PinData(8, 3)},
                120,
                new ToolType[] { ToolType.ReSin, ToolType.Sin, ToolType.Magnet, ToolType.ReMagnet, ToolType.Frozen}),
            new LevelData(
                new PinData[] { new PinData(3, 4), new PinData(8, 7), new PinData(8, 3), new PinData(3, 4), new PinData(8, 7), new PinData(8, 3)},
                120,
                new ToolType[] { ToolType.Random, ToolType.Frozen }),
            new LevelData(
                new PinData[] { new PinData(6, 2), new PinData(10, 0), new PinData(6, 2), new PinData(8, 7), new PinData(5, 3), new PinData(3, 5), new PinData(2, 10), new PinData(8, 7), new PinData(8, 3)},
                120,
                new ToolType[] { ToolType.ReSin, ToolType.Sin, ToolType.Frozen}),

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
            _windowManager.OpenGameOverWindow();
        }

        private void OpenLevel(int numberLevel)
        {
            if (numberLevel > _levels.Length)
            {
                _levelController.Fill(RandomLevel(), numberLevel);
                return;
            }

            _levelController.Fill(_levels[numberLevel - 1], numberLevel);
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
            currentLevel = 1;
            OpenLevel(currentLevel);
        }

        private LevelData RandomLevel()
        {
            var pinCount = Random.Range(3, 9);
            var pins = new List<PinData>();

            for (var i = 0; i < pinCount; i++)
            {
                pins.Add(new PinData(Random.Range(0,10), Random.Range(0,10)));
            }

            var toolsCount = Random.Range(4, 10);
            var tools = new List<ToolType>();
            var toolTypeValues = System.Enum.GetValues(typeof(ToolType));
            for (var i = 0; i < toolsCount; i++)
            {
                tools.Add((ToolType)toolTypeValues.GetValue(Random.Range(0, toolTypeValues.Length)));
            }

            return new LevelData(
                pins.ToArray(),
                Random.Range(60, 240),
                tools.Distinct().ToArray());
        }
    }
}
