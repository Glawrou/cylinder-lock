using System;
using UnityEngine;
using UnityEngine.UI;

namespace AndreyNosov.CylinderLock.Game
{
    public class Timer : MonoBehaviour
    {
        public Action OnEndTimer;

        [SerializeField] private Text _timerText;

        private float _remainingTime;
        private bool _active = false;

        public void StartTimer(LevelData level)
        {
            _remainingTime = level.Timer;
            _active = true;
        }

        private void ShowTimeer(float timer)
        {
            _timerText.text = "" + Mathf.Ceil(timer);
        }

        private void Update()
        {
            if (!_active)
            {
                return;
            }

            _remainingTime -= Time.deltaTime;
            if (_remainingTime <= 0)
            {
                EndTimeHandler();
                return;
            }

            ShowTimeer(_remainingTime);
        }

        private void EndTimeHandler()
        {
            _active = false;
            _timerText.color = Color.red;
            ShowTimeer(0);
            OnEndTimer?.Invoke();
        }
    }
}
