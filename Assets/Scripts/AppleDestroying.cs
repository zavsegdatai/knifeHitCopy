using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleDestroying : MonoBehaviour
{

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Knife")
        {
            Settings.applesCount++;
            Settings.Save();
            Destroy(GetComponent<SphereCollider>());
            Destroy(GetComponent<Rigidbody>());
            var tmp = GetComponentsInChildren<Rigidbody>();
            for (int i = 0; i < tmp.Length; i++)
            {
                tmp[i].isKinematic = false;
                tmp[i].useGravity = true;
                tmp[i].AddExplosionForce(50, transform.position, 5);
                tmp[i].AddRelativeTorque(Vector3.left, ForceMode.Impulse);
            }
            Destroy(gameObject,1);
        }
    }
    
    
}
