using UnityEngine;
using System.Collections;

namespace UnityStandardAssets.ImageEffects
{
    public class JumpScareSystem : MonoBehaviour
    {

        public GameObject ScareObject;
        public string ScareObjectAnim;
        public string JumscareAnim;
        public AudioClip ScareSound;
        public MotionBlur Sanity;

        void Start()
        {
            ScareObject.GetComponent<Animation>().Stop(ScareObjectAnim);             //stop looping (walk, run or any) animation on scare object
        }

        public void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "Player")
            {
                ScareObject.GetComponent<Animation>().Play(ScareObjectAnim);            //play stopped scare object animation
                GetComponent<Animation>().Play(JumscareAnim);       //play jumpscare animation
                GetComponent<AudioSource>().clip = ScareSound;                    //set scare sound
                GetComponent<AudioSource>().Play();                                           //play scare sound
                GetComponent<Collider>().enabled = false;                      //disable collider for repeat scare
                if (Sanity) { Sanity.enabled = true; }        //enable sanity
                StartCoroutine(ScaredWait());            //wait for destroy and sanity
            }
        }

        IEnumerator ScaredWait()
        {
            yield return new WaitForSeconds(3.0f);
            if (Sanity) { Sanity.enabled = false; }
            Destroy(this);
        }
    }
}