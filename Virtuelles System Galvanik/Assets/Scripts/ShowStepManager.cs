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
        LoopCurrentAnimation();
        userInterface.DisplayInstruction(currentStep.Instruction);
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

    private void LoopCurrentAnimation() 
    {
        currentStep.animator.enabled = true;
        currentStep.animator.SetTrigger(currentStep.triggerAnimation);
    }

    private void StopCurrentAnimation()
    {
        //currentStep.animator.SetTrigger(currentStep.triggerAnimation);
        currentStep.GameObject.SetActive(false);
        currentStep.GameObject.SetActive(true);
    }

    public void ShowNextStep() 
    {
        StopCurrentAnimation();
        stepIndex += 1;
        UpdateButtonState();
        if (stepIndex < workingSteps.Length && stepIndex >= 0)
        {
            currentStep = workingSteps[stepIndex];
            LoopCurrentAnimation();
            userInterface.DisplayInstruction(currentStep.Instruction);
        }
    }

    public void ShowPreviousStep()
    {
        StopCurrentAnimation();
        stepIndex -= 1;
        UpdateButtonState();
        if (stepIndex >= 0 && stepIndex < workingSteps.Length)
        {
            currentStep = workingSteps[stepIndex];
            LoopCurrentAnimation();
            userInterface.DisplayInstruction(currentStep.Instruction);
        }
    }

}

