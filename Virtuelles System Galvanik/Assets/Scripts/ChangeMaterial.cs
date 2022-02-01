using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMaterial : MonoBehaviour
{
    [SerializeField] Material entfetter;
    [SerializeField] Material aktivator;
    [SerializeField] Material elektrolyt;

    public void setEntfetter()
    {
        MeshRenderer renderer = GetComponent<MeshRenderer>();
        renderer.material = entfetter;
    }

    public void setAktivator()
    {
        MeshRenderer renderer = GetComponent<MeshRenderer>();
        renderer.material = aktivator;
    }

    public void setElektrolyt()
    {
        MeshRenderer renderer = GetComponent<MeshRenderer>();
        renderer.material = elektrolyt;
    }
}
