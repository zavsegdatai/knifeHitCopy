using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] Image appleImg;
    [SerializeField] Text apples;
    [SerializeField] Text knifesMax;
    [SerializeField] Text lvlMax;
    [SerializeField] Text logo;
    [SerializeField] Button play;

    private void Awake()
    {
        if(Screen.height < 2960 & Screen.height >= 2560)
        {
            appleImg.rectTransform.localPosition = new Vector3(425, 1155, 0);
            lvlMax.rectTransform.localPosition = new Vector3(-356, 1140, 0);
            knifesMax.rectTransform.localPosition = new Vector3(-319, 1016, 0);
        }
        if(Screen.height < 2560 & Screen.height >= 2160)
        {
            appleImg.rectTransform.localPosition = new Vector3(297, 853, 0);
            lvlMax.rectTransform.localPosition = new Vector3(-155, 845, 0);
            knifesMax.rectTransform.localPosition = new Vector3(-118, 721, 0);
            knifesMax.fontSize = 62;
            lvlMax.fontSize = 80;
            logo.fontSize = 150;
            play.GetComponent<RectTransform>().localScale = new Vector3(4, 4, 1);
        }
        if(Screen.height < 1920 & Screen.height >= 1280)
        {
            appleImg.rectTransform.localPosition = new Vector3(183, 537, 0);
            lvlMax.rectTransform.localPosition = new Vector3(6, 502, 0);
            knifesMax.rectTransform.localPosition = new Vector3(36, 439, 0);
            knifesMax.fontSize = 42;
            lvlMax.fontSize = 60;
            logo.fontSize = 110;
            appleImg.rectTransform.sizeDelta = new Vector2(50, 50);
            apples.fontSize = 40;
            apples.rectTransform.localPosition = new Vector3(118, -2, 0);
            play.GetComponent<RectTransform>().localScale = new Vector3(3, 3, 1);
        }
        if(Screen.height < 1280 & Screen.height >= 800)
        {
            appleImg.rectTransform.localPosition = new Vector3(120, 351, 0);
            lvlMax.rectTransform.localPosition = new Vector3(102, 305, 0);
            knifesMax.rectTransform.localPosition = new Vector3(133, 273, 0);
            knifesMax.fontSize = 30;
            lvlMax.fontSize = 40;
            logo.fontSize = 70;
            logo.rectTransform.localPosition = new Vector3(0, -35, 0);
            appleImg.rectTransform.sizeDelta = new Vector2(30, 30);
            apples.fontSize = 30;
            apples.rectTransform.localPosition = new Vector3(96, -1, 0);
            play.GetComponent<RectTransform>().localScale = new Vector3(2, 2, 1);
        }
    }
    void Start()
    {
        apples.text = SaveBinary.Load().appleCount.ToString();
        knifesMax.text =$"TotalKnifesHit: {SaveBinary.Load().maxKnifesFixed}";
        lvlMax.text = $"MaxLvl: {SaveBinary.Load().maxLvl}";
    }

}
