using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BC3 : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Trigger"))
        {
            FindObjectOfType<AudioManager>().Play("moshimo");
            /*FindObjectOfType<AudioManager>().Stop("Theme");*/
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Trigger"))
        {
            FindObjectOfType<AudioManager>().Stop("moshimo");
            /*FindObjectOfType<AudioManager>().Play("Theme");*/
        }
    }
}
