using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interact : MonoBehaviour {

    public string interactButton;
    public float interactDistance = 3.0f; //Distance able to interact with object.
    public LayerMask interactLayer;

    public Image interactIcon; //Hand icon so user knows what they can interact with.

    public bool isInteracting;


    // Use this for initialization
    void Start ()
    {
        if(interactIcon != null)
        {
            interactIcon.enabled = false;
        }       
	}
	
	// Update is called once per frame
	void Update ()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        //Check for hits in the interact layer.
        if (Physics.Raycast(ray, out hit, interactDistance, interactLayer))
        {
            if(isInteracting == false)
            {
                if(interactIcon != null)
                {
                    interactIcon.enabled = true;
                }

                //When press the interact button, open the door. 
                if (Input.GetButtonDown(interactButton))
                {
                    if (hit.collider.CompareTag("Door"))
                    {
                        hit.collider.GetComponent<DoorScript>().ChangeDoorState();
                    }

                    else if (hit.collider.CompareTag("Gate"))
                    {
                        hit.collider.GetComponent<Gate>().ChangeDoorState();
                    }

                    else if (hit.collider.CompareTag("Safe"))
                    {
                        hit.collider.GetComponent<Safe>().showSafeCanvas();
                    }
                    
                    else if (hit.collider.CompareTag("Note"))
                    {
                        hit.collider.GetComponent<Note>().ShowNoteImage();
                    }
                   
                    else if (hit.collider.CompareTag("Document"))
                    {
                        hit.collider.GetComponent<Documents>().ShowDocumentImage();
                    }

                    else if (hit.collider.CompareTag("Key"))
                    {
                        hit.collider.GetComponent<Key>().unlockGate();
                    }

                    else if (hit.collider.CompareTag("Arcade"))
                    {
                        hit.collider.GetComponent<ArcadePlay>().PlayArcadeGame();
                    }
                }
            }
        }
        else
        {
            interactIcon.enabled = false; 
        }	
	}
}
