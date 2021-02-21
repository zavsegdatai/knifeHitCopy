using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float power;
    GameObject stump;

    void Start()
    {
        stump = GameObject.FindGameObjectWithTag("Stump");
        rb = GetComponent<Rigidbody>();
        if (transform.tag == "Knife")
        {
            GameManager.current++;
        }
    }

    void Update()
    {
        Vector3 forceVect = new Vector3(stump.transform.position.x, stump.transform.position.y, 5.105f) - transform.position;
        transform.rotation.SetLookRotation(stump.transform.position);
        if (Input.GetMouseButtonDown(0))
        {
            rb.AddForce(forceVect*power, ForceMode.VelocityChange);
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
            Vibration.Vibrate(400);
            GameManager.fixedKnife++;
            rb.Sleep();
            transform.parent.gameObject.transform.parent = collision.gameObject.transform;
            Destroy(rb);
            Destroy(this);
        }

        if(collision.collider.tag == "Knife")
        {
            GameManager.LoadScene(2);
        }
        if(collision.collider.tag == "Apple")
        {
            collision.gameObject.SendMessage("DestroyApple");
        }
    }
}
