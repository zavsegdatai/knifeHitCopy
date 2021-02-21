using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] Text applesCounter;

    // Update is called once per frame
    void Update()
    {
        applesCounter.text = $"Apples collected: {Settings.applesCount}";
    }
}
