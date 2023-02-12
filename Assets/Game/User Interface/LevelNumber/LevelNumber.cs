using UnityEngine;
using UnityEngine.UI;

namespace AndreyNosov.CylinderLock.Game
{
    public class LevelNumber : MonoBehaviour
    {
        [SerializeField] private Text _levelNumber;

        public void Fill(int level)
        {
            _levelNumber.text = level.ToString();
        }
    }
}
