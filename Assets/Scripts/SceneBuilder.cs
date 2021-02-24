using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneBuilder : MonoBehaviour
{
    [SerializeField] Settings settings;
    [SerializeField] List <GameObject> apples;
    [SerializeField] List<GameObject> knifes;

    private void Awake()
    {
        GetKnifes();
        GetApples();
    }

    void GetKnifes()
    {
        System.Random rnd = new System.Random();
        var i = rnd.Next(1, 4);
        for (int tmp = 0; tmp < i; tmp++)
        {
            knifes[rnd.Next(0, knifes.Count)].SetActive(true);
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
                apples[a].SetActive(true);
            }
        }
    }

}
