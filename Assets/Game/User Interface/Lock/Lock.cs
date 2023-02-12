using UnityEngine;

namespace AndreyNosov.CylinderLock.Game
{
    public class Lock : MonoBehaviour
    {
        [SerializeField] private Pin _pinPrefab;

        private Pin[] _pins;

        public void Fill(LevelData level)
        {
            SpawnPins(level.Pins);
        }

        public void UseTool(ToolType toolType)
        {
            ToolsHanler.UseTool(toolType, _pins);
        }

        private void SpawnPins(PinData[] pins)
        {
            ClearPins();
            var pinsCount = pins.Length;
            _pins = new Pin[pinsCount];
            for (var i = 0; i < pinsCount; i++)
            {
                _pins[i] = Instantiate(_pinPrefab, transform);
                _pins[i].Fill(pins[i]);
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
