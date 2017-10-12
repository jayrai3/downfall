/* FlashlightPickup.cs by ThunderWire Games / script for pick up flashlight */
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FlashlightPickup : MonoBehaviour {
	private Transform myTransform;
	private GameObject MessageLabel;
	
	public GameObject FlashLight;
	public GameObject UIPanel;
	
	public AudioClip pickupSound;
	public bool removeOnUse = true;
	
	public bool PickupMessage;
	public string PickupTEXT = "You have picked up a Flashlight";
	public Color PickupTextColor = Color.white;	
	
	void Start () {
		myTransform = transform;
		UIPanel.SetActive(false);
	}

    public void UseObject (){
		FlashlightScriptNEW FlashlightComponent = FlashLight.GetComponent<FlashlightScriptNEW>();
		UIPanel.SetActive(true);
		FlashlightComponent.PickedFlashlight = true;
		
		this.GetComponent<Renderer>().enabled = false;
		this.GetComponent<Collider>().enabled = false;
		
         if(pickupSound){AudioSource.PlayClipAtPoint(pickupSound, myTransform.position, 0.75f);}//Main Audio		 
		 if(PickupMessage){StartCoroutine(SendMessage());}
	}
	
 	public IEnumerator SendMessage (){
		MessageLabel = GameObject.Find("UI_MessageLabel");
		Text Message = MessageLabel.GetComponent<Text>();
		/* Message Line */
		Message.enabled = true;
		Message.color = PickupTextColor;
		Message.text = PickupTEXT;
		yield return new WaitForSeconds(3);
		Message.CrossFadeAlpha(0, 2.0f, false);
		yield return new WaitForSeconds(5);
		Message.enabled = false;
	}
}
