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
    [SerializeField] GameObject knifesPanel;
    [SerializeField] List<GameObject> knifes;

    private void Awake()
    {
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
