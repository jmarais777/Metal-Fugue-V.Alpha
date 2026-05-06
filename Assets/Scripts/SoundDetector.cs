using Unity.VisualScripting;
using UnityEngine;

public class SoundDetector : MonoBehaviour
{
    public GameObject LampRight_0;
    public GameObject LampFrontLit_1;
    public GameObject LampFrontLit_2;
    public GameObject LampFrontLit_3;
    public GameObject LampFrontLit_4;
    public GameObject LampFrontLit_5;
    public GameObject LampRight_2;


    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("LightFlicker"))
        {

            LampRight_0.GetComponent<AudioSource>().mute = false;
            Debug.Log("Light Detetcted");
        }
        if (collision.CompareTag("LightFlicker"))
        {

            LampFrontLit_1.GetComponent<AudioSource>().mute = false;
            Debug.Log("Light Detetcted");
        }
        if (collision.CompareTag("LightFlicker"))
        {

            LampFrontLit_2.GetComponent<AudioSource>().mute = false;
            Debug.Log("Light Detetcted");
        }
        if (collision.CompareTag("LightFlicker"))
        {

            LampFrontLit_3.GetComponent<AudioSource>().mute = false;
            Debug.Log("Light Detetcted");
        }
        if (collision.CompareTag("LightFlicker"))
        {

            LampFrontLit_3.GetComponent<AudioSource>().mute = false;
            Debug.Log("Light Detetcted");

        }
        if (collision.CompareTag("LightFlicker"))
        {

            LampFrontLit_4.GetComponent<AudioSource>().mute = false;
            Debug.Log("Light Detetcted");
        }
        if (collision.CompareTag("LightFlicker"))
        {

            LampFrontLit_5.GetComponent<AudioSource>().mute = false;
            Debug.Log("Light Detetcted");
        }
    
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        LampRight_0.GetComponent<AudioSource>().mute = true;
        LampFrontLit_1.GetComponent<AudioSource>().mute = true;
        LampFrontLit_2.GetComponent<AudioSource>().mute = true;
        LampFrontLit_3.GetComponent<AudioSource>().mute = true;
        LampFrontLit_4.GetComponent<AudioSource>().mute = true;
        LampFrontLit_5.GetComponent<AudioSource>().mute = true;
    }


}