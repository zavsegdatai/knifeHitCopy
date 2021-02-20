using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateStump : MonoBehaviour
{
    [SerializeField] Vector3 rotAxis;
    [SerializeField] float angle;
    void Start()
    {
        
    }


    void Update()
    {
        transform.Rotate(rotAxis, angle);
    }
}
