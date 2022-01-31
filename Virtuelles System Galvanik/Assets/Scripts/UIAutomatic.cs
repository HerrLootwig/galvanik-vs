using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIAutomatic : MonoBehaviour
{
    [Header("Text Labels")]
    [SerializeField] private TextMeshProUGUI instructionLabel = null;

    // Start is called before the first frame update
    public void DisplayInstruction(string instruction)
    {
        
        instructionLabel.SetText(instruction);
    }
}
