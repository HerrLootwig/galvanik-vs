using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{

    public enum RotationAxis
    {
        X,
        Y,
        Z
    }

    [SerializeField] private RotationAxis axis;
    private Vector3 axisVector;

    [SerializeField] private float angle;


    public float Angle => angle;

    // Start is called before the first frame update
    void Start()
    {
        axisVector = axis switch
        {
            RotationAxis.X => Vector3.right,
            RotationAxis.Y =>
                // axisVector = transform.up;
                Vector3.up,
            RotationAxis.Z =>
                // axisVector = transform.forward;
                Vector3.forward,
            _ => axisVector
        };

    }

    // Update is called once per frame
    void Update()
    {
        Rotate();
    }

    public void Rotate() => Rotate(angle);

    public void Rotate(float rotationAngle)
    {
        transform.Rotate(axisVector, rotationAngle);
    }

}
