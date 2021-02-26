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
    public static int knifeCounter = 0;

    void Awake()
    {
        preparing = true;
        current = 0;
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByBuildIndex(1))
        {
            knifeCounter = 0;
            Settings.currentLvl = 1;
            settings.LvlCount = 1;
        }
        Settings.Load();
    }

    private void Start()
    {
        fixedKnife = 0;
        Instantiate(knife, new Vector3(5, 0.2f, 5.105f), Quaternion.identity);
        StartCoroutine(awaitngForWin());
        IEnumerator awaitngForWin()
        {
            yield return new WaitUntil(() => fixedKnife == settings.AmountOfKnifes);
            Settings.currentLvl++;
            Settings.Save();
            StopCoroutine(PrepareKnife());
            if (settings.LvlCount == 4)
                settings.LvlCount = 1;
            else
                settings.LvlCount++;
            won = true;
            yield return new WaitForSeconds(1);
            Settings.LoadScene(2);
            preparing = true;
            won = false;
        }
        StartCoroutine(PrepareKnife());
        IEnumerator PrepareKnife()
        {
            yield return null;
            yield return new WaitUntil(() => (current <= settings.AmountOfKnifes-1 & !preparing));
            yield return new WaitForSecondsRealtime(settings.PauseOnSpawn);
            Instantiate(knife, new Vector3(5, 0.2f, 5.105f), Quaternion.identity);
            yield return StartCoroutine(PrepareKnife());
        }
    }
    void Update()
    {
        if (Settings.currentLvl > Settings.maxLvl)
        {
            Settings.maxLvl = Settings.currentLvl;
        }
        if(Settings.maxKnifesFixed < knifeCounter)
        {
            Settings.maxKnifesFixed = knifeCounter;
        }
    }

}
