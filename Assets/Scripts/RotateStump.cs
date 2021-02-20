using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateStump : MonoBehaviour
{
    [SerializeField] Vector3 rotAxis;
    [SerializeField] float angle;
    void Awake()
    {
        transform.GetChild(0).gameObject.SetActive(false);
    }


    void Update()
    {
        transform.Rotate(rotAxis, angle);

        if (GameManager.won)
        {
            transform.GetChild(0).gameObject.SetActive(true);
            transform.GetChild(0).gameObject.transform.parent = null;
            gameObject.SetActive(false);
        }

    }
    
}
