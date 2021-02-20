using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneBuilder : MonoBehaviour
{
    [SerializeField] GameObject[] knife;

    private void Awake()
    {
        GetKnifes();
        Physics.Simulate(1f);
        Physics.autoSimulation = false;
        Physics.autoSimulation = true;
    }

    void GetKnifes()
    {
        System.Random rnd = new System.Random();
        var i = rnd.Next(3, 4);
        for (int tmp = 0; tmp < i; tmp++)
        {
            knife[rnd.Next(0, knife.Length)].SetActive(true);
        }
    }
}
