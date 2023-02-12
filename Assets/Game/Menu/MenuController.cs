using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace AndreyNosov.CylinderLock.Menu
{
    public class MenuController : MonoBehaviour
    {
        [SerializeField] private Button _play;
        [SerializeField] private Button _close;

        private const string NameGameScene = "Game";

        private void Awake()
        {
            _play.onClick.AddListener(ClickPlayHandler);
            _close.onClick.AddListener(ClickExitHandler);
        }

        private void ClickPlayHandler()
        {
            SceneManager.LoadScene(NameGameScene);
        }

        private void ClickExitHandler()
        {
            Application.Quit();
        }
    }
}
