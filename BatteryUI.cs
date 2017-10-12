/* BatteryNGUI.cs by ThunderWire Games / script for Battery UI */
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BatteryUI : MonoBehaviour {
     public GameObject BatteryLabel;
	 public AudioClip ReloadBatteriesSound;
	 public KeyCode BatteryReloadKey = KeyCode.B;
	 
	 public float Batteries;
	 private float MinBatteries = 0.0f;
	 private float MaxBatteries = 0.20f;
	 private float BatteryDeduct = 1.0f;
	 private Transform myTransform;	
	 
	 public bool EnableBattery;
	 

	void Start () {
		myTransform = transform;//manually set transform for efficiency
	}
	 
	// Update is called once per frame
	void Update () {
	//Debug.Log ("Batteries: " + Batteries.ToString() );
	if(Input.GetKeyDown(BatteryReloadKey) && Batteries > 0 && Batteries <= 0.20f) {
	    FlashlightScriptNEW FlashlightScriptComponent = this.GetComponent<FlashlightScriptNEW>();
		
	if(FlashlightScriptComponent.batteryPercentage < 90.0f){
		FlashlightScriptComponent.batteryPercentage = 100;
		Batteries -= BatteryDeduct * 0.01f;
		if(ReloadBatteriesSound){AudioSource.PlayClipAtPoint(ReloadBatteriesSound, myTransform.position, 0.75f);}
		}
     }

	 	Text Battery = BatteryLabel.GetComponent<Text>();

		Batteries = Mathf.Clamp(Batteries, 0.0f, 0.20f);
		
	    if (Batteries <= MinBatteries)
			{
			     Batteries = MinBatteries;
				 Battery.text = "0 / 20";
				 EnableBattery = true;
			}
		
	    else if (Batteries <= 0.01f && Batteries > 0)
			{
				 Battery.text = "1 / 20";
				 EnableBattery = true;
			}				
		
	    else if (Batteries <= 0.02f && Batteries > 0.01f)
			{
				 Battery.text = "2 / 20";
				 EnableBattery = true;
			}				
		
	    else if (Batteries <= 0.03f && Batteries > 0.02f)
			{
				 Battery.text = "3 / 20";
				 EnableBattery = true;
			}				
		
	    else if (Batteries <= 0.04f && Batteries > 0.03f)
			{
				 Battery.text = "4 / 20";
				 EnableBattery = true;
			}				
		
	    else if (Batteries <= 0.05f && Batteries > 0.04f)
			{
				 Battery.text = "5 / 20";
				 EnableBattery = true;
			}

        else if (Batteries <= 0.06f && Batteries > 0.05f)
        {
            Battery.text = "6 / 20";
            EnableBattery = true;
        }

        else if (Batteries <= 0.07f && Batteries > 0.06f)
        {
            Battery.text = "7 / 20";
            EnableBattery = true;
        }

        else if (Batteries <= 0.08f && Batteries > 0.07f)
        {
            Battery.text = "8 / 20";
            EnableBattery = true;
        }

        else if (Batteries <= 0.09f && Batteries > 0.08f)
        {
            Battery.text = "9 / 20";
            EnableBattery = true;
        }

        else if (Batteries <= 0.10f && Batteries > 0.09f)
        {
            Battery.text = "10 / 20";
            EnableBattery = true;
        }

        else if (Batteries <= 0.11f && Batteries > 0.10f)
        {
            Battery.text = "11 / 20";
            EnableBattery = true;
        }

        else if (Batteries <= 0.12f && Batteries > 0.11f)
        {
            Battery.text = "12 / 20";
            EnableBattery = true;
        }

        else if (Batteries <= 0.13f && Batteries > 0.12f)
        {
            Battery.text = "13 / 20";
            EnableBattery = true;
        }

        else if (Batteries <= 0.14f && Batteries > 0.13f)
        {
            Battery.text = "14 / 20";
            EnableBattery = true;
        }

        else if (Batteries <= 0.15f && Batteries > 0.14f)
        {
            Battery.text = "15 / 20";
            EnableBattery = true;
        }

        else if (Batteries <= 0.16f && Batteries > 0.15f)
        {
            Battery.text = "16 / 20";
            EnableBattery = true;
        }

        else if (Batteries <= 0.17f && Batteries > 0.16f)
        {
            Battery.text = "17 / 20";
            EnableBattery = true;
        }

        else if (Batteries <= 0.18f && Batteries > 0.17f)
        {
            Battery.text = "18 / 20";
            EnableBattery = true;
        }

        else if (Batteries <= 0.19f && Batteries > 0.18f)
        {
            Battery.text = "19 / 20";
            EnableBattery = true;
        }

        else if (Batteries <= 0.20f && Batteries > 0.19f)
        {
            Battery.text = "20 / 20";
            EnableBattery = true;
        }

        //Setting for a max batteries
        else if(Batteries > 0.20f)
		   {
              Batteries = MaxBatteries;
			  EnableBattery = false;
           }
  }
}