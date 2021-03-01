using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] Text applesCounter;
    [SerializeField] Image appleImg;
    [SerializeField] Text currentLevel;
    [SerializeField] Text record;
    [SerializeField] Image[] lvlImg;
    [SerializeField] Settings settings;
    [SerializeField] Color newColor;
    [SerializeField] GameObject knifesPanel;
    [SerializeField] List<GameObject> knifes;

    private void Awake()
    {
        if (Screen.height < 2960 & Screen.height >= 2560)
        {
            appleImg.rectTransform.localPosition = new Vector3(491, 1220, 0);
            record.rectTransform.localPosition = new Vector3(-501, 1215, 0);
            currentLevel.rectTransform.localPosition = new Vector3(-16, 1082, 0);
            knifesPanel.GetComponent<RectTransform>().position = new Vector3(108, 453, 0);
            knifesPanel.GetComponent<RectTransform>().localScale = new Vector3(0.9f, 0.9f, 0.9f);
        }
        if (Screen.height < 2560 & Screen.height >= 2160)
        {
            appleImg.rectTransform.localPosition = new Vector3(288, 986, 0);
            appleImg.rectTransform.localScale = new Vector3(0.9f, 0.9f, 0.9f);
            record.rectTransform.localPosition = new Vector3(-467, 970, 0);
            currentLevel.rectTransform.localPosition = new Vector3(-16, 856, 0);
            currentLevel.rectTransform.localScale = new Vector3(0.8f, 0.8f, 0.8f);
            knifesPanel.GetComponent<RectTransform>().position = new Vector3(108, 453, 0);
            knifesPanel.GetComponent<RectTransform>().localScale = new Vector3(0.8f, 0.8f, 0.8f);

        }
        if (Screen.height <= 1920 & Screen.height >= 1080)
        {
            appleImg.rectTransform.localPosition = new Vector3(356, 863, 0);
            appleImg.rectTransform.localScale = new Vector3(0.8f, 0.8f, 0.8f);
            record.rectTransform.localPosition = new Vector3(-370, 837, 0);
            currentLevel.rectTransform.localPosition = new Vector3(-16, 804, 0);
            currentLevel.rectTransform.localScale = new Vector3(0.8f, 0.8f, 0.8f);
            knifesPanel.GetComponent<RectTransform>().position = new Vector3(107, 330, 0);
            knifesPanel.GetComponent<RectTransform>().localScale = new Vector3(0.6f, 0.6f, 0.6f);

        }
        if (Screen.height <= 1280 & Screen.height >= 800)
        {
            appleImg.rectTransform.localPosition = new Vector3(186, 576, 0);
            appleImg.rectTransform.localScale = new Vector3(0.6f, 0.6f, 0.6f);
            record.rectTransform.localPosition = new Vector3(-263, 565, 0);
            record.rectTransform.localScale = new Vector3(0.6f, 0.6f, 0.6f);
            currentLevel.rectTransform.localPosition = new Vector3(-16, 508, 0);
            currentLevel.rectTransform.localScale = new Vector3(0.6f, 0.6f, 0.6f);
            knifesPanel.GetComponent<RectTransform>().position = new Vector3(88, 179, 0);
            knifesPanel.GetComponent<RectTransform>().localScale = new Vector3(0.4f, 0.4f, 0.4f);

        }
        if(Screen.height<1280 & Screen.height > 800)
        {
            appleImg.rectTransform.localPosition = new Vector3(162, 343, 0);
            appleImg.rectTransform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
            record.rectTransform.localPosition = new Vector3(-166, 337, 0);
            record.rectTransform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
            currentLevel.rectTransform.localPosition = new Vector3(-6, 304, 0);
            currentLevel.rectTransform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
            knifesPanel.GetComponent<RectTransform>().position = new Vector3(54, 82, 0);
            knifesPanel.GetComponent<RectTransform>().localScale = new Vector3(0.2f, 0.2f, 0.2f);
        }
        StartCoroutine(fillKnifes(settings.AmountOfKnifes));
        IEnumerator fillKnifes(int amount)
        {
            for (int i = 0; i < amount; i++)
            {
                yield return new WaitUntil(() => i < amount);
                knifes[i].SetActive(true);
            }
        }
    }
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
        
    }
    void Update()
    {
        applesCounter.text = Settings.applesCount.ToString();
        if(GameManager.fixedKnife > 0)
            knifes[GameManager.fixedKnife-1].transform.GetChild(1).gameObject.SetActive(false);
        record.text = GameManager.knifeCounter.ToString();
    }

}
