using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SetDisplayValue : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI textMesh;

    float value;

    // Update is called once per frame
    void Update()
    {
        textMesh.SetText(value.ToString() + " V");
    }

    public void setFloat(float input)
    {
        value = input;
    }
}
