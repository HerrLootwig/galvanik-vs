using System.Collections;
using TMPro;
using UnityEngine;

namespace haw.unitytutorium.w21
{
    public class UserInterface : MonoBehaviour
    {
        [Header("Text Labels")] [SerializeField]
        private TextMeshProUGUI instructionLabel = null;

        [SerializeField] private TextMeshProUGUI errorLabel;
        [SerializeField] private TextMeshProUGUI helpLabel;

        [SerializeField] private TextMeshProUGUI errorCountLabel = null;
        [SerializeField] private TextMeshProUGUI helpCountLabel = null;

        
        
        [SerializeField] private float helpDelayTime = 0.1f;
        [SerializeField] private float helpDisplayTime = 5.0f;
        [SerializeField] private float errorDelayTime = 0.1f;
        [SerializeField] private float errorDisplayTime = 4.0f;

        [Header("Results Panel")]
        [SerializeField] private GameObject Panel;
        [SerializeField] private TextMeshProUGUI errorResult = null;
        [SerializeField] private TextMeshProUGUI helpResult = null;
        [SerializeField] private TextMeshProUGUI ratingResult = null;
        [SerializeField] private GameObject helpButton;

        private void Start()
        {
            instructionLabel.text = "";
            errorLabel.text = "";
            helpLabel.text = "";
            
            SetErrorCount(0);
            SetHelpCount(0);
        }

        public void DisplayResults()
        {
            StartCoroutine(waiter());

            if (Panel != null) {
                errorResult.text = errorCountLabel.text;
                helpResult.text = helpCountLabel.text;
                helpButton.SetActive(false);
                Panel.SetActive(true);
            }
        }

        IEnumerator waiter()
        {
            yield return new WaitForSeconds(5);
        }

            public void HideResults()
        {
            if (Panel != null)
            {
                helpButton.SetActive(true);
                Panel.SetActive(false);
            }
        }

        public void DisplayInstruction(string instruction)
        {
            StopHelpAndErrorDisplay();
            instructionLabel.SetText(instruction);
        }

        public void DisplayHelpMessage(string helpMsg)
        {
            StopHelpAndErrorDisplay();
            StartCoroutine(DisplayWithDelayAndDuration(helpLabel, helpMsg, helpDelayTime, helpDisplayTime));
        }

        public void DisplayErrorMessage(string errorMsg)
        {
            StopHelpAndErrorDisplay();
            StartCoroutine(DisplayWithDelayAndDuration(errorLabel, errorMsg, errorDelayTime, errorDisplayTime));
        }

        public void StopHelpAndErrorDisplay()
        {
            StopAllCoroutines();
            helpLabel.SetText("");
            errorLabel.SetText("");
        }

        private IEnumerator DisplayWithDelayAndDuration(TextMeshProUGUI label, string msg, float delay, float duration)
        {
            label.text = "";
            yield return new WaitForSeconds(delay);
            label.text = msg;
            yield return new WaitForSeconds(duration);
            label.text = "";
        }

        public void SetErrorCount(int count) => errorCountLabel.text = "" + count;

        public void SetHelpCount(int count) => helpCountLabel.text = "" + count;

        public void SetRatingResult(string result) => ratingResult.text = result;
    }
}