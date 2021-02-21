using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "settingsData", menuName = "LevelSettings", order = 51)]
public class Settings : ScriptableObject
{
    [Header ("Chance to spawn an apple in %")]
    [SerializeField] [Range (0, 100)] int chance;
    [SerializeField] [Range(0, 10)] int amountOfKnifes;
    public static int applesCount = 0;
    public float Chance { get { return (float) chance/100; } }
    public int AmountOfKnifes { get { return amountOfKnifes; } }

}
