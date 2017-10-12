using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class displayUI : MonoBehaviour
{
    public GameObject text1;

    void Start()
    {
        text1.active = false;    
    }

    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        text1.active = true;    
    }

    private void OnTriggerExit(Collider other)
    {
        text1.active = false;
    }
}
