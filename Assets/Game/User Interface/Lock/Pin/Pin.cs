using UnityEngine;
using UnityEngine.UI;
using System;

namespace AndreyNosov.CylinderLock.Game
{
    public class Pin : MonoBehaviour
    {
        public Action On—orrectValue;

        [SerializeField] private Text _pinValueText;

        public int PinValue
        {
            get
            {
                return _pinValue;
            }
            set
            {
                _pinValue = Mathf.Clamp(value, MinValue, MaxValue);
                if (_pinValue == _correctValue)
                {
                    CorrectValueHandler();
                }

                ShowPinValue(_pinValue);
            }
        }

        private int _pinValue;
        private int _correctValue;

        private const int MinValue = 0;
        private const int MaxValue = 10;

        public void Fill(int pinValue, int ÒorrectValue)
        {
            PinValue = Mathf.Clamp(pinValue, MinValue, MaxValue);
            _correctValue = Mathf.Clamp(ÒorrectValue, MinValue, MaxValue);
        }

        private void ShowPinValue(int value)
        {
            _pinValueText.text = "" + value;
        }

        private void CorrectValueHandler()
        {
            On—orrectValue?.Invoke();
        }
    }
}
