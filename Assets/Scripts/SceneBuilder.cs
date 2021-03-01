using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneBuilder : MonoBehaviour
{
    [SerializeField] Settings settings;
    [SerializeField] List <GameObject> apples;
    [SerializeField] List<GameObject> knifes;
    int knifesCount;
    int applesCount;

    private void Awake()
    {
        GetKnifes();
        GetApples();
    }

    void GetKnifes()
    {
        System.Random rnd = new System.Random();
        var i = rnd.Next(1, 4);
        knifesCount = i;
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
            applesCount = amount;
            for(var a = 0; a < amount; a++)
            {
                apples[a].SetActive(true);
            }
        }
    }
    private void Start()
    {
        StartCoroutine(clearPool());
        IEnumerator clearPool()
        {
            yield return new WaitWhile(() => (apples.Count == applesCount & knifes.Count == knifesCount));

            for (var i =0; i < apples.Count; i++)
            {
                if (!apples[i].activeSelf)
                {
                    Destroy(apples[i].gameObject, 0.1f);
                    apples.Remove(apples[i]);
                }
            }
            
            for (var i = 0; i< knifes.Count; i++)
            {
                if (!knifes[i].activeSelf)
                {
                    Destroy(knifes[i].gameObject, 0.1f);
                    knifes.Remove(knifes[i]);
                }
               
            }
                yield return StartCoroutine(clearPool());
            
        }
    }

}
