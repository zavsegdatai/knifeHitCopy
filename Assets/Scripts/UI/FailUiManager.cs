using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FailUiManager : MonoBehaviour
{

    void Awake()
    {
        if (Screen.height <= 1280)
        {
            gameObject.GetComponent<RectTransform>().localScale = new Vector3(0.5f, 0.5f, 0.5f);
        }
    }


}
