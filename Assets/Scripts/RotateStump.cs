using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateStump : MonoBehaviour
{
    enum Mode
    {
        simpleRotating,
        boostRotating,
        reverseRotating,
        dragRotation,
    }

    [SerializeField] Vector3 rotAxis;
    [SerializeField] float speed;
    [SerializeField] float newSpeed;
    [SerializeField] float timeToAction;
    [SerializeField] float timeToreturnValues;
    Mode mode;
    float startSpeed;

    void Awake()
    {
        System.Random rnd = new System.Random();
        var i = (Mode)rnd.Next(0, 4);
        startSpeed = speed;
        transform.GetChild(0).gameObject.SetActive(false);
        StartCoroutine(modeManager(i));
        IEnumerator modeManager(Mode mode)
        {
            if(mode == Mode.reverseRotating)
            {
                speed = -speed;
                yield break;
            }
            if(mode == Mode.boostRotating)
            {
                yield return new WaitForSeconds(timeToAction);
                speed = newSpeed;
                yield return new WaitForSeconds(timeToreturnValues);
                speed = startSpeed;
                yield return StartCoroutine(modeManager(i));
            }
            if(mode == Mode.dragRotation)
            {
                int a;
                yield return new WaitForSeconds(timeToAction);
                if (speed > 0)
                    a = -1;
                else
                    a = 1;
                speed = 0;
                yield return new WaitForSeconds(0.5f);
                speed = startSpeed * 1.5f * a;
                yield return StartCoroutine(modeManager(i));
            }
            yield break;
        }
    }

    
    void Update()
    {
       transform.Rotate(rotAxis, Time.deltaTime * speed);

        if (GameManager.won)
        {
            transform.GetChild(0).gameObject.SetActive(true);
            transform.GetChild(0).gameObject.transform.parent = null;
            gameObject.SetActive(false);
        }

    }
    
}
