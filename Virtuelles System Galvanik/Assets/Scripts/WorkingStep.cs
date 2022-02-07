using UnityEngine;
using UnityEngine.Events;


    [System.Serializable]
    public struct WorkingStep
    {
    
    public string Instruction;
    public string description;
    public GameObject clickedObject;
    public UnityEvent Response;
}

