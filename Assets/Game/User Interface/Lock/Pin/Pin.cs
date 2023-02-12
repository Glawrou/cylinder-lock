using UnityEngine;
using UnityEngine.UI;
using System;

namespace AndreyNosov.CylinderLock.Game
{
    public class Pin : MonoBehaviour
    {
        public Action On—orrectValue;

        [SerializeField] private Text _pinValueText;
        [SerializeField] private Image _progressBar;
        [SerializeField] private AudioSource _audioSource;

        [SerializeField] private Color _noCorrenct;
        [SerializeField] private Color _correnct;

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

        public void Fill(PinData pinData)
        {
            PinValue = Mathf.Clamp(pinData.Value, MinValue, MaxValue);
            _correctValue = Mathf.Clamp(pinData.CorrectValue, MinValue, MaxValue);
        }

        private void ShowPinValue(int value)
        {
            _progressBar.fillAmount = value == _correctValue ? 1 : (float)_pinValue / MaxValue;
            _progressBar.color = value == _correctValue ? _correnct : _noCorrenct;
            _pinValueText.text = "" + value;
        }

        private void CorrectValueHandler()
        {
            _audioSource.Play();
            On—orrectValue?.Invoke();
        }
    }
}
