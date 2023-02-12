using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AndreyNosov.CylinderLock.Game
{
    public class Lock : MonoBehaviour
    {
        [SerializeField] private Pin _pinPrefab;

        private Pin[] _pins;

        public void SpawnPins(int number)
        {
            ClearPins();
            _pins = new Pin[number];
            for (var i = 0; i < number; i++)
            {
                _pins[i] = Instantiate(_pinPrefab, transform);
            }
        }

        private void ClearPins()
        {
            if (_pins == null)
            {
                return;
            }

            for (var i = 0; i < _pins.Length; i++)
            {
                Destroy(_pins[i].gameObject);
            }
        }
    }
}
