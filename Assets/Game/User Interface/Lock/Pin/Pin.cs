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
                if (_frozen)
                {
                    return;
                }

                _pinValue = Mathf.Clamp(value, MinValue, MaxValue);
                if (_pinValue == _correctValue)
                {
                    CorrectValueHandler();
                }

                ShowPinValue(_pinValue);
            }
        }

        public bool IsCorrect 
        { 
            get 
            {
                return _pinValue == _correctValue;
            } 
        }

        private int _pinValue;
        private int _defaultValue;
        private int _correctValue;

        private const int MinValue = 0;
        private const int MaxValue = 10;


        private bool _frozen = false;

        public void Fill(PinData pinData)
        {
            _defaultValue = Mathf.Clamp(pinData.Value, MinValue, MaxValue);
            PinValue = _defaultValue;
            _correctValue = Mathf.Clamp(pinData.CorrectValue, MinValue, MaxValue);
        }

        public void ResetValue()
        {
            PinValue = _defaultValue;
        }

        public void FrozenValue()
        {
            if (PinValue == _correctValue)
            {
                _frozen = true;
            }
        }

        private void ShowPinValue(int value)
        {
            _progressBar.fillAmount = (float)_pinValue / MaxValue;
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
