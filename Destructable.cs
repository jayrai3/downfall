using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructable : MonoBehaviour
{
    public GameObject debrisPrefab;
    public Transform explosionForceLocation;

    void OnMouseDown()
    {
        if (debrisPrefab)
        {
            Instantiate(debrisPrefab, transform.position, transform.rotation);
        }

        Destroy(gameObject);

        foreach(Transform t in transform)
        {
            Rigidbody rb1;
            rb1 = t.GetComponent<Rigidbody>();

            rb1.AddExplosionForce(40, explosionForceLocation.transform.position, 20, 2, ForceMode.Impulse);
        }
               
    }
	
}
