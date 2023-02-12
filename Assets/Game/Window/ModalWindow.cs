using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

namespace AndreyNosov.CylinderLock.Game
{
    public class ModalWindow : MonoBehaviour
    {
        public Action OnClickTrue;
        public Action OnClickFalse;

        [SerializeField] private Text _lable;
        [SerializeField] private Text _description;

        [Header("Buttons")]
        [SerializeField] private Button _false;
        [SerializeField] private Text _falseButtonText;
        [SerializeField] private Button _true;
        [SerializeField] private Text _trueButtonText;

        private const float speedTextDescription = 0.04f;

        public void Fill(string lable, string description, string falseText, string trueText)
        {
            _lable.text = "";
            _description.text = "";
            _falseButtonText.text = "";
            _trueButtonText.text = "";
            _false.gameObject.SetActive(false);
            _true.gameObject.SetActive(false);
            gameObject.SetActive(true);
            StartCoroutine(GradualFilling(lable, description, falseText, trueText));
            _false.onClick.AddListener(ClickFalseHandler);
            _true.onClick.AddListener(ClickTrueHandler);
        }

        private IEnumerator GradualFilling(string lable, string description, string falseText, string trueText)
        {
            _lable.text = lable;
            yield return new WaitForFixedUpdate();
            var textDescription = "";
            foreach (var c in description)
            {
                textDescription += c;
                yield return new WaitForSeconds(speedTextDescription);
                _description.text = textDescription;
            }

            _falseButtonText.text = falseText;
            _trueButtonText.text = trueText;
            _false.gameObject.SetActive(true);
            _true.gameObject.SetActive(true);
        }

        private void ClickTrueHandler()
        {
            OnClickTrue?.Invoke();
        }

        private void ClickFalseHandler()
        {
            OnClickTrue?.Invoke();
        }

        public void Close()
        {
            Destroy(gameObject);
        }
    }
}
