using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] Settings settings;
    [SerializeField] float power;
    [SerializeField] ParticleSystem particles;
    GameObject stump;

    private void Awake()
    {
        GameManager.preparing = true;
    }
    void Start()
    {
        Vibration.Init();
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

            if (Input.GetMouseButtonDown(0))
            {
                GetComponentInParent<AudioSource>().Play();
                GameManager.preparing = false;
                rb.AddForce(forceVect * power, ForceMode.VelocityChange);
                GetComponent<BoxCollider>().enabled = true;
            }
            else
            {
                GameManager.preparing = true;
            }

    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.collider.tag == "Stump")
        {
            particles.Play();
            Vibration.Vibrate(100);
            GameManager.fixedKnife++;
            rb.Sleep();
            transform.parent.gameObject.transform.parent = collision.gameObject.transform;
            GameManager.knifeCounter++;
            Destroy(rb);
            collision.collider.GetComponent<AudioSource>().Play();
            Destroy(this);
        }

        if(collision.collider.tag == "Knife")
        {
            Settings.Save();
            Settings.LoadScene(4);
        }
        if(collision.collider.tag == "Apple")
        {
            collision.gameObject.SendMessage("DestroyApple");
        }
    }
}
