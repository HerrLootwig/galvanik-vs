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

            if (Input.GetKeyDown(KeyCode.H))
            {
                HandleHelpRequest();
            }
        }

        private void CheckInteractionOrder(GameObject selectedGameObject)
        {
            if (interactions == null || interactionIndex < 0 || interactionIndex >= interactions.Length)
                return;

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
        }

        private void HandleHelpRequest()
        {
            userInterface.DisplayHelpMessage(currentInteraction.HelpMsg);
        }
    }
}