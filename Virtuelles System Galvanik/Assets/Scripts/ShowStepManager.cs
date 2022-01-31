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
        userInterface.DisplayInstruction(currentStep.Instruction);
    }


    public void showFirstStep()
    {
        if (workingSteps == null || stepIndex < 0 || stepIndex >= workingSteps.Length)
        {
            return;
        }
            currentStep = workingSteps[stepIndex];
            userInterface.DisplayInstruction(currentStep.Instruction);
    }

    public void showNextStep() {
        stepIndex+= 1;

        if (stepIndex < workingSteps.Length && stepIndex >= 0)
        {
            currentStep = workingSteps[stepIndex];
            userInterface.DisplayInstruction(currentStep.Instruction);
        }
    }

    public void showPreviousStep()
    {
        stepIndex-= 1;

        if (stepIndex >= 0 && stepIndex < workingSteps.Length)
        {
            currentStep = workingSteps[stepIndex];
            userInterface.DisplayInstruction(currentStep.Instruction);
        }
    }

}

