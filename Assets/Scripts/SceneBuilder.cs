using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneBuilder : MonoBehaviour
{
    [SerializeField] GameObject knife;
    [SerializeField] Vector3[] pos;
    GameObject knifeDub;

    private void Awake()
    {
        System.Random rnd = new System.Random();
        knifeDub = Instantiate(knife, pos[0], Quaternion.identity);
        Physics.Simulate(1f);
        Physics.autoSimulation = false;
        knifeDub.GetComponent<Rigidbody>().AddForce(Vector3.up * 20, ForceMode.VelocityChange);
        Physics.autoSimulation = true;
    }

}
