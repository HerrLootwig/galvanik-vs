using System;
using System.Collections;
using UnityEngine;

public class ShowStepManager : MonoBehaviour
{

    [SerializeField] private UIAutomatic userInterface;
    [SerializeField] private WorkingStep[] workingSteps = null;

    private WorkingStep currentStep;
    private int stepIndex = 0;

    private void Start()
    {
        currentStep = workingSteps[stepIndex];
        UpdateButtonState();

        userInterface.DisplayInstruction(currentStep.Instruction);
        userInterface.DisplayDescription(currentStep.description);
        //LoopCurrentAnimation();
    }

    private void UpdateButtonState()
    {
        if (stepIndex == 0)
        {
            userInterface.HidePreviousButton();
        }
        else if (stepIndex == (workingSteps.Length - 1))
        {
            userInterface.HideNextButton();
        }
        else
        {
            userInterface.DisplayButtons();
        }
    }

    /*
    private void LoopCurrentAnimation()
    {
        currentStep.animator.SetTrigger(currentStep.triggerAnimation);
    }
    */
    

    public void ShowNextStep()
    {
        stepIndex += 1;
        UpdateButtonState();
        if (stepIndex < workingSteps.Length && stepIndex >= 0)
        {
            currentStep = workingSteps[stepIndex];
            userInterface.DisplayInstruction(currentStep.Instruction);
            userInterface.DisplayDescription(currentStep.description);
            currentStep.Response?.Invoke();
            //LoopCurrentAnimation();
        }
    }

    public void ShowPreviousStep()
    {
        stepIndex -= 1;
        UpdateButtonState();
        if (stepIndex >= 0 && stepIndex < workingSteps.Length)
        {
            currentStep = workingSteps[stepIndex];
            userInterface.DisplayInstruction(currentStep.Instruction);
            userInterface.DisplayDescription(currentStep.description);
            currentStep.Response?.Invoke();
            //LoopCurrentAnimation();
        }
    }

}
