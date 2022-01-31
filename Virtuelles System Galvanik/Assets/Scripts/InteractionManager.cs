using System;
using System.Collections;
using UnityEngine;

namespace haw.unitytutorium.w21
{
    [RequireComponent(typeof(MouseSelectionController))]
    public class InteractionManager : MonoBehaviour
    {
        [SerializeField] private UserInterface userInterface;
        [SerializeField] private string defaultErrorMsg;
        [SerializeField] private Interaction[] interactions = null;

        private MouseSelectionController mouseSelectionController;

        private Interaction currentInteraction;
        private int interactionIndex;

        private int helpCount = 0;
        private int errorCount = 0;

        private bool inputBlocked;

        private void Awake()
        {
            mouseSelectionController = GetComponent<MouseSelectionController>();
        }

        private void Start()
        {
            if (interactions == null)
            {
                Debug.LogWarning("No Interactions defined in InteractionManager.");
                return;
            }

            currentInteraction = interactions[interactionIndex];
            userInterface.DisplayInstruction(currentInteraction.Instruction);
        }

        #region Solution with Events & Delegates

        // Comment out or remove this whole region if you want to use the solution without events and delegates.

        private void OnEnable()
        {
            mouseSelectionController.OnMouseClick += OnMouseClick;
        }

        private void OnDisable()
        {
            mouseSelectionController.OnMouseClick -= OnMouseClick;
        }

        private void OnMouseClick(GameObject clickedObject)
        {
            if (!clickedObject || inputBlocked)
                return;

            CheckInteractionOrder(clickedObject);
        }

        #endregion

        private void Update()
        {
            if(inputBlocked)
                return;
            
            // Solution WITHOUT Delegates and Events
            // This handles the mouse click directly on this component.
            // On MouseClick we check if there currently is a MouseOverGameObject (the user hovers a selectable object of the radio)
            // If that's the case we call the same CheckInteractionOrder method like in the Solution with events and delegates.
            //
            // if (Input.GetMouseButtonDown(0))
            // {
            //     if (!mouseSelectionController.MouseOverGameObject)
            //         return;
            //     
            //     CheckInteractionOrder(mouseSelectionController.MouseOverGameObject);
            // }


            /*
            if (Input.GetKeyDown(KeyCode.H))
            {
                HandleHelpRequest();
            } */
        }

        private void CheckInteractionOrder(GameObject selectedGameObject)
        {
            if (interactions == null || interactionIndex < 0 || interactionIndex >= interactions.Length) {
                calculateResult();
                userInterface.DisplayResults();
                return;
            }
                

            if (selectedGameObject.Equals(interactions[interactionIndex].GameObject))
            {
                StartCoroutine(UpdateInteraction());
            }
            else
            {
                HandleError();
            }
        }

        private IEnumerator UpdateInteraction()
        {
            inputBlocked = true;
            userInterface.StopHelpAndErrorDisplay();
            
            currentInteraction.Response?.Invoke();
            yield return new WaitForSeconds(currentInteraction.duration);
            
            interactionIndex++;

            if (interactionIndex < interactions.Length)
            {
                currentInteraction = interactions[interactionIndex];
                userInterface.DisplayInstruction(currentInteraction.Instruction);
            }

            inputBlocked = false;
        }

        private void HandleError()
        {
            userInterface.DisplayErrorMessage(currentInteraction.ErrorMsg);
            errorCount += 1;
            userInterface.SetErrorCount(errorCount);
        }

        public void HandleHelpRequest()
        {
            userInterface.DisplayHelpMessage(currentInteraction.HelpMsg);
            helpCount += 1;
            userInterface.SetHelpCount(helpCount);
        }

        private void calculateResult() {
            var score = errorCount + helpCount;

            if (score == 0) 
            {
                userInterface.SetRatingResult("Sehr gut! Sie sind bereit für die reale Anwendung.");
            }
            else if (score <= 5)
            {
                userInterface.SetRatingResult(" Gut! Sie sollten aber noch ein wenig üben.");
            }
            else
            {
                userInterface.SetRatingResult(" Schauen Sie sich nochmal den Demo-Modus an.");
            }
        }
    }
}