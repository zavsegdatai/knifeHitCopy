using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Globalization;

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
        Notifications.CancelNotification();
        preparing = true;
        current = 0;
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByBuildIndex(1))
        {
            knifeCounter = 0;
            Settings.currentLvl = 1;
            settings.LvlCount = 1;
        }
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByBuildIndex(3))
            settings.LvlCount = 0;
        Settings.Load();
    }

    IEnumerator awaitngForWin()
    {
        yield return new WaitUntil(() => fixedKnife == settings.AmountOfKnifes);
        Settings.currentLvl++;
        Settings.Save();
        StopCoroutine(PrepareKnife());
        if (settings.LvlCount == settings.ToBoss)
            settings.LvlCount = 1;
        else
            settings.LvlCount++;
        won = true;
        yield return new WaitForSeconds(1);
        if ((Settings.currentLvl % settings.ToBoss) == 1)
        {
            Settings.LoadScene(3);
        }
        else
        {
            Settings.LoadScene(2);
        }
        preparing = true;
        won = false;
    }

    IEnumerator PrepareKnife()
    {
        yield return null;
        yield return new WaitUntil(() => (current <= settings.AmountOfKnifes - 1 & !preparing));
        yield return new WaitForSeconds(settings.PauseOnSpawn);
        Instantiate(knife, new Vector3(5, 0.2f, 5.105f), Quaternion.identity);
        yield return StartCoroutine(PrepareKnife());
    }

    private void Start()
    {
        fixedKnife = 0;
        StartCoroutine(awaitngForWin());
        StartCoroutine(PrepareKnife());
        Instantiate(knife, new Vector3(5, 0.2f, 5.105f), Quaternion.identity);
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

    private void OnApplicationPause(bool pause)
    {
        PlayerPrefs.SetString("TimeOnExit", System.DateTime.Now.ToString("u", CultureInfo.InvariantCulture));
        Notifications.SendNotification();
    }

}
