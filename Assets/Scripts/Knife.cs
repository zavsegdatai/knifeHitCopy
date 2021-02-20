using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float power;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (transform.tag == "Knife")
        {
            GameManager.current++;
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            rb.AddForce(Vector3.up*power, ForceMode.VelocityChange);
                GameManager.preparing = false;
        }
        else
        {
                GameManager.preparing = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "Stump")
        {
            GameManager.fixedKnife++;
            rb.Sleep();
            gameObject.transform.parent = collision.gameObject.transform;
            Destroy(rb);
            Destroy(this);
        }

        if(collision.collider.tag == "Knife")
        {
            GameManager.LoadScene(1);
        }
    }
}
