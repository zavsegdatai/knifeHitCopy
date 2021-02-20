using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneBuilder : MonoBehaviour
{
    [SerializeField] GameObject[] knife;
    [SerializeField] Settings settings;
    [SerializeField] GameObject[] apple;

    private void Awake()
    {
        GetKnifes();
        GetApples();
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

    void GetApples()
    {
        var i = Random.value;
        if (i < settings.Chance)
        {
            System.Random rnd = new System.Random();
            var amount = rnd.Next(1, 4);
            for(var a = 0; a < amount; a++)
            {
                apple[a].SetActive(true);
            }
        }
    }

}
