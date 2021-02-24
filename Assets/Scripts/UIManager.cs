using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] Text applesCounter;
    [SerializeField] Text currentLevel;
    [SerializeField] Text record;
    [SerializeField] Image[] lvlImg;
    [SerializeField] Settings settings;
    [SerializeField] Color newColor;

    private void Start()
    {
        if (settings.LvlCount <= 4)
        {
            for (int i = 0; i < settings.LvlCount; i++)
            {
                lvlImg[i].color = newColor;
            }
        }
        currentLevel.text = Settings.currentLvl.ToString();
        record.text = Settings.maxLvl.ToString();
    }
    void Update()
    {
        applesCounter.text = Settings.applesCount.ToString();
    }
}
