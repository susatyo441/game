using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BC5 : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Trigger"))
        {
            FindObjectOfType<AudioManager>().Play("blackpink");
            /*FindObjectOfType<AudioManager>().Stop("Theme");*/
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Trigger"))
        {
            FindObjectOfType<AudioManager>().Stop("blackpink");
            /*FindObjectOfType<AudioManager>().Play("Theme");*/
        }
    }
}
