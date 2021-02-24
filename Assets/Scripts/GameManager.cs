using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] Settings settings;
    [SerializeField] GameObject knife;
    public static int current = 0;
    public static bool preparing = true;
    public static int fixedKnife = 0;
    public static bool won = false;

    void Awake()
    {
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByBuildIndex(1))
        {
            Settings.currentLvl = 1;
            settings.LvlCount = 1;
        }
        Settings.Load();
        current = 0;
        fixedKnife = 0;

    }
    private void Start()
    {
        StartCoroutine(awaitngForWin());
        IEnumerator awaitngForWin()
        {
            yield return new WaitUntil(() => fixedKnife == settings.AmountOfKnifes);
            Settings.currentLvl++;
            Settings.Save();
            if (settings.LvlCount == 4)
                settings.LvlCount = 1;
            else
                settings.LvlCount++;
            won = true;
            yield return new WaitForSeconds(1);
            won = false;
            Settings.LoadScene(2);
            yield break;
        }
    }
    void Update()
    {
        if (current < settings.AmountOfKnifes & !preparing)
        {
            StartCoroutine(pause());
            IEnumerator pause()
            {
                yield return new WaitForSeconds(0.15f);
                Instantiate(knife, new Vector3(5, 0.2f, 5.105f), Quaternion.identity);
            }
        }
        if (Settings.currentLvl > Settings.maxLvl)
        {
            Settings.maxLvl = Settings.currentLvl;
        }
    }

}
