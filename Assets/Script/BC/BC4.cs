using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BC4 : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Trigger"))
        {
            FindObjectOfType<AudioManager>().Play("jkt");
            /*FindObjectOfType<AudioManager>().Stop("Theme");*/
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Trigger"))
        {
            FindObjectOfType<AudioManager>().Stop("jkt");
            /*FindObjectOfType<AudioManager>().Play("Theme");*/
        }
    }
}
