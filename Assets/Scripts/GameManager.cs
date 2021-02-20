using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] Settings settings;
    public static int current = 0;
    [SerializeField] GameObject knife;
    public static bool preparing = true;
    public static int fixedKnife = 0;
    public static bool won = false;

    void Awake()
    {
        current = 0;
        fixedKnife = 0;
    }

    void Update()
    {
        Debug.Log(current + " " + preparing + " fixedKnife " + fixedKnife);
        if(current < settings.AmountOfKnifes & !preparing)
        {
            StartCoroutine(pause());
            IEnumerator pause()
            {
                yield return new WaitForSeconds(0.1f);
                Instantiate(knife, new Vector3(5, 0.2f, 5), Quaternion.identity);
            }
        }
        if(fixedKnife == settings.AmountOfKnifes)
        {
            won = true;
            StartCoroutine(pause());
            Debug.Log("Won!");
            IEnumerator pause()
            {
                yield return new WaitForSeconds(2);
                won = false;
                SceneManager.LoadScene(2);
            }
        }
    }
    
    public static void LoadScene(int index)
    {
        SceneManager.LoadScene(index);
    }

    
}
