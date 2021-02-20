using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StumpDiyng : MonoBehaviour
{
    Rigidbody rb;
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
       
    }

    private void OnEnable()
    {
        rb.AddExplosionForce(300, transform.position, 5);
        rb.AddTorque(Vector3.right, ForceMode.Impulse);
    }

}
