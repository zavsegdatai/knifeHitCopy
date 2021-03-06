using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[CreateAssetMenu(fileName = "settingsData", menuName = "LevelSettings", order = 51)]
public class Settings : ScriptableObject
{
    [Header ("Chance to spawn an apple in %")]
    [SerializeField] [Range (0, 100)] int chance;
    [Header("Amount of knifes to win")]
    [SerializeField] [Range(0, 10)] int amountOfKnifes;
    [Header("Amount of won levels to fight with boss")]
    [SerializeField] [Range(1, 10)] int lvlToBoss;
    [Header("Pause beetwen throwing knife")]
    [SerializeField] [Range(0.1f, 0.5f)] float pauseOnSpawn;
    public static int currentLvl = 1;
    public static int applesCount = 0;
    public static int maxLvl = 1;
    static int lvlCounter = 1;
    public static int maxKnifesFixed = 0;

    public float PauseOnSpawn { get { return pauseOnSpawn; } }
    public int ToBoss { get { return lvlToBoss; } }
    public float Chance { get { return (float) chance/100; } }
    public int AmountOfKnifes { get { return amountOfKnifes; } }
    public int LvlCount { get { return Mathf.Clamp(lvlCounter, 0, lvlToBoss); } set { lvlCounter = Mathf.Clamp(value, 0, lvlToBoss); } }

    public static void Save()
    {
        
      SaveBinary.Save(currentLvl, applesCount, maxKnifesFixed);
    }

    public static void Load()
    {
        maxLvl = SaveBinary.Load().maxLvl;
        applesCount = SaveBinary.Load().appleCount;
        maxKnifesFixed = SaveBinary.Load().maxKnifesFixed;
    }

    public static void LoadScene(int index)
    {
        SceneManager.LoadScene(index);
    }

    public static void Exit()
    {
        Application.Quit();
    }
}
