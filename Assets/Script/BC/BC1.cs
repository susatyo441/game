using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BC1 : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Trigger"))
        {
            FindObjectOfType<AudioManager>().Play("Hymne Polines");
            /*FindObjectOfType<AudioManager>().Stop("Theme");*/
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Trigger"))
        {
            FindObjectOfType<AudioManager>().Stop("Hymne Polines");
            /*FindObjectOfType<AudioManager>().Play("Theme");*/
        }
    }
}
