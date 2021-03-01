using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnedKnife : MonoBehaviour
{
    RaycastHit hit;
    private void OnEnable()
    {
        GetComponent<BoxCollider>().enabled = true;
        var stump = GameObject.FindGameObjectWithTag("Stump");
        Vector3 forceVect = new Vector3(stump.transform.position.x, stump.transform.position.y, 5.105f) - transform.position;
        transform.rotation.SetLookRotation(stump.transform.position);
        GetComponent<Rigidbody>().AddForce(forceVect * 10, ForceMode.VelocityChange);
        Physics.Raycast(transform.position, forceVect, out hit);
        if (hit.collider.tag == "Apple")
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Stump")
        {
            transform.tag = "Knife";
            GetComponent<Rigidbody>().Sleep();
            transform.parent.gameObject.transform.parent = collision.gameObject.transform;
            Destroy(GetComponent<Rigidbody>());
            Destroy(this);
        }
    }
}
