using UnityEngine;
using UnityEngine.Audio;

namespace AndreyNosov.CylinderLock.Game
{
    public class AudioManager : MonoBehaviour
    {
        [SerializeField] private AudioMixer _audioMixer;

        private const string NameMixer = "Game";
        private const int MuteValue = -80;
        private const int NormalValue = 0;

        public void SetSoundActive(bool active)
        {
            _audioMixer.SetFloat(NameMixer, active ? NormalValue : MuteValue);
        }
    }
}
