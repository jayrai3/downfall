using UnityEngine;
using System.Collections;
using UnityStandardAssets.Vehicles.Car;

public class EnterVehicle : MonoBehaviour
{
    private bool inVehicle = false;
    CarUserControl vehicleScript;
    public GameObject guiObj;
    GameObject player;
    GameObject vehicle;

    void Start()
    {
        vehicleScript = GetComponent<CarUserControl>();
        player = GameObject.FindWithTag("Player");
        vehicle = GameObject.FindWithTag("CarCamera");
        vehicle.SetActive(false);
        guiObj.SetActive(false);
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player" && inVehicle == false)
        {
            //guiObj.SetActive(true);
            if (Input.GetKey(KeyCode.E))
            {
                guiObj.SetActive(false);
                player.transform.parent = gameObject.transform;
                vehicleScript.enabled = true;
                player.SetActive(false);
                vehicle.SetActive(true);
                inVehicle = true;
            }
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            guiObj.SetActive(false);
        }
    }
    void Update()
    {
        if (inVehicle == true && Input.GetKey(KeyCode.F))
        {
            vehicleScript.enabled = false;
            player.SetActive(true);
            vehicle.SetActive(false);
            player.transform.parent = null;
            inVehicle = false;
        }
    }
}