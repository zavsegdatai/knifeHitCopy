using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] Text apples;
    [SerializeField] Text knifesMax;
    [SerializeField] Text lvlMax;

    void Start()
    {
        apples.text = SaveBinary.Load().appleCount.ToString();
        knifesMax.text =$"TotalKnifesHit: {SaveBinary.Load().maxKnifesFixed}";
        lvlMax.text = $"MaxLvl: {SaveBinary.Load().maxLvl}";
    }

}
