using System;
using UnityEngine;

namespace AndreyNosov.CylinderLock.Game
{
    public class WindowManager : MonoBehaviour
    {
        public Action OnNextLevel;
        public Action OnExit;
        public Action OnFirstLevel;

        [SerializeField] private ModalWindow _modalWindow;
        [SerializeField] private GameObject _back;

        private ModalWindow _openWindow;

        public void OpenWinWindow()
        {
            if (_openWindow != null)
            {
                return;
            }

            _back.SetActive(true);
            _openWindow = Instantiate(_modalWindow, transform);
            _openWindow.Fill("WIN", "Congratulations, you've won. Now you have access to a new level.", "Exit", "Next Level");
            _openWindow.OnClickTrue += ClickNextLevelHandler;
            _openWindow.OnClickFalse += ClickExitHandler;
        }

        public void OpenGameOverWindow()
        {
            if (_openWindow != null)
            {
                return;
            }

            _back.SetActive(true);
            _openWindow = Instantiate(_modalWindow, transform);
            _openWindow.Fill("Game Over", "You lost, but you can try again. You will succeed.", "Exit", "First Level");
            _openWindow.OnClickTrue += ClickGoFirstLevelHandler;
            _openWindow.OnClickFalse += ClickExitHandler;
        }

        private void ClickNextLevelHandler()
        {
            CloseWindow();
            OnNextLevel?.Invoke();
        }

        private void ClickExitHandler()
        {
            CloseWindow();
            OnExit?.Invoke();
        }

        private void ClickGoFirstLevelHandler()
        {
            CloseWindow();
            OnFirstLevel?.Invoke();
        }

        private void CloseWindow()
        {
            _openWindow.Close();
            _back.SetActive(false);
            _openWindow = null;
        }
    }
}
