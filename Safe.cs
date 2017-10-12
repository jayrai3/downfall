using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class Safe : MonoBehaviour {

    public Canvas safeCanvas;
    public GameObject playerObject;

    private int number01 = 1;
    private int number02 = 1;
    private int number03 = 1;

    public Text textNumber01;
    public Text textNumber02;
    public Text textNumber03;

    public bool opened;

    public float doorOpenAngle = 150.0f;
    public float smooth = 2.0f;

    void Start()
    {
        safeCanvas.enabled = false;
        opened = false;   
    }

    public void showSafeCanvas()
    {
        safeCanvas.enabled = true;
        playerObject.GetComponent<FirstPersonController>().enabled = false;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

	// Update is called once per frame
	void Update ()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            playerObject.GetComponent<FirstPersonController>().enabled = true;

            safeCanvas.enabled = false;
        }

        if(number01 == 1 && number02 == 9 && number03 == 4)
        {
            opened = true;
        }

        if(opened == true)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            playerObject.GetComponent<FirstPersonController>().enabled = true;
            safeCanvas.enabled = false;

            gameObject.layer = 0;

            UnlockSafe(); 
        }
	}

    void UnlockSafe()
    {
        //Open the door here.
        Quaternion targetRotationOpen = Quaternion.Euler(0, doorOpenAngle, 0);
        transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotationOpen, smooth * Time.deltaTime);
    }

    public void IncreaseNumber(int _number)
    {
        if(_number == 1)
        {
            number01++;
            textNumber01.text = number01.ToString();

            if(number01 > 9)
            {
                number01 = 1;
                textNumber01.text = number01.ToString();
            }
        }

        else if(_number == 2)
        {
            number02++;
            textNumber02.text = number02.ToString();

            if (number02 > 9)
            {
                number02 = 1;
                textNumber02.text = number02.ToString();
            }
        }

        else if (_number == 3)
        {
            number03++;
            textNumber03.text = number03.ToString();

            if (number03 > 9)
            {
                number03 = 1;
                textNumber03.text = number03.ToString();
            }
        }
    }

    public void DecreaseNumber(int _number)
    {
        if (_number == 1)
        {
            number01--;
            textNumber01.text = number01.ToString();

            if (number01 < 1)
            {
                number01 = 9;
                textNumber01.text = number01.ToString();
            }
        }

        else if (_number == 2)
        {
            number02--;
            textNumber02.text = number02.ToString();

            if (number02 < 1)
            {
                number02 = 9;
                textNumber02.text = number02.ToString();
            }
        }

        else if (_number == 3)
        {
            number03--;
            textNumber03.text = number03.ToString();

            if (number03 < 1)
            {
                number03 = 9;
                textNumber03.text = number03.ToString();
            }
        }
    }
}
